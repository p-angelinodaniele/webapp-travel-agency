using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp_travel_agency.DataBase;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<PacchettoViaggio> PacchettiViaggi = new List<PacchettoViaggio>();
            using (AgenziaContext db = new AgenziaContext())
            {
                PacchettiViaggi = db.PacchettoViaggio.ToList<PacchettoViaggio>();
            }
            return View("Index", PacchettiViaggi);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            using (AgenziaContext db = new AgenziaContext())
            {
                try
                {

                
                    PacchettoViaggio pacchettoFound = db.PacchettoViaggio
                        .Where(pacchettoViaggio => pacchettoViaggio.Id == id)
                        .First();
                    return View("Details", pacchettoFound);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Il pacchetto con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

            }    
        }
    }
}