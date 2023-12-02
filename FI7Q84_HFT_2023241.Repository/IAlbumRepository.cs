using FI7Q84_HFT_2023241.Models;
using System.Linq;

namespace FI7Q84_HFT_2023241.Repository
{
    public interface IAlbumRepository
    {
        void Create(Album album);
        void Delete(int id);
        Album Read(int id);
        IQueryable<Album> ReadAll();
        void Update(Album album);
    }
}