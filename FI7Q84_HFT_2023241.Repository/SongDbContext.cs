using FI7Q84_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Repository
{
    public class SongDbContext :DbContext
    {
        public DbSet<Song>  Songs { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Album> Albums { get; set; }

        public SongDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                UseLazyLoadingProxies().UseInMemoryDatabase("SongDataBase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>(entity =>
            {
                entity
                .HasOne(song => song.Author)
                .WithMany(author => author.Songs)
                .HasForeignKey(song => song.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(song => song.Album)
                .WithMany(album => album.Songs)
                .HasForeignKey(song => song.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Author>(entity =>
            {

                entity
                .HasMany(author => author.Songs)
                .WithOne(Song =>Song.Author )
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasMany(author => author.Albums)
                .WithOne(album => album.Author)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity
                .HasMany(album => album.Songs)
                .WithOne(Song => Song.Album)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(album => album.Author)
                .WithMany(Author => Author.Albums)
                .HasForeignKey(album =>album.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            Author eminem = new Author() { Id = 1, Name = "Eminem", Age = 51, Gender = "Male" };
            Author adele = new Author() { Id = 2, Name = "Adele", Age = 33, Gender = "Female" };
            Author kanyeWest = new Author() { Id = 3, Name = "Kanye West", Age = 44, Gender = "Male" };
            Author taylorSwift = new Author() { Id = 4, Name = "Taylor Swift", Age = 32, Gender = "Female" };
            Author drake = new Author() { Id = 5, Name = "Drake", Age = 35, Gender = "Male" };
            Author beyonce = new Author() { Id = 6, Name = "Beyoncé", Age = 40, Gender = "Female" };
            Author edSheeran = new Author() { Id = 7, Name = "Ed Sheeran", Age = 31, Gender = "Male" };

            entered

            Album eminemAlbum = new Album() { Id = 1, Name = "The Eminem Show", ReleaseYear = 2002,
                AmountSold = 27000000, AuthorId=eminem.Id };
            Album adeleAlbum = new Album() { Id = 2, Name = "21", ReleaseYear = 2011, 
                AmountSold = 31000000, AuthorId = adele.Id };
            Album kanyeAlbum = new Album() { Id = 3, Name = "My Beautiful Dark Twisted Fantasy", ReleaseYear = 2010,
                AmountSold = 3500000, AuthorId = kanyeWest.Id };
            Album taylorAlbum = new Album() { Id = 4, Name = "1989", ReleaseYear = 2014,
                AmountSold = 31000000, AuthorId = taylorSwift.Id };
            Album drakeAlbum = new Album() { Id = 5, Name = "Take Care", ReleaseYear = 2011,
                AmountSold = 6000000, AuthorId = drake.Id };
            Album beyonceAlbum = new Album() { Id = 6, Name = "Lemonade", ReleaseYear = 2016,
                AmountSold = 2800000, AuthorId = beyonce.Id };
            Album edSheeranAlbum = new Album() { Id = 7, Name = "÷", ReleaseYear = 2017,
                AmountSold = 15000000, AuthorId = edSheeran.Id };

            Song eminemSong = new Song() { Id = 1, Title = "'Till I Collapse", Genre = "Pop", ReleaseYear = 2002,
                Length = 298,AuthorId=eminem.Id,AlbumId=eminemAlbum.Id };
            Song adeleSong = new Song() { Id = 2, Title = "Rolling in the Deep", Genre = "Soul", ReleaseYear = 2010, Length = 228,
                AuthorId = adele.Id, AlbumId = adeleAlbum.Id };
            Song kanyeSong = new Song() { Id = 3, Title = "Power", Genre = "Hip Hop", ReleaseYear = 2010, Length = 278,
                AuthorId = kanyeWest.Id, AlbumId = kanyeAlbum.Id };
            Song taylorSong = new Song() { Id = 4, Title = "Shake It Off", Genre = "Pop", ReleaseYear = 2014, Length = 219,
                AuthorId = taylorSwift.Id, AlbumId = taylorAlbum.Id };
            Song drakeSong = new Song() { Id = 5, Title = "Hotline Bling", Genre = "R&B", ReleaseYear = 2015, Length = 267,
                AuthorId = drake.Id, AlbumId = drakeAlbum.Id };
            Song beyonceSong = new Song() { Id = 6, Title = "Formation", Genre = "R&B", ReleaseYear = 2016, Length = 232,
                AuthorId = beyonce.Id, AlbumId = beyonceAlbum.Id };
            Song edSheeranSong = new Song() { Id = 7, Title = "Shape of You", Genre = "Pop", ReleaseYear = 2017, Length = 234,
                AuthorId = edSheeran.Id, AlbumId = edSheeranAlbum.Id };

            modelBuilder.Entity<Author>().HasData(eminem, adele,kanyeWest,taylorSwift,drake,beyonce,edSheeran);
            modelBuilder.Entity<Album>().HasData(eminemAlbum,adeleAlbum,kanyeAlbum,taylorAlbum,drakeAlbum,beyonceAlbum,edSheeranAlbum);
            modelBuilder.Entity<Song>().HasData(eminemSong,adeleSong,kanyeSong,taylorSong,drakeSong,beyonceSong,edSheeranSong);


        }
    }
}
