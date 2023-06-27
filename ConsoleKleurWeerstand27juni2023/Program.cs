internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Vraag aan de gebruiker om de ringkleuren van de eerste 3 ringen in te voeren als tekst (bv groen). Toon vervolgens de de waarde van deze weerstand.");
        //Console.WriteLine(@"https://www.electronics-tutorials.ws/resistor/res_2.html");

        Console.WriteLine("Geef de kleur van de eerste ring: ");
        string sKleur1 = Console.ReadLine();
        Kleur ring1 = KleurFunctie(sKleur1);
        if (ring1 != Kleur.Wrong)
        {
            Console.WriteLine("Geef de kleur van de tweede ring: ");
            string sKleur2 = Console.ReadLine();
            Kleur ring2 = KleurFunctie(sKleur2);
            if (ring2 != Kleur.Wrong)
            {
                Console.WriteLine("Geef de kleur van de derde ring: ");
                string sKleur3 = Console.ReadLine();
                Kleur ring3 = KleurFunctie(sKleur3);
                if (ring3 != Kleur.Wrong)
                {
                    int weerstandTiental = (int)ring1;
                    if (weerstandTiental >= 0 && weerstandTiental <= 9)
                    {
                        int weerstandEenheid = (int)ring2;
                        if (weerstandEenheid >= 0 && weerstandEenheid <= 9)
                        {
                            // Ring 3 is anders geimplementeerd dan de multiplier op de webpagina van https://www.electronics-tutorials.ws/resistor/res_2.html
                            // Dit lijkt mij een logischere keuze dan die van de electronici.
                            int weerstandExponent = (int)ring3 - 2;
                            if (weerstandExponent >= -2 && weerstandExponent <= 7)
                            {
                                double weerstandInOhm = BerekenWeerstand(weerstandEenheid, weerstandTiental, weerstandExponent);
                                ToonResultaat(sKleur1, sKleur2, sKleur3, weerstandInOhm);
                            }
                        }
                    }
                }
            }
        }
        Console.ReadLine();
        Console.WriteLine("Kris Borremans");
    }

    /// <summary>
    /// toont in de Console een tabel.
    /// </summary>
    /// <param name="kleur1"></param>
    /// <param name="kleur2"></param>
    /// <param name="kleur3"></param>
    /// <param name="weerstandInOhm"></param>
    static void ToonResultaat(string kleur1 = "zwart", string kleur2 = "zwart", string kleur3 = "zwart", double weerstandInOhm = 0)
    {
        string output1 = @"+-----------------------+------------------------+
| ring1 | ring2 | ring3 | Totaal(Ohm)            |
|       |       |       |                        |
+-------+-------+-------+------------------------+
|{0,6} |{1,6} |{2,6} |   {3,13}    Ohm |
|       |       |       |                        |
+-------+-------+-------+------------------------+";
        // index[,alignment][:formatString]

        Console.WriteLine(output1, kleur1, kleur2, kleur3, weerstandInOhm);
    }

    /// <summary>
    /// in Ohm.
    /// </summary>
    /// <param name="eenheid"></param>
    /// <param name="tiental"></param>
    /// <param name="exponent"></param>
    /// <returns></returns>
    static double BerekenWeerstand(int eenheid = 0, int tiental = 0, int exponent = -2)
    {
        return (eenheid + 10 * tiental) * Math.Pow(10, exponent);
    }

    enum Kleur { Black = 0, Brown = 1, Red = 2, Orange = 3, Yellow = 4, Green = 5, Blue = 6, Violet = 7, Grey = 8, White = 9, Wrong = -1 }

    /// <summary>
    /// zet een kleur als string om in een kleur enumeration.
    /// </summary>
    /// <param name="sKleur"></param>
    /// <returns></returns>
    static Kleur KleurFunctie(string sKleur = "zwart")
    {
        Kleur keuze = Kleur.Wrong;
        switch (sKleur.ToLower())
        {
            case "zwart":
                keuze = Kleur.Black;
                break;
            case "bruin":
                keuze = Kleur.Brown;
                break;
            case "rood":
                keuze = Kleur.Red;
                break;
            case "oranje":
                keuze = Kleur.Orange;
                break;
            case "geel":
                keuze = Kleur.Yellow;
                break;
            case "groen":
                keuze = Kleur.Green;
                break;
            case "blauw":
                keuze = Kleur.Blue;
                break;
            case "violet":
                keuze = Kleur.Violet;
                break;
            case "grijs":
                keuze = Kleur.Grey;
                break;
            case "wit":
                keuze = Kleur.White;
                break;
            default:
                Console.WriteLine("Sorry, dit is geen aanvaardbare kleur.\nDruk op een toets om het programma te sluiten.");
                keuze = Kleur.Wrong;
                break;
        }
        return keuze;
    }
}


