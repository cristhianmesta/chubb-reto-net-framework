using ChubbReto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChubbReto.Domain.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAll();
    }
}
