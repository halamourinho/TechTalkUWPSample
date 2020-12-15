using System;
using Windows.UI.Xaml;

namespace TestSample.Controls
{
    public partial class LoopItemsPanel
    {

        public static readonly DependencyProperty OffsetRangeProperty =
            DependencyProperty.Register("OffsetRange", typeof(int), typeof(LoopItemsPanel), new PropertyMetadata(7));

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(LoopItemsPanel), new PropertyMetadata(TimeSpan.FromMilliseconds(200)));

        
        
        public int OffsetRange
        {
            get { return (int)GetValue(OffsetRangeProperty); }
            set { SetValue(OffsetRangeProperty, value); }
        }

        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        
        
        private int itemsCount
        {
            get
            {
                return Children?.Count ?? 0;
            }
        }
    }
}
