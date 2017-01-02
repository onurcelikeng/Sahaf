using Newtonsoft.Json;
using SahafAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Sahaf.Views
{
    public sealed partial class MessageView : Page
    {
        MainPage rootPage = MainPage.Current;
        private MessageWebSocket messageWebSocket;
        private DataWriter messageWriter;


        public MessageView()
        {
            this.InitializeComponent();
            this.OnConnect();
        }


        private async void OnConnect()
        {
            await ConnectAsync();
        }

        private async void OnSend()
        {
            await SendAsync();
        }

        private void OnDisconnect()
        {
            CloseSocket();
        }

        private async Task ConnectAsync()
        {
            Uri server = rootPage.TryGetUri("ws://146.185.147.162:8000/?To=45&From=80&Room=murat");

            messageWebSocket = new MessageWebSocket();
            messageWebSocket.Control.MessageType = SocketMessageType.Utf8;
            messageWebSocket.MessageReceived += MessageReceived;
            messageWebSocket.Closed += OnClosed;

            try
            {
                await messageWebSocket.ConnectAsync(server);
            }

            catch (Exception)
            {
                messageWebSocket.Dispose();
                messageWebSocket = null;
                return;
            }

            messageWriter = new DataWriter(messageWebSocket.OutputStream);
        }

        private async Task SendAsync()
        {
            try
            {
                var model = new SendMessageModel()
                {
                    Text = messageTextBox.Text
                };

                string message = JsonConvert.SerializeObject(model);
                messageTextBox.Text = string.Empty;

                messageWriter.WriteString(message);

                await messageWriter.StoreAsync();
            }

            catch (Exception)
            {

            }
        }

        private void CloseSocket()
        {
            if (messageWriter != null)
            {
                messageWriter.DetachStream();
                messageWriter.Dispose();
                messageWriter = null;
            }

            if (messageWebSocket != null)
            {
                try
                {
                    messageWebSocket.Close(1000, "Closed due to user request.");
                }

                catch (Exception)
                {

                }
                messageWebSocket = null;
            }
        }

        private async void OnServerCustomValidationRequested(MessageWebSocket sender, WebSocketServerCustomValidationRequestedEventArgs args)
        {
            bool isValid;
            using (Deferral deferral = args.GetDeferral())
            {
                isValid = await MainPage.AreCertificateAndCertChainValidAsync(args.ServerCertificate, args.ServerIntermediateCertificates);

                if (!isValid)
                {
                    args.Reject();
                }
            }

            var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {});
        }

        private void MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
        {
            var ignore = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                using (DataReader reader = args.GetDataReader())
                {
                    reader.UnicodeEncoding = UnicodeEncoding.Utf8;

                    try
                    {
                        string data = reader.ReadString(reader.UnconsumedBufferLength);

                        var model = JsonConvert.DeserializeObject<MessageModel>(data);

                        if(model.From == ProfileView.user.UserId.ToString())//buraya bakılacak.
                        {
                            var chat = new ChatModel()
                            {
                                me = model.Text,
                                me_opacity = "1",
                                friend_opacity = "0"
                            };

                            listView.Items.Add(chat);
                        }

                        else
                        {
                            var chat = new ChatModel()
                            {
                                friend = model.Text,
                                friend_opacity = "1",
                                me_opacity = "0"
                            };
                            listView.Items.Add(chat);
                        }
                    }

                    catch (Exception)
                    {

                    }
                }
            });
        }

        private async void OnClosed(IWebSocket sender, WebSocketClosedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (messageWebSocket == sender)
                {
                    CloseSocket();
                }
            });
        }
    }

    public class ChatModel
    {
        public string me { get; set; }

        public string friend { get; set; }

        public string me_opacity { get; set; }

        public string friend_opacity { get; set; }
    }
}