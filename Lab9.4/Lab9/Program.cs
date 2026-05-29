using System;
using System.Collections;

namespace CDCatalogApp
{
    class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"\"{Title}\" - {Artist}";
        }
    }

    class Program
    {
        static Hashtable catalog = new Hashtable();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("MUSIC CD CATALOG");
                Console.WriteLine("1. Add a new CD");
                Console.WriteLine("2. Remove a CD");
                Console.WriteLine("3. Add a song to a CD");
                Console.WriteLine("4. Remove a song from a CD");
                Console.WriteLine("5. View the entire catalog");
                Console.WriteLine("6. View the contents of a specific CD");
                Console.WriteLine("7. Search for all songs by an artist");
                Console.WriteLine("0. Exit the program");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Select an action (0-7): ");

                string choice = Console.ReadLine();

                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter a name for the new disk: ");
                        string newCdName = Console.ReadLine();
                        AddCD(newCdName);
                        break;

                    case "2":
                        Console.Write("Enter the name of the CD to remove: ");
                        string cdToRemove = Console.ReadLine();
                        RemoveCD(cdToRemove);
                        break;

                    case "3":
                        Console.Write("Enter the name of the CD to add a song to: ");
                        string cdForSong = Console.ReadLine();
                        Console.Write("Enter the title of the song: ");
                        string songTitle = Console.ReadLine();
                        Console.Write("Enter the name of the artist: ");
                        string songArtist = Console.ReadLine();
                        AddSong(cdForSong, songTitle, songArtist);
                        break;

                    case "4":
                        Console.Write("Enter the name of the CD to remove a song from: ");
                        string cdForDelSong = Console.ReadLine();
                        Console.Write("Enter the title of the song to remove: ");
                        string songToDel = Console.ReadLine();
                        RemoveSong(cdForDelSong, songToDel);
                        break;

                    case "5":
                        ViewCatalog();
                        break;

                    case "6":
                        Console.Write("Enter the name of the CD to view: ");
                        string cdToView = Console.ReadLine();
                        Console.WriteLine($"\n💿 Contents of the CD '{cdToView}':");
                        ViewCD(cdToView);
                        break;

                    case "7":
                        Console.Write("Enter the name of the artist to search for: ");
                        string artistToSearch = Console.ReadLine();
                        SearchByArtist(artistToSearch);
                        break;

                    case "0":
                        isRunning = false;
                        Console.WriteLine("The program has ended.");
                        break;

                    default:
                        Console.WriteLine("[!] Invalid choice. Please enter a number from 0 to 7.");
                        break;
                }
            }
        }

        static void AddCD(string cdName)
        {
            if (string.IsNullOrWhiteSpace(cdName))
            {
                Console.WriteLine("[!] The CD name cannot be empty.");
                return;
            }

            if (!catalog.ContainsKey(cdName))
            {
                catalog.Add(cdName, new ArrayList());
                Console.WriteLine($"[+] The CD '{cdName}' has been successfully added.");
            }
            else
            {
                Console.WriteLine($"[!] The CD '{cdName}' already exists.");
            }
        }

        static void RemoveCD(string cdName)
        {
            if (catalog.ContainsKey(cdName))
            {
                catalog.Remove(cdName);
                Console.WriteLine($"[-] The CD '{cdName}' has been removed from the catalog.");
            }
            else
            {
                Console.WriteLine($"[!] The CD '{cdName}' was not found.");
            }
        }

        static void AddSong(string cdName, string songTitle, string artist)
        {
            if (string.IsNullOrWhiteSpace(songTitle) || string.IsNullOrWhiteSpace(artist))
            {
                Console.WriteLine("[!] The song title and artist name cannot be empty.");
                return;
            }

            if (catalog.ContainsKey(cdName))
            {
                ArrayList songs = (ArrayList)catalog[cdName];
                songs.Add(new Song(songTitle, artist));
                Console.WriteLine($"[+] The song '{songTitle}' has been added to the CD '{cdName}'.");
            }
            else
            {
                Console.WriteLine($"[!] The CD '{cdName}' was not found. Please create it first.");
            }
        }

        static void RemoveSong(string cdName, string songTitle)
        {
            if (catalog.ContainsKey(cdName))
            {
                ArrayList songs = (ArrayList)catalog[cdName];
                Song songToRemove = null;

                foreach (Song song in songs)
                {
                    if (song.Title.Equals(songTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        songToRemove = song;
                        break;
                    }
                }

                if (songToRemove != null)
                {
                    songs.Remove(songToRemove);
                    Console.WriteLine($"[-] The song '{songToRemove.Title}' has been removed from the CD '{cdName}'.");
                }
                else
                {
                    Console.WriteLine($"[!] The song '{songTitle}' was not found on the CD '{cdName}'.");
                }
            }
            else
            {
                Console.WriteLine($"[!] The CD '{cdName}' was not found.");
            }
        }

        static void ViewCatalog()
        {
            if (catalog.Count == 0)
            {
                Console.WriteLine("The catalog is currently empty.");
                return;
            }

            foreach (DictionaryEntry entry in catalog)
            {
                string cdName = (string)entry.Key;
                Console.WriteLine($"\n💿 CD: {cdName}");
                ViewCD(cdName);
            }
        }

        static void ViewCD(string cdName)
        {
            if (catalog.ContainsKey(cdName))
            {
                ArrayList songs = (ArrayList)catalog[cdName];
                if (songs.Count == 0)
                {
                    Console.WriteLine("   (the CD is empty)");
                }
                else
                {
                    foreach (Song song in songs)
                    {
                        Console.WriteLine($"   🎵 {song}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"[!] The CD '{cdName}' was not found.");
            }
        }

        static void SearchByArtist(string targetArtist)
        {
            if (string.IsNullOrWhiteSpace(targetArtist)) return;

            bool foundAny = false;

            foreach (DictionaryEntry entry in catalog)
            {
                string cdName = (string)entry.Key;
                ArrayList songs = (ArrayList)entry.Value;

                foreach (Song song in songs)
                {
                    if (song.Artist.Equals(targetArtist, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Found on CD '{cdName}': {song}");
                        foundAny = true;
                    }
                }
            }

            if (!foundAny)
            {
                Console.WriteLine($"No songs by the artist '{targetArtist}' were found in the catalog.");
            }
        }
    }
}