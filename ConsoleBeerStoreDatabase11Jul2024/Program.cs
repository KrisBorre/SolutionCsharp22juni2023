using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ConsoleBeerStoreDatabase11Jul2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello BeerStore Database!");
            BeerStoreDbContext dbContext = new BeerStoreDbContext();

            FormattableString query2 = $"SELECT * FROM Customers";
            var allCustomers = dbContext.Customers.FromSql(query2).ToList();


            Console.ReadLine();
        }
    }


    internal class BeerStoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=../../../../beerstore9jul2024.db");

        public DbSet<Article> Articles { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Sale>().HasKey(sale => new { sale.ArticleId, sale.CustomerId });


            base.OnModelCreating(modelBuilder);
        }
    }

    internal class Article
    {
        [Key]
        public int Id { get; set; }

        public string ArtikelNummer { get; set; }
        public string Omschrijving { get; set; }
        public double Plato { get; set; }
        public double AlcoholGraad { get; set; }
        public string Eenheid { get; set; }
        public double PrijsInEuroExclusiefTaksen { get; set; }
    }

    internal class Customer
    {
        [Key]
        public int Id { get; set; }

        public string KlantID { get; set; }
        public string Naam { get; set; }
        public string Land { get; set; }
        public string Plaats { get; set; }
        public string Adres { get; set; }
    }

    internal class Sale
    {
        [Key]
        public int Id { get; set; }

        public int ArticleId { get; set; }
        public int CustomerId { get; set; }

        public string Datum { get; set; }
        public DateTime DateTime { get; set; }
        public string Klantennummer { get; set; }
        public string Artikelnummer { get; set; }
        public bool IsLeeggoed { get; set; }
        public string Omschrijving { get; set; }
        public double AantalGeboekt { get; set; }
        public string Basiseenheid { get; set; }
        public double OmzetInEuroNaKorting { get; set; }
        public double TotaleKorting { get; set; }
    }
}
