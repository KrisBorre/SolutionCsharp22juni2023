namespace StaticMoverSetCursorPosition27juni2023
{
    internal class Mover27juni2023
    {
        public Mover27juni2023(int xi, int yi, int dxi, int dyi)
        {
            x = xi;
            y = yi;
            dx = dxi;
            dy = dyi;
        }

        private static int height;
        public static int Height
        {
            get { return height; }
            set
            {
                if (value > 0 && value < Console.LargestWindowHeight)
                    height = value;
            }
        }

        private static int width;
        public static int Width
        {
            get { return width; }
            set
            {
                if (value > 0 && value < Console.LargestWindowWidth)
                    width = value;
            }
        }

        private int dx = 1;
        private int dy = 0;
        private int x = 0;
        private int y = 0;

        public void Update()
        {
            x += dx;
            if (x >= Width || x < 0) 
            {
                dx *= -1;
                x += dx;
            }

            y += dy;
            if (y >= Height || y < 0)
            {
                dy *= -1;
                y += dy;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }
    }
}
