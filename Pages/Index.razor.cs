using System;
using PruebaSnake.Data;
using System.Timers;

namespace PruebaSnake.Pages
{
    public partial class Index : IDisposable
    {
        public int tabX, tabY;
        public Snake MySnake;
        public int AppleX { get; set; }
        public int AppleY { get; set; }
        private Timer MyTimer;
        private int direction = Snake.RIGHT;
        private int lastDirection = Snake.RIGHT;
        public Random RandNum = new Random();
        protected override void OnInitialized()
        {
            tabX = 25;
            tabY = 25;
            MyTimer = new();
            MyTimer.Interval = 100;
            MyTimer.Elapsed += TimerEvent;
            MySnake = new();
            CreateApple();
        }

        private void CreateApple()
        {
            AppleX = RandNum.Next(0, tabX);
            AppleY = RandNum.Next(0, tabY);
        }

        private void TimerStart()
        {
            MyTimer.Start();
        }

        private void TimerStop()
        {
            MyTimer.Stop();
        }

        private void TimerEvent(object senter, ElapsedEventArgs e)
        {
            MySnake.Move(direction);
            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            MyTimer.Dispose();
        }

    }
}
