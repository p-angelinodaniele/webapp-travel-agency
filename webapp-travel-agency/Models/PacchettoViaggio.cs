namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Prezzo { get; set; }
        public string Destinazioni { get; set; }
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
