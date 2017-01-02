using SahafAPI.Models;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Sahaf.Views.ContentDialogs
{
    public sealed partial class ReportDialog : ContentDialog
    {
        private ReportPersonModel model = new ReportPersonModel();


        public ReportDialog(int PersonId)
        {
            this.InitializeComponent();
            this.InitializeUI();

            model.ReportedUserId_id = PersonId;
        }


        private void InitializeUI()
        {
            tick_1.Visibility = Visibility.Collapsed;
            tick_2.Visibility = Visibility.Collapsed;
            tick_3.Visibility = Visibility.Collapsed;
            tick_4.Visibility = Visibility.Collapsed;
        }

        private async void PersonReportRequest(ReportPersonModel model)
        {
            await App.Client.ReportPerson(model);
        }

        private void report_1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tick_1.Visibility = Visibility.Visible;
            tick_2.Visibility = Visibility.Collapsed;
            tick_3.Visibility = Visibility.Collapsed;
            tick_4.Visibility = Visibility.Collapsed;

            model.Description = "Bu kişi ebni rahatsız ediyor";
        }

        private void report_2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tick_1.Visibility = Visibility.Collapsed;
            tick_2.Visibility = Visibility.Visible;
            tick_3.Visibility = Visibility.Collapsed;
            tick_4.Visibility = Visibility.Collapsed;

            model.Description = "Tanıdığım birisini taklit ediyor";
        }

        private void report_3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tick_1.Visibility = Visibility.Collapsed;
            tick_2.Visibility = Visibility.Collapsed;
            tick_3.Visibility = Visibility.Visible;
            tick_4.Visibility = Visibility.Collapsed;

            model.Description = "Uygunsuz içerik paylaşıyor";
        }

        private void report_4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tick_1.Visibility = Visibility.Collapsed;
            tick_2.Visibility = Visibility.Collapsed;
            tick_3.Visibility = Visibility.Collapsed;
            tick_4.Visibility = Visibility.Visible;

            model.Description = "Bu sahte bir hesap";
        }

        private void close_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Hide();
        }

        private async void report_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (model.Description != null)
            {
                ResultModel result = await App.Client.ReportPerson(model);

                if(result.IsSuccess == true)
                {
                    Hide();
                    await new MessageDialog("Şikayetiniz tarafımıza iletilmiştir. İlginiz için teşekkürler.", "Bildirim").ShowAsync();
                }
            }
        }
    }
}