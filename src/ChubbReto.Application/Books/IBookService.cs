using ChubbReto.Application.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChubbReto.Application.Books
{
    public interface IBookService
    {
        Task<IEnumerable<ListBookFullDto>> ListBooks();
        Task<Result<int>> CreateBook(CreateBookDto dto);
    }
}
