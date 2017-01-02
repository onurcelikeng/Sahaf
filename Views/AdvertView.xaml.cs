using System;
using Windows.UI.Xaml;
using SahafAPI.Models;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.Storage;
using Windows.UI.Core;

namespace Sahaf.Views
{
    public sealed partial class AdvertView : Page
    {
        private static List<AdvertModel> advertList = new List<AdvertModel>();
        private static Geopoint myLocation;
        private static string city;


        public AdvertView()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            this.InitializeComponent();
            this.Loaded += AdvertView_Loaded;
        }


        private async void GetLocation()
        {
            progress.IsIndeterminate = true;

            var gl = new Geolocator() { DesiredAccuracy = PositionAccuracy.High };
            var location = await gl.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(5));
            myLocation = location.Coordinate.Point;

            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(myLocation);

            string _city = result.Locations[0].Address.Region;
            if (myLocation == null)
            {
                //last location
            }

            else
            {
                city = _city;
                GetAdvertsRequest();
            }

            progress.IsIndeterminate = false;
        }

        private async void GetAdvertsRequest()
        {
            progress.IsIndeterminate = true;

            var model = new ReqAdvertModel()
            {
                Latitude = myLocation.Position.Latitude.ToString().Replace(",", "."),
                Longitude = myLocation.Position.Longitude.ToString().Replace(",", "."),
                City = city
            };

            advertList = await App.Client.GetNearestAdverts(model);

            if (advertList != null)
            {
                for (int i = 0; i < advertList.Count; i++)
                {
                    if (i % 2 == 0) advertList[i].BgColor = "#FBFBFB";
                    else advertList[i].BgColor = "#FFFFFF";
                }

                listView.ItemsSource = advertList;
            }

            ApplicationData.Current.LocalSettings.Values["City"] = model.City;
            ApplicationData.Current.LocalSettings.Values["Latitude"] = model.Latitude;
            ApplicationData.Current.LocalSettings.Values["Longitude"] = model.Longitude;

            progress.IsIndeterminate = false;
        }

        private void AdvertView_Loaded(object sender, RoutedEventArgs e)
        {
            if (myLocation == null && city == null)
            {
                GetLocation();
            }

            else
            {
                GetAdvertsRequest();
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdvertDetailsView.advert = listView.SelectedItem as AdvertModel;
            Frame.Navigate(typeof(AdvertDetailsView));
        }
    }
}