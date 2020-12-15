using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSample.Models.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace TestSample.Controls
{
    public partial class LoopItemsPanel
    {
        public event EventHandler<UIElement> MiddleItemChanged;

        private Storyboard storyboard;
        private UIElement itemToScrollToNext;

        private double offsetSeparator;
        private bool templateApplied;

        public double ItemWidth { get; private set; } = 1d;

        private int currentMiddleIndex = 0;
        private int previousMiddleIndex = 0;

        private bool isManipulating;
        private DispatchThrottler throttle;

        private double startX;
    }
}
