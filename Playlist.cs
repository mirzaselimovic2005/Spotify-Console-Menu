using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Playlist
    {
        public string Title { get; set; }
        public List<Song> Songs { get; set; }
        public List<Album> Albums { get; set; }

        public Playlist()
        {
            Songs = new List<Song>();
            Albums = new List<Album>();
        }

    public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
        }

        public void Play()
        {
            foreach (var song in Songs)
            {
                Console.WriteLine($"Playing {song.Title} by {song.Artist} ({song.Duration})");
            }
        }
    }
}
