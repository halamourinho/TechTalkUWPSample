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
    public sealed partial class SecondPage : Page
    {
        private ObservableCollection<TestModel> TestCollection = new ObservableCollection<TestModel>();
        public SecondPage()
        {
            this.InitializeComponent();
            InstanceViewModel.Current?.IncreasePage2Count();
            //var settings = new UISettings();
            //settings.ColorValuesChanged += OnColorValuesChanged;

            var items = TestModel.GetItems();
            items.ForEach(p => TestCollection.Add(p));
        }

        private void OnColorValuesChanged(UISettings sender, object args)
        {
            // Do nothing...
        }

        ~SecondPage()
        {
            InstanceViewModel.Current?.DecreasePage2Count();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class TestModel
    {
        public int Number { get; set; }

        public void OnButtonClick(object sender, RoutedEventArgs e)
        {

        }

        public TestModel(int num)
        {
            this.Number = num;
        }

        public static List<TestModel> GetItems()
        {
            var result = new List<TestModel>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new TestModel(i));
            }
            return result;
        }

        public override string ToString()
        {
            return $"Item {Number}";
        }
    }
}
