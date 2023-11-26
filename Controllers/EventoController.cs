using Microsoft.AspNetCore.Mvc;
using CalendarAppFinal.Interfaces;
using System.Security.Claims;
using CalendarAppFinal.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using CalendarAppFinal.Models;
using Microsoft.AspNetCore.Authorization;
using CalendarAppFinal.Controllers.ActionFilters;

namespace CalendarAppFinal.Controllers
{
    [Authorize]
    public class EventoController : Controller
    {
        private readonly IDAL _dal;
        private readonly UserManager<User> _usermanager;

        public EventoController(IDAL dal, UserManager<User> usermanager)
        {
            _dal = dal;
            _usermanager = usermanager;
        }

        // GET: Evento
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }

            return View(_dal.GetMeusEventos(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        // GET: Evento/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var evento = _dal.GetEvento((int)id);

            if (evento == null)
                return NotFound();

            return View(evento);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            return View(new EventoViewModel(_dal.GetEtiquetas(), User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventoViewModel vm, IFormCollection form)
        {
            try
            {
                _dal.CreateEvento(form);
                TempData["Alert"] = "Parabéns! Você criou um novo evento para: " + form["Evento.Nome"];
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "Um erro ocorreu: " + ex.Message;
                return View(vm);
            }
        }

        // GET: Evento/Edit/5
        [UserAcessOnly]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var evento = _dal.GetEvento((int)id);

            if (evento == null)
                return NotFound();

            var vm = new EventoViewModel(evento, _dal.GetEtiquetas(), User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(vm);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            try
            {
                _dal.UpdateEvento(form);
                TempData["Alert"] = "Parabéns! Você modificou um evento para: " + form["Evento.Nome"];
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "Um erro ocorreu: " + ex.Message;
                var vm = new EventoViewModel(_dal.GetEvento(id), _dal.GetEtiquetas(), User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(vm);
            }
        }

        // GET: Evento/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = _dal.GetEvento((int) id);

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _dal.DeleteEvento(id);
            TempData["Alert"] = "Você deletou um evento.";
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
          return (_dal.GetEventos().Any(e => e.Id == id));
        }
    }
}
