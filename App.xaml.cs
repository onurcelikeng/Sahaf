using System;
using Sahaf.Views;
using Sahaf.Client;
using Sahaf.Helpers;
using Windows.UI.Xaml;
using Windows.Storage;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;
using Windows.ApplicationModel.Activation;

namespace Sahaf
{
    sealed partial class App : Application
    {
        private ContinuationManager _continuator = new ContinuationManager();
        private static DataClient _client = new DataClient();
        private TransitionCollection transitions;


        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }


        public static DataClient Client
        {
            get
            {
                return _client;
            }
        }

        private void CreateRootFrame()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");
                Window.Current.Content = rootFrame;
            }
        }

        protected async override void OnActivated(IActivatedEventArgs args)
        {
            CreateRootFrame();

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                try
                {
                    await SuspensionManager.RestoreAsync();
                }
                catch { }
            }

            if (args is IContinuationActivatedEventArgs)
            {
                _continuator.ContinueWith(args);
            }

            Window.Current.Activate();
        }

        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.CacheSize = 1;
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {

                }

                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }
                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;

                var token = ApplicationData.Current.LocalSettings.Values["Token"];

                if (token == null)
                {
                    rootFrame.Navigate(typeof(Views.LoginView), e.Arguments);
                }

                else
                {
                    Client.SetToken(token.ToString());
                    ProfileView.user = await Client.GetMe();
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
            }

            Window.Current.Activate();
        }

        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }

        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
}