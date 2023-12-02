using FI7Q84_HFT_2023241.Models;
using FI7Q84_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Logic
{
    public class AlbumLogic
    {
        IAlbumRepository albumRepository;
        public AlbumLogic(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        public void Create(Album album)
        {
            if (album.Name == null)
            {
                throw new NullReferenceException("Wrong albumname!");
            }
            albumRepository.Create(album);
        }

        public Album Read(int id)
        {
            return albumRepository.Read(id);
        }

        public IEnumerable<Album> ReadAll()
        {
            return albumRepository.ReadAll();
        }

        public void Delete(int id)
        {
            albumRepository.Delete(id);
        }

        public void Update(Album album)
        {
            albumRepository.Update(album);
        }
        public IEnumerable<Album> MostSellingAlbum()
        {
            
            var albumWithMostSales = albumRepository.ReadAll().OrderByDescending(album => album.AmountSold).Take(1);
            return albumWithMostSales;
        }
        public IEnumerable<Album> ReleaseYear2002()
        {
            var release2002 = albumRepository.ReadAll().Where(album => album.ReleaseYear == 2002);
            return release2002;
        }
    }
}
