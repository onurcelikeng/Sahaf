using System;
using Sahaf.Views.ContentDialogs;
using SahafAPI.Models;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Sahaf.Views
{
    public sealed partial class ChatRoomView : Page
    {

        public ChatRoomView()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            this.InitializeComponent();
        }
        
    }
}