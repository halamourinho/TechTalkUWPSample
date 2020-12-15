using System;
using Windows.UI.Xaml;

namespace TestSample.Models.UI
{
    public class DispatchThrottler
    {
        private readonly Action action;
        private readonly DispatcherTimer timer;

        public DispatchThrottler(Action action,int interval)
        {
            this.action = action;
            this.timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(interval)
            };

            this.timer.Tick += OnTick;
        }

        public void Start()
        {
            this.timer.Start();
        }

        private void OnTick(object sender, object e)
        {
            this.timer.Stop();
            this.action.Invoke();
        }
    }
}
