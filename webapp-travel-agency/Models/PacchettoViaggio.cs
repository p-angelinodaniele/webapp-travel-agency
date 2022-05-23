using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il titolo non può avere più di 20 caratteri")]
        public string Titolo { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        [StringLength(100, ErrorMessage = "La descrizione non può avere più di 100 caratteri")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "l'URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "Mi dispiace l'URL inserito non è valido")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        public double Prezzo { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        public string Destinazioni { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        public string Giorni { get; set; }




        public PacchettoViaggio()
        {

        }
        public PacchettoViaggio(string titolo, string description, string image, double prezzo, string destinazioni, string giorni)
        {
            Titolo = titolo;
            Description = description;
            Image = image;
            Prezzo = prezzo;
            Destinazioni = destinazioni;
            Giorni = giorni;
        }
    }
}
