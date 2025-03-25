using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NivelStocareDate;
using System.Runtime.ConstrainedExecution;
using LibrarieModele;
using System.Configuration;


namespace ProiectPIU
{
    class Program
    {
        static void Main()
        {

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            AdministrareJucatori_FisierText adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);

            Jucator jucatorNou = new Jucator();
            int nrJucatori = 0;

            adminJucatori.GetJucatori(out nrJucatori);

            string optiune;
            do
            {
                Console.WriteLine("C.Citire jucator de la tastatura");
                Console.WriteLine("I.Afisarea ultimului jucator introdus de la tastatura");
                Console.WriteLine("A.Afisare jucatori in fisier");
                Console.WriteLine("S.Salvare jucatori in fisier");
                Console.WriteLine("N.Cautare jucator dupa nume");
                Console.WriteLine("X. Inchidere program");
                

                Console.WriteLine("Alegeti o optiune:");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        jucatorNou = CitireJucatorTastatura();
                        Console.WriteLine("\n");
                        break;
                    case "I":
                        string ultimJucator = AfisareJucatorTastatura(jucatorNou);
                        Console.WriteLine(ultimJucator);
                        Console.WriteLine("\n");
                        break;
                    case "A":
                        Jucator[] jucatori = adminJucatori.GetJucatori(out nrJucatori);
                        AfisareJucatori(jucatori);
                        break;
                    case "S":
                        int idJucator = ++nrJucatori;
                        jucatorNou.IdJucator = idJucator;
                        adminJucatori.AddJucator(jucatorNou);
                        Console.WriteLine("Ultimul jucator introdus a fost salvat");
                        Console.WriteLine("\n");
                        break;
                    case "N":
                        Console.Write("Introduceti numele: ");
                        string numeC = Console.ReadLine();
                        Console.Write("Introduceti prenumele: ");
                        string prenumeC = Console.ReadLine();

                        Jucator gasit = adminJucatori.CautareDupaNume(numeC, prenumeC);
                        if ( gasit != null)
                        {
                            string infogasit = AfisareJucatorTastatura(gasit);
                            Console.WriteLine(infogasit);
                        }
                        else
                        {
                            Console.WriteLine("Jucatorul {0} {1} nu a fost gasit", numeC, prenumeC);
                        }
                        Console.WriteLine("\n");
                        break;
                    case "X":
                        return;

                    default:
                        Console.WriteLine("Optiune inexistenta");
                        Console.WriteLine("\n");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        public static Jucator CitireJucatorTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele:");
            string prenume = Console.ReadLine();

            Console.WriteLine("Introduceti inaltimea:");
            string valoare = Console.ReadLine();
            float.TryParse(valoare, out float val_inaltime);

            Jucator jucator = new Jucator(0,nume, prenume, val_inaltime);

            Console.WriteLine("Alegeti pozitia jucatorului:");
            Console.WriteLine(" 1 - Portar \n" +
                              "2 - Fundas \n" +      
                              "3 - Mijlocas \n" +       
                              "4 - Atacant \n" +       
                              "5 - Rezerva");
            int opt = Convert.ToInt32(Console.ReadLine());
            jucator.pozitieJucator = (Pozitie_jucator)opt;

            return jucator;
        }

        public static string AfisareJucatorTastatura(Jucator jucator)
        {
            string infoJucator = string.Format("Jucatorul cu id - ul {0} are numele {1} {2} si inaltimea {3:F2}. Pozitia acestuia este: {4}",
                jucator.IdJucator,
                jucator.numeJucator ?? " NECUNOSCUT ",
                jucator.prenumeJucator ?? " NECUNOSCUT ",
                jucator.inaltimeJucator,
                jucator.pozitieJucator);

            return infoJucator;
        }

        public static void AfisareJucatori(Jucator[] jucatori)
        {
            Console.WriteLine("Jucatorii sunt: ");

            foreach (Jucator jucator in jucatori)
            {
                string infoJucator = jucator.Info();
                Console.WriteLine(infoJucator);
            }
        }
        //test


    }
}
