using ChubbReto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChubbReto.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<int> Add(Book book);
        Task<int> CountByAuthor(int authorId);
    }
}
