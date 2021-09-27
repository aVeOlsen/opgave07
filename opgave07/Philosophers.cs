using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace opgave07
{
    public class Philosophers
    {
        private int numberOfMaxThreads = 5;
        private int activeThreads = 0;
        public int activeEatingThread = 0;
        public int activeSleeperThread = 0;
        private int i = 0;

        public void ControlMethod()
        {
            
            //for (int i = 0; i < 10; i++)
            while(activeThreads<numberOfMaxThreads)
            {
               
                Thread.Sleep(1000);
                if(activeThreads < 4)
                {
                    
                    if (activeEatingThread < 1)
                    {
                        //opretter threads her
                        ThreadStart eatingThread = new ThreadStart(Eat);
                        Thread t = new Thread(eatingThread);
                        activeEatingThread++;
                        activeThreads++;
                        i++;
                        t.Name = $"{t}{i}";
                        t.Start();
                    }
                    else
                    {
                        ThreadStart sleepThread = new ThreadStart(Sleep);
                        Thread t1 = new Thread(sleepThread);
                        activeSleeperThread++;
                        activeThreads++;
                        i++;
                        t1.Name = $"{t1}{i}";
                        t1.Start();
                    }
                    Console.WriteLine("\n\nactive eating threads:\t{0}\n" +
                   "active sleeping threads:\t{1}\n" +
                   "total active threads:\t{2}\n\n", activeEatingThread, activeSleeperThread, activeThreads);
                }

            }

        }
        public void Eat()
        {
            Console.WriteLine("Thread: {0} Is Eating Rice", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            activeEatingThread--;
            activeThreads--;
            i--;
        }
        public void Sleep()
        {
            Console.WriteLine("Thread: {0} Is Sleeping", Thread.CurrentThread.Name);
            Thread.Sleep(4000);
            activeSleeperThread--;
            activeThreads--;
            i--;
            ControlMethod();
        }
    }
}
