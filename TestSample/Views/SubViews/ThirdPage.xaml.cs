using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestSample.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestSample.Views.SubViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThirdPage : Page
    {
        private ObservableCollection<TestModel> TestCollection = new ObservableCollection<TestModel>();
        public ThirdPage()
        {
            this.InitializeComponent();
            InstanceViewModel.Current?.IncreasePage3Count();
            //var settings = new UISettings();
            //settings.ColorValuesChanged += OnColorValuesChanged;

            var items = TestModel.GetItems();
            items.ForEach(p => TestCollection.Add(p));
        }

        private void OnColorValuesChanged(UISettings sender, object args)
        {
            // Do nothing...
        }

        ~ThirdPage()
        {
            InstanceViewModel.Current?.DecreasePage3Count();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
