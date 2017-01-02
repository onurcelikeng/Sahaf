using System;
using Windows.UI.Xaml;
using SahafAPI.Models;
using Windows.UI.Core;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;
using Sahaf.Views.ContentDialogs;

namespace Sahaf.Views
{
    public sealed partial class AdvertDetailsView : Page
    {
        public static AdvertModel advert;


        public AdvertDetailsView()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManager_BackRequested;
            this.InitializeComponent();
            this.Loaded += AdvertDetailsView_Loaded;
        }


        private void AdvertDetailsView_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = advert;

            if (advert.IsSold == true)
            {
                soldPicture.Visibility = Visibility.Visible;
                messageButton.Visibility = Visibility.Collapsed;
                deleteButton.Visibility = Visibility.Collapsed;
            }

            else
            {
                if (advert.SellerId == ProfileView.user.UserId)
                {
                    soldPicture.Visibility = Visibility.Collapsed;
                    messageButton.Visibility = Visibility.Collapsed;
                    deleteButton.Visibility = Visibility.Visible;
                }

                else
                {
                    soldPicture.Visibility = Visibility.Collapsed;
                    messageButton.Visibility = Visibility.Visible;
                    deleteButton.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void personButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ProfileView.user.UserId != advert.SellerId)
            {
                PersonView.PersonId = advert.SellerId;
                Frame.Navigate(typeof(PersonView));
            }
        }

        private void messageButton_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void deleteButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AdvertSettingsDialog dialog = new AdvertSettingsDialog(advert);
            ContentDialogResult content = await dialog.ShowAsync();
        }

        #region BackRequested Handlers

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            bool handled = e.Handled;
            this.BackRequested(ref handled);
            e.Handled = handled;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            bool ignored = false;
            this.BackRequested(ref ignored);
        }

        private void BackRequested(ref bool handled)
        {
            if (this.Frame == null)
                return;

            if (this.Frame.CanGoBack && !handled)
            {
                handled = true;
                this.Frame.GoBack();
            }
        }

        #endregion
    }
}