using FI7Q84_HFT_2023241.Models;
using System.Linq;

namespace FI7Q84_HFT_2023241.Repository
{
    public interface IAuthorRepository
    {
        void Create(Author author);
        void Delete(int id);
        Author Read(int id);
        IQueryable<Author> ReadAll();
        void Update(Author author);
    }
}