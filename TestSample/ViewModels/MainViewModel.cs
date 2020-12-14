using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSample.Models.UI;

namespace TestSample.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<NavigationItem> NavigationItemCollection = new ObservableCollection<NavigationItem>();

        public event EventHandler ReloadCurrentPage;

        public static MainViewModel Current;

        public MainViewModel()
        {
            NavigationInit();
            Current = this;
        }

        private void NavigationInit()
        {
            var items = NavigationItem.GetNavigationItems();
            items.ForEach(p => NavigationItemCollection.Add(p));
        }

        public void Reload()
        {
            ReloadCurrentPage?.Invoke(this, EventArgs.Empty);
        }
    }
}
