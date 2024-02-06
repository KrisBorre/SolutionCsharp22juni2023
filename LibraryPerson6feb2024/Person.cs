using LibraryPhysicalUnits6feb2024;

namespace LibraryPerson6feb2024
{
    public class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private IWeight weight;

        public IWeight Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
