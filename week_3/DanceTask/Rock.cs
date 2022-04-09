using System;


namespace DanceTask
{
    public class Rock : IMusic
    {
        public string DanceMove()
        {
            string dance = "Rock dance.";
            return dance;
        }
        public void PlayMusic()
        {
            Console.WriteLine("This is Rock music is playing.");
        }
    }
}
