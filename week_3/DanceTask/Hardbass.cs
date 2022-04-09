using System;


namespace DanceTask
{
    public class Hardbass : IMusic
    {
        public string DanceMove()
        {
            string dance = "Elbow dance.";
            return dance;
        }
        public void PlayMusic()
        {
            Console.WriteLine("This is Hardbass music is playing.");
        }
    }
}
