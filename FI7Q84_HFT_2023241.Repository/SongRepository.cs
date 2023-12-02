using FI7Q84_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Repository
{
    public class SongRepository : ISongRepository
    {
        SongDbContext dataBase;
        public SongRepository(SongDbContext dataBase)
        {
            this.dataBase = dataBase;
        }

        public void Create(Song song)
        {
            dataBase.Songs.Add(song);
            dataBase.SaveChanges();
        }

        public Song Read(int id)
        {
            return dataBase.Songs.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Song> ReadAll()
        {
            return dataBase.Songs;
        }

        public void Delete(int id)
        {
            dataBase.Remove(Read(id));
            dataBase.SaveChanges();
        }

        public void Update(Song song)
        {
            var oldSong = Read(song.Id);
            oldSong.Id = song.Id;
            oldSong.Author = song.Author;
            oldSong.Album = song.Album;
            oldSong.AlbumId = song.AlbumId;
            oldSong.AuthorId = song.AuthorId;
            oldSong.Length = song.Length;
            oldSong.Genre = song.Genre;
            oldSong.ReleaseYear = song.ReleaseYear;
            oldSong.Title = song.Title;
            dataBase.SaveChanges();
        }
    }
}
