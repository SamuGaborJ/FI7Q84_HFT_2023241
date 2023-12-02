using FI7Q84_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        SongDbContext dataBase;
        public AlbumRepository(SongDbContext dataBase)
        {
            this.dataBase = dataBase;
        }

        public void Create(Album album)
        {
            dataBase.Albums.Add(album);
            dataBase.SaveChanges();
        }

        public Album Read(int id)
        {
            return dataBase.Albums.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Album> ReadAll()
        {
            return dataBase.Albums;
        }

        public void Delete(int id)
        {
            dataBase.Remove(Read(id));
            dataBase.SaveChanges();
        }

        public void Update(Album album)
        {
            var oldAlbum = Read(album.Id);
            oldAlbum.Author = album.Author;
            oldAlbum.AuthorId = album.AuthorId;
            oldAlbum.AmountSold = album.AmountSold;
            oldAlbum.Id = album.Id;
            oldAlbum.ReleaseYear = album.ReleaseYear;
            oldAlbum.Name = album.Name;
            oldAlbum.Songs = album.Songs;
            dataBase.SaveChanges();
        }
    }
}
