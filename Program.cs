using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    class Program
    {
        static void Main(string[] args)
        {
            Person currentUser = new Person("UserTestje");
            // while loop die altijd vraagt wat de user wilt doen
            while (true)
            {
                Console.WriteLine($"Welkom {currentUser.Name}");
                Console.WriteLine("Wat wil je doen?");
                Console.WriteLine("1. Beheer afspeellijsten");
                Console.WriteLine("2. Bekijk vrienden");
                Console.WriteLine("3. Verlaten");

                int keuze = Convert.ToInt32(Console.ReadLine());
                // switch case om de keuze te bepalen
                switch (keuze)
                {
                    case 1:
                        Console.WriteLine("Wat wil je doen met je afspeellijsten?");
                        Console.WriteLine("1. Bekijk afspeellijsten");
                        Console.WriteLine("2. Voeg afspeellijst toe");
                        Console.WriteLine("3. Afspeellijst verwijderen");
                        Console.WriteLine("4. Nummer toevoegen aan afspeellijst");
                        Console.WriteLine("5. Nummer uit afspeellijst verwijderen");
                        Console.WriteLine("6. Nummer uit afspeellijst afspelen");

                        int afspeellijstkeuze = Convert.ToInt32(Console.ReadLine());

                        switch (afspeellijstkeuze)
                        {
                            case 1:
                                List<Playlist> playlists = currentUser.GetPlaylists();
                                Console.WriteLine($"Je hebt {playlists.Count} afspeellijsten:");
                                foreach (Playlist Playlist in playlists)
                                {
                                    Console.WriteLine(Playlist.Title);
                                }
                                break;

                            case 2:
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string playlistName = Console.ReadLine();
                                Playlist newPlaylist = new Playlist();
                                newPlaylist.Title = playlistName;
                                currentUser.AddPlaylist(newPlaylist);
                                Console.WriteLine($"Afspeellijst '{playlistName}' is toegevoegd.");
                                break;

                            case 3:
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string playlistToRemove = Console.ReadLine();
                                List<Playlist> userPlaylists = currentUser.GetPlaylists();
                                Playlist playlist = userPlaylists.FirstOrDefault(p => p.Title == playlistToRemove);
                                if (playlist != null)
                                {
                                    currentUser.RemovePlaylist(playlist);
                                    Console.WriteLine($"Afspeellijst '{playlistToRemove}' is verwijderd.");
                                }
                                else
                                {
                                    Console.WriteLine($"Afspeellijst '{playlistToRemove}' is niet gevonden");
                                }
                                break;

                            case 4:
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
                                Playlist selectedPlaylist = userPlaylists2.FirstOrDefault(p => p.Title == playlistToAddTo);
                                if (selectedPlaylist != null)
                                {
                                    currentUser.AddSongToPlaylist(newSong, selectedPlaylist);
                                    Console.WriteLine($"Nummer '{songTitle}' is toegevoegd aan afspeellijst '{playlistToAddTo}'");
                                }
                                else
                                {
                                    Console.WriteLine($"Afspeellijst '{playlistToAddTo}' niet gevonden.");
                                }
                                break;

                            case 5:
                                Console.WriteLine("Voer de titel van het nummer in:");
                                string songTitle2 = Console.ReadLine();
                                Console.WriteLine("Voer artiest in:");
                                string songArtist2 = Console.ReadLine();
                                Console.WriteLine("Voer de duur van het nummer in mm:ss:");
                                string songDurationString2 = Console.ReadLine();
                                TimeSpan songDuration2 = TimeSpan.ParseExact(songDurationString2, "mm:ss", null);
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string playlistToRemoveFrom = Console.ReadLine();
                                List<Playlist> userPlaylists3 = currentUser.GetPlaylists();
                                Playlist selectedPlaylist2 = userPlaylists3.FirstOrDefault(p => p.Title == playlistToRemoveFrom);
                                if (selectedPlaylist2 != null)
                                {
                                    Song songToRemove = selectedPlaylist2.Songs.FirstOrDefault(s => s.Title == songTitle2 && s.Artist == songArtist2 && s.Duration == songDuration2);
                                    if (songToRemove != null)
                                    {
                                        currentUser.RemoveSongFromPlaylist(songToRemove, selectedPlaylist2);
                                        Console.WriteLine($"Nummer '{songTitle2}' is verwijderd uit afspeellijst '{playlistToRemoveFrom}'.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nummer '{songTitle2}' is niet gevonden in afspeellijst '{playlistToRemoveFrom}'.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Afspeellijst '{playlistToRemoveFrom}' niet gevonden.");
                                }
                                break;

                            case 6:
                                Console.WriteLine("Van welke afspeellijst wil je een liedje afspelen?");
                                string selectedPlaylistName = Console.ReadLine();
                                List<Playlist> playlists2 = currentUser.GetPlaylists();
                                Playlist selected = null;
                                foreach (Playlist playlist2 in playlists2)
                                {
                                    if (playlist2.Title == selectedPlaylistName)
                                    {
                                        selected = playlist2;
                                        break;
                                    }
                                }
                                if (selected != null)
                                {
                                    Console.WriteLine($"Welk nummer wil je afspelen? (1-{selected.Songs.Count})");
                                    int songNumber = Convert.ToInt32(Console.ReadLine());
                                    if (songNumber >= 1 && songNumber <= selected.Songs.Count)
                                    {
                                        Song selectedSong = selected.Songs[songNumber - 1];
                                        Console.WriteLine($"'{selectedSong.Title}' word afgespeeld!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("niet mogelijk!!!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Afspeellijst '{selectedPlaylistName}' is niet gevonden.");
                                }
                                break;

                            default:
                                Console.WriteLine("NIET MOGELIJKK!!");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("1. Vriend toevoegen");
                        Console.WriteLine("2. Vriend verwijderen");
                        Console.WriteLine("3. Vrienden bekijken");


                        int keuze2 = int.Parse(Console.ReadLine());

                        switch (keuze2)
                        {
                            case 1:
                                Console.WriteLine("Voer de naam van de vriend in:");
                                string friendName = Console.ReadLine();
                                Person newFriend = new Person(friendName);

                                if (newFriend != null)
                                {
                                    currentUser.AddFriend(newFriend);
                                    Console.WriteLine($"Vriend {friendName} is toevoegd!");

                                } else
                                {
                                    Console.WriteLine($"Vriend {friendName} niet gevonden!");
                                }
                                break;

                            case 2:
                                Console.WriteLine("Voer de naam van de vriend in:");
                                string Friendname2 = Console.ReadLine();
                                var friendToRemove = currentUser.GetFriends().FirstOrDefault(x => x.Name == Friendname2);
                                if (friendToRemove != null)
                                {
                                    currentUser.RemoveFriend(friendToRemove);
                                    Console.WriteLine($"Vriend {Friendname2} is verwijderd!");
                                }
                                else
                                {
                                    Console.WriteLine($"Vriend {Friendname2} niet gevonden!");
                                }
                                break;

                            default:
                                Console.WriteLine("Ongeldige keuze");
                                break;

                            case 3:
                                List<Person> friends = currentUser.GetFriends();
                                Console.WriteLine($"You have {friends.Count} friends:");
                                foreach (Person friend in friends)
                                {
                                    Console.WriteLine(friend.Name);
                                }
                                break;
                        }
                        break;


                    case 3:
                        Console.WriteLine("jo");
                        return;

                    default:
                        Console.WriteLine("niet mogelijk!!!");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}



