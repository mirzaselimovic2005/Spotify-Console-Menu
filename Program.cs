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

            // Voeg gebruiker toe
            Person currentUser = new Person("Mirza");

            // Voeg playlist met songs toe
            Playlist newPlaylist1 = new Playlist();
            Playlist newPlaylist2 = new Playlist();
            Playlist newPlaylist3 = new Playlist();

            newPlaylist1.Title = "AFSPEELLIJSTTEST";
            newPlaylist2.Title = "Afspeellijstje 2";
            newPlaylist3.Title = "Afspeellijstje 3";

            Song song1 = new Song("leuk", "Artiest 1", TimeSpan.FromMinutes(3.5), "Pop");
            Song song2 = new Song("testje", "Artiest 2", TimeSpan.FromMinutes(4.0), "Rock");
            Song song3 = new Song("pik", "Artiest 3", TimeSpan.FromMinutes(1.0), "awddwa");
            Song song4 = new Song("liedje4", "Artiest 4", TimeSpan.FromMinutes(4.0), "Roawdck");
            Song song5 = new Song("liedje5", "Artiest 5", TimeSpan.FromMinutes(2.0), "waddaaawdck");
            Song song6 = new Song("liedje6", "Artiest 6", TimeSpan.FromMinutes(3.0), "esfoawdck");

            newPlaylist1.AddSong(song1);
            newPlaylist1.AddSong(song2);
            newPlaylist2.AddSong(song3);
            newPlaylist2.AddSong(song4);
            newPlaylist3.AddSong(song5);
            newPlaylist3.AddSong(song6);

            // voeg playlist aan user toe
            currentUser.AddPlaylist(newPlaylist1);

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

            friend1.AddPlaylist(newPlaylist1);
            friend2.AddPlaylist(newPlaylist2);



            // MAIN WHILE TRUE BEGINT HIER
            while (true)
            {
                Console.WriteLine($"@MIEP1194390");
                Console.WriteLine($"Welkom {currentUser.Name}");
                Console.WriteLine("Wat wil je doen?");
                Console.WriteLine("0. Beheer albums");
                Console.WriteLine("1. Beheer afspeellijsten");
                Console.WriteLine("2. Bekijk vrienden");
                Console.WriteLine("3. Verlaten");

                int keuze = Convert.ToInt32(Console.ReadLine());
                switch (keuze) {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Wat wil je doen met je albums?");
                        Console.WriteLine("1. Bekijk albums");
                        Console.WriteLine("2. Voeg album toe aan afspeellijst");
                        Console.WriteLine("3. Album verwijderen van playlist");
                        Console.WriteLine("4. Album afspelen");
                        Console.WriteLine("5. Shuffle");
                        Console.WriteLine("6. Terug naar hoofdmenu");

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
                                Playlist afspeellijst = currentUser.Playlists.Find(p => p.Title == playlistnaam);
                                if (afspeellijst != null) {
                                    Console.WriteLine("Voer de naam van het album in:");
                                    string albumnaam = Console.ReadLine();
                                    Album album = currentUser.Albums.Find(a => a.Title == albumnaam);
                                    if (album != null) {
                                        afspeellijst.AddAlbum(album);
                                        Console.WriteLine($"{album.Title} is toegevoegd aan {afspeellijst.Title}.");
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
                                Playlist playlist = currentUser.Playlists.Find(p => p.Title == afspeellijstnaam);
                                if (playlist != null) {
                                    Console.WriteLine("Voer de naam van het album in:");
                                    string albumnaam = Console.ReadLine();
                                    Album album = playlist.Albums.Find(a => a.Title == albumnaam);
                                    if (album != null) {
                                        playlist.RemoveAlbum(album);
                                        Console.WriteLine($"{album.Title} is verwijderd van {playlist.Title}.");
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
                                    Console.WriteLine($"Afspeellijst {albumToPlay.Title} wordt afgespeeld...");
                                } else {
                                    Console.WriteLine("Album niet gevonden.");
                                }
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Shuffle albums");
                                List<Album> shuffledAlbums = currentUser.Albums.OrderBy(a => Guid.NewGuid()).ToList();
                                Console.WriteLine("De albums zijn geschud:");
                                foreach (Album album in shuffledAlbums) {
                                    Console.WriteLine(album.Title);
                                }
                                break;
                            case 6:
                                Console.Clear();
                                break;
                        }
                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("Wat wil je doen met je afspeellijsten?");
                        Console.WriteLine("1. Bekijk afspeellijsten");
                        Console.WriteLine("2. Voeg afspeellijst toe");
                        Console.WriteLine("3. Afspeellijst verwijderen");
                        Console.WriteLine("4. Nummer toevoegen aan afspeellijst");
                        Console.WriteLine("5. Nummer uit afspeellijst verwijderen");
                        Console.WriteLine("6. Nummer uit afspeellijst afspelen");
                        Console.WriteLine("7. Shuffle");
                        Console.WriteLine("8. Terug naar hoofdmenu");


                        int afspeellijstkeuze = Convert.ToInt32(Console.ReadLine());

                        switch (afspeellijstkeuze)
                        {
                            case 1:
                                Console.Clear();
                                List<Playlist> playlists = currentUser.GetPlaylists();
                                Console.WriteLine($"Je hebt {playlists.Count} afspeellijsten:");
                                foreach (Playlist Playlist in playlists)
                                {
                                    Console.WriteLine(Playlist.Title);
                                }
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("Voer de naam van de afspeellijst in:");
                                string playlistName = Console.ReadLine();
                                Console.WriteLine($"Afspeellijst '{playlistName}' is toegevoegd.");
                                break;

                            case 3:
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                    for (int i = 0; i < selected.Songs.Count; i++) {
                                        Song song = selected.Songs[i];
                                        Console.WriteLine($"{i + 1}. {song.Title} - {song.Artist}");
                                    }
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


                            case 7:
                                Console.Clear();
                                Console.WriteLine("Van welke afspeellijst wil je de liedjes schufflen?");
                                string selectedPlaylistName2 = Console.ReadLine();
                                List<Playlist> playlists3 = currentUser.GetPlaylists();
                                Playlist selected2 = null;
                                foreach (Playlist playlist3 in playlists3) {
                                    if (playlist3.Title == selectedPlaylistName2) {
                                        selected2 = playlist3;
                                        break;
                                    }
                                }
                                if (selected2 != null) {
                                    selected2.Shuffle();
                                    Console.WriteLine($"Liedjes in afspeellijst '{selectedPlaylistName2}' zijn geshuffled.");
                                }
                                else {
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
                        Console.WriteLine("1. Vriend toevoegen");
                        Console.WriteLine("2. Vriend verwijderen");
                        Console.WriteLine("3. Vrienden bekijken");
                        Console.WriteLine("4. Afspeellijsten vergelijken van vrienden");
                        Console.WriteLine("4. Terug naar hoofdmenu");

                        int keuze2 = int.Parse(Console.ReadLine());

                        switch (keuze2)
                        {
                            case 1:
                                Console.Clear();
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
                                Console.Clear();
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
                                List<Song> matchingSongs = currentUser.GetSameSongs();

                                if (matchingSongs.Count == 0) {
                                    Console.WriteLine("Er komen geen nummers overeen met jouw vrienden hun afspeellijst.");
                                } else {
                                    Console.WriteLine("De nummers die overeen komen met de afspeellijst van jouw en je vrienden:");
                                    foreach (Song song in matchingSongs) {
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
                Console.WriteLine();
            }
        }
    }
}



