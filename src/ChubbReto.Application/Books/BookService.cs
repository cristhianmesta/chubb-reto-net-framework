using ChubbReto.Application.Shared;
using ChubbReto.Domain.Entities;
using ChubbReto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace ChubbReto.Application.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly int _maxBooksPerAuthor;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, BookSettings settings)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _maxBooksPerAuthor = settings.MaxBooksPerAuthor;
        }

        public async Task<IEnumerable<ListBookFullDto>> ListBooks()
        {
            var books = await _bookRepository.GetAll();

            return books.Select(x => new ListBookFullDto
            {
                BookId = x.BookId,
                Title = x.Title,
                Year = x.Year,
                Genre = x.Genre?.Name,
                NumberOfPages = x.NumberOfPages,
                Author = x.Author.FullName
            });
        }

        public async Task<Result<int>> CreateBook(CreateBookDto dto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Title.Trim()))
                errors.Add("El Título es requerido.");

            var currentYear = DateTime.Now.Year;

            if (dto.Year <= 0)
                errors.Add("El año es requerido.");
            else if (dto.Year < 1000 || dto.Year > currentYear)
                errors.Add($"El año debe estar entre 1000 y {currentYear}.");

            if (dto.AuthorId <= 0)
                errors.Add("Debe seleccionar un autor.");

            var author = await _authorRepository.Get(dto.AuthorId);
            if (author == null)
                errors.Add("El autor no está registrado.");
            else
            {
                var count = await _bookRepository.CountByAuthor(dto.AuthorId);
                if (count >= _maxBooksPerAuthor)
                {
                    errors.Add($"No es posible registrar el libro, se alcanzó el máximo permitido.");
                }
            }

            if (dto.NumberOfPages.HasValue && dto.NumberOfPages <= 0)
                errors.Add("El número de páginas debe ser mayor que 0.");

            if (errors.Any())
                return Result<int>.Fail(errors);

            try
            {

                var newBook = new Book
                {
                    Title = dto.Title.Trim(),
                    Year = dto.Year,
                    GenreId = dto.GenreId,
                    NumberOfPages = dto.NumberOfPages,
                    AuthorId = dto.AuthorId,
                };

                var id = await _bookRepository.Add(newBook);

                return Result<int>.Ok(id, "Autor creado correctamente");
            }
            catch (Exception ex)
            {
                // Aqui podríamos escribir en logs
                return Result<int>.Fail("Ocurrió un error al guardar el autor.");
            }

        }
    }
}
