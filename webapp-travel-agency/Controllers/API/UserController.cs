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
        public IActionResult Get()
        {
            List<PacchettoViaggio> listaPacchetti = new List<PacchettoViaggio>();
            using (AgenziaContext db = new AgenziaContext())
            {
                listaPacchetti = db.PacchettoViaggio.ToList<PacchettoViaggio>();
            }
            return Ok(listaPacchetti);
        }
    }
}
