using System;
using SahafAPI.Models;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Sahaf.Views
{
    public sealed partial class ProfileView : Page
    {
        private List<AdvertModel> advertList = new List<AdvertModel>();
        public static UserModel user;


        public ProfileView()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            this.InitializeComponent();
            this.InitializeUI();
            this.DataContext = user;
        }


        public void InitializeUI()
        {
            panel1.Opacity = 1;
            panel2.Opacity = 0;
            pivot.SelectedItem = pivotItem1;
        }

        private async void GetAdvertsFindByIdRequest(int id)
        {
            progress.IsIndeterminate = true;

            List<AdvertModel> onlineAdvertList = new List<AdvertModel>();
            List<AdvertModel> offlineAdvertList = new List<AdvertModel>();

            advertList = await App.Client.GetAdvertsFindById(id);

            if(advertList.Count != 0)
            {
                for(int i = 0; i < advertList.Count; i++)
                {
                    if(advertList[i].IsSold == false)
                    {
                        onlineAdvertList.Add(advertList[i]);
                    }

                    else if (advertList[i].IsSold == true)
                    {
                        offlineAdvertList.Add(advertList[i]);
                    }
                }

                for(int i = 0; i < onlineAdvertList.Count; i++)
                {
                    if (i % 2 == 0) onlineAdvertList[i].BgColor = "#FBFBFB";
                    else onlineAdvertList[i].BgColor = "#FFFFFF";
                }

                for (int i = 0; i < offlineAdvertList.Count; i++)
                {
                    if (i % 2 == 0) offlineAdvertList[i].BgColor = "#FBFBFB";
                    else offlineAdvertList[i].BgColor = "#FFFFFF";
                }

                list1.ItemsSource = onlineAdvertList;
                list3.ItemsSource = offlineAdvertList;
            }

            progress.IsIndeterminate = false;
        }

        private void onlineAdvertButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            panel1.Opacity = 1;
            panel2.Opacity = 0;
            pivot.SelectedItem = pivotItem1;
        }

        private void offlineAdvertButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            panel1.Opacity = 0;
            panel2.Opacity = 1;
            pivot.SelectedItem = pivotItem3;
        }

        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pivot.SelectedItem == pivotItem1)
            {
                panel1.Opacity = 1;
                panel2.Opacity = 0;
                GetAdvertsFindByIdRequest(user.UserId);
            }

            else
            {
                panel1.Opacity = 0;
                panel2.Opacity = 1;
            }
        }

        #region Button Events

        private async void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            var newMessage = new MessageDialog("Uygulamadan çıkış yapmak istediğinize emin misiniz?", "Bildirim");
            newMessage.Commands.Add(new UICommand("Evet"));
            newMessage.Commands.Add(new UICommand("Hayır"));
            IUICommand result = await newMessage.ShowAsync();

            if (result != null && result.Label == "Evet")
            {
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["Token"] = null;
                Application.Current.Exit();
            }
        }

        #endregion

        #region List Item Selection

        private void list1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdvertDetailsView.advert = list1.SelectedItem as AdvertModel;
            Frame.Navigate(typeof(AdvertDetailsView));
        }

        private void list3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdvertDetailsView.advert = list3.SelectedItem as AdvertModel;
            Frame.Navigate(typeof(AdvertDetailsView));
        }

        #endregion
    }
}