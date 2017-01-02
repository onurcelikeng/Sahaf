using Facebook;
using Sahaf.Helpers;
using SahafAPI.Models;
using System;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Sahaf.Views
{
    public sealed partial class LoginView : Page, IWebAuthenticationBrokerContinuable
    {
        private FaceBookHelper helper;
        private FacebookClient client;


        public LoginView()
        {
            this.InitializeComponent();
            this.InitializeUI();

            helper = new FaceBookHelper();
            client = new FacebookClient();
        }


        private async void InitializeUI()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                var statusBar = StatusBar.GetForCurrentView();
                await statusBar.HideAsync();
            }
        }

        private void facebookButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            helper.LoginAndContinue();
        }

        public async void ContinueWithWebAuthenticationBroker(WebAuthenticationBrokerContinuationEventArgs args)
        {
            try
            {
                progress.IsIndeterminate = true;

                helper.ContinueAuthentication(args);

                if (helper.AccessToken != null)
                {
                    TokenModel model = await App.Client.FacebookLogin(helper.AccessToken);

                    if(model.IsSuccess == true)
                    {
                        App.Client.SetToken(model.token);
                        ProfileView.user = await App.Client.GetMe();

                        ApplicationData.Current.LocalSettings.Values["Token"] = model.token;
                        Frame.Navigate(typeof(MainPage));
                    }
                }

                progress.IsIndeterminate = false;
            }

            catch (Exception)
            {
                progress.IsIndeterminate = false;
            }
        }
    }
}