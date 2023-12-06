using FI7Q84_HFT_2023241.Logic;
using FI7Q84_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FI7Q84_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IAlbumLogic albumLogic;
        ISongLogic songLogic;
        IAuthorLogic authorLogic;
        public StatController(IAlbumLogic albumLogic, ISongLogic songLogic, IAuthorLogic authorLogic)
        {
            this.albumLogic = albumLogic;
            this.songLogic = songLogic;
            this.authorLogic = authorLogic;
        }

        

        [HttpGet]
        public IEnumerable<Album> Q1()
        {
            return albumLogic.MostSellingAlbum();
        }


        public IEnumerable<Album> Q2()
        {
            return albumLogic.ReleaseYear2002();
        }

        public IEnumerable<Song> Q3()
        {
            return songLogic.EminemSongs();
        }

        public IEnumerable<Author> Q4()
        {
            return authorLogic.MaleAuthors();
        }

        public IEnumerable<Author> Q5()
        {
            return authorLogic.olderThan40();
        }

    }
}
