using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation
{
    class Song
    {
        public string Artist { get; set; }
        public string TrackName { get; set; }
        public double TrackLength { get; set; }
    }

    class AllTracks
    {
        // Our media player can have a maximum of 10,000 songs
        public Song[] allSongs = new Song[10000];

        public AllTracks()
        {
            // Fill up the array here in the constructor
            Console.WriteLine("Filling up the songs");
        }

    }

    // The MediaPlayer has an AllTracks object
    class MediaPlayer
    {
        // Assume these m ethods do something useful
        public void Play() { }
        public void Pause() { }
        public void Stop() { }

        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>();

        public AllTracks GetAllTracks()
        {
            // return all of the songs
            return allSongs.Value;
        }

        // Alternative use of Lazy<T> specifying a function to customize the creation of the lazy data
        private Lazy<AllTracks> allSpecificSongs = new Lazy<AllTracks>(() =>
        {
            Console.WriteLine("Specific stuff");
            return new AllTracks();
        }
        );

    }

}
