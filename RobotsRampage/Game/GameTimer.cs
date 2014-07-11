namespace SpaceRampage.Game
{
    #region Using
    using System;
    using System.Diagnostics;
    using System.Threading;

    #endregion

    public class GameTimer
    {
        #region Fields
        private readonly Action EndCallback;
        private readonly Action FrameCallback;
        private readonly Action StartCallback;
        private double ActualFPS;
        private long MsToUpdate;
        private long State;
        private int desiredFPS;
        #endregion

        #region Constructors and Destructors
        public GameTimer(Action frameCallback, int desiredFps, Action startCallback = null, Action endCallback = null)
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
        #endregion

        #region Enums
        private enum GameTimerState
        {
            Created,
            Running,
            Stopped
        };
        #endregion

        #region Public Properties
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
        #endregion

        #region Public Methods and Operators
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
        #endregion

        #region Methods
        private void Run(object state)
        {
            var stopWatch = new Stopwatch();
            long lastMsUpdate = 0;

            this.StartCallback();

            stopWatch.Start();

            while (Interlocked.Read(ref this.State) == (int)GameTimerState.Running)
            {
                long currentMs = stopWatch.ElapsedMilliseconds;
                if (currentMs - lastMsUpdate >= this.MsToUpdate)
                {
#if DEBUG
                    this.ActualFPS = 1000.0 / (currentMs - lastMsUpdate);
                    lastMsUpdate = currentMs;
                    Debug.WriteLine("Actual FPS: {0}", this.ActualFPS);
#endif
                    this.FrameCallback();
                }
                else
                {
                    Thread.Yield();
                }
            }

            this.EndCallback();
            stopWatch.Stop();
        }
        #endregion
    }
}