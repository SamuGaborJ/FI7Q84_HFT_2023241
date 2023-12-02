using FI7Q84_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        SongDbContext dataBase;
        public AuthorRepository(SongDbContext dataBase)
        {
            this.dataBase = dataBase;
        }

        public void Create(Author author)
        {
            dataBase.Authors.Add(author);
            dataBase.SaveChanges();
        }

        public Author Read(int id)
        {
            return dataBase.Authors.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Author> ReadAll()
        {
            return dataBase.Authors;
        }

        public void Delete(int id)
        {
            dataBase.Remove(Read(id));
            dataBase.SaveChanges();
        }

        public void Update(Author author)
        {
            var oldAuthor = Read(author.Id);

            dataBase.SaveChanges();
        }
    }
}
