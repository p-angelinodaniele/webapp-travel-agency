using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;


namespace webapp_travel_agency.DataBase
{
    public class AgenziaContext : DbContext
    {
        public DbSet<PacchettoViaggio> PacchettoViaggio { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Agenzia;Integrated Security=True");
        }
    }
}