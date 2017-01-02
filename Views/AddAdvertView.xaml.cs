using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.Storage.Streams;
using SahafAPI.Models;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using System.IO;

namespace Sahaf.Views
{
    public sealed partial class AddAdvertView : Page
    {
        public static IRandomAccessStream imageStream;
        private static Geopoint myLocation;
        private string imageToken;


        public AddAdvertView()
        {
            this.InitializeComponent();
            this.GetLocation();
        }


        private async void GetLocation()
        {
            var gl = new Geolocator() { DesiredAccuracy = PositionAccuracy.High };
            var location = await gl.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(5));
            myLocation = location.Coordinate.Point;

            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(myLocation);

            string _city = result.Locations[0].Address.Region;
            if (!string.IsNullOrEmpty(_city))
            {
                city.Text = _city;
            }
        }

        private async void GetAddAdvertRequest()
        {
            var data = await ConvertToArray(imageStream);

            imageToken = await GetImageToken(data);

            var model = new AddAdvertModel()
            {
                AdvertDate = DateTime.Now.ToString("dd/MM/yyyy"),
                Name = advertName.Text,
                Image = imageToken,
                Category = "Tümü",
                City = city.Text,
                Description = "Dokuz Eylül Üni calculus dersi için ders kitabı kullanmadığım için satıyorum",
                Latitude = myLocation.Position.Latitude.ToString().Replace(",", "."),
                Longitude = myLocation.Position.Longitude.ToString().Replace(",", "."),
                Price = price.Text
            };

            ResultModel result = await App.Client.AddAdvert(model);

            if(result.IsSuccess == true)
            {
                await new MessageDialog("İlanınız başarıyla eklenmiştir.", "Bildirim").ShowAsync();
            }
        }

        private async Task<string> GetImageToken(byte[] imageArray)
        {
            TokenModel model = await App.Client.ImageUpload(imageArray);

            if (model.IsSuccess == true)
            {
                return model.token;
            }

            return null;
        }

        private async Task<byte[]> ConvertToArray(IRandomAccessStream stream)
        {
            var dataReader = new DataReader(stream.GetInputStreamAt(0));
            var bytes = new byte[stream.Size];

            await dataReader.LoadAsync((uint)stream.Size);
            dataReader.ReadBytes(bytes);

            return bytes;
        }

        private void advertButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GetAddAdvertRequest();
        }

        private void deleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}