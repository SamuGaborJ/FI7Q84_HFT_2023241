using FI7Q84_HFT_2023241.Models;
using FI7Q84_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Logic
{
    public class SongLogic : ISongLogic
    {
        ISongRepository songRepository;
        public SongLogic(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }

        public void Create(Song song)
        {
            if (song.Title == null)
            {
                throw new NullReferenceException("You entered an empty song name!");
            }
            songRepository.Create(song);
        }

        public Song Read(int id)
        {
            return songRepository.Read(id);
        }

        public IEnumerable<Song> ReadAll()
        {
            return songRepository.ReadAll();
        }

        public void Delete(int id)
        {
            songRepository.Delete(id);
        }

        public void Update(Song song)
        {
            songRepository.Update(song);
        }
        public IEnumerable<Song> EminemSongs()
        {
            var eminemSongs = songRepository.ReadAll().Where(song => song.Author.Name == "Eminem");
            return eminemSongs;
        }

        public IEnumerable<Song> YoungAuthorSongs()
        {
            var youngAuthor = songRepository.ReadAll().Where(song => song.Author.Age < 40);
            return youngAuthor;
        }
        public IEnumerable<Song> FemaleAuthorSongs()
        {
            var femaleSong = songRepository.ReadAll().Where(song => song.Author.Gender == "Female");
            return femaleSong;
        }

        public IEnumerable<Song> AlbumReleaseYear2011()
        {
            var albumRelease = songRepository.ReadAll().Where(song => song.Album.ReleaseYear < 2011);
            return albumRelease;
        }

    }
}
