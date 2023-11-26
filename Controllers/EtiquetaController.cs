using Microsoft.AspNetCore.Mvc;
using CalendarAppFinal.Models;
using CalendarAppFinal.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CalendarAppFinal.Controllers
{
    [Authorize]
    public class EtiquetaController : Controller
    {
        private readonly IDAL _dal;
        private readonly UserManager<User> _usermanager;

        public EtiquetaController(IDAL idal, UserManager<User> userManager)
        {
            _dal = idal;
            _usermanager = userManager;
        }


        // GET: Etiqueta
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
                ViewData["Alert"] = TempData["Alert"];

            return View(_dal.GetEtiquetas());
        }

        // GET: Etiqueta/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var etiqueta = _dal.GetEtiqueta((int)id);

            if (etiqueta == null)
                return NotFound();

            return View(etiqueta);
        }

        // GET: Etiqueta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etiqueta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Etiqueta etiqueta)
        {
            try
            {
                _dal.CreateEtiqueta(etiqueta);
                TempData["Alert"] = "Parbéns! Você criou uma etiqueta para: " + etiqueta.Nome;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "Um erro ocorreu: " + ex.Message;
                return View(etiqueta);
            }
        }
    }
}
