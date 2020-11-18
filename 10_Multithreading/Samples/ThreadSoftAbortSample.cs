using System;
using System.Collections.Generic;
using System.Text;

namespace _10_Multithreading.Samples
{
    //Przerywanie wątków za pomocą Abort / Interrupt nie jest wskazane ze względu na brak kontroli kiedy nastąpi przerwanie
    //Lepszym rozwiązaniem jest samodzielna kontrola nad przerwaniami
    //https://jonskeet.uk/csharp/threads/shutdown.html
    public class ThreadSoftAbortSample
    {
        /// <summary>
        /// Lock covering stopping and stopped
        /// </summary>
        readonly object stopLock = new object();
        /// <summary>
        /// Whether or not the worker thread has been asked to stop
        /// </summary>
        bool stopping = false;
        /// <summary>
        /// Whether or not the worker thread has stopped
        /// </summary>
        bool stopped = false;

        /// <summary>
        /// Returns whether the worker thread has been asked to stop.
        /// This continues to return true even after the thread has stopped.
        /// </summary>
        public bool Stopping
        {
            get
            {
                lock (stopLock)
                {
                    return stopping;
                }
            }
        }

        /// <summary>
        /// Returns whether the worker thread has stopped.
        /// </summary>
        public bool Stopped
        {
            get
            {
                lock (stopLock)
                {
                    return stopped;
                }
            }
        }

        /// <summary>
        /// Tells the worker thread to stop, typically after completing its 
        /// current work item. (The thread is *not* guaranteed to have stopped
        /// by the time this method returns.)
        /// </summary>
        public void Stop()
        {
            lock (stopLock)
            {
                stopping = true;
            }
        }

        /// <summary>
        /// Called by the worker thread to indicate when it has stopped.
        /// </summary>
        void SetStopped()
        {
            lock (stopLock)
            {
                stopped = true;
            }
        }

        /// <summary>
        /// Main work loop of the class.
        /// </summary>
        public void Run()
        {
            try
            {
                while (!Stopping)
                {
                    // Insert work here. Make sure it doesn't tight loop!
                    // (If work is arriving periodically, use a queue and Monitor.Wait,
                    // changing the Stop method to pulse the monitor as well as setting
                    // stopping.)

                    // Note that you may also wish to break out *within* the loop
                    // if work items can take a very long time but have points at which
                    // it makes sense to check whether or not you've been asked to stop.
                    // Do this with just:
                    // if (Stopping)
                    // {
                    //     return;
                    // }
                    // The finally block will make sure that the stopped flag is set.
                }
            }
            finally
            {
                SetStopped();
            }
        }
    }
}
