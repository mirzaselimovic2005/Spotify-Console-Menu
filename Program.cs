﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify {
    class Program {
        static void Main(string[] args) {

            // Voeg gebruiker toe
            Person currentUser = new Person("Mirza");

            // Voeg playlist met songs toe
            Playlist newPlaylist2 = new Playlist("");
            Playlist newPlaylist3 = new Playlist("");
            Playlist newPlaylist4 = new Playlist("Mom of 4");
            Playlist newPlaylist5 = new Playlist("Enja");

            // Voeg songs toe
            //Voeg songs toe aan playlist
            Song song1 = new Song("Shape of You", "Ed Sheeran", TimeSpan.FromMinutes(4.23), "Pop");
            Song song2 = new Song("Bohemian Rhapsody", "Queen", TimeSpan.FromMinutes(5.55), "Rock");
            Song song3 = new Song("Billie Jean", "Michael Jackson", TimeSpan.FromMinutes(4.53), "Pop");
            Song song4 = new Song("Stairway to Heaven", "Led Zeppelin", TimeSpan.FromMinutes(8.02), "Rock");
            Song song5 = new Song("I Will Always Love You", "Whitney Houston", TimeSpan.FromMinutes(4.32), "Pop");
            Song song6 = new Song("Sweet Child O' Mine", "Guns N' Roses", TimeSpan.FromMinutes(5.56), "Rock");
            Song song7 = new Song("Thriller", "Michael Jackson", TimeSpan.FromMinutes(5.58), "Pop");
            Song song8 = new Song("Hotel California", "The Eagles", TimeSpan.FromMinutes(6.30), "Rock");
            Song song9 = new Song("Thinking Out Loud", "Ed Sheeran", TimeSpan.FromMinutes(4.41), "Pop");
            Song song10 = new Song("November Rain", "Guns N' Roses", TimeSpan.FromMinutes(8.57), "Rock");

            // voeg playlist aan user toe
            //currentUser.AddPlaylist(newPlaylist1);

            // Voeg albums toe en liedjes aan albums
            Album album1 = new Album("Mom of 4", "Enja");
            Album album2 = new Album("Elektriciteits", "Componentje");
            album1.AddSong(song1);
            album1.AddSong(song2);
            currentUser.AddAlbum(album1);
            currentUser.AddAlbum(album2);

            // Voeg vrienden toe
            Person friend1 = new Person("Vriend 1");
            Person friend2 = new Person("Vriend 2");
            currentUser.AddFriend(friend1);
            currentUser.AddFriend(friend2);

            // Voeg playlist toe aan vrienden
            friend1.AddPlaylist(newPlaylist5);
            friend2.AddPlaylist(newPlaylist4);



            // MAIN WHILE TRUE BEGINT HIER
            while (true) {
                Console.WriteLine($"@MIEP1194390 - https://github.com/Miep1194390/Spotify-Console-Menu");
                Console.WriteLine($"Welkom {currentUser.Name}!");
                Console.WriteLine("0. Beheer albums");
                Console.WriteLine("1. Beheer afspeellijsten");
                Console.WriteLine("2. Bekijk vrienden");
                Console.WriteLine("3. Verlaten");

               int keuze = Convert.ToInt32(Console.ReadLine());
                switch (keuze) {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Album menu");
                        Console.WriteLine("1. Bekijk albums");
                        Console.WriteLine("2. Voeg album toe aan afspeellijst");
                        Console.WriteLine("3. Album verwijderen van playlist");
                        Console.WriteLine("4. Album afspelen");
                        Console.WriteLine("5. Terug naar hoofdmenu");

                        int albumkeuze = Convert.ToInt32(Console.ReadLine());
                        switch (albumkeuze) {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Je hebt de volgende albums:");
                                foreach (Album album in currentUser.Albums) {
                                    Console.WriteLine(album.Title);
                                }
                                if (currentUser.Albums == null || currentUser.Albums.Count == 0) {
                                    Console.WriteLine("Je hebt nog geen albums.");
                                    break;
                                }
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Voeg album toe aan afspeellijst");
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string playlistnaam = Console.ReadLine();
                                Playlist afspeellijst = currentUser.Playlists.Find(p => p.Name == playlistnaam);
                                if (afspeellijst != null) {
                                    Console.WriteLine("Voer de naam van het album in:");
                                    string albumnaam = Console.ReadLine();
                                    Album album = currentUser.Albums.Find(a => a.Title == albumnaam);
                                    if (album != null) {
                                        afspeellijst.AddAlbum(album);
                                        Console.WriteLine($"{album.Title} is toegevoegd aan {afspeellijst.Name}.");
                                    } else {
                                        Console.WriteLine("Album niet gevonden.");
                                    }
                                } else {
                                    Console.WriteLine("Afspeellijst niet gevonden.");
                                }
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Album verwijderen van afspeellijst");
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string afspeellijstnaam = Console.ReadLine();
                                Playlist playlist = currentUser.Playlists.Find(p => p.Name == afspeellijstnaam);
                                if (playlist != null) {
                                    Console.WriteLine("Voer de naam van het album in:");
                                    string albumnaam = Console.ReadLine();
                                    Album album = playlist.Albums.Find(a => a.Title == albumnaam);
                                    if (album != null) {
                                        playlist.RemoveAlbum(album);
                                        Console.WriteLine($"{album.Title} is verwijderd van {playlist.Name}.");
                                    } else {
                                        Console.WriteLine("Album niet gevonden.");
                                    }
                                } else {
                                    Console.WriteLine("Afspeellijst niet gevonden.");
                                }
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("Album afspelen");
                                Console.WriteLine("Voer de naam van het album in:");
                                string albumName = Console.ReadLine();
                                Album albumToPlay = currentUser.Albums.Find(a => a.Title == albumName);
                                if (albumToPlay != null) {
                                    Console.WriteLine($"Album {albumToPlay.Title} wordt afgespeeld...");
                                } else {
                                    Console.WriteLine("Album niet gevonden.");
                                }
                                break;
                            case 5:
                                Console.Clear();
                                break;
                        }
                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("Afspeellijst menu");
                        Console.WriteLine("1. Bekijk afspeellijsten");
                        Console.WriteLine("2. Voeg afspeellijst toe");
                        Console.WriteLine("3. Afspeellijst verwijderen");
                        Console.WriteLine("4. Nummer toevoegen aan afspeellijst");
                        Console.WriteLine("5. Nummer uit afspeellijst verwijderen");
                        Console.WriteLine("6. Nummer uit afspeellijst afspelen");
                        Console.WriteLine("7. Shuffle");
                        Console.WriteLine("8. Terug naar hoofdmenu");


                        int afspeellijstkeuze = Convert.ToInt32(Console.ReadLine());

                        switch (afspeellijstkeuze) {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Je hebt de volgende afspeellijsten:");
                                Console.WriteLine("Aantal afspeellijsten: " + currentUser.Playlists.Count);
                                foreach (Playlist currentPlaylist in currentUser.Playlists) {
                                    Console.WriteLine(currentPlaylist.Name);
                                }
                                if (currentUser.Playlists == null || currentUser.Playlists.Count == 0) {
                                    Console.WriteLine("Je hebt nog geen afspeellijsten.");
                                    break;
                                }
                                break;




                            case 2:
                                Console.Clear();
                                Console.WriteLine("Voeg afspeellijst toe");
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string playlistName = Console.ReadLine();
                                currentUser.AddPlaylist(new Playlist(playlistName));
                                Console.WriteLine($"Afspeellijst '{playlistName}' is toegevoegd.");
                                break;  


                            case 3:
                                Console.Clear();
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string playlistToRemove = Console.ReadLine();
                                List<Playlist> userPlaylists = currentUser.GetPlaylists();
                                Playlist playlist = userPlaylists.FirstOrDefault(p => p.Name == playlistToRemove);
                                if (playlist != null) {
                                    currentUser.RemovePlaylist(playlist);
                                    Console.WriteLine($"Afspeellijst '{playlistToRemove}' is verwijderd.");
                                } else {
                                    Console.WriteLine($"Afspeellijst '{playlistToRemove}' is niet gevonden");
                                }
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("Voer de titel van het nummer in:");
                                string songTitle = Console.ReadLine();
                                Console.WriteLine("Voer artiest in:");
                                string songArtist = Console.ReadLine();
                                Console.WriteLine("Voer de duur van het nummer in mm:ss:");
                                string songDurationString = Console.ReadLine();
                                TimeSpan songDuration = TimeSpan.ParseExact(songDurationString, "mm\\:ss", null);
                                Console.WriteLine("Voer het songgenre in:");
                                string songGenre = Console.ReadLine();
                                Song newSong = new Song(songTitle, songArtist, songDuration, songGenre);
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string playlistToAddTo = Console.ReadLine();
                                List<Playlist> userPlaylists2 = currentUser.GetPlaylists();
                                Playlist selectedPlaylist = userPlaylists2.FirstOrDefault(p => p.Name == playlistToAddTo);
                                if (selectedPlaylist != null) {
                                    currentUser.AddSongToPlaylist(newSong, selectedPlaylist);
                                    Console.WriteLine($"Nummer '{songTitle}' is toegevoegd aan afspeellijst '{playlistToAddTo}'");
                                } else {
                                    Console.WriteLine($"Afspeellijst '{playlistToAddTo}' niet gevonden.");
                                }
                                break;

                            case 5:
                                Console.Clear();
                                Console.WriteLine("Voer de titel van het nummer in:");
                                string songTitle2 = Console.ReadLine();
                                Console.WriteLine("Voer artiest in:");
                                string songArtist2 = Console.ReadLine();
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string playlistToRemoveFrom = Console.ReadLine();
                                List<Playlist> userPlaylists3 = currentUser.GetPlaylists();
                                Playlist selectedPlaylist2 = userPlaylists3.FirstOrDefault(p => p.Name == playlistToRemoveFrom);
                                if (selectedPlaylist2 != null) {
                                    Song songToRemove = selectedPlaylist2.Songs.FirstOrDefault(s => s.Title == songTitle2 && s.Artist == songArtist2);
                                    if (songToRemove != null) {
                                        currentUser.RemoveSongFromPlaylist(songToRemove, selectedPlaylist2);
                                        Console.WriteLine($"Nummer '{songTitle2}' is verwijderd uit afspeellijst '{playlistToRemoveFrom}'.");
                                    } else {
                                        Console.WriteLine($"Nummer '{songTitle2}' is niet gevonden in afspeellijst '{playlistToRemoveFrom}'.");
                                    }
                                } else {
                                    Console.WriteLine($"Afspeellijst '{playlistToRemoveFrom}' niet gevonden.");
                                }
                                break;

                            case 6:
                                Console.Clear();
                                Console.WriteLine("Van welke afspeellijst wil je een liedje afspelen?");
                                string selectedPlaylistName = Console.ReadLine();
                                List<Playlist> playlists2 = currentUser.GetPlaylists();
                                Playlist selected = null;
                                foreach (Playlist playlist2 in playlists2) {
                                    if (playlist2.Name == selectedPlaylistName) {
                                        selected = playlist2;
                                        break;
                                    }
                                }
                                if (selected != null) {
                                    Console.WriteLine($"Welk nummer wil je afspelen? (1-{selected.Songs.Count})");
                                    for (int i = 0; i < selected.Songs.Count; i++) {
                                        Song song = selected.Songs[i];
                                        Console.WriteLine($"{i + 1}. {song.Title} - {song.Artist}");
                                    }
                                    int songNumber = Convert.ToInt32(Console.ReadLine());
                                    if (songNumber >= 1 && songNumber <= selected.Songs.Count) {
                                        Song selectedSong = selected.Songs[songNumber - 1];
                                        Console.WriteLine($"'{selectedSong.Title}' word afgespeeld!");
                                    } else {
                                        Console.WriteLine("niet mogelijk!!!");
                                    }
                                } else {
                                    Console.WriteLine($"Afspeellijst '{selectedPlaylistName}' is niet gevonden.");
                                }
                                break;


                            case 7:
                                Console.Clear();
                                Console.WriteLine("Van welke afspeellijst wil je de liedjes schufflen?");
                                string selectedPlaylistName2 = Console.ReadLine();
                                List<Playlist> playlists3 = currentUser.GetPlaylists();
                                Playlist selected2 = null;
                                foreach (Playlist playlist3 in playlists3) {
                                    if (playlist3.Name == selectedPlaylistName2) {
                                        selected2 = playlist3;
                                        break;
                                    }
                                }
                                if (selected2 != null) {
                                    selected2.Shuffle();
                                    Console.WriteLine($"Liedjes in afspeellijst '{selectedPlaylistName2}' zijn geshuffled.");
                                } else {
                                    Console.WriteLine($"Afspeellijst '{selectedPlaylistName2}' is niet gevonden.");
                                }
                                break;

                            case 8:
                                Console.Clear();
                                break;



                            default:
                                Console.WriteLine("NIET MOGELIJKK!!");
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Vrienden menu");
                        Console.WriteLine("1. Vriend toevoegen");
                        Console.WriteLine("2. Vriend verwijderen");
                        Console.WriteLine("3. Vrienden bekijken");
                        Console.WriteLine("4. Afspeellijsten vergelijken van vrienden");
                        Console.WriteLine("5. Terug naar hoofdmenu");

                        int keuze2 = int.Parse(Console.ReadLine());

                        switch (keuze2) {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Voer de naam van de vriend in:");
                                string friendName = Console.ReadLine();
                                Person newFriend = new Person(friendName);

                                if (newFriend != null) {
                                    currentUser.AddFriend(newFriend);
                                    Console.WriteLine($"Vriend {friendName} is toevoegd!");

                                } else {
                                    Console.WriteLine($"Vriend {friendName} niet gevonden!");
                                }
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("Voer de naam van de vriend in:");
                                string Friendname2 = Console.ReadLine();
                                var friendToRemove = currentUser.GetFriends().FirstOrDefault(x => x.Name == Friendname2);
                                if (friendToRemove != null) {
                                    currentUser.RemoveFriend(friendToRemove);
                                    Console.WriteLine($"Vriend {Friendname2} is verwijderd!");
                                } else {
                                    Console.WriteLine($"Vriend {Friendname2} niet gevonden!");
                                }
                                break;

                            default:
                                Console.WriteLine("Ongeldige keuze");
                                break;

                            case 3:
                                Console.Clear();
                                List<Person> friends = currentUser.GetFriends();
                                Console.WriteLine($"Je hebt {friends.Count} vrienden:");
                                foreach (Person friend in friends) {
                                    Console.WriteLine($"- {friend.Name}:");
                                    foreach (Playlist playlist in friend.GetPlaylists()) {
                                        Console.WriteLine($"- {playlist.Title}");
                                        foreach (Song song in playlist.GetSongs()) {
                                            Console.WriteLine($"    - {song.Title} by {song.Artist}");
                                        }
                                    }
                                }
                                break;

                            case 4:
                                Console.Clear();
                                List<Song> sameSongs = currentUser.GetSameSongs();

                                if (sameSongs.Count == 0) {
                                    Console.WriteLine("Er komen geen nummers overeen met jouw vrienden hun afspeellijst.");
                                } else {
                                    Console.WriteLine("De nummers die overeen komen met de afspeellijst van jouw en je vrienden:");
                                    foreach (Song song in sameSongs) {
                                        Console.WriteLine($"- {song.Title} by {song.Artist}");
                                    }
                                }
                                break;


                            case 5:
                                Console.Clear();
                                break;
                        }
                        break;


                    case 3:
                        Console.Clear();
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("niet mogelijk!!!");
                        break;
                }


            }

        }

    }

}



