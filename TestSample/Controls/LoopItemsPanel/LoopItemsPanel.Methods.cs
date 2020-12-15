using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace TestSample.Controls
{
    public partial class LoopItemsPanel
    {
        private void ScrollToSelectedItem(UIElement selectedItem, Rect rect)
        {
            if (!this.templateApplied)
                return;

            TranslateTransform compisiteTransform = selectedItem.RenderTransform as TranslateTransform;

            if (compisiteTransform == null)
                return;

            var centerLeftOfsset = (ActualWidth / 2d) - (ItemWidth / 2d);
            var deltaOffset = centerLeftOfsset - rect.X;

            UpdatePosition(deltaOffset);
        }

        private void UpdatePosition(double offsetDelta, bool isUseAnimation = true)
        {
            if (itemsCount == 0)
                return;

            double maxLogicalWidth = itemsCount * ItemWidth;

            offsetSeparator = (offsetSeparator + offsetDelta) % maxLogicalWidth;

            int itemNumSeparator = Convert.ToInt32(Math.Abs(offsetSeparator) / ItemWidth);

            int itemIndexChanging;
            double offsetAfter;
            double offsetBefore;

            if (offsetSeparator > 0)
            {
                itemIndexChanging = itemsCount - itemNumSeparator - 1;
                offsetAfter = offsetSeparator;

                if (offsetSeparator % maxLogicalWidth == 0)
                    itemIndexChanging++;

                offsetBefore = offsetAfter - maxLogicalWidth;
            }
            else
            {
                itemIndexChanging = itemNumSeparator;
                offsetBefore = offsetSeparator;
                offsetAfter = maxLogicalWidth + offsetSeparator;
            }

            storyboard = new Storyboard();
            storyboard.Completed += OnStoryboardCompleted;

            if (itemIndexChanging < 0)
                itemIndexChanging = 0;

            UpdatePosition(itemIndexChanging, itemsCount, offsetBefore, storyboard, isUseAnimation);
            UpdatePosition(0, itemIndexChanging, offsetAfter, storyboard, isUseAnimation);

            if (storyboard.Children.Count > 0)
                storyboard.Begin();
        }

        private void UpdatePosition(int startIndex, int endIndex, double offset, Storyboard storyboard, bool isUseAnimation)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                UIElement loopListItem = Children[i];
                var compisiteTransform = loopListItem.RenderTransform as TranslateTransform;

                if (compisiteTransform == null)
                    continue;

                if (isUseAnimation && (IsInRangeOfIndex(i, currentMiddleIndex) || IsInRangeOfIndex(i, previousMiddleIndex)))
                {
                    var animateSnap = new DoubleAnimation
                    {
                        EnableDependentAnimation = true,
                        From = compisiteTransform.X,
                        To = offset,
                        Duration = AnimationDuration,
                        EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseInOut }
                    };
                    Storyboard.SetTarget(animateSnap, loopListItem);
                    Storyboard.SetTargetProperty(animateSnap, "(UIElement.RenderTransform).(TranslateTransform.X)");
                    storyboard.Children.Add(animateSnap);
                }
                else
                    compisiteTransform.X = offset;
            }
        }

        private void CompleteManipulation()
        {
            isManipulating = false;
            var centerPoint = (ActualWidth / 2d) - (this.ItemWidth / 2d);

            foreach (var element in Children)
            {
                if (element == null)
                    continue;

                var rect = element.TransformToVisual(this).TransformBounds(new Rect(0, 0, element.DesiredSize.Width, element.DesiredSize.Height));

                if (rect.X >= (centerPoint - ItemWidth / 2) && rect.X < (centerPoint + ItemWidth / 2))
                {
                    ScrollToItem(element);
                    MiddleItemChanged?.Invoke(this, element);
                    break;
                }
            }
        }
    }
}
