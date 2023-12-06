using FI7Q84_HFT_2023241.Logic;
using FI7Q84_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace FI7Q84_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : Controller
    {
        IAlbumLogic albumLogic;
        
        public AlbumController(IAlbumLogic albumLogic)
        {
            this.albumLogic = albumLogic;
            
        }
        // GET: /album
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return albumLogic.ReadAll();
        }

        // GET /album/id
        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return albumLogic.Read(id);
        }

        // POST /album
        [HttpPost]
        public void Post([FromBody] Album value)
        {
            albumLogic.Create(value);
            
        }

        // PUT /album
        [HttpPut]
        public void Put([FromBody] Album value)
        {
            albumLogic.Update(value);
            
        }

        // DELETE /album/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var albumToDelete = albumLogic.Read(id);
            albumLogic.Delete(id);
            
        }
    }
}
