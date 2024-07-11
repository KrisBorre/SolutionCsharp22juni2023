using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace ConsoleBeerStore9Jul2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Beer Store!");

            List<Article> articles0 = new List<Article>();

            string file1 = Path.Combine(@"..\..\..\", "beers.txt");
            using (StreamReader textReader1 = new StreamReader(file1))
            {
                int number_of_rows = 0;
                string line1;

                while ((line1 = textReader1.ReadLine()) != null)
                {
                    number_of_rows++;
                    //Console.WriteLine("number_of_rows= " + number_of_rows);
                    if (number_of_rows == 1)
                    {
                        Console.WriteLine(line1);
                    }
                    else
                    {
                        string[] articleProperties = SplitRespectingQuotes(line1);
                        Article article = new Article();
                        article.ArtikelNummer = articleProperties[0];
                        article.Omschrijving = articleProperties[1];
                        string plato = articleProperties[2];
                        if (!string.IsNullOrEmpty(plato))
                        {
                            article.Plato = double.Parse(plato, CultureInfo.GetCultureInfo("en-US"));
                        }
                        string alcoholGraad = articleProperties[3];
                        if (!string.IsNullOrEmpty(alcoholGraad))
                        {
                            article.AlcoholGraad = double.Parse(alcoholGraad, CultureInfo.GetCultureInfo("en-US"));
                        }
                        article.Eenheid = articleProperties[4];
                        article.PrijsInEuroExclusiefTaksen = double.Parse(articleProperties[5], CultureInfo.GetCultureInfo("en-US"));
                        articles0.Add(article);
                    }

                }
            }

            Console.WriteLine("Successfully read the entire file with articles.");

            List<Customer> customers0 = new List<Customer>();

            string file2 = Path.Combine(@"..\..\..\", "customers.txt");
            using (StreamReader textReader2 = new StreamReader(file2))
            {
                string line2;
                int number_of_rows = 0;

                while ((line2 = textReader2.ReadLine()) != null)
                {
                    number_of_rows++;
                    //Console.WriteLine("number_of_rows= " + number_of_rows);
                    if (number_of_rows == 1)
                    {
                        Console.WriteLine(line2);
                    }
                    else
                    {
                        string[] customerProperties = SplitRespectingQuotes(line2);
                        Customer customer = new Customer();
                        customer.KlantID = customerProperties[0];
                        customer.Naam = customerProperties[1];
                        customer.Land = customerProperties[2];
                        customer.Plaats = customerProperties[3];
                        customer.Adres = customerProperties[4];
                        customers0.Add(customer);
                    }
                }
            }

            Console.WriteLine("Successfully read the entire file with customers.");

            BeerStoreDbContext dbContext = new BeerStoreDbContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.Articles.AddRange(articles0);
            dbContext.Customers.AddRange(customers0);
            dbContext.SaveChanges();


            List<Article> articles1 = dbContext.Articles.ToList();
            List<Customer> customers1 = dbContext.Customers.ToList();

            List<Sale> sales0 = new List<Sale>();

            string file3 = Path.Combine(@"..\..\..\", "orders.txt");
            using (StreamReader textReader3 = new StreamReader(file3))
            {
                int number_of_rows = 0;
                string line3;

                while ((line3 = textReader3.ReadLine()) != null)
                {
                    number_of_rows++;
                    //Console.WriteLine("number_of_rows= " + number_of_rows);
                    if (number_of_rows == 1)
                    {
                        Console.WriteLine(line3);
                    }
                    else
                    {
                        string[] saleProperties = SplitRespectingQuotes(line3);
                        Sale sale = new Sale();

                        sale.Datum = saleProperties[0];
                        sale.DateTime = DateTime.ParseExact(saleProperties[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        string klantennummer = saleProperties[1];
                        sale.Klantennummer = klantennummer;
                        string artikelnummer = saleProperties[2];
                        sale.Artikelnummer = artikelnummer;

                        sale.IsLeeggoed = bool.Parse(saleProperties[3]);
                        string omschrijving = saleProperties[4];
                        sale.Omschrijving = omschrijving;
                        string aantalGeboekt = saleProperties[5];
                        if (!string.IsNullOrEmpty(aantalGeboekt))
                        {
                            sale.AantalGeboekt = double.Parse(aantalGeboekt, CultureInfo.GetCultureInfo("en-US"));
                        }
                        sale.Basiseenheid = saleProperties[6];
                        string omzetInEuroNaKorting = saleProperties[7];
                        if (!string.IsNullOrEmpty(omzetInEuroNaKorting))
                        {
                            sale.OmzetInEuroNaKorting = double.Parse(omzetInEuroNaKorting, CultureInfo.GetCultureInfo("en-US"));
                        }
                        string totaleKorting = saleProperties[8];
                        if (!string.IsNullOrEmpty(totaleKorting))
                        {
                            sale.TotaleKorting = double.Parse(totaleKorting, CultureInfo.GetCultureInfo("en-US"));
                        }

                        Article article = articles1.FirstOrDefault(a => (a.ArtikelNummer == artikelnummer));
                        if (article == null)
                        {
                            article = articles1.FirstOrDefault(a => (a.Omschrijving == omschrijving));
                            if (article != null)
                            {
                                //Console.WriteLine("Het article wordt gevonden door middel van omschrijving: " + line3);
                                //Console.WriteLine("Dus het articlenummer in de sale tabel is verkeerd.");
                                //Console.WriteLine();

                                // 2016-05-15,102109,1008206,false,Nogne Porter,1,KEYKEG,69.47,0
                                // 2016-05-15,102109,1008207,false,Nogne India Pale Ale,1,KEYKEG,70.76,0
                                // 2016-05-15,102109,1008209,false,Nogne Imperial Stout,1,KEYKEG,74.28,0
                                // 2016-05-15,102109,1008211,false,Nogne Imperial Rye Porter,1,KEYKEG,76.66,0
                                // 2016-05-15,102109,1008215,false,Nogne Sunturnbrew,1,KEYKEG,83.69,0
                                // 2016-05-15,102109,1008216,false,Nogne God Jul,1,KEYKEG,72.23,0
                                // 2017-03-15,102572,1008207,false,Nogne India Pale Ale,1,KEYKEG,78.77,0
                                // 2017-07-15,102524,1008682,false,BBNo 14|03-Tripel-Ella,1,KEYKEG,97.11,10.79
                                // 2017-04-15,101671,1008206,false,Nogne Porter,1,KEYKEG,77.26,0
                                // 2017-04-15,101671,1008207,false,Nogne India Pale Ale,1,KEYKEG,78.77,0
                                // 2017-04-15,101671,1008211,false,Nogne Imperial Rye Porter,1,KEYKEG,85.99,0
                            }
                        }
                        Customer customer = customers1.First(c => (c.KlantID == klantennummer));
                        if (customer == null)
                        {
                            Console.WriteLine("De klant wordt niet gevonden: " + line3);
                            Console.WriteLine();
                        }

                        if (article == null)
                        {
                            if (!sale.IsLeeggoed)
                            {
                                //Console.WriteLine("Het artikel wordt niet gevonden: " + line3);
                                //Console.WriteLine();
                            }
                        }
                        else
                        {
                            sale.ArticleId = article.Id;
                            // Alle klanten worden gevonden.
                            sale.CustomerId = customer.Id;

                            sales0.Add(sale);
                        }
                    }

                }
            }

            Console.WriteLine("Successfully read the entire file with sales.");

            dbContext.Sales.AddRange(sales0);
            dbContext.SaveChanges();

            List<Sale> sales1 = dbContext.Sales.ToList();
            double revenue = 0;
            for (int i = 0; i < sales1.Count; i++)
            {
                Sale sale = sales1[i];
                revenue += sale.OmzetInEuroNaKorting;
            }
            Console.WriteLine("Totale omzet is " + revenue); // 5009564,6

            Console.ReadLine();

        }


        public static string[] SplitRespectingQuotes(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string[0]; // Empty array for empty string
            }

            List<string> parts = new List<string>();
            bool inQuotes = false;
            StringBuilder currentPart = new StringBuilder();

            foreach (char c in text)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ',' && !inQuotes)
                {
                    parts.Add(currentPart.ToString());
                    currentPart.Clear();
                }
                else
                {
                    currentPart.Append(c);
                }
            }

            parts.Add(currentPart.ToString());
            return parts.ToArray();
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

        public string ArtikelNummer;
        public string Omschrijving;
        public double Plato;
        public double AlcoholGraad;
        public string Eenheid;
        public double PrijsInEuroExclusiefTaksen;
    }

    internal class Customer
    {
        [Key]
        public int Id { get; set; }

        public string KlantID;
        public string Naam;
        public string Land;
        public string Plaats;
        public string Adres;
    }

    internal class Sale
    {
        [Key]
        public int Id { get; set; }

        public int ArticleId;
        public int CustomerId;

        public string Datum;
        public DateTime DateTime;
        public string Klantennummer;
        public string Artikelnummer;
        public bool IsLeeggoed;
        public string Omschrijving;
        public double AantalGeboekt;
        public string Basiseenheid;
        public double OmzetInEuroNaKorting;
        public double TotaleKorting;
    }
}
