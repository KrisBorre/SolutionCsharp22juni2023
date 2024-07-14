using System.Data.SQLite;

namespace ConsoleBeerStoreSqlConnection12Jul2024
{
    internal class Program
    {
        static string connectionString = $"Data Source=../../../../beerstore9jul2024.db";

        static void ExecuteQuery(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    SQLiteDataReader reader = command.ExecuteReader();

                    int columnCount = reader.FieldCount;
                    Console.WriteLine("The number of columns: " + columnCount);

                    // Print column names as a header
                    for (int i = 0; i < columnCount; i++)
                    {
                        Console.Write(reader.GetName(i) + "\t"); // Tab separation between column names
                    }
                    Console.WriteLine(); // New line after header

                    // Read and print data from each row
                    while (reader.Read())
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            // Get the data type of the current column
                            var dataType = reader.GetFieldType(i);

                            switch (dataType)
                            {
                                case Type t when t == typeof(string):
                                    Console.Write(reader.GetString(i) + "\t");
                                    break;
                                case Type t when t == typeof(int):
                                    Console.Write(reader.GetInt32(i) + "\t");
                                    break;
                                case Type t when t == typeof(double):
                                    // Access double value and consider formatting if needed
                                    double value1 = reader.GetDouble(i);
                                    Console.Write(value1.ToString("F") + "\t"); // Format as fixed-point with one decimal place
                                    break;
                                case Type t when t == typeof(bool):
                                    // Access boolean value
                                    bool value2 = reader.GetBoolean(i);
                                    Console.Write(value2.ToString() + "\t"); // Print "true" or "false"
                                    break;
                                case Type t when t == typeof(DateTime):
                                    // Access DateTime value and consider formatting if needed
                                    DateTime value3 = reader.GetDateTime(i);
                                    Console.Write(value3.ToString("yyyy-MM-dd HH:mm:ss") + "\t"); // Format as YYYY-MM-DD HH:MM:SS
                                    break;
                                default:
                                    Console.Write(reader.GetValue(i) + "\t"); // Handle unknown types generically
                                    break;
                            }
                        }
                        Console.WriteLine(); // New line after each row
                    }

                    reader.Close();
                }
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Beerstore SQLite SQLiteConnection!");

            //string query1 = "SELECT * FROM Customers";
            //ExecuteQuery(query1);

            //string query2 = "SELECT Naam FROM Customers ORDER BY Naam;";
            //ExecuteQuery(query2);

            //string query3 = "SELECT Naam FROM Customers ORDER BY Naam DESC;";
            //ExecuteQuery(query3);

            //string query4 = "SELECT Naam, Land FROM Customers ORDER BY Land ASC;";
            //ExecuteQuery(query4);
            /*
            Naam    Land
            Jason Pugh      Australi?
            BSBP BVBA       Belgi?
            Hexagon Europe BVBA     Belgi?
            Intertracon     Belgi?
            Topace Europe   Belgi?
            Huang Trading bvba      Belgi?
            White Pony Pub  Belgi?
            Den Troetsel    Belgi?
            Den Arend       Belgi?
            */

            //string query5 = "SELECT DISTINCT Land FROM Customers;";
            //ExecuteQuery(query5);

            //string query6 = "SELECT * FROM Customers WHERE naam LIKE 'M%';";
            //ExecuteQuery(query6);
            /*
            Id      KlantID Naam    Land    Plaats  Adres
            20      100585  Multi Bier Asten BV     Nederland       Helmond Varenschut, 25
            23      101343  Multidrink S.R.L.(Multibirra)   Itali?
            43      101973  Made in Belgium Itali?  Lentate Sul Seveso
            */

            //string query7 = "SELECT * FROM customers WHERE naam LIKE '_e%';";
            //ExecuteQuery(query7);
            /*
            Id      KlantID Naam    Land    Plaats  Adres
            5       101992  WENZHOU WIN-WIN INTERNATIONAL TRADE CO., LTD    China   Wenzhou
            8       100017  Den-Belgiske-Olmand     Denemarken
            10      100039  Henk Smit       Nederland
            16      100220  Belgisk Bryg I/S        Denemarken
            */

            //string query8 = "SELECT * FROM customers WHERE land IN ('Denemarken', 'Nederland');";
            //ExecuteQuery(query8);
            /*
            Id      KlantID Naam    Land    Plaats  Adres
            1       100219  Bier en Co Amsterdam BV Nederland
            2       100452  B&S Global Food Purchase B.V.   Nederland       Dordrecht       Rijksstraatweg, 7
            4       101989  Prima Beer ApS  Denemarken      Hobro
            8       100017  Den-Belgiske-Olmand     Denemarken
            10      100039  Henk Smit       Nederland
            11      100041  Soren Claus Knudsen     Denemarken      Helsinge
            */

            //string query9 = "SELECT * FROM customers WHERE land IN ('denemarken', 'nederland');";
            //ExecuteQuery(query9);
            /*
            The number of columns: 6
            Id      KlantID Naam    Land    Plaats  Adres
            End of program. Press enter.
            */

            //string query10 = "SELECT COUNT(*) FROM customers WHERE land IN ('Denemarken', 'Nederland');";
            //ExecuteQuery(query10);
            /*
            The number of columns: 1
            COUNT(*)
            30
            */

            //string query11 = "SELECT COUNT(DISTINCT land) FROM customers WHERE land IN ('Denemarken', 'Nederland');";
            //ExecuteQuery(query11);
            /*
            COUNT(DISTINCT land)
            2
            */

            //string query12 = "SELECT COUNT(DISTINCT land) FROM customers;";
            //ExecuteQuery(query12);
            /*
            COUNT(DISTINCT land)
            27
            */

            //string query13 = "SELECT COUNT(DISTINCT land) FROM customers WHERE naam LIKE '___';";
            //ExecuteQuery(query13);
            /*
            COUNT(DISTINCT land)
            1
            */

            //string query14 = "SELECT * FROM customers WHERE naam LIKE '___';";
            //ExecuteQuery(query14);
            /*
            The number of columns: 6
            Id      KlantID Naam    Land    Plaats  Adres
            107     101624  HLS     Belgi?  Antwerpen
            */

            //string query15 = "SELECT land, count(*) FROM customers GROUP BY land;";
            //ExecuteQuery(query15);
            /*
            Land    count(*)
            Australi?       1
            Belgi?  15
            Bulgarije       2
            China   3
            Denemarken      7
            Duitsland       3
            Estland 1
            */

            //string query16 = "SELECT land, count(*) FROM customers GROUP BY land HAVING land LIKE '%e%e%';";
            //ExecuteQuery(query16);
            /*
            Land    count(*)
            Denemarken      7
            Griekenland     2
            Nederland       23
            Nieuw-Zeeland   1
            Roemeni?        1
            */

            //string query17 = "SELECT * FROM customers WHERE land != 'Nederland'";
            //ExecuteQuery(query17);

            //string query18 = "SELECT * FROM customers WHERE land <> 'Denemarken'";
            //ExecuteQuery(query18);

            //string query19 = "SELECT * FROM articles";
            //ExecuteQuery(query19);

            // What is the total sales amount?
            //string query20 = "SELECT SUM(OmzetInEuroNaKorting) AS TotalSales FROM Sales";
            //ExecuteQuery(query20);
            /*
            TotalSales
            5009564,60
            */

            // What are the top 10 articles sold by quantity?
            //string query21 = @"SELECT Omschrijving, SUM(AantalGeboekt) AS TotalQuantitySold
            //            FROM Sales
            //            GROUP BY Omschrijving
            //            ORDER BY TotalQuantitySold DESC
            //            LIMIT 10;";
            //ExecuteQuery(query21);
            /*
            Omschrijving    TotalQuantitySold
            Vedett Extra White 24/33cl      359712,00
            Lindemans Kriek 24/25cl 265896,00
            Rochefort 10 24/33cl    231504,00
            Lindemans Pecheresse 24/25cl    174552,00
            Duvel 24/33cl   146520,00
            Chimay Blauw 24/33cl    132892,00
            Rochefort 8 24/33cl     130660,00
            Chimay Rood 24/33cl     125760,00
            La Chouffe 24/33cl      119812,00
            St.Bernardus Abt 12 24/33cl     119640,00
            */

            // What is the total sales amount for each customer?
            //string query22 = @"SELECT c.Naam, SUM(s.OmzetInEuroNaKorting) AS TotalSales
            //    FROM Sales s
            //    INNER JOIN Customers c ON s.CustomerId = c.Id
            //    GROUP BY c.Naam
            //    ORDER BY TotalSales DESC;";
            //ExecuteQuery(query22);
            /*
            Naam    TotalSales
            Hansen Dranken BV       786921,90
            Huang Trading bvba      488960,21
            FASSBIERE S.L.  404064,15
            WENZHOU WIN-WIN INTERNATIONAL TRADE CO., LTD    357107,94
            Beerhub 268748,15
            RYS Trading Company B.V.        263743,48
            Multi Bier Asten BV     237556,33
            Henk Smit       198900,70
            Ningbo Wohai International Trading Co., Ltd     177088,19
            */

            // How many customers are from each country?
            //string query23 = @"SELECT c.Land, COUNT(*) AS CustomerCount
            //    FROM Customers c
            //    GROUP BY c.Land
            //    ORDER BY CustomerCount DESC;";
            //ExecuteQuery(query23);
            /*
            Land    CustomerCount
            Nederland       23
            Itali?  20
            Belgi?  15
            Spanje  7
            Denemarken      7
            */

            // Get details of customers along with their most recent purchase information (e.g., article name, date).
            //string query24 = @"SELECT c.Naam, s.Omschrijving, s.OmzetInEuroNaKorting, s.DateTime AS LatestPurchaseDate
            //        FROM Customers c
            //        INNER JOIN Sales s ON s.CustomerId = c.Id
            //        ORDER BY s.DateTime DESC
            //        LIMIT 10;";
            //ExecuteQuery(query24);
            /*
            Naam    Omschrijving    OmzetInEuroNaKorting    LatestPurchaseDate
            Den-Belgiske-Olmand     Boon Oude Gueuze 12/37,5cl      30,51   2017-07-15 00:00:00
            Den-Belgiske-Olmand     Boon Kriek 12/37.5cl    98,41   2017-07-15 00:00:00
            Den-Belgiske-Olmand     Lindemans Apple 24/25cl 73,39   2017-07-15 00:00:00
            Den-Belgiske-Olmand     Lindemans Kriek 24/25cl 173,65  2017-07-15 00:00:00
            Den-Belgiske-Olmand     Lindemans Pecheresse 24/25cl    171,73  2017-07-15 00:00:00
            Den-Belgiske-Olmand     Mort Subite Gueuze 20/37.5cl    137,27  2017-07-15 00:00:00
            Den-Belgiske-Olmand     Saison Dupont Bio 24/25cl       84,14   2017-07-15 00:00:00
            Den-Belgiske-Olmand     Achel blond 24/33cl     92,13   2017-07-15 00:00:00
            Den-Belgiske-Olmand     Brunehaut Blonde Bio 24/33cl    42,36   2017-07-15 00:00:00
            Den-Belgiske-Olmand     Brugge Tripel 24/33cl   58,23   2017-07-15 00:00:00
            */

            //string query25 = "SELECT * FROM articles ORDER BY AlcoholGraad DESC LIMIT 10";
            //ExecuteQuery(query25);
            /*
            Id      ArtikelNummer   Omschrijving    Plato   AlcoholGraad    Eenheid PrijsInEuroExclusiefTaksen
            1985    1010252 Uiltje Old Enough To Drink 24/33cl      25,00   21,00   24/33cl 166,63
            2006    1007031 Watt Dickie Brewdog     30,00   20,00   60ml    6,50
            1199    1006572 Mikkeller French Oak Series 2X6/37,5cl  36,40   19,30   237,5cl6/3      83,00
            1979    1010113 Uiltje Mind your step Bourbon BA Sequence 2Y 15/50      30,00   19,20   15/50cl 169,71
            1147    1006350 Mikkeller Barrel Aged Black-BA imp.Stout 12/37,5cl      30,00   18,80   12/37,5cl       71,61
            1165    1007186 Mikkeller Black 12/37,5cl       42,00   18,70   12/37,5cl       58,82
            1168    1006349 Mikkeller Black Impy Stout 12/37,5cl    30,00   17,50   12/37,5cl       55,86
            1169    1007223 Mikkeller Black Inc & Blood BA Brandy 6/75cl    30,00   17,00   6/75cl  75,52
            275     1007051 Brewdog Tokyo*  30,00   16,50   24/33cl 173,05
            1170    1006791 Mikkeller Black Inc Crooked Moon 6/75cl 30,00   16,50   6/75cl  57,59
            */

            //string query26 = @"SELECT c.Naam, c.Land, c.Plaats, c.Adres, s.Omschrijving, s.OmzetInEuroNaKorting AS OmzetInEuro, s.DateTime, a.AlcoholGraad 
            //        FROM articles a, customers c, sales s 
            //        WHERE a.ArtikelNummer = s.Artikelnummer AND s.CustomerId = c.Id 
            //        ORDER BY s.OmzetInEuroNaKorting DESC 
            //        LIMIT 10;";
            //ExecuteQuery(query26);
            /*
            Naam    Land    Plaats  Adres   Omschrijving    OmzetInEuro     DateTime        AlcoholGraad
            Beerhub China   Wenzhou         Vedett Extra White 24/33cl      39984,00        2017-06-15 00:00:00     4,70
            WENZHOU WIN-WIN INTERNATIONAL TRADE CO., LTD    China   Wenzhou         Rochefort 10 24/33cl    37260,94        2016-09-15 00:00:00     11,30
            Beerhub China   Wenzhou         Chimay Blauw 24/33cl    37121,66        2016-11-15 00:00:00     9,00
            Beerhub China   Wenzhou         Rochefort 10 24/33cl    28620,00        2017-07-15 00:00:00     11,30
            Beerhub China   Wenzhou         Duvel 24/33cl   23841,45        2017-04-15 00:00:00     8,50
            Beerhub China   Wenzhou         Chimay Rood 24/33cl     22779,09        2016-11-15 00:00:00     7,00
            Beerhub China   Wenzhou         Rochefort 10 24/33cl    21463,56        2016-11-15 00:00:00     11,30
            WENZHOU WIN-WIN INTERNATIONAL TRADE CO., LTD    China   Wenzhou         Chimay Blauw 24/33cl    20904,00        2017-04-15 00:00:00     9,00
            Huang Trading bvba      Belgi?  Deurne  Bisschoppenhoflaan, 79/1        Rochefort 10 24/33cl    20365,58        2017-04-15 00:00:00     11,30
            WENZHOU WIN-WIN INTERNATIONAL TRADE CO., LTD    China   Wenzhou         Rochefort 10 24/33cl    19966,12        2016-05-15 00:00:00     11,30
            */

            string query27 = @"SELECT a.AlcoholGraad, SUM(s.OmzetInEuroNaKorting) AS Omzet
                FROM articles a, sales s 
                WHERE a.ArtikelNummer = s.Artikelnummer 
                GROUP BY a.AlcoholGraad 
                ORDER BY SUM(s.OmzetInEuroNaKorting) DESC
                LIMIT 10;";
            ExecuteQuery(query27);
            /*
            AlcoholGraad    Omzet
            8,00    687560,41
            9,00    330807,86
            8,50    327166,27
            11,30   323188,32
            7,00    311588,86
            10,00   247010,66
            3,50    240646,83
            4,70    237699,49
            6,00    225765,42
            9,50    218661,80
            */


            Console.WriteLine("End of program. Press enter.");
            Console.Read();
        }
    }
}
