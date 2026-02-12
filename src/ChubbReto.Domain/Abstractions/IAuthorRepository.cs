using ChubbReto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChubbReto.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> Get(int id);
        Task<int> Add(Author author);
        Task<bool> Exists(string fullName);
    }
}