using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();

        public void Play()
        {
            foreach (var song in Songs)
            {
                Console.WriteLine($"Playing {song.Title} by {song.Artist} ({song.Duration})");
            }
        }
    }
}
