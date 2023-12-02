﻿using FI7Q84_HFT_2023241.Models;
using FI7Q84_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Logic
{
    public class SongLogic
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
        
        

    }
}
