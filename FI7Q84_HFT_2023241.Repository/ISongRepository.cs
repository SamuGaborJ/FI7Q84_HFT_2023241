using FI7Q84_HFT_2023241.Models;
using System.Linq;

namespace FI7Q84_HFT_2023241.Repository
{
    public interface ISongRepository
    {
        void Create(Song song);
        void Delete(int id);
        Song Read(int id);
        IQueryable<Song> ReadAll();
        void Update(Song song);
    }
}