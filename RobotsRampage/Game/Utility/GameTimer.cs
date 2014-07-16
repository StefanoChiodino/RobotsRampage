namespace RobotsRampage.Game
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public class GameTimer
    {
        private readonly Action EndCallback;
        private readonly Action<long> FrameCallback;
        private readonly Action StartCallback;
        private double ActualFPS;
        private long MsToUpdate;
        private long State;
        private int desiredFPS;
        public int DesiredFPS
        {
            get
            {
                return this.desiredFPS;
            }
            set
            {
                this.desiredFPS = value;
                this.MsToUpdate = (long)Math.Round(1000.0 / value);
            }
        }

        public GameTimer(Action<long> frameCallback, int desiredFps, Action startCallback = null, Action endCallback = null)
        {
            if (frameCallback == null)
            {
                throw new ArgumentNullException("frameCallback");
            }
            if (desiredFps <= 0)
            {
                throw new ArgumentException("desiredFPS");
            }

            this.FrameCallback = frameCallback;
            this.StartCallback = startCallback ?? (() => { });
            this.EndCallback = endCallback ?? (() => { });
            this.DesiredFPS = desiredFps;
        }

        public bool Start()
        {
            if (Interlocked.CompareExchange(ref this.State, (long)GameTimerState.Running, (long)GameTimerState.Created)
                != (long)GameTimerState.Created)
            {
                return false;
            }
            ThreadPool.QueueUserWorkItem(this.Run);
            return true;
        }

        public bool Stop()
        {
            if (Interlocked.CompareExchange(ref this.State, (long)GameTimerState.Stopped, (long)GameTimerState.Running)
                != (long)GameTimerState.Running)
            {
                return false;
            }
            return true;
        }

        private void Run(object state)
        {
            var stopWatch = new Stopwatch();
            long lastMsUpdate = 0;

            this.StartCallback();

            stopWatch.Start();

            while (Interlocked.Read(ref this.State) == (int)GameTimerState.Running)
            {
                long currentMs = stopWatch.ElapsedMilliseconds;
                long elapsed = currentMs - lastMsUpdate;
                if (elapsed >= this.MsToUpdate)
                {
#if DEBUG
                    this.ActualFPS = 1000.0 / elapsed;
                    lastMsUpdate = currentMs;
                    Debug.WriteLine("Actual FPS: {0}", this.ActualFPS);
#endif
                    this.FrameCallback(elapsed);
                }
                else
                {
                    Thread.Yield();
                }
            }

            this.EndCallback();
            stopWatch.Stop();
        }

        private enum GameTimerState
        {
            Created,
            Running,
            Stopped
        };
    }
}