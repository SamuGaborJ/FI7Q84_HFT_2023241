using FI7Q84_HFT_2023241.Models;
using System.Collections.Generic;

namespace FI7Q84_HFT_2023241.Logic
{
    public interface IAuthorLogic
    {
        void Create(Author author);
        void Delete(int id);
        IEnumerable<Author> MaleAuthors();
        IEnumerable<Author> olderThan40();
        Author Read(int id);
        IEnumerable<Author> ReadAll();
        void Update(Author author);
    }
}