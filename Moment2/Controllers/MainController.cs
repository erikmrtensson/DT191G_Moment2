using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Moment2.Models;
using System.Reflection;
using System.Text.Json;

namespace Moment2.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Start()
        {
            // Hämta sessionsdata
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.SessionSavedProgram = HttpContext.Session.GetString("UserProgram");

            if (!string.IsNullOrEmpty(userName))
            {
                ViewBag.SessionSavedName = userName;
            }
            else
            {
                ViewBag.SessionSavedName = null;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Submit(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Alla fält måste fyllas i!";
                return View("Start");
            }

            // Spara data i ViewBag, ViewData och skicka via model
            ViewBag.Message = "Personen har sparats!";
            ViewData["UserName"] = model.UserName;
            ViewData["Age"] = model.Age;
            ViewBag.SavedEmail = model.Email;
            ViewBag.SavedYear = model.Year;
            ViewBag.SavedProgram = model.Program;

            // Spara i session
            HttpContext.Session.SetString("UserName", model.UserName);
            HttpContext.Session.SetString("UserEmail", model.Email);
            HttpContext.Session.SetInt32("UserAge", (int)model.Age);
            HttpContext.Session.SetString("UserYear", model.Year);
            HttpContext.Session.SetString("UserProgram", model.Program);

            return View("Result", model);
        }

        public IActionResult CurrentSessionData()
        {
            // Hämta sessionsdata
            var userName = HttpContext.Session.GetString("UserName") ?? "Inget";
            var email = HttpContext.Session.GetString("UserEmail") ?? "Inget";
            var age = HttpContext.Session.GetInt32("UserAge") ?? 0;
            var year = HttpContext.Session.GetString("UserYear") ?? "Ej valt";
            var program = HttpContext.Session.GetString("UserProgram") ?? "Ej valt";

            // Beräkna ut användarens ålder
            int birthYear = DateTime.Now.Year - age;

            ViewBag.SessionSavedName = userName;
            ViewBag.SessionSavedEmail = email;
            ViewData["SessionSavedAge"] = age;
            ViewBag.SessionSavedYear = year;
            ViewBag.SessionSavedProgram = program;
            ViewData["BirthYear"] = birthYear; 

            return View();
        }

        [Route("main/routechange")]
        public IActionResult Random()
        {
            ViewBag.SessionSavedProgram = HttpContext.Session.GetString("UserProgram");
            ViewBag.SessionSavedName = HttpContext.Session.GetString("UserName");
            ViewBag.CurrentRoute = "route1";
            return View();
        }

        [Route("random")] 
        public IActionResult RandomAlternative()
        {
            ViewBag.SessionSavedProgram = HttpContext.Session.GetString("UserProgram");
            ViewBag.SessionSavedName = HttpContext.Session.GetString("UserName");
            ViewBag.CurrentRoute = "route2";
            return View("Random");
        }
    }
}
