internal class Program
{
    private static void Main(string[] args)
    {
        int grootste = -2_147_483_648;
        int x = 0;
        int y = 0; // -2,147,483,648 to 2,147,483,647
        short z = 0; // -32,768 to 32,767
        sbyte u = 0;
        do
        {
            u += (sbyte)x;
            z += (short)x;
            y += x;
            grootste = Math.Max(grootste, x);
            Console.WriteLine("Voer gehele waarden in (32767=stop)");
            string instring = Console.ReadLine() ?? string.Empty;
            x = Convert.ToInt32(instring);
        } while (x != 32767);

        Console.WriteLine($"Gebruikmakend van Signed 32-bit integers is de som is {y}");
        Console.WriteLine($"Gebruikmakend van Signed 16-bit integers is de som is {z}");
        Console.WriteLine($"Gebruikmakend van Signed 8-bit integers is de som is {u}");
        Console.WriteLine($"De grootste waarde die werd ingevoerd is {grootste}");

        Console.ReadLine();
    }
}