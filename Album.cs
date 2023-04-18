using System;
using System.Collections.Generic;

namespace Spotify {
    public class Album {
        public string Title { get; set; }
        public string Artist { get; set; }
        public List<Song> Songs { get; set; }

        public Album(string title, string artist) {
            Title = title;
            Artist = artist;
            Songs = new List<Song>();
        }

        public void AddSong(Song song) {
            Songs.Add(song);
        }

        public void RemoveSong(Song song) {
            Songs.Remove(song);
        }

        public void Play() {
            Console.WriteLine($"Afspelend album: {Title} - {Artist}");
            foreach (Song song in Songs) {
                song.Play();
            }
        }

        public void Shuffle() {
            Random rand2 = new Random();
            int n = Songs.Count;
            while (n > 1) {
                n--;
                int k = rand2.Next(n + 1);
                Song value = Songs[k];
                Songs[k] = Songs[n];
                Songs[n] = value;
            }
            Console.WriteLine($"Album {Title} is geshuffled.");
        }

        public override string ToString() {
            return $"{Title} - {Artist} ({Songs.Count} nummers)";
        }
    }
}
