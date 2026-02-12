using ChubbReto.Application.Authors;
using ChubbReto.Application.Books;
using ChubbReto.Application.Genres;
using ChubbReto.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChubbReto.Web.Controllers
{
    public class LibrosController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public LibrosController(IGenreService genreService,
                                IBookService bookService,
                                IAuthorService authorService)
        {
            _genreService = genreService;
            _bookService = bookService;
            _authorService = authorService;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _bookService.ListBooks();
            return View(result);
        }

        public async Task<ActionResult> Create()
        {
            var authors = await _authorService.ListAuthors();
            var genres = await _genreService.ListGenres();

            var model = new CreateBookViewModel
            {
                Authors = authors.Select(a =>
                    new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.FullName
                    }),

                Genres = genres.Select(g =>
                    new SelectListItem
                    {
                        Value = g.Id.ToString(),
                        Text = g.Name
                    })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadCombos(model);
                return View(model);
            }

            var dto = new CreateBookDto()
            {
                Title = model.Title,
                Year = model.Year,
                GenreId = model.GenreId,
                NumberOfPages = model.NumberOfPages,
                AuthorId = model.AuthorId,
            };

            var result = await _bookService.CreateBook(dto);

            if (!result.Success)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error);

                await LoadCombos(model);
                return View(model);
            }

            TempData["SuccessMessage"] = "Libro registrado correctamente.";
            return RedirectToAction("Index");
        }

        private async Task LoadCombos(CreateBookViewModel model)
        {
            var authors = await _authorService.ListAuthors();
            var genres = await _genreService.ListGenres();

            model.Authors = authors.Select(a =>
                new SelectListItem { Value = a.Id.ToString(), Text = a.FullName });

            model.Genres = genres.Select(g =>
                new SelectListItem { Value = g.Id.ToString(), Text = g.Name });
        }
    }
}