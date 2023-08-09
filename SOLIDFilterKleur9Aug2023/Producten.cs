namespace SOLIDFilterKleur9Aug2023
{
    internal class Producten : List<Product>
    {
        public override string ToString()
        {
            string result = "";
            foreach (Product product in this)
            {
                result += product.Naam + "; ";
            }
            return result;
        }
    }
}
