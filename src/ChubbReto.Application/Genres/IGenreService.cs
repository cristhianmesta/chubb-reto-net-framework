using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChubbReto.Application.Genres
{
    public interface IGenreService
    {
        Task<IEnumerable<ListGenreDto>> ListGenres();
    }
}
