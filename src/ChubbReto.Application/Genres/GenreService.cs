using ChubbReto.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChubbReto.Application.Genres
{
    public class GenreService : IGenreService
    {

        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<ListGenreDto>> ListGenres()
        {
            var genres = await _genreRepository.GetAll();

            return genres.Select(x => new ListGenreDto
            {
                Id = x.GenreId,
                Name = x.Name,
            });
        }
    }
}
