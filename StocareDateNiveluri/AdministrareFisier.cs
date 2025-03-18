using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectPIU;

namespace StocareDateNiveluri
{
    public class AdministrareFisier
    {
        private const int nr_max_jucatori = 50;
        private string numeFisier;

        public AdministrareFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // deschiderea fisierului in modul OpenOrCreate
            // se creeaza daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddJucator(Jucator jucator)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(jucator.ConversieLaSir_PentruFisier());
            }
        }




    }
}
