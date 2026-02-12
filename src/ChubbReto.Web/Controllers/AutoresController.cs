using ChubbReto.Application.Authors;
using ChubbReto.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChubbReto.Web.Controllers
{
    public class AutoresController : Controller
    {
        private readonly IAuthorService _authorService;

        public AutoresController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _authorService.ListAuthorsFull();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAuthorViewModel model)
        {
            var dto = new CreateAuthorDto()
            {
                NombreCompleto = model.NombreCompleto,
                FechaDeNacimiento = model.FechaDeNacimiento,
                CiudadDeProcedencia = model.CiudadDeProcedencia,
                CorreoElectronico = model.CorreoElectronico
            };

            var result = await _authorService.CreateAuthor(dto);

            if (!result.Success)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error);

                return View(model);
            }

            TempData["SuccessMessage"] = "Autor registrado correctamente.";
            return RedirectToAction("Index");
        }
    }
}