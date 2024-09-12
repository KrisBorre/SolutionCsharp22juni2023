using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] strings = { "sine", "cosine", "tangent", "cosecant", "secant", "cotangent", "hyperbolic sine", "hyperbolic cosine", "hyperbolic tangent" };
        Console.WriteLine("test 1");
        foreach (string a in strings)
        {
            Console.WriteLine($"{a}");
        }
        Console.WriteLine("test 2");
        foreach (string a in strings)
        {
            Console.WriteLine("{0}", a);
        }
        Console.WriteLine("test 3");
        foreach (string a in strings)
        {
            Console.WriteLine("{0, 20}", a);
        }
        Console.WriteLine("test 4");
        foreach (string a in strings)
        {
            Console.WriteLine("{0, 5}", a);
        }
        Console.WriteLine("test 5");
        int getal = 1;
        foreach (string a in strings)
        {
            Console.WriteLine($"{getal} en {a}");
        }
        Console.WriteLine("test 6");
        foreach (string a in strings)
        {
            Console.WriteLine("{0} en {1, 20}", getal, a);
        }
        Console.WriteLine("test 7");
        getal = 1;
        foreach (string a in strings)
        {
            getal *= 10;
            Console.WriteLine("{0} en {1, 20}", getal, a);
        }
        Console.WriteLine("test 8");
        getal = 1;
        foreach (string a in strings)
        {
            getal *= 10;
            Console.WriteLine("{0} en {1, 20}", getal, a);
        }
        Console.WriteLine("test 9");
        getal = 1;
        foreach (string a in strings)
        {
            getal *= 10;
            Console.WriteLine("{0, 20} en {1, 20}", getal, a);
        }
        Console.WriteLine("test 10");
        getal = 1;
        foreach (string a in strings)
        {
            getal *= 10;
            Console.WriteLine("{0, 12} en {1, 12}", getal, a);
        }
        // index[,alignment][:formatString]
        Console.WriteLine("test 11");
        getal = 1;
        foreach (string a in strings)
        {
            getal *= 10;
            Console.WriteLine("{0, 20:E} en {1, 10}", getal, a);
        }
        Console.WriteLine("test 12");
        getal = 1;
        foreach (string a in strings)
        {
            getal *= 10;
            Console.WriteLine("{0, 10:F2} en {1, 15}", getal, a);
        }
        Console.WriteLine("test 13");
        getal = 1;
        foreach (string a in strings)
        {
            getal *= 10;
            Console.WriteLine("{0,10:E3} en {1, 13} en verder is het {2}", getal, a, DateTime.Now);
        }
        Console.WriteLine("test 14");
        getal = 1;
        foreach (string a in strings)
        {
            getal *= 10;
            Console.WriteLine("{0,10:E4} en {1,12} en verder is het {2:hh} uur", getal, a, DateTime.Now);
        }
        Console.WriteLine("test 15");
        getal = 1;
        foreach (string a in strings)
        {
            getal *= 10;
            string string1 = string.Format("{0,10:E5} en {1,10} en verder is het {2} uur", getal, a, DateTime.Now);
            Console.WriteLine(string1);
        }

        /*test 1
sine
cosine
tangent
cosecant
secant
cotangent
hyperbolic sine
hyperbolic cosine
hyperbolic tangent
test 2
sine
cosine
tangent
cosecant
secant
cotangent
hyperbolic sine
hyperbolic cosine
hyperbolic tangent
test 3
                sine
              cosine
             tangent
            cosecant
              secant
           cotangent
     hyperbolic sine
   hyperbolic cosine
  hyperbolic tangent
test 4
 sine
cosine
tangent
cosecant
secant
cotangent
hyperbolic sine
hyperbolic cosine
hyperbolic tangent
test 5
1 en sine
1 en cosine
1 en tangent
1 en cosecant
1 en secant
1 en cotangent
1 en hyperbolic sine
1 en hyperbolic cosine
1 en hyperbolic tangent
test 6
1 en                 sine
1 en               cosine
1 en              tangent
1 en             cosecant
1 en               secant
1 en            cotangent
1 en      hyperbolic sine
1 en    hyperbolic cosine
1 en   hyperbolic tangent
test 7
10 en                 sine
100 en               cosine
1000 en              tangent
10000 en             cosecant
100000 en               secant
1000000 en            cotangent
10000000 en      hyperbolic sine
100000000 en    hyperbolic cosine
1000000000 en   hyperbolic tangent
test 8
10 en                 sine
100 en               cosine
1000 en              tangent
10000 en             cosecant
100000 en               secant
1000000 en            cotangent
10000000 en      hyperbolic sine
100000000 en    hyperbolic cosine
1000000000 en   hyperbolic tangent
test 9
                  10 en                 sine
                 100 en               cosine
                1000 en              tangent
               10000 en             cosecant
              100000 en               secant
             1000000 en            cotangent
            10000000 en      hyperbolic sine
           100000000 en    hyperbolic cosine
          1000000000 en   hyperbolic tangent
test 10
          10 en         sine
         100 en       cosine
        1000 en      tangent
       10000 en     cosecant
      100000 en       secant
     1000000 en    cotangent
    10000000 en hyperbolic sine
   100000000 en hyperbolic cosine
  1000000000 en hyperbolic tangent
test 11
       1,000000E+001 en       sine
       1,000000E+002 en     cosine
       1,000000E+003 en    tangent
       1,000000E+004 en   cosecant
       1,000000E+005 en     secant
       1,000000E+006 en  cotangent
       1,000000E+007 en hyperbolic sine
       1,000000E+008 en hyperbolic cosine
       1,000000E+009 en hyperbolic tangent
test 12
     10,00 en            sine
    100,00 en          cosine
   1000,00 en         tangent
  10000,00 en        cosecant
 100000,00 en          secant
1000000,00 en       cotangent
10000000,00 en hyperbolic sine
100000000,00 en hyperbolic cosine
1000000000,00 en hyperbolic tangent
test 13
1,000E+001 en          sine en verder is het 22/06/2023 16:58:51
1,000E+002 en        cosine en verder is het 22/06/2023 16:58:51
1,000E+003 en       tangent en verder is het 22/06/2023 16:58:51
1,000E+004 en      cosecant en verder is het 22/06/2023 16:58:51
1,000E+005 en        secant en verder is het 22/06/2023 16:58:51
1,000E+006 en     cotangent en verder is het 22/06/2023 16:58:51
1,000E+007 en hyperbolic sine en verder is het 22/06/2023 16:58:51
1,000E+008 en hyperbolic cosine en verder is het 22/06/2023 16:58:51
1,000E+009 en hyperbolic tangent en verder is het 22/06/2023 16:58:51
test 14
1,0000E+001 en         sine en verder is het 04 uur
1,0000E+002 en       cosine en verder is het 04 uur
1,0000E+003 en      tangent en verder is het 04 uur
1,0000E+004 en     cosecant en verder is het 04 uur
1,0000E+005 en       secant en verder is het 04 uur
1,0000E+006 en    cotangent en verder is het 04 uur
1,0000E+007 en hyperbolic sine en verder is het 04 uur
1,0000E+008 en hyperbolic cosine en verder is het 04 uur
1,0000E+009 en hyperbolic tangent en verder is het 04 uur
test 15
1,00000E+001 en       sine en verder is het 22/06/2023 16:58:51 uur
1,00000E+002 en     cosine en verder is het 22/06/2023 16:58:51 uur
1,00000E+003 en    tangent en verder is het 22/06/2023 16:58:51 uur
1,00000E+004 en   cosecant en verder is het 22/06/2023 16:58:51 uur
1,00000E+005 en     secant en verder is het 22/06/2023 16:58:51 uur
1,00000E+006 en  cotangent en verder is het 22/06/2023 16:58:51 uur
1,00000E+007 en hyperbolic sine en verder is het 22/06/2023 16:58:51 uur
1,00000E+008 en hyperbolic cosine en verder is het 22/06/2023 16:58:51 uur
1,00000E+009 en hyperbolic tangent en verder is het 22/06/2023 16:58:51 uur*/

        Console.WriteLine("test 16");
        foreach (string a in strings)
        {
            if (a.Length > 10) // Filter strings longer than 10 characters
            {
                Console.WriteLine(a);
            }
        }

        Console.WriteLine("test 17");
        foreach (string a in strings)
        {
            Console.WriteLine($"{char.ToUpper(a[0])}{a.Substring(1)}");
        }

        Console.WriteLine("test 18 LINQ Uppercase");
        strings.Select(s => s.ToUpper()).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("test 19 LINQ Sorted");
        strings.OrderBy(s => s).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("test 20 Padding or Truncation");
        foreach (string a in strings)
        {
            string paddedOrTruncated = a.Length > 10 ? a.Substring(0, 10) : a.PadRight(10);
            Console.WriteLine(paddedOrTruncated);
        }

        /*
        test 16
        hyperbolic sine
        hyperbolic cosine
        hyperbolic tangent
        test 17
        Sine
        Cosine
        Tangent
        Cosecant
        Secant
        Cotangent
        Hyperbolic sine
        Hyperbolic cosine
        Hyperbolic tangent
        test 18 LINQ Uppercase
        SINE
        COSINE
        TANGENT
        COSECANT
        SECANT
        COTANGENT
        HYPERBOLIC SINE
        HYPERBOLIC COSINE
        HYPERBOLIC TANGENT
        test 19 LINQ Sorted
        cosecant
        cosine
        cotangent
        hyperbolic cosine
        hyperbolic sine
        hyperbolic tangent
        secant
        sine
        tangent
        test 20 Padding or Truncation
        sine
        cosine
        tangent
        cosecant
        secant
        cotangent
        hyperbolic
        hyperbolic
        hyperbolic
        */

        Console.WriteLine("test 21 Random Output");
        Random rnd = new Random();
        strings.OrderBy(s => rnd.Next()).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("test 22 Indexes");
        for (int i = 0; i < strings.Length; i++)
        {
            Console.WriteLine($"Index {i}: {strings[i]}");
        }

        Console.WriteLine("test 23 Custom getal Increment");
        getal = 1;
        int prev = 0;
        foreach (string a in strings)
        {
            int temp = getal;
            getal = getal + prev;  // Fibonacci-like sequence
            prev = temp;
            Console.WriteLine($"{getal} en {a}");
        }

        /*
        test 21 Random Output
        cosine
        cosecant
        hyperbolic tangent
        cotangent
        hyperbolic sine
        hyperbolic cosine
        tangent
        secant
        sine
        test 22 Indexes
        Index 0: sine
        Index 1: cosine
        Index 2: tangent
        Index 3: cosecant
        Index 4: secant
        Index 5: cotangent
        Index 6: hyperbolic sine
        Index 7: hyperbolic cosine
        Index 8: hyperbolic tangent
        test 23 Custom getal Increment
        1 en sine
        2 en cosine
        3 en tangent
        5 en cosecant
        8 en secant
        13 en cotangent
        21 en hyperbolic sine
        34 en hyperbolic cosine
        55 en hyperbolic tangent
        */

        Console.WriteLine("test 24 Dictionary");
        Dictionary<string, int> trigDictionary = new Dictionary<string, int>
        {
            {"sine", 1}, {"cosine", 2}, {"tangent", 3},
            {"cosecant", 4}, {"secant", 5}, {"cotangent", 6},
            {"hyperbolic sine", 7}, {"hyperbolic cosine", 8}, {"hyperbolic tangent", 9}
        };

        foreach (var pair in trigDictionary)
        {
            Console.WriteLine($"{pair.Key} has the value {pair.Value}");
        }

        Console.WriteLine("test 25 Colored Output");
        foreach (string a in strings)
        {
            Console.ForegroundColor = a.Length > 8 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(a);
        }
        Console.ResetColor();

        /*
        test 24 Dictionary
        sine has the value 1
        cosine has the value 2
        tangent has the value 3
        cosecant has the value 4
        secant has the value 5
        cotangent has the value 6
        hyperbolic sine has the value 7
        hyperbolic cosine has the value 8
        hyperbolic tangent has the value 9
        test 25 Colored Output
        sine
        cosine
        tangent
        cosecant
        secant
        cotangent
        hyperbolic sine
        hyperbolic cosine
        hyperbolic tangent
        */

        Console.WriteLine("test 26 Parallel Output");
        var tasks = strings.Select(s => Task.Run(() => Console.WriteLine(s)));
        Task.WaitAll(tasks.ToArray());

        Console.WriteLine("test 27 Time-Based Output");
        foreach (string a in strings)
        {
            Console.WriteLine(a);
            Thread.Sleep(500); // Half-second delay
        }

        Console.WriteLine("test 28");
        foreach (string a in strings)
        {
            Console.WriteLine(a.ToUpper());
        }

        Console.WriteLine("test 29");
        Array.Sort(strings);
        foreach (string a in strings)
        {
            Console.WriteLine(a);
        }

        Console.WriteLine("test 30");
        foreach (string a in strings)
        {
            Console.WriteLine(a.Length > 10 ? a.Substring(0, 10) : a.PadRight(10));
        }

        Console.WriteLine("test 31");
        var longStrings = strings.Where(a => a.Length > 10);
        foreach (var a in longStrings)
        {
            Console.WriteLine(a);
        }

        /*
        test 26 Parallel Output
        cosine
        sine
        tangent
        cotangent
        hyperbolic sine
        hyperbolic cosine
        hyperbolic tangent
        secant
        cosecant
        test 27 Time-Based Output
        sine
        cosine
        tangent
        cosecant
        secant
        cotangent
        hyperbolic sine
        hyperbolic cosine
        hyperbolic tangent
        test 28
        SINE
        COSINE
        TANGENT
        COSECANT
        SECANT
        COTANGENT
        HYPERBOLIC SINE
        HYPERBOLIC COSINE
        HYPERBOLIC TANGENT
        test 29
        cosecant
        cosine
        cotangent
        hyperbolic cosine
        hyperbolic sine
        hyperbolic tangent
        secant
        sine
        tangent
        test 30
        cosecant
        cosine
        cotangent
        hyperbolic
        hyperbolic
        hyperbolic
        secant
        sine
        tangent
        test 31
        hyperbolic cosine
        hyperbolic sine
        hyperbolic tangent
        */

        Console.WriteLine("test 32");
        var capitalizedStrings = strings.Select(a => $"{char.ToUpper(a[0])}{a.Substring(1)}");
        foreach (var a in capitalizedStrings)
        {
            Console.WriteLine(a);
        }

        Console.WriteLine("test 33");
        foreach (var a in strings.Where(a => a.Length > 10))
        {
            Console.WriteLine($"{char.ToUpper(a[0])}{a.Substring(1)}");
        }

        Console.WriteLine("test 34");
        foreach (var a in strings)
        {
            if (!string.IsNullOrEmpty(a) && a.Length > 10)
            {
                Console.WriteLine(a);
            }
        }

        /*
        test 32
        Cosecant
        Cosine
        Cotangent
        Hyperbolic cosine
        Hyperbolic sine
        Hyperbolic tangent
        Secant
        Sine
        Tangent
        test 33
        Hyperbolic cosine
        Hyperbolic sine
        Hyperbolic tangent
        test 34
        hyperbolic cosine
        hyperbolic sine
        hyperbolic tangent
        */

        Console.WriteLine("test 35");
        foreach (var a in strings)
        {
            if (!string.IsNullOrEmpty(a))
            {
                Console.WriteLine($"{char.ToUpper(a[0])}{(a.Length > 1 ? a.Substring(1) : "")}");
            }
        }

        Console.WriteLine("test 36");
        var result36 = new StringBuilder();
        foreach (var a in strings)
        {
            if (a.Length > 10)
            {
                result36.AppendLine(a);
            }
        }
        Console.WriteLine(result36.ToString());

        Console.WriteLine("test 37");
        var result37 = new StringBuilder();
        foreach (var a in strings)
        {
            result37.AppendLine($"{char.ToUpper(a[0])}{a.Substring(1)}");
        }
        Console.WriteLine(result37.ToString());

        /*
        test 35
        Cosecant
        Cosine
        Cotangent
        Hyperbolic cosine
        Hyperbolic sine
        Hyperbolic tangent
        Secant
        Sine
        Tangent
        test 36
        hyperbolic cosine
        hyperbolic sine
        hyperbolic tangent

        test 37
        Cosecant
        Cosine
        Cotangent
        Hyperbolic cosine
        Hyperbolic sine
        Hyperbolic tangent
        Secant
        Sine
        Tangent
        */

        Console.WriteLine("test 38");
        Parallel.ForEach(strings, a =>
        {
            if (a.Length > 10)
            {
                Console.WriteLine(a);
            }
        });

        Console.WriteLine("test 39");
        Parallel.ForEach(strings, a =>
        {
            Console.WriteLine($"{char.ToUpper(a[0])}{a.Substring(1)}");
        });

        Console.WriteLine("test 40 with chaining");
        strings
            .Where(a => a.Length > 10)
            .Select(a => $"{char.ToUpper(a[0])}{a.Substring(1)}")
            .ToList()
            .ForEach(Console.WriteLine);

        /*
        test 38
        hyperbolic sine
        hyperbolic tangent
        hyperbolic cosine
        test 39
        Cosecant
        Hyperbolic sine
        Secant
        Cosine
        Cotangent
        Hyperbolic tangent
        Hyperbolic cosine
        Tangent
        Sine
        test 40 with chaining
        Hyperbolic cosine
        Hyperbolic sine
        Hyperbolic tangent
        */

        Console.WriteLine("test 41 sorted by length");
        var sortedStrings = strings.Where(a => a.Length > 10).OrderBy(a => a.Length);
        foreach (var a in sortedStrings)
        {
            Console.WriteLine(a);
        }

        Console.WriteLine("test 42 sorted by length");
        var sortedCapitalizedStrings = strings
            .OrderBy(a => a.Length)
            .Select(a => $"{char.ToUpper(a[0])}{a.Substring(1)}");

        foreach (var a in sortedCapitalizedStrings)
        {
            Console.WriteLine(a);
        }

        /*
        test 41 sorted by length
        hyperbolic sine
        hyperbolic cosine
        hyperbolic tangent
        test 42 sorted by length
        Sine
        Cosine
        Secant
        Tangent
        Cosecant
        Cotangent
        Hyperbolic sine
        Hyperbolic cosine
        Hyperbolic tangent
        */

        Console.ReadLine();
    }
}