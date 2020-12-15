using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace TestSample.Controls
{
    public partial class LoopItemsPanel
    {
        #region Manipulation
        private void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (e == null)
                return;

            isManipulating = true;
            UpdatePosition(e.Delta.Translation.X, false);
        }

        private void OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            CompleteManipulation();
        }

        private void gestureRecognizer_ManipulationCompleted(GestureRecognizer sender, ManipulationCompletedEventArgs args)
        {
            CompleteManipulation();
        }

        private void gestureRecognizer_ManipulationUpdated(GestureRecognizer sender, ManipulationUpdatedEventArgs args)
        {
            UpdatePosition(args.Cumulative.Translation.X / 2, false);
        }

        private void gestureRecognizer_ManipulationStarted(GestureRecognizer sender, ManipulationStartedEventArgs args)
        {
            isManipulating = true;
            startX = args.Cumulative.Translation.X;
        }
        #endregion

        #region Pointer
        private void OnPointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Internal
        private void OnStoryboardCompleted(object sender, object e)
        {
            if (storyboard != null)
                storyboard.Completed -= OnStoryboardCompleted;

            storyboard = null;

            if (itemToScrollToNext != null)
            {
                ScrollToItem(itemToScrollToNext);
            }
        }

        private bool IsInRangeOfIndex(int currentIndex, int selectedIndex)
        {
            return (currentIndex >= (selectedIndex - OffsetRange) && currentIndex <= (selectedIndex + OffsetRange))
                    || currentIndex <= GetUpperWordBoundary(selectedIndex)
                    || currentIndex >= GetLowerWordBoundary(selectedIndex);
        }

        private int GetUpperWordBoundary(int selectedIndex)
        {
            return selectedIndex + OffsetRange > itemsCount ? (selectedIndex + OffsetRange) % itemsCount : -1;
        }

        private int GetLowerWordBoundary(int selectedIndex)
        {
            return itemsCount + (selectedIndex - OffsetRange);
        }
        #endregion

        #region Layout
        protected override Size ArrangeOverride(Size finalSize)
        {
            this.Clip = new RectangleGeometry { Rect = new Rect(0, 0, finalSize.Width, finalSize.Height) };
            this.offsetSeparator = 0;

            double positionLeft = 0d;

            foreach (var item in Children)
            {
                if (item == null)
                    continue;

                var desiredSize = item.DesiredSize;

                if (double.IsNaN(desiredSize.Width) || double.IsNaN(desiredSize.Height))
                    continue;

                var rect = new Rect(positionLeft, 0, ItemWidth, desiredSize.Height);
                item.Arrange(rect);

                var compisiteTransform = new TranslateTransform();
                item.RenderTransform = compisiteTransform;

                positionLeft += ItemWidth;
            }

            templateApplied = true;
            currentMiddleIndex = itemsCount / 2;
            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var measuredSize = base.MeasureOverride(availableSize);

            Clip = new RectangleGeometry { Rect = new Rect(0, 0, measuredSize.Width, measuredSize.Height) };

            foreach (var element in Children)
            {
                element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

                if (ItemWidth < element.DesiredSize.Width)
                    ItemWidth = element.DesiredSize.Width;
            }

            return measuredSize;
        }
        #endregion
    }
}
