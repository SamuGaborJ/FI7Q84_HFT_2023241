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
    public class AuthorController : Controller
    {
        IAuthorLogic authorLogic;
        
        public AuthorController(IAuthorLogic authorLogic)
        {
            this.authorLogic = authorLogic;
            
        }
        // GET: /author
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return authorLogic.ReadAll();
        }

        // GET /author/id
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return authorLogic.Read(id);
        }

        // POST /author
        [HttpPost]
        public void Post([FromBody] Author value)
        {
            authorLogic.Create(value);
            
        }

        // PUT /author
        [HttpPut]
        public void Put([FromBody] Author value)
        {
            authorLogic.Update(value);
            
        }

        // DELETE /author/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var authorToDelete = authorLogic.Read(id);
            authorLogic.Delete(id);
           
        }
    }
}
