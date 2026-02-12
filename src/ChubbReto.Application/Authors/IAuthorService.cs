using ChubbReto.Application.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChubbReto.Application.Authors
{
    public interface IAuthorService
    {
        Task<IEnumerable<ListAurthorDto>> ListAuthors();
        Task<IEnumerable<ListAuthorFullDto>> ListAuthorsFull();
        Task<Result<int>> CreateAuthor(CreateAuthorDto dto);
    }
}
