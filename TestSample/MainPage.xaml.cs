using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestSample.Models.UI;
using TestSample.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainViewModel vm;
        public InstanceViewModel instanceVM;
        public MainPage()
        {
            this.InitializeComponent();
            
            vm = new MainViewModel();
            vm.ReloadCurrentPage += OnReloadCurrentPage;

            instanceVM = new InstanceViewModel();
        }

        private void OnReloadCurrentPage(object sender, EventArgs e)
        {
            MainFrame.Navigate(MainFrame.Content.GetType(),null,new SuppressNavigationTransitionInfo());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var first = vm.NavigationItemCollection.First();
            NavView.SelectedItem=first;
            MainFrame.Navigate(first.PageType);
            TitleBlock.Text = first.Title;
            base.OnNavigatedTo(e);
        }

        private void NavView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as NavigationItem;
            TitleBlock.Text = item.Title;
            MainFrame.Navigate(item.PageType);
        }
    }
}
