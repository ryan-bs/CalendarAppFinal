using CalendarAppFinal.Helpers;
using CalendarAppFinal.Interfaces;
using CalendarAppFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CalendarAppFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDAL _idal;

        public HomeController(IDAL idal)
        {
            _idal = idal;
        }

        public IActionResult Index()
        {
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_idal.GetEtiquetas());
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_idal.GetEventos());
            return View();
        }

        [Authorize]
        public IActionResult MyCalendar()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_idal.GetEtiquetas());
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_idal.GetMeusEventos(userid));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ViewResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}
