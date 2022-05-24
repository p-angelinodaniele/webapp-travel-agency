using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Messaggio
    {
       
        [Key]
        public int MessaggioId { get; set; }

        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il titolo non può avere più di 20 caratteri")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Il campo cognome è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il titolo non può avere più di 20 caratteri")]
        public string cognome { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        [StringLength(500, ErrorMessage = "La descrizione non può avere più di 500 caratteri")]
        public string messaggio { get; set; }

        [Required(ErrorMessage = "Il campo email è obbligatorio")]
        [EmailAddress]
        public string email { get; set; }

       
        public int PacchettoViaggioId { get; set; }
        public PacchettoViaggio PacchettoViaggio { get; set; }


        public Messaggio()
        {
            
        }

        public Messaggio(string nome, string cognome, string messaggio, string email, int pacchettoViaggioId)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.messaggio = messaggio;
            this.email = email;
            PacchettoViaggioId = pacchettoViaggioId;
            
        }
    }
}
