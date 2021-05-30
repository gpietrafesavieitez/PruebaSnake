using System;
using PruebaSnake.Data;
using System.Timers;

namespace PruebaSnake.Pages
{
    public partial class Index : IDisposable
    {
        private Board MyBoard;
        private Snake MySnake;
        private Apple MyApple;
        private Timer MyTimer;
        private Random RandNum;
        Direction Dir;

        protected override void OnInitialized()
        {
            MyBoard = new(20, 20);
            MySnake = new(0, 0);
            MyApple = new(0, 0);
            RandNum = new();
            MyTimer = new();
            MyTimer.Interval = 100;
            MyTimer.Elapsed += TimerEvent;
            Dir = Direction.RIGHT;
            CreateApple();
        }

        private void CreateApple()
        {
            MyApple.PosX = RandNum.Next(0, MyBoard.TabX);
            MyApple.PosY = RandNum.Next(0, MyBoard.TabY);
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
            MySnake.Move(Dir);
            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            MyTimer.Dispose();
        }

    }
}
