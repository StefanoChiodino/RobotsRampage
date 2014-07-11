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

        private int DesiredFPS;
        private int ActualFPS = 0;
        private enum GameTimerState { Created, Running, Stopped };

        private long State;

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
            long msToUpdate = (long)Math.Round(1000m / this.DesiredFPS);
            long msToNextUpdate = msToUpdate;
            stopWatch.Start();

            while (Interlocked.Read(ref State) == (int)GameTimerState.Running)
            {
                long currentMs = stopWatch.ElapsedMilliseconds;
                long elapsed = currentMs - lastMsUpdate;
                msToNextUpdate -= elapsed;
                if (msToNextUpdate <= 0)
                {
                    msToNextUpdate = msToUpdate - msToNextUpdate;
                    FrameCallback();
                }

                lastMsUpdate = currentMs;
                Thread.Yield();

            }
            stopWatch.Stop();
        }

    }
}