using FI7Q84_HFT_2023241.Logic;
using FI7Q84_HFT_2023241.Models;
using FI7Q84_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        private static SongLogic songLogic;
        private static AuthorLogic authorLogic;
        private static AlbumLogic albumLogic;

        private static List<Song> songList;
        private static List<Author> authorList;
        private static List<Album> albumList;

        private static Mock<ISongRepository> songMoq;
        private static Mock<IAuthorRepository> authorMoq;
        private static Mock<IAlbumRepository> albumMoq;

        [SetUp]
        public static void TestSetUp()
        {
            songMoq = new Mock<ISongRepository>();
            authorMoq = new Mock<IAuthorRepository>();
            albumMoq = new Mock<IAlbumRepository>();

            authorList = new List<Author>
            {
                new Author() { Id = 1, Name = "Eminem", Age = 51, Gender = "Male" },
                new Author() { Id = 2, Name = "Adele", Age = 33, Gender = "Female" },
                new Author() { Id = 3, Name = "Kanye West", Age = 44, Gender = "Male" },
                new Author() { Id = 4, Name = "Taylor Swift", Age = 32, Gender = "Female" },
                new Author() { Id = 5, Name = "Drake", Age = 35, Gender = "Male" },
                new Author() { Id = 6, Name = "Beyoncé", Age = 40, Gender = "Female" },
                new Author() { Id = 7, Name = "Ed Sheeran", Age = 31, Gender = "Male" }
            };

            albumList = new List<Album>
            {
                new Album() { Id = 1, Name = "The Eminem Show", ReleaseYear = 2002,
                AmountSold = 27000000, AuthorId=authorList[0].Id },
                new Album() { Id = 2, Name = "21", ReleaseYear = 2011,
                AmountSold = 31000000, AuthorId = authorList[1].Id },
                new Album() { Id = 3, Name = "My Beautiful Dark Twisted Fantasy", ReleaseYear = 2010,
                AmountSold = 3500000, AuthorId = authorList[2].Id },
                new Album() { Id = 4, Name = "1989", ReleaseYear = 2014,
                AmountSold = 31000000, AuthorId = authorList[3].Id },
                new Album() { Id = 5, Name = "Take Care", ReleaseYear = 2011,
                AmountSold = 6000000, AuthorId = authorList[4].Id },
                new Album() { Id = 6, Name = "Lemonade", ReleaseYear = 2016,
                AmountSold = 2800000, AuthorId = authorList[5].Id },
                new Album() { Id = 7, Name = "÷", ReleaseYear = 2017,
                AmountSold = 15000000, AuthorId = authorList[6].Id }
            };

            songList = new List<Song> {
                new Song() { Id = 1, Title = "'Till I Collapse", Genre = "Pop", ReleaseYear = 2002,
                Length = 298,AuthorId=authorList[0].Id,AlbumId=albumList[0].Id },
                new Song() { Id = 2, Title = "Rolling in the Deep", Genre = "Soul", ReleaseYear = 2010, Length = 228,
                AuthorId = authorList[1].Id, AlbumId = albumList[1].Id },
                new Song() { Id = 3, Title = "Power", Genre = "Hip Hop", ReleaseYear = 2010, Length = 278,
                AuthorId = authorList[2].Id, AlbumId = albumList[2].Id },
                new Song() { Id = 4, Title = "Shake It Off", Genre = "Pop", ReleaseYear = 2014, Length = 219,
                AuthorId = authorList[3].Id, AlbumId = albumList[3].Id },
                new Song() { Id = 5, Title = "Hotline Bling", Genre = "R&B", ReleaseYear = 2015, Length = 267,
                AuthorId = authorList[4].Id, AlbumId = albumList[4].Id },
                new Song() { Id = 6, Title = "Formation", Genre = "R&B", ReleaseYear = 2016, Length = 232,
                AuthorId = authorList[5].Id, AlbumId = albumList[5].Id },
                new Song() { Id = 7, Title = "Shape of You", Genre = "Pop", ReleaseYear = 2017, Length = 234,
                AuthorId = authorList[6].Id, AlbumId = albumList[6].Id }

            };

            songMoq.Setup(x => x.ReadAll()).Returns(songList.AsQueryable());
            authorMoq.Setup(x => x.ReadAll()).Returns(authorList.AsQueryable());
            albumMoq.Setup(x => x.ReadAll()).Returns(albumList.AsQueryable());

            songLogic = new SongLogic(songMoq.Object);
            authorLogic = new AuthorLogic(authorMoq.Object);
            albumLogic = new AlbumLogic(albumMoq.Object);
        }

        [Test]
        public static void TestReadingAllSongs()
        {
            List<Song> songs = songList;

            var result = songLogic.ReadAll();

            Assert.That(result, Is.EquivalentTo(songs));
        }
        [Test]
        public static void TestReadingAllAuthors()
        {
            List<Author> authors = authorList;

            var result = authorLogic.ReadAll();

            Assert.That(result, Is.EquivalentTo(authors));
        }
        [Test]
        public static void TestReadingAllAlbums()
        {
            List<Album> albums = albumList;

            var result = albumLogic.ReadAll();

            Assert.That(result, Is.EquivalentTo(albums));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public static void TestReadingOneSong(int id)
        {
            songMoq.Setup(repo => repo.Read(id)).Returns(songList[id]);

            var result = songLogic.Read(id);

            Assert.That(result, Is.EqualTo(songList[id]));
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public static void TestReadingOneAuthor(int id)
        {
            authorMoq.Setup(repo => repo.Read(id)).Returns(authorList[id]);

            var result = authorLogic.Read(id);

            Assert.That(result, Is.EqualTo(authorList[id]));
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public static void TestReadingOneAlbum(int id)
        {
            albumMoq.Setup(repo => repo.Read(id)).Returns(albumList[id]);

            var result = albumLogic.Read(id);

            Assert.That(result, Is.EqualTo(albumList[id]));
        }

        [Test]
        public static void TestAddingSong()
        {
            Song song = new Song { Id = 8, Title = "Hollywood", ReleaseYear = 2010 };
            songMoq.Setup(repo => repo.Create(song));

            songLogic.Create(song);
            songMoq.Verify(repo => repo.Create(song));
        }
        [Test]
        public static void TestAddingAuthor()
        {
            Author author = new Author { Id = 8, Name = "Marina", Gender = "female" };
            authorMoq.Setup(repo => repo.Create(author));

            authorLogic.Create(author);
            authorMoq.Verify(repo => repo.Create(author));
        }
        [Test]
        public static void TestAddingAlbum()
        {
            Album album = new Album { Id = 8, Name = "The Family Jewels", ReleaseYear = 2010 };
            albumMoq.Setup(repo => repo.Create(album));

            albumLogic.Create(album);
            albumMoq.Verify(repo => repo.Create(album));
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public static void TestUpdatingSong(int id)
        {
            Song song = new Song { Id = id, Title = "To Be Human", ReleaseYear = 2018 };
            songMoq.Setup(repo => repo.Update(song));

            songLogic.Update(song);
            songMoq.Verify(repo => repo.Update(song));
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public static void TestUpdatingAuthor(int id)
        {
            Author author = new Author { Id = id, Name = "Marina", Gender = "female"};
            authorMoq.Setup(repo => repo.Update(author));

            authorLogic.Update(author);
            authorMoq.Verify(repo => repo.Update(author));
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public static void TestUpdatingAlbum(int id)
        {
            Album album = new Album { Id = id, Name = "The Family Jewel", ReleaseYear = 2013 };
            albumMoq.Setup(repo => repo.Update(album));

            albumLogic.Update(album);
            albumMoq.Verify(repo => repo.Update(album));
        }
    }

    
}
