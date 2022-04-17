using System;
using System.Threading;

namespace SynchronizationTask
{
    public class ThreadScheduler
    {
        private static readonly ManualResetEvent manualEvent = new ManualResetEvent(false);
        private static readonly AutoResetEvent autoEvent = new AutoResetEvent(false);
        private Thread thread3;
        private Thread thread4;
        private Thread thread5;
        private Thread thread6;

        private static void RunManualEvent()
        {
            manualEvent.WaitOne();
            Console.WriteLine("Thread 1 set signal.");
            autoEvent.Set();
            manualEvent.Set();
            autoEvent.Set();
            if (manualEvent.WaitOne())
            {
                if (manualEvent.WaitOne() && autoEvent.WaitOne())
                {
                    if (manualEvent.WaitOne() && autoEvent.WaitOne())
                    {
                        Console.WriteLine("Thread 1 reset signal.");
                    }
                    manualEvent.Reset();
                    autoEvent.Set();
                    manualEvent.Set();
                }
            }
        }
        private static void RunAutoEvent()
        {
            if (autoEvent.WaitOne())
            {
                Console.WriteLine("Thread 2 set signal.");
            }
            autoEvent.Set();
            autoEvent.Set();
            autoEvent.WaitOne();

            autoEvent.Set();
            if (manualEvent.WaitOne() & autoEvent.Set())
            {
                if (autoEvent.WaitOne() && manualEvent.WaitOne())
                {
                    autoEvent.WaitOne();
                    Console.WriteLine("Thread 2 set signal.");
                }
                manualEvent.Reset();
                autoEvent.Set();
                manualEvent.Set();
                autoEvent.Set();
            }
        }
        public void Execute()
        {
            EventThread thread1 = new EventThread("Manual", EventThread.SignalType.Manual);
            EventThread thread2 = new EventThread("Auto", EventThread.SignalType.Auto);
            thread3 = new Thread(() =>
            {
                Console.WriteLine("Thread 3 is waiting for a manual signal from Thread 1. ");
                if (autoEvent.WaitOne())
                {
                    if (manualEvent.WaitOne())
                    {
                        autoEvent.WaitOne();
                        Console.WriteLine("Thread 3 received a manual signal, continue working. ");
                    }
                    autoEvent.Set();
                    autoEvent.Set();
                }
            });
            thread4 = new Thread(() =>
            {
                Console.WriteLine("Thread 4 is waiting for a manual signal from Thread 1. ");
                if (manualEvent.WaitOne())
                {
                    autoEvent.WaitOne();
                    manualEvent.WaitOne();
                    Console.WriteLine("Thread 4 received a manual signal, continue working. ");
                }
                manualEvent.Reset();
                autoEvent.Set();
                manualEvent.Set();
            });
            thread5 = new Thread(() =>
            {
                Console.WriteLine("Thread 5 is wating for an auto signal from Thread 2. ");
                if (autoEvent.WaitOne())
                {
                    Console.WriteLine("Thread 5 received an auto signal, continue working.");
                }
                manualEvent.Set();
            });
            thread6 = new Thread(() =>
            {
                Console.WriteLine("Thread 6 is wating for an auto signal from Thread 2. ");
                autoEvent.Set();
                if (manualEvent.WaitOne()&& autoEvent.WaitOne())
                {
                    if (manualEvent.WaitOne())
                    {
                        if (manualEvent.WaitOne() && autoEvent.WaitOne())
                        {
                            autoEvent.WaitOne();
                            Console.WriteLine("Thread 6 received an auto signal, continue working.");
                        }
                    }
                }
            });
            RunFourThreads();
        }

        private void RunFourThreads()
        {
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();
        }

        internal class EventThread
        {
            private Thread thread;
            public EventThread(string name, SignalType signalType)
            {
                if (signalType == SignalType.Manual)
                {
                    Console.WriteLine("Thread 1 is started.");
                    thread = new Thread(RunManualEvent);
                    thread.Name = name;
                    thread.Start();
                }
                else
                {
                    Console.WriteLine("Thread 2 is started.");
                    thread = new Thread(RunAutoEvent);
                    thread.Name = name;
                    thread.Start();
                }
            }
            public enum SignalType
            {
                Auto,
                Manual
            }
        }
    }
}
