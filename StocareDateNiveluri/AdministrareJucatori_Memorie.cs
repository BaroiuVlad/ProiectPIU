
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectPIU;

namespace StocareDateNiveluri
{
    public class AdministrareJucatori_Memorie
    {
        private Jucator[] jucatori;
        private int nrJucatori;

        private const int nr_max_jucatori = 50;

        public AdministrareJucatori_Memorie()
        {
            jucatori = new Jucator[nr_max_jucatori];
            nrJucatori = 0;
            
        }

        public void AdaugareJucator(Jucator jucator)
        {
            jucatori[nrJucatori] = jucator;
            nrJucatori++;
        }

        public Jucator[] GetJucators(out int nrJucatori)
        {
            nrJucatori = this.nrJucatori;
            return jucatori;
        }

        public static void IdentificareDupaNume(Jucator jucator)
        {
            Console.Write("Introduceti un nume:");
            string nume1 = Console.ReadLine();

            if (nume1 == jucator.nume)
            {
                Console.WriteLine($"Inaltimea Jucatorului {jucator.nume} este {jucator.inaltime}");
            }
            else
            {
                Console.WriteLine("Numele introdus nu corespunde");
            }
        }

    }
}
