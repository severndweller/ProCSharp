using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with Lazy Instantiation ********");
            MediaPlayer myPlayer = new MediaPlayer();

            // No allocation of all tracks here
            myPlayer.Play();

            // Allocation of allTracks happens when GetAllTracks is called
            AllTracks myMusicLibrary = myPlayer.GetAllTracks();
            Console.ReadLine();
        }
    }
}
