using StaticMoverSetCursorPosition27juni2023;

internal class Program
{
    private static void Main(string[] args)
    {
        #region static
        {            
            Console.CursorVisible = false; 
            Mover27juni2023.Height = Console.WindowHeight;
            Mover27juni2023.Width = Console.WindowWidth;

            Mover27juni2023 m1 = new Mover27juni2023(1, 1, 1, 1);
            Mover27juni2023 m2 = new Mover27juni2023(6, 7, -2, 1);

            for (int count = 0; count < 1_000_000; count++)
            {
                if (count % 20 == 0) // iedere seconde (daar we telkens 50ms slapen (1 seconde = 1000 ms => 1000ms/50ms == 20))
                {
                    Mover27juni2023.Width++;
                    Mover27juni2023.Height++;
                }
                Console.SetWindowSize(Mover27juni2023.Width, Mover27juni2023.Height);

                m1.Update();
                m1.Draw();

                m2.Update();
                m2.Draw();

                Thread.Sleep(50);
                Console.Clear();
            }

            Console.WriteLine("Kris Borre");
        }
        #endregion
    }
}