using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestSample.Controls;
using TestSample.Models.UI;
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
    public sealed partial class PanelPage : Page
    {
        public ObservableCollection<TestModel> TestCollection = new ObservableCollection<TestModel>();
        DispatchThrottler throttler;
        public PanelPage()
        {
            this.InitializeComponent();
            for (int i = 0; i < 15; i++)
            {
                TestCollection.Add(new TestModel("\uE00B", $"Test{i}"));
            }
            DataListView.SelectedIndex = 0;
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataListView.SelectedIndex > 0)
                DataListView.SelectedIndex--;
            else
                DataListView.SelectedIndex = DataListView.Items.Count - 1;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataListView.SelectedIndex < DataListView.Items.Count - 1)
                DataListView.SelectedIndex++;
            else
                DataListView.SelectedIndex = 0;
        }

        private void CenterItem()
        {
            if (DataListView.SelectedIndex < 0)
                return;

            var panel = DataListView.ItemsPanelRoot as LoopItemsPanel;
            var item = DataListView.ContainerFromIndex(DataListView.SelectedIndex) as ListViewItem;

            if (panel != null && item != null)
            {
                panel.ScrollToItem(item);
            }
        }

        private void LoopItemsPanel_MiddleItemChanged(object sender, UIElement e)
        {
            var item = e as ListViewItem;
            if (item.IsSelected)
                CenterItem();
            else
                item.IsSelected = true;
        }

        private void DataListView_Loaded(object sender, RoutedEventArgs e)
        {
            throttler = new DispatchThrottler(CenterItem, 600);
            DataListView.SizeChanged += DataListView_SizeChanged;
            CenterItem();
        }

        private void DataListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            throttler.Start();
        }

        private void DataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataListView.SelectedIndex == -1)
                return;

            CenterItem();
        }
    }

    public class TestModel
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        internal TestModel()
        {

        }
        public TestModel(string icon, string title)
        {
            Icon = icon;
            Title = title;
        }
        public static TestModel Temp = new TestModel("\uE00B", "Test");
    }
}
