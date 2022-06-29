using KTU_Social.Model;
using KTU_Social.Table;
using KTU_Social.View;
using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace KTU_Social
{
    sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Window.Current.Content is Frame rootFrame))
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                Window.Current.Activate();
            }

            rootFrame = (Frame)Window.Current.Content;
            mainPage = (MainPage)rootFrame.Content;
            view = (Grid)mainPage.FindName("View");
            login = (LoginView)view.FindName("LoginView");

            _ = new Database();
        }

        public static Frame rootFrame;
        public static MainPage mainPage;
        public static Grid view;
        public static LoginView login;

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }

        public static readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
    }
}
