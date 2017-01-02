using System;
using SahafAPI.Models;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;

namespace Sahaf.Views.ContentDialogs
{
    public sealed partial class AdvertSettingsDialog : ContentDialog
    {
        private AdvertModel advert;


        public AdvertSettingsDialog(AdvertModel model)
        {
            this.InitializeComponent();
            advert = model;
            DataContext = model;
        }


        private async void GetAdvertSoldRequest()
        {
            ResultModel result = await App.Client.AdvertSold(advert.AdvertId);

            if (result.IsSuccess == true)
            {
                Hide();
                await new MessageDialog("İlanınız başarıyla satıldı.", "Bildirim").ShowAsync();
            }
        }

        private async void GetAdvertDeleteRequest()
        {
            ResultModel result = await App.Client.AdvertDelete(advert.AdvertId);

            if (result.IsSuccess == true)
            {
                Hide();
                await new MessageDialog("İlanınız başarıyla silindi.", "Bildirim").ShowAsync();
            }
        }

        private void soldButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GetAdvertSoldRequest();
        }

        private void deleteButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GetAdvertDeleteRequest();
        }

        private void closeButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Hide();
        }
    }
}