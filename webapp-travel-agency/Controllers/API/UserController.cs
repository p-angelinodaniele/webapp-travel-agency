using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.DataBase;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            List<PacchettoViaggio> listaPacchetti = new List<PacchettoViaggio>();
            using (AgenziaContext db = new AgenziaContext())
            {
                if(search != null && search != "")
                {
                    listaPacchetti = db.PacchettoViaggio.Where(listaPacchetti => listaPacchetti.Titolo.Contains(search) || listaPacchetti.Description.Contains(search)).ToList<PacchettoViaggio>();
                }
                else
                {
                    listaPacchetti = db.PacchettoViaggio.ToList<PacchettoViaggio>();
                }
            }

            return Ok(listaPacchetti);
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
                    return Ok(pacchettoFound);
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


        [HttpPost]
        public IActionResult MoreInfo([FromBody] Messaggio messaggio)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            using (AgenziaContext db = new AgenziaContext())
            {
                messaggio = new Messaggio(messaggio.nome, messaggio.cognome, messaggio.email, messaggio.messaggio, messaggio.PacchettoViaggioId);
                
                db.Messaggio.Add(messaggio);
                db.SaveChanges();
            }
            return Ok(messaggio);

        }


    }
}
