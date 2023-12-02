using FI7Q84_HFT_2023241.Models;
using FI7Q84_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI7Q84_HFT_2023241.Logic
{
    public class AuthorLogic
    {
        IAuthorRepository authorRepository;
        public AuthorLogic(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public void Create(Author author)
        {
            if (author.Name == null)
            {
                throw new NullReferenceException("Author doesn't exist");
            }
            authorRepository.Create(author);
        }

        public Author Read(int id)
        {
            return authorRepository.Read(id);
        }

        public IEnumerable<Author> ReadAll()
        {
            return authorRepository.ReadAll();
        }

        public void Delete(int id)
        {
            authorRepository.Delete(id);
        }

        public void Update(Author author)
        {
            authorRepository.Update(author);
        }
        public IEnumerable<Author> olderThan40()
        {

            var olderThan40 = authorRepository.ReadAll().Where(authorAge => authorAge.Age > 40);
            return olderThan40;
        }
        public IEnumerable<Author> MaleAuthors()
        {
            var males = authorRepository.ReadAll().Where(author => author.Gender == "Male");
            return males;
        }
    }
}
