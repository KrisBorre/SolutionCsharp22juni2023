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

        Console.ReadLine();

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

    }
}