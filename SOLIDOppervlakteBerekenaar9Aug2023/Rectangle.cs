namespace SOLIDOppervlakteBerekenaar9Aug2023
{
    internal class Rectangle : Shape
    {
        public int lengte;
        public int breedte;

        public Rectangle(int l, int b)
        {
            lengte = l;
            breedte = b;
        }

        public override double Oppervlakte()
        {
            return lengte * breedte;
        }

        public double Omtrek()
        {
            return 2 * lengte + 2 * breedte;
        }
    }
}
