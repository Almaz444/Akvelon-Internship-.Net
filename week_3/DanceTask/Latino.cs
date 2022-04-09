using System;


namespace DanceTask
{
    public class Latino : IMusic
    {
        public string DanceMove()
        {
            string dance = "Latino dance.";
            return dance;
        }
        public void PlayMusic()
        {
            Console.WriteLine("This is Latino music is playing.");
        }
    }
}
