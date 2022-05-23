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


        [HttpGet]
        public IActionResult Create()
        {
            return View("CreazionePacchetto");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PacchettoViaggio nuovoPacchetto)
        {
            if (!ModelState.IsValid)
            {
                return View("CreazionePacchetto", nuovoPacchetto);
            }

            using (AgenziaContext db = new AgenziaContext())
            {
                PacchettoViaggio pacchettoDaCreare = new PacchettoViaggio(nuovoPacchetto.Titolo, nuovoPacchetto.Description, nuovoPacchetto.Image, nuovoPacchetto.Prezzo, nuovoPacchetto.Destinazioni, nuovoPacchetto.Giorni);
                db.PacchettoViaggio.Add(pacchettoDaCreare);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            PacchettoViaggio pacchettoDaModificare = null;
            using (AgenziaContext db = new AgenziaContext())
            {
                pacchettoDaModificare = db.PacchettoViaggio
                    .Where (pacchetto => pacchetto.Id == id)
                    .FirstOrDefault();
            }

            if(pacchettoDaModificare != null)
            {
                return View("Update", pacchettoDaModificare);
            }
            else
            {
                return NotFound("Il pacchetto viaggi con id " + id + " non è stato trovato");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PacchettoViaggio model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);  
            }
            PacchettoViaggio pacchettoDaModificare = null;

            using (AgenziaContext db = new AgenziaContext())
            {
                pacchettoDaModificare = db.PacchettoViaggio
                    .Where(pacchetto => pacchetto.Id == id)
                    .FirstOrDefault();

                if(pacchettoDaModificare != null)
                {
                    pacchettoDaModificare.Titolo = model.Titolo;
                    pacchettoDaModificare.Description = model.Description;
                    pacchettoDaModificare.Image = model.Image;
                    pacchettoDaModificare.Prezzo = model.Prezzo;
                    pacchettoDaModificare.Destinazioni = model.Destinazioni;
                    pacchettoDaModificare.Giorni = model.Giorni;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound();  
                }


            }


        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (AgenziaContext db = new AgenziaContext())
            {
                PacchettoViaggio pacchettoDaEliminare = db.PacchettoViaggio
                    .Where(pacchetto => pacchetto.Id == id)
                    .FirstOrDefault();

                if (pacchettoDaEliminare != null)
                {
                    db.PacchettoViaggio.Remove(pacchettoDaEliminare);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound();
                }

            }
        }


    }
}