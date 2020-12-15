using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestSample.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestSample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InstancePage : Page
    {
        public InstanceViewModel vm = InstanceViewModel.Current;
        public InstancePage()
        {
            this.InitializeComponent();
        }

        private void Page1Button_Click(object sender, RoutedEventArgs e)
        {
            SubFrame.Navigate(typeof(SubViews.FirstPage));
        }

        private void Page2Button_Click(object sender, RoutedEventArgs e)
        {
            SubFrame.Navigate(typeof(SubViews.SecondPage));
        }

        private void GCButton_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

        private async void NewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            //CoreApplicationView newView = CoreApplication.CreateNewView();
            //int newViewId = 0;
            //await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            //    Frame frame = new Frame();
            //    frame.Navigate(typeof(InstancePage), null);
            //    Window.Current.Content = frame;
            //    // You have to activate the window in order to show it later.
            //    Window.Current.Activate();

            //    newViewId = ApplicationView.GetForCurrentView().Id;
            //});
            //bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            AppWindow appWindow = await AppWindow.TryCreateAsync();
            Frame appWindowContentFrame = new Frame();
            appWindowContentFrame.Navigate(typeof(InstancePage));
            ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowContentFrame);
            await appWindow.TryShowAsync();
            appWindow.Closed += delegate
            {
                appWindowContentFrame.Content = null;
                appWindow = null;
            };
        }
    }
}
