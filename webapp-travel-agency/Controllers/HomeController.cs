using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp_travel_agency.DataBase;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<PacchettoViaggio> PacchettiViaggi = new List<PacchettoViaggio>();
            using (AgenziaContext db = new AgenziaContext())
            {
                PacchettiViaggi = db.PacchettoViaggio.ToList<PacchettoViaggio>();
            }
            return View();
        }
    }
}