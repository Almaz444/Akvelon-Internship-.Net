using System;
using System.Collections.Generic;
using System.Threading;

namespace DanceTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dance Club. Now our DJ will play music.");
            List<IMusic> tracks = new List<IMusic>();

            Latino latino = new Latino();
            Rock rock = new Rock();
            Hardbass hardbass = new Hardbass();

            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int dice = random.Next(1, 4);
                if (dice == 1)
                    tracks.Add(latino);
                else if (dice == 2)
                    tracks.Add(rock);
                else
                    tracks.Add(hardbass);
            }
            foreach (IMusic track in tracks)
            {
                track.PlayMusic();
                for (int i = 1; i < 11; i++)
                {
                    Thread t = new Thread(() => Console.WriteLine("I am dancer number {0}, {1}", i,track.DanceMove()));
                    t.Start();
                    t.Join();
                }
                Thread.Sleep(5000);
            }
            Console.WriteLine("Time to go home.");
        }
    }
}
