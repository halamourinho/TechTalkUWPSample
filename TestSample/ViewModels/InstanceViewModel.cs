using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSample.Models.UI;

namespace TestSample.ViewModels
{
    public class InstanceViewModel:BindableBase
    {
        private int _page1Count;
        public int Page1Count
        {
            get => _page1Count;
            set => Set(ref _page1Count, value);
        }

        private int _page2Count;
        public int Page2Count
        {
            get => _page2Count;
            set => Set(ref _page2Count, value);
        }

        public static InstanceViewModel Current;

        public InstanceViewModel()
        {
            Current = this;
        }

        public void IncreasePage1Count()
        {
            Page1Count++;
        }
        public void DecreasePage1Count()
        {
            Page1Count--;
        }

        public void IncreasePage2Count()
        {
            Page2Count++;
        }

        public void DecreasePage2Count()
        {
            Page2Count--;
        }
    }
}
