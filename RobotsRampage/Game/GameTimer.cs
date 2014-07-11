using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRampage.Game
{
    using System.Activities.Statements;
    using System.Diagnostics;
    using System.Threading;

    public class GameTimer
    {
        private Action FrameCallback;
        private Action StartCallback;
        private Action EndCallback;

        private int desiredFPS;
        public int DesiredFPS
        {
            get
            {
                return desiredFPS;
            }
            set
            {
                desiredFPS = value;
                this.MsToUpdate = (long)Math.Round(1000.0 / value);
            }
        }

        private double ActualFPS;
        private enum GameTimerState { Created, Running, Stopped };

        private long State;

        private long MsToUpdate;

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

        public bool Start()
        {
            if (Interlocked.CompareExchange(ref this.State, (long)GameTimerState.Running, (long)GameTimerState.Created) != (long)GameTimerState.Created)
            {
                return false;
            }
            ThreadPool.QueueUserWorkItem(Run);
            return true;
        }

        public bool Stop()
        {
            if (Interlocked.CompareExchange(ref this.State, (long)GameTimerState.Stopped, (long)GameTimerState.Running) != (long)GameTimerState.Running)
            {
                return false;
            }
            return true;
        }
        private void Run(object state)
        {
            var stopWatch = new Stopwatch();
            long lastMsUpdate = 0;

            StartCallback();

            stopWatch.Start();

            while (Interlocked.Read(ref State) == (int)GameTimerState.Running)
            {
                long currentMs = stopWatch.ElapsedMilliseconds;
                if (currentMs - lastMsUpdate >= this.MsToUpdate)
                {
                    ActualFPS = 1000.0 / (currentMs - lastMsUpdate);
                    lastMsUpdate = currentMs;
#if DEBUG
                    Debug.WriteLine("Actual FPS: {0}", ActualFPS);
#endif
                    FrameCallback();
                }
                else
                {
                    Thread.Yield();
                }
            }

            EndCallback();
            stopWatch.Stop();
        }

    }
}