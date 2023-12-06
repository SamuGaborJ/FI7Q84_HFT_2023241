using FI7Q84_HFT_2023241.Models;
using System.Collections.Generic;

namespace FI7Q84_HFT_2023241.Logic
{
    public interface IAlbumLogic
    {
        void Create(Album album);
        void Delete(int id);
        IEnumerable<Album> MostSellingAlbum();
        Album Read(int id);
        IEnumerable<Album> ReadAll();
        IEnumerable<Album> ReleaseYear2002();
        void Update(Album album);
    }
}