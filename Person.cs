using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Person
    {
        public string Name { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Person> Friends { get; set; }

        public Person(string name)
        {
            Name = name;
            Playlists = new List<Playlist>();
            Friends = new List<Person>();
        }

        private List<Person> friends = new List<Person>();

        public void AddFriend(Person friend)
        {
            friends.Add(friend);
        }

        public void RemoveFriend(Person friend)
        {
            friends.Remove(friend);
        }

        public List<Person> GetFriends()
        {
            return friends;
        }

        public void ViewFriends()
        {
            Console.WriteLine($"Friends of {Name}:");
            foreach (var friend in Friends)
            {
                Console.WriteLine($"- {friend.Name}");
            }
        }

        public List<Playlist> GetPlaylists()
        {
            return Playlists;
        }

        public void AddPlaylist(Playlist playlist)
        {
            Playlists.Add(playlist);
        }

        public void RemovePlaylist(Playlist playlist)
        {
            Playlists.Remove(playlist);
        }

        public void AddSongToPlaylist(Song song, Playlist playlist)
        {
            playlist.AddSong(song);
        }

        public void RemoveSongFromPlaylist(Song song, Playlist playlist)
        {
            playlist.RemoveSong(song);
        }
    }
}
