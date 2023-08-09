namespace SOLIDFilterKleur9Aug2023
{
    internal class FilterGrootte : IFilter
    {
        readonly int grootte;

        public FilterGrootte(int grootte)
        {
            this.grootte = grootte;
        }

        public Producten Filter(Producten producten)
        {
            Producten result = new Producten();
            foreach (Product product in producten)
            {
                if (product.Grootte == grootte)
                    result.Add(product);
            }
            return result;
        }
    }
}
