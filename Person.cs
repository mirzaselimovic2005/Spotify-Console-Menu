using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify {
    public class Person {
        public string Name { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Person> Friends { get; set; }
        public List<Album> Albums { get; set; }

        public Person(string name) {
            Name = name;
            Playlists = new List<Playlist>();
            Friends = new List<Person>();
            Albums = new List<Album>();
        }

        private List<Person> friends = new List<Person>();

        public void AddFriend(Person friend) {
            friends.Add(friend);
        }

        public void RemoveFriend(Person friend) {
            friends.Remove(friend);
        }

        public List<Person> GetFriends() {
            return friends;
        }

        public void SeeFriends() {
            Console.WriteLine($"Vrienden van {Name}:");
            foreach (var friend in Friends) {
                Console.WriteLine($"- {friend.Name}");
            }
        }

        public List<Playlist> GetPlaylists() {
            return Playlists;
        }

        public void SeePlaylists() {
            Console.WriteLine($"Playlists van {Name}:");
            foreach (var playlist in Playlists) {
                Console.WriteLine($"- {playlist.Name}");
            }
        }

        public void AddPlaylist(Playlist playlist) {
            Playlists.Add(playlist);
        }

        public void RemovePlaylist(Playlist playlist) {
            Playlists.Remove(playlist);
        }

        public void AddSongToPlaylist(Song song, Playlist playlist) {
            playlist.AddSong(song);
        }

        public void RemoveSongFromPlaylist(Song song, Playlist playlist) {
            playlist.RemoveSong(song);
        }

        public void AddAlbum(Album album) {
            Albums.Add(album);
        }

        public List<Song> GetSameSongs() {
            List<Song> sameSongs = new List<Song>();
            List<Playlist> friendPlaylists = Friends.SelectMany(friend => friend.GetPlaylists()).ToList();

            foreach (Song song in Playlists.SelectMany(playlist => playlist.GetSongs())) {
                bool songInPL = true;

                foreach (Playlist friendPlaylist in friendPlaylists) {
                    if (!friendPlaylist.Songs.Contains(song)) {
                        songInPL = false;
                        break;
                    }
                }

                if (songInPL && !sameSongs.Contains(song)) {
                    sameSongs.Add(song);
                }
            }

            return sameSongs;
        }

    }
}
