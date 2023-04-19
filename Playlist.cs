using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify {
    public class Playlist {
        public string Title { get; set; }
        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
        private string name;

        public Playlist(string name) {
            Name = name;
            Songs = new List<Song>();
            Albums = new List<Album>();
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public void AddSong(Song song) {
            Songs.Add(song);
        }

        public void RemoveSong(Song song) {
            Songs.Remove(song);
        }

        public void AddAlbum(Album album) {
            Albums.Add(album);
        }


        public void RemoveAlbum(Album album) {
            Albums.Remove(album);
        }

        public List<Song> GetSongs() {
            return Songs;
        }



        public void Play() {
            foreach (var song in Songs) {
                Console.WriteLine($"Afspelend {song.Title} door {song.Artist} ({song.Duration})");
            }
        }


        public void Shuffle() {
            Random rand = new Random();
            for (int i = 0; i < Songs.Count; i++) {
                int randIndex = rand.Next(0, Songs.Count);
                Song temp = Songs[i];
                Songs[i] = Songs[randIndex];
                Songs[randIndex] = temp;
            }
        }
    }
}
