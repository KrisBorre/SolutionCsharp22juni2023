internal class Program
{
    private static void Main(string[] args)
    {
        Random gen = new Random();
        string input = "";
        while (input != "stop" && input != "exit")
        {
            Console.WriteLine("Gok de teerling: (exit is stop)");
            input = Console.ReadLine() ?? string.Empty;
            if (Int32.TryParse(input, out int gok) && input != "stop" && input != "exit")
            {
                int getal = gen.Next(1, 7);
                if (gok == getal)
                {
                    Console.WriteLine("Proficiat!");
                }
                else
                {
                    Console.WriteLine("You lose, but you can't win if you don't play. Success doesn't just find you. You have to go out and get it. Great things never come from comfort zones.");
                }
            }
        }
    }
}