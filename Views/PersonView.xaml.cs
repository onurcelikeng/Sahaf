using System;
using SahafAPI.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using Sahaf.Views.ContentDialogs;

namespace Sahaf.Views
{
    public sealed partial class PersonView : Page
    {
        private List<AdvertModel> advertList = new List<AdvertModel>();
        public static int PersonId;
        private PersonModel person;
        

        public PersonView()
        {
            this.InitializeComponent();
            this.GetPersonInformationRequest();
        }


        private async void GetPersonInformationRequest()
        {
            progress.IsIndeterminate = true;

            person = await App.Client.GetPersonInformation(PersonId);

            if(person != null)
            {
                DataContext = person;
            }

            progress.IsIndeterminate = false;
        }

        private async void GetAdvertsFindByIdRequest(int id)
        {
            progress.IsIndeterminate = true;

            List<AdvertModel> onlineAdvertList = new List<AdvertModel>();
            List<AdvertModel> offlineAdvertList = new List<AdvertModel>();

            advertList = await App.Client.GetAdvertsFindById(id);

            if (advertList.Count != 0)
            {
                for (int i = 0; i < advertList.Count; i++)
                {
                    if (advertList[i].IsSold == false)
                    {
                        onlineAdvertList.Add(advertList[i]);
                    }

                    else if (advertList[i].IsSold == true)
                    {
                        offlineAdvertList.Add(advertList[i]);
                    }
                }

                for (int i = 0; i < onlineAdvertList.Count; i++)
                {
                    if (i % 2 == 0) onlineAdvertList[i].BgColor = "#FBFBFB";
                    else onlineAdvertList[i].BgColor = "#FFFFFF";
                }

                for (int i = 0; i < offlineAdvertList.Count; i++)
                {
                    if (i % 2 == 0) offlineAdvertList[i].BgColor = "#FBFBFB";
                    else offlineAdvertList[i].BgColor = "#FFFFFF";
                }

                OnlineAdvert.Text = onlineAdvertList.Count.ToString();
                OfflineAdvert.Text = offlineAdvertList.Count.ToString();
                list1.ItemsSource = onlineAdvertList;
                list2.ItemsSource = offlineAdvertList;
            }

            progress.IsIndeterminate = false;
        }

        private async void reportButton_Click(object sender, RoutedEventArgs e)
        {
            ReportDialog report = new ReportDialog(PersonId);
            ContentDialogResult content = await report.ShowAsync();
        }

        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pivot.SelectedItem == pivotItem1)
            {
                panel1.Opacity = 1;
                panel2.Opacity = 0;

                GetAdvertsFindByIdRequest(PersonId);
            }

            else
            {
                panel1.Opacity = 0;
                panel2.Opacity = 1;
            }
        }

        private void list1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdvertDetailsView.advert = list1.SelectedItem as AdvertModel;
            Frame.Navigate(typeof(AdvertDetailsView));
        }

        private void list2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdvertDetailsView.advert = list2.SelectedItem as AdvertModel;
            Frame.Navigate(typeof(AdvertDetailsView));
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

            pivot.SelectedItem = pivotItem2;
        }
    }
}