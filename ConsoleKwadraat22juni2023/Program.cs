internal class Program
{
    private static void Main(string[] args)
    {

        #region Methoden Opwarmers

        #region Kwadraat
        {
            Console.WriteLine("Welkom bij het kwadraat.");
            string input = "";
            while (input != "stop" && input != "exit")
            {
                Console.WriteLine("Geef een getal (exit is stop)");
                input = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(input, out double x) && input != "stop" && input != "exit")
                {
                    double resultaat = Kwadraat(x);
                    Console.WriteLine($"Kwadraat van {x} is {resultaat}.");
                }
            }
        }
        #endregion


        #region BerekenStraal
        {
            Console.WriteLine("Welkom bij de straal van een cirkel.");
            string input = "";
            while (input != "stop" && input != "exit")
            {
                Console.WriteLine("Geef de diameter (exit is stop)");
                input = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(input, out double x) && input != "stop" && input != "exit")
                {
                    double resultaat = BerekenStraal(x);
                    Console.WriteLine($"Als de diameter gelijk is aan {x}, dan is de straal gelijk aan {resultaat}!");
                }
            }
        }
        #endregion


        #region BerekenOmtrek
        {
            Console.WriteLine("Welkom bij de omtrek van een cirkel.");
            string input = "";
            while (input != "stop" && input != "exit")
            {
                Console.WriteLine("Geef de diameter (exit is stop)");
                input = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(input, out double x) && input != "stop" && input != "exit")
                {
                    double resultaat = BerekenOmtrek(x);
                    Console.WriteLine($"Als de diameter gelijk is aan {x}, dan is de omtrek van de cirkel gelijk aan {resultaat}!");
                }
            }
        }
        #endregion


        #region BerekenOppervlakte
        {
            Console.WriteLine("Welkom bij de oppervlakte van een cirkel.");
            string input = "";
            while (input != "stop" && input != "exit")
            {
                Console.WriteLine("Geef de diameter (exit is stop)");
                input = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(input, out double x) && input != "stop" && input != "exit")
                {
                    double resultaat = BerekenOppervlakte(x);
                    Console.WriteLine($"Als de diameter van de cirkel gelijk is aan {x}, dan is de oppervlakte gelijk aan {resultaat}.");
                }
            }
        }
        #endregion

        #region GeefGrootste
        {
            Console.WriteLine("Welkom bij de grootste.");
            string input = "";
            while (input != "stop" && input != "exit")
            {
                Console.WriteLine("Geef het eerste getal (exit is stop)");
                input = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(input, out double getal1) && input != "stop" && input != "exit")
                {
                    Console.WriteLine("Geef het tweede getal (exit is stop)");
                    input = Console.ReadLine() ?? string.Empty;
                    if (double.TryParse(input, out double getal2) && input != "stop" && input != "exit")
                    {
                        double resultaat = GeefGrootste(getal1, getal2);
                        Console.WriteLine($"De grootste waarde is {resultaat}.");
                    }
                }
            }
        }
        #endregion


        #region IsEven
        {
            Console.WriteLine("Welkom bij even getallen.");
            string input = "";
            while (input != "stop" && input != "exit")
            {
                Console.WriteLine("Geef een getal (exit is stop)");
                input = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(input, out double x) && input != "stop" && input != "exit")
                {
                    if (IsEven(x)) Console.WriteLine($"{x} is even!");
                    else Console.WriteLine($"{x} is oneven!");
                }
            }
        }
        #endregion


        #region IsArmstrong
        {
            Console.WriteLine("Welkom bij Armstrong.");
            string sGetal;
            do
            {
                Console.WriteLine("Geef getal: (exit is stop)");
                sGetal = Console.ReadLine() ?? string.Empty;
                int iGetal;

                while (!int.TryParse(sGetal, out iGetal) && sGetal != "stop" && sGetal != "exit")
                {
                    Console.WriteLine("Geef een natuurlijk getal, aub: (exit is stop)");
                    sGetal = Console.ReadLine() ?? string.Empty;
                }

                if (sGetal != "stop" && sGetal != "exit")
                {
                    if (IsArmstrong(iGetal))
                    {
                        Console.WriteLine("Het ingevoerde getal is een Armstrong-nummer.");
                    }
                    else
                    {
                        Console.WriteLine("Het ingevoerde getal is NIET een Armstrong-nummer.");
                    }
                }
            } while (sGetal != "stop" && sGetal != "exit");
        }
        #endregion


        #region ToonOnEvenNummers
        {
            Console.WriteLine("Welkom bij de oneven getallen.");
            string sGetal;
            do
            {
                Console.WriteLine("Geef getal: (exit is stop)");
                sGetal = Console.ReadLine() ?? string.Empty;
                int iGetal;

                while (!int.TryParse(sGetal, out iGetal) && sGetal != "stop" && sGetal != "exit")
                {
                    Console.WriteLine("Geef een natuurlijk getal, aub: (exit is stop)");
                    sGetal = Console.ReadLine() ?? string.Empty;
                }

                if (sGetal != "stop" && sGetal != "exit")
                {
                    ToonOnEvenNummers(iGetal);
                }
            } while (sGetal != "stop" && sGetal != "exit");
        }
        #endregion

        #region ToonArmstrongNummers
        {
            Console.WriteLine("Welkom bij de Armstrong getallen.");
            string sGetal;
            do
            {
                Console.WriteLine("Geef getal: (exit is stop)");
                sGetal = Console.ReadLine() ?? string.Empty;
                int iGetal;

                while (!int.TryParse(sGetal, out iGetal) && sGetal != "stop" && sGetal != "exit")
                {
                    Console.WriteLine("Geef een natuurlijk getal, aub: (exit is stop)");
                    sGetal = Console.ReadLine() ?? string.Empty;
                }

                if (sGetal != "stop" && sGetal != "exit")
                {
                    ToonArmstrongNummers(iGetal);
                }
            } while (sGetal != "stop" && sGetal != "exit");
        }
        #endregion


        #endregion

    }


    /// <summary>
    /// Methode Kwadraat die het kwadraat van een ingevoerd getal berekend ( het getal geef je mee als paramater).
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    static double Kwadraat(double x)
    {
        return Math.Pow(x, 2);
    }

    /// <summary>
    /// Methode BerekenStraal die de straal van een cirkel kan berekenen waarvan je de diameter meegeeft (de diameter geef je mee als parameter).
    /// </summary>
    /// <param name="diameter"></param>
    /// <returns></returns>
    static double BerekenStraal(double diameter)
    {
        return diameter / 2;
    }

    /// <summary>
    /// omtrek van een cirkel
    /// </summary>
    /// <param name="diameter"></param>
    /// <returns></returns>
    static double BerekenOmtrek(double diameter)
    {
        return 2 * Math.PI * BerekenStraal(diameter);
    }

    /// <summary>
    /// oppervlakte van een cirkel
    /// </summary>
    /// <param name="diameter"></param>
    /// <returns></returns>
    static double BerekenOppervlakte(double diameter)
    {
        return Math.PI * Kwadraat(BerekenStraal(diameter));
    }

    /// <summary>
    /// Geeft de grootste van 2 getallen.
    /// </summary>
    /// <param name="getal1"></param>
    /// <param name="getal2"></param>
    /// <returns></returns>
    static double GeefGrootste(double getal1, double getal2)
    {
        return Math.Max(getal1, getal2);
    }


    /// <summary>
    /// Methode IsEven die bepaald of een getal even of oneven is (geeft een bool terug die true is indien even).
    /// </summary>
    /// <param name="getal"></param>
    /// <returns></returns>
    static bool IsEven(double getal)
    {
        bool result = false;
        if (getal % 2 == 0) result = true;
        return result;
    }


    static bool IsArmstrong(int iGetal)
    {
        bool isArmstrong = false;
        int lengte = iGetal.ToString().Length;
        int oorspronkelijkGetal = iGetal;
        int result = 0;
        for (int i = lengte - 1; i >= 0; i--)
        {
            int power = (int)Math.Pow(10, i);
            int getal = iGetal / power;
            result += (int)Math.Pow(getal, lengte);
            iGetal -= getal * power;
        }

        if (oorspronkelijkGetal == result)
        {
            isArmstrong = true;
        }
        return isArmstrong;
    }

    static void ToonOnEvenNummers(int iGetal)
    {
        for (int i = 1; i <= iGetal; i++)
        {
            if (!IsEven(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    static void ToonArmstrongNummers(int iGetal)
    {
        for (int i = 1; i <= iGetal; i++)
        {
            if (IsArmstrong(i))
            {
                Console.WriteLine(i);
            }
        }
    }

}
