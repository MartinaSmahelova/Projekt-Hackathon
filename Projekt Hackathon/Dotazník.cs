using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Projekt_Hackathon
{
    class Dotazník
    {
        public Dotazník()
        {

        }

        public Image NahrajZmensenyObrazekWink()
        {
            return Properties.Resources.small_wink;
        }

        public Image NahrajZmensenyObrazekSmile()
        {
            return Properties.Resources.smale_smile;
        }

        public Image NahrajZmensenyObrazekNeutral()
        {
            return Properties.Resources.small_neutral;
        }

        public Image NahrajZmensenyObrazekSad()
        {
            return Properties.Resources.small_sad;
        }

        public Image NahrajZmensenyObrazekAngry()
        {
            return Properties.Resources.small__anger;
        }

        public String VypisCitat()
        {
            List<String> souborCitatu = new List<string>();
            string line;

            StreamReader nacitacCitatu = new StreamReader(@"C:\Users\marti\source\repos\Projekt Hackathon\Projekt Hackathon\Resources\Citaty.txt");
            while ((line = nacitacCitatu.ReadLine()) != null)
            {
                souborCitatu.Add(line);
            }

            Random random = new Random();
            int nahodneCislo = random.Next(souborCitatu.Count());
            nacitacCitatu.Close();

            return souborCitatu[nahodneCislo].Replace(";","\n");

        }
    }


}
