using System.Diagnostics;
using System.Reflection;

namespace StaticMoverWinForms14jan2024
{
    public partial class Form1 : Form
    {
        private Graphics g;

        private Mover14jan2024 m1 = new Mover14jan2024(10, 10, 1, 1);
        private Mover14jan2024 m2 = new Mover14jan2024(6, 7, -2, 1);

        private int counter = 0;

        public Form1()
        {
            InitializeComponent();

            this.g = this.CreateGraphics();
            this.g.Clear(Color.RoyalBlue);
            this.timer1.Start();

            // loop through the assemblies that this app references 
            foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                // load the assembly so we can read its details
                var a = Assembly.Load(new AssemblyName(r.FullName));

                // declare a variable to count the number of methods
                int methodCount = 0;

                // loop through all the types in the assembly 
                foreach (var t in a.DefinedTypes)
                {
                    // add up the counts of methods 
                    methodCount += t.GetMethods().Count();
                }
                // output the count of types and their methods
                Debug.WriteLine($"{a.DefinedTypes.Count():N0} types with {methodCount:N0} methods in {r.Name} assembly.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.g.Clear(Color.RoyalBlue);

            Mover14jan2024.Height = Math.Min(this.ClientSize.Height, 1000);
            Mover14jan2024.Width = Math.Min(this.ClientSize.Width, 1000);

            if (counter % 20 == 0)
            {
                Mover14jan2024.Width++;
                Mover14jan2024.Height++;
                this.g = this.CreateGraphics();
            }
            this.ClientSize = new Size(Mover14jan2024.Width, Mover14jan2024.Height);

            m1.Update();
            m1.Draw(this.g);

            m2.Update();
            m2.Draw(this.g);

            counter++;
        }
    }
}