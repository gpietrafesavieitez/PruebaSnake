using System;
using PruebaSnake.Data;
using System.Timers;

namespace PruebaSnake.Pages
{
    public enum Mode
    {
        EASY, NORMAL, HARD, EXTREME
    }

    public partial class Index : IDisposable
    {
        private Board MyBoard;
        private Snake MySnake;
        private Apple MyApple;
        private Timer MyTimer;
        private Random RandNum;
        private Direction Dir;
        private int Score, Counter;
        private bool GameOver;
        private int TimeInterval;
        private string Difficulty;
        
        protected override void OnInitialized()
        {
            GameOver = false;
            MyBoard = new(20, 20);
            MySnake = new(0, 0);
            MyApple = new(10, 10);
            RandNum = new();
            MyTimer = new();
            UpdateDifficulty(Mode.EASY);
            MyTimer.Elapsed += TimerEvent;
            Dir = Direction.RIGHT;
        }

        private void CreateApple()
        {
            MyApple.PosX = RandNum.Next(0, MyBoard.TabX);
            MyApple.PosY = RandNum.Next(0, MyBoard.TabY);
        }

        public void UpdateDifficulty(Mode mode)
        {
            switch (mode)
            {
                case Mode.EASY:
                    TimeInterval = 100;
                    Difficulty = "Fácil";
                    break;
                case Mode.NORMAL:
                    TimeInterval = 80;
                    Difficulty = "Normal";
                    break;
                case Mode.HARD:
                    TimeInterval = 50;
                    Difficulty = "Difícil";
                    break;
                case Mode.EXTREME:
                    TimeInterval = 40;
                    Difficulty = "Extremo";
                    break;

            }
            MyTimer.Interval = TimeInterval;
            FocusOnControls();
        }

        private void TimerStart()
        {
            MyTimer.Start();
            FocusOnControls();
        }

        private void TimerStop()
        {
            MyTimer.Stop();
        }

        private void TimerEvent(object senter, ElapsedEventArgs e)
        {
            Counter++;
            MySnake.Move(Dir);
            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            MyTimer.Dispose();
        }

    }
}
