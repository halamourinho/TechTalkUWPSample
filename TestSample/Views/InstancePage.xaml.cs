using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestSample.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
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
        public InstanceViewModel vm;
        public InstancePage()
        {
            this.InitializeComponent();
            vm = new InstanceViewModel();
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
    }
}
