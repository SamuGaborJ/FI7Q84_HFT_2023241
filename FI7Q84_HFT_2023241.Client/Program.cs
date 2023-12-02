using FI7Q84_HFT_2023241.Repository;
using System;
using System.Linq;

namespace FI7Q84_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SongDbContext dataBase = new SongDbContext();

            var albums = dataBase.Albums.ToArray();

            SongRepository songRepository = new SongRepository(dataBase);

            var elsoSong = songRepository.Read(1);
            
        }
    }
}
