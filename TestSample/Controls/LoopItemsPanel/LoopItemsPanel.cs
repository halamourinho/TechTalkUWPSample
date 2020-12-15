using System;
using TestSample.Models.UI;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace TestSample.Controls
{
    public partial class LoopItemsPanel : StackPanel
    {
        public LoopItemsPanel()
        {
            throttle = new DispatchThrottler(CompleteManipulation, 300);
        }

        public void ScrollToItem(UIElement selectedItem)
        {
            if (this.isManipulating)
                return;

            if (storyboard != null && storyboard.GetCurrentState() != ClockState.Stopped)
            {
                this.itemToScrollToNext = selectedItem;
                return;
            }

            itemToScrollToNext = null;

            var rect = selectedItem.TransformToVisual(this).TransformBounds(new Rect(0, 0, selectedItem.DesiredSize.Width, selectedItem.DesiredSize.Height));

            previousMiddleIndex = currentMiddleIndex;
            currentMiddleIndex = Children.IndexOf(selectedItem);

            ScrollToSelectedItem(selectedItem, rect);
        }
    }
}
