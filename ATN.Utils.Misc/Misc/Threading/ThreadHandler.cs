using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATN.Utils.Threading
{
    public abstract class ThreadHandler
    {
        const int sleepDuration = 250;

        object _lockObj = new object();

        bool _toContinueRunning = true;

        bool _isRunning = false;

        bool IsRunning
        {
            get
            {
                lock (_lockObj)
                {
                    return _isRunning;
                }
            }
            set
            {
                lock (_lockObj)
                {
                    _isRunning = value;
                }
            }
        }

        bool ToContinueRunning
        {
            get
            {
                lock (_lockObj)
                {
                    return _toContinueRunning;
                }
            }
            set
            {
                lock (_lockObj)
                {
                    _toContinueRunning = value;
                }
            }
        }

        Thread thread;

        public ThreadHandler()
        {
            thread = new Thread(() => Run());
            thread.Start();
        }


        public void Run()
        {
            IsRunning = true;

            while (ToContinueRunning)
            {
                DoWork();

                System.Threading.Thread.Sleep(sleepDuration);
            }

            IsRunning = false;
        }

        protected abstract void DoWork();

        public bool Stop()
        {
            ToContinueRunning = false;
            for (int i = 0; i < 10; i++)
            {
                if (IsRunning == false)
                {
                    return true;
                }
                Thread.Sleep(100);
            }

            thread.Abort();

            return false;
        }

    }
}

