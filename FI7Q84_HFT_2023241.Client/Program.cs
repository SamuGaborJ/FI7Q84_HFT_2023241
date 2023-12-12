using ConsoleTools;
using FI7Q84_HFT_2023241.Models;
using System;
using System.Linq;

namespace FI7Q84_HFT_2023241.Client
{
    public class Program
    {
        static RestService rs = new RestService("http://localhost:21049");
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            var subSongMenu = new ConsoleMenu(args, level: 1)
                .Add("Adding new song", () => AddNewSong())
                .Add("Song List", () => ReadAllSongs())
                .Add("Read Song By ID", () => GetSongByID())
                .Add("Update Song By ID", () => ModifySongByID())
                .Add("Delete Song By ID", () => DeleteSong())
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.EnableWriteTitle = true;
                    config.Title = "Song Menu";
                });
           

            var subAuthorMenu = new ConsoleMenu(args, level: 1)
                .Add("Adding New Author", () => AddNewAuthor())
                .Add("Author List", () => ReadAllAuthors())
                .Add("Read Author By ID", () => GetAuthorByID())
                .Add("Update Author By ID", () => ModifyAuthorByID())
                .Add("Delete Author By ID", () => DeleteAuthor())
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.EnableWriteTitle = true;
                    config.Title = "Author Menu";
                });
           

            var subAlbumMenu = new ConsoleMenu(args, level: 1)
                .Add("Adding New Album", () => AddNewAlbum())
                .Add("Album List", () => ReadAllAlbums())
                .Add("Read Album By ID", () => GetAlbumByID())
                .Add("Update Album By ID", () => ModifyAlbumByID())
                .Add("Delete Album By ID", () => DeleteAlbum())
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.EnableWriteTitle = true;
                    config.Title = "Album Menu";
                });

            var subNonCrudMenu = new ConsoleMenu(args, level: 1)
                .Add("Eminem songs: ", () => EminemSongs())
                .Add("Authors older than 40: ", () => olderThan40())
                .Add("Male authors: ", () => MaleAuthors())
                .Add("Album that was released in 2002: ", () => ReleaseYear2002())
                .Add("Most selling album: ", () => MostSellingAlbum())//
                .Add("Old Authors Songs: ", () => OldAuthorsAlbum())
                .Add("Male Authors album: ", () => MaleAuthorsAlbum())
                .Add("Young author songs: ", () => YoungAuthorSongs())
                .Add("Female author songs: ", () => FemaleAuthorSongs())
                .Add("Album released 2000: ", () => AlbumReleaseYear2011())


                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.EnableWriteTitle = true;
                    config.Title = "Non-crud menu";
                });

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Song Data ", subSongMenu.Show)
                .Add("Album Data ", subAlbumMenu.Show)
                .Add("Author Data", subAuthorMenu.Show)
                .Add("Queries ", subNonCrudMenu.Show)
                .Add("Exit", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.EnableWriteTitle = true;
                    config.Title = "Song Database Menu";
                });

            menu.Show();
        }


        #region
        private static void AddNewSong()
        {

            Song newSong = new Song();
            Console.WriteLine("New Song Title:");
            string title = Console.ReadLine();
            Console.WriteLine("New Song Release Year:");
            int releaseYear = int.Parse(Console.ReadLine());
            Console.WriteLine("New Song Genre:");
            string genre=Console.ReadLine();
            Console.WriteLine("New Song Length:");
            int length=int.Parse(Console.ReadLine());
            newSong.Title = title;
            newSong.ReleaseYear = releaseYear;
            newSong.Genre = genre;
            newSong.Length = length;
            rs.Post<Song>(newSong, "song");
            Console.WriteLine($"{title} added! \n Press Enter to Continue! ");
            Console.ReadKey();

        }
        private static void ReadAllSongs()
        {
            Console.WriteLine("Song Data:");
            rs.Get<Song>("song")
                .ForEach(s => Console.WriteLine($"[{s.Id}] Song title: {s.Title} Song Release Year: {s.ReleaseYear} Song Genre: {s.Genre}"));
            Console.WriteLine("Press Enter To Continue!");
            Console.ReadLine();
        }

        private static void GetSongByID()
        {

            Console.Write("Please enter an ID: ");
            string id = Console.ReadLine();
            Song song = rs.GetSingle<Song>($"song/{id}");
            
            if (song != null)
            {
                Console.WriteLine($"{song.Title}:");
                Console.WriteLine($"[{song.Id}] Book Title: {song.Title} Book Release Year: {song.ReleaseYear}");
                Console.WriteLine("Press Enter to Continue!");
                
            }
            
            Console.ReadLine();
        }

        private static void ModifySongByID()
        {
            Console.Write("Please enter an ID: ");

            string id = Console.ReadLine();

            Song song = rs.GetSingle<Song>($"song/{id}");

            if (song != null)
            {
                Console.WriteLine($"Updating {song.Title}!");
                Console.WriteLine($"{song.Title}'s new Title: ");
                string newTitle = Console.ReadLine();
                Console.Write($"{song.Title}'s Release Year: ");
                int newReleaseYear = int.Parse(Console.ReadLine());
                Console.Write($"{song.Title}'s Genre: ");
                string newGenre = Console.ReadLine();
                Console.Write($"{song.Title}'s Length: ");
                int newLength = int.Parse(Console.ReadLine());
                song.Title = newTitle;
                song.ReleaseYear = newReleaseYear;
                song.Genre = newGenre;
                song.Length = newLength;
                rs.Put<Song>(song, "song");
                Console.WriteLine($"Done Updating!");
                Console.WriteLine("Press Enter to Continue");

            }
            Console.ReadLine();
        }
        private static void DeleteSong()
        {
            Console.Write("Please enter an ID: ");
            int id = int.Parse(Console.ReadLine());

            string name = "";
            Song song = rs.GetSingle<Song>($"song/{id}");

            if (song != null)
            {
                name = song.Title;
                rs.Delete(id, $"song");
                Console.WriteLine($"{song.Title} deleted!");
                Console.WriteLine("Press Enter to Continue!");
            }
            Console.ReadLine();
        }
        #endregion
        #region
        private static void AddNewAuthor()
        {

            Author newAuthor = new Author();
            Console.WriteLine("New Author Name:");
            string name = Console.ReadLine();
            Console.WriteLine("New Author Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("New Author Gender:");
            string gender = Console.ReadLine();
            newAuthor.Name = name;
            newAuthor.Gender = gender;
            newAuthor.Age = age;
            rs.Post<Author>(newAuthor, "author");
            Console.WriteLine($"{name} added! \n Press Enter to Continue! ");
            Console.ReadKey();

        }
        private static void ReadAllAuthors()
        {
            Console.WriteLine("Author Data:");
            rs.Get<Author>("author")
                .ForEach(a => Console.WriteLine($"[{a.Id}] Author Name: {a.Name} Author Gender: {a.Gender} Author Age: {a.Age}"));
            Console.WriteLine("Press Enter To Continue!");
            Console.ReadLine();
        }

        private static void GetAuthorByID()
        {

            Console.Write("Please enter an ID: ");
            string id = Console.ReadLine();
            Author author = rs.GetSingle<Author>($"author/{id}");

            if (author != null)
            {
                Console.WriteLine($"{author.Name}:");
                Console.WriteLine($"[{author.Id}] Author Name: {author.Name} Author Gender: {author.Gender} Author Age: {author.Age}");
                Console.WriteLine("Press Enter to Continue!");

            }

            Console.ReadLine();
        }

        private static void ModifyAuthorByID()
        {
            Console.Write("Please enter an ID: ");

            string id = Console.ReadLine();

            Author author = rs.GetSingle<Author>($"author/{id}");

            if (author != null)
            {
                Console.WriteLine($"Updating {author.Name}!");
                Console.WriteLine($"{author.Name}'s new Name: ");
                string newName = Console.ReadLine();
                Console.Write($"{author.Name}'Age: ");
                int newAge = int.Parse(Console.ReadLine());
                Console.Write($"{author.Name}'s Gender: ");
                string newGender = Console.ReadLine();
                author.Name = newName;
                author.Age = newAge;
                author.Gender = newGender;
                rs.Put<Author>(author, "author");
                Console.WriteLine($"Done Updating!");
                Console.WriteLine("Press Enter to Continue");

            }
            Console.ReadLine();
        }
        private static void DeleteAuthor()
        {
            Console.Write("Please enter an ID: ");
            int id = int.Parse(Console.ReadLine());

            string name = "";
            Author author = rs.GetSingle<Author>($"author/{id}");

            if (author != null)
            {
                name = author.Name;
                rs.Delete(id, $"author");
                Console.WriteLine($"{author.Name} deleted!");
                Console.WriteLine("Press Enter to Continue!");
            }
            Console.ReadLine();
        }
        #endregion
        #region
        private static void AddNewAlbum()
        {

            Album newAlbum = new Album();
            Console.WriteLine("New Album Name:");
            string name = Console.ReadLine();
            Console.WriteLine("New Album Amount Sold:");
            int amountSond = int.Parse(Console.ReadLine());
            Console.WriteLine("New Album Release Year:");
            int releaseYear = int.Parse(Console.ReadLine());
            newAlbum.Name = name;
            newAlbum.AmountSold = amountSond;
            newAlbum.ReleaseYear = releaseYear;
            rs.Post<Album>(newAlbum, "album");
            Console.WriteLine($"{name} added! \n Press Enter to Continue! ");
            Console.ReadKey();

        }
        private static void ReadAllAlbums()
        {
            Console.WriteLine("Album Data:");
            rs.Get<Album>("album")
                .ForEach(a => Console.WriteLine($"[{a.Id}] Album Name: {a.Name} Album Amount Sold: {a.AmountSold} Album Release Year: {a.ReleaseYear}"));
            Console.WriteLine("Press Enter To Continue!");
            Console.ReadLine();
        }

        private static void GetAlbumByID()
        {

            Console.Write("Please enter an ID: ");
            string id = Console.ReadLine();
            Album album = rs.GetSingle<Album>($"album/{id}");

            if (album != null)
            {
                Console.WriteLine($"{album.Name}:");
                Console.WriteLine($"[{album.Id}] Album Name: {album.Name} Album Amount Sold: {album.AmountSold} Album Release Year: {album.ReleaseYear}");
                Console.WriteLine("Press Enter to Continue!");

            }

            Console.ReadLine();
        }

        private static void ModifyAlbumByID()
        {
            Console.Write("Please enter an ID: ");

            string id = Console.ReadLine();

            Album album = rs.GetSingle<Album>($"album/{id}");

            if (album != null)
            {
                Console.WriteLine($"Updating {album.Name}!");
                Console.WriteLine($"{album.Name}'s new Name: ");
                string newName = Console.ReadLine();
                Console.Write($"{album.Name}'s Release Year: ");
                int newReleaseYear = int.Parse(Console.ReadLine());
                Console.Write($"{album.Name}'s Amount Sold: ");
                int newAmountSold = int.Parse(Console.ReadLine());
                album.Name = newName;
                album.ReleaseYear = newReleaseYear;
                album.AmountSold = newAmountSold;
                rs.Put<Album>(album, "album");
                Console.WriteLine($"Done Updating!");
                Console.WriteLine("Press Enter to Continue");

            }
            Console.ReadLine();
        }
        private static void DeleteAlbum()
        {
            Console.Write("Please enter an ID: ");
            int id = int.Parse(Console.ReadLine());

            string name = "";
            Album album = rs.GetSingle<Album>($"album/{id}");

            if (album != null)
            {
                name = album.Name;
                rs.Delete(id, $"album");
                Console.WriteLine($"{album.Name} deleted!");
                Console.WriteLine("Press Enter to Continue!");
            }
            Console.ReadLine();
        }
        #endregion

        private static void EminemSongs()
        {
            Console.WriteLine("Songs by Eminem: ");
            rs.Get<Song>("stat/q3").ToList()
                .ForEach(e => Console.WriteLine($"[{e.Id}] Title: {e.Title}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }
        private static void MostSellingAlbum()
        {
            Console.WriteLine("Most selling albums: ");
            rs.Get<Album>("stat/q1").ToList()
                .ForEach(a => Console.WriteLine($"[{a.Id}] Title: {a.Name}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }
        private static void ReleaseYear2002()
        {
            Console.WriteLine("Album that was released in 2002: ");
            rs.Get<Album>("stat/q2").ToList()
                .ForEach(r => Console.WriteLine($"[{r.Id}] Title: {r.Name}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }
        private static void MaleAuthors()
        {
            Console.WriteLine("Male authors: ");
            rs.Get<Author>("stat/q4").ToList()
                .ForEach(m => Console.WriteLine($"[{m.Id}] Title: {m.Name}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }
        
            private static void olderThan40()
        {
            Console.WriteLine("Authors older than 40: ");
            rs.Get<Author>("stat/q5").ToList()
                .ForEach(f => Console.WriteLine($"[{f.Id}] Title: {f.Name}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }

        private static void OldAuthorsAlbum()
        {
            Console.WriteLine("Old authors album: ");
            rs.Get<Author>("stat/q6").ToList()
                .ForEach(m => Console.WriteLine($"[{m.Id}] Title: {m.Name}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }
        private static void MaleAuthorsAlbum()
        {
            Console.WriteLine("Male authors albums: ");
            rs.Get<Author>("stat/q7").ToList()
                .ForEach(m => Console.WriteLine($"[{m.Id}] Title: {m.Name}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }

        private static void YoungAuthorSongs()
        {
            Console.WriteLine("Young authors Songs: ");
            rs.Get<Song>("stat/q8").ToList()
                .ForEach(m => Console.WriteLine($"[{m.Id}] Title: {m.Title}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }

        private static void FemaleAuthorSongs()
        {
            Console.WriteLine("Female authors Songs: ");
            rs.Get<Song>("stat/q9").ToList()
                .ForEach(m => Console.WriteLine($"[{m.Id}] Title: {m.Title}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }
        
            private static void AlbumReleaseYear2011()
        {
            Console.WriteLine("Album release year 2011: ");
            rs.Get<Song>("stat/q10").ToList()
                .ForEach(m => Console.WriteLine($"[{m.Id}] Title: {m.Title}"));
            Console.Write("Press Enter To Continue");
            Console.ReadLine();
        }
    }
}
