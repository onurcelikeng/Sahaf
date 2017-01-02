using Sahaf.Views;
using System;
using Windows.Foundation.Metadata;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Sahaf
{
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;
        private int index;


        public MainPage()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            this.InitializeComponent();
            this.InitializeUI();
            Current = this;
        }


        private async void InitializeUI()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                await StatusBar.GetForCurrentView().HideAsync();
            }

            index = 0;
            shoppingButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 144, 36));
            cameraButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
            messageButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
            profileButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));

            iframe.Navigate(typeof(AdvertView));
        }

        private void shoppingButton_Click(object sender, RoutedEventArgs e)
        {
            if(index != 0)
            {
                index = 0;
                shoppingButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 144, 36));
                cameraButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                messageButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                profileButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));

                iframe.Navigate(typeof(AdvertView));
            }
        }

        private async void cameraButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(index != 1)
                {
                    index = 1;
                    CameraCaptureUI captureUI = new CameraCaptureUI();
                    captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;

                    StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

                    using (IRandomAccessStream fileStream = await photo.OpenAsync(FileAccessMode.Read))
                    {
                        AddAdvertView.imageStream = fileStream.CloneStream();
                    }

                    if (AddAdvertView.imageStream != null)
                    {
                        shoppingButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                        cameraButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 144, 36));
                        messageButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                        profileButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));

                        Frame.Navigate(typeof(AddAdvertView));
                    }
                }
            }

            catch (Exception)
            {

            }
        }

        private void messageButton_Click(object sender, RoutedEventArgs e)
        {
            if(index != 2)
            {
                index = 2;
                shoppingButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                cameraButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                messageButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 144, 36));
                profileButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));

                iframe.Navigate(typeof(MessageView));
            }
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
            if(index != 3)
            {
                index = 3;
                shoppingButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                cameraButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                messageButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                profileButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 144, 36));

                iframe.Navigate(typeof(ProfileView));
            }
        }
    }
}