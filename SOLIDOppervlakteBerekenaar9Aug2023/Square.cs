namespace SOLIDOppervlakteBerekenaar9Aug2023
{
    internal class Square : Shape
    {
        public int lengte;

        public Square(int l)
        {
            lengte = l;
        }

        public override double Oppervlakte()
        {
            return lengte * lengte;
        }

        public double Omtrek()
        {
            return 4 * lengte;
        }
    }
}
