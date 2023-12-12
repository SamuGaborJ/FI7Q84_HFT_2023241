using FI7Q84_HFT_2023241.Models;
using System.Collections.Generic;

namespace FI7Q84_HFT_2023241.Logic
{
    public interface ISongLogic
    {
        void Create(Song song);
        void Delete(int id);
        IEnumerable<Song> EminemSongs();
        Song Read(int id);
        IEnumerable<Song> ReadAll();
        void Update(Song song);
        IEnumerable<Song> YoungAuthorSongs();
        IEnumerable<Song> FemaleAuthorSongs();
        IEnumerable<Song> AlbumReleaseYear2011();
    }
}