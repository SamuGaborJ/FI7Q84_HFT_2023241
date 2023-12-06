using FI7Q84_HFT_2023241.Logic;
using FI7Q84_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FI7Q84_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ISongLogic songLogic;
        
        public SongController(ISongLogic songLogic)
        {
            this.songLogic = songLogic;
           
        }
        // GET: /song
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return songLogic.ReadAll();
        }

        // GET /song/id
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return songLogic.Read(id);
        }

        // POST /song
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            songLogic.Create(value);
            
        }

        // PUT /song
        [HttpPut]
        public void Put([FromBody] Song value)
        {
            songLogic.Update(value);
            
        }

        // DELETE /song/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var songToDelete = songLogic.Read(id);
            songLogic.Delete(id);
            
        }
    }
}
