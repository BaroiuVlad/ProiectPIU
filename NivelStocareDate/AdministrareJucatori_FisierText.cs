using ProiectPIU;
using System;

using System.IO;


namespace NivelStocareDate
{
    public class AdministrareJucatori_FisierText
    {
        private const int NR_MAX_JUCATORI = 50;
        private string numeFisier;

        public AdministrareJucatori_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;

            string director = Path.GetDirectoryName(numeFisier);
            if (!Directory.Exists(director))
            {
                Directory.CreateDirectory(director);
            }

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

        public Jucator[] GetJucatori(out int nrJucatori)
        {
            Jucator[] jucatori = new Jucator[NR_MAX_JUCATORI];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrJucatori = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    jucatori[nrJucatori++] = new Jucator(linieFisier);
                }
            }
            Array.Resize(ref jucatori, nrJucatori);

            return jucatori;
        }

        public Jucator CautareDupaNume(string nume, string prenume)
        {
            int nrJucatori;
            Jucator[] jucatori = GetJucatori(out nrJucatori);

            foreach (var jucator in jucatori)
            {
                if (jucator != null && jucator.numeJucator == nume && jucator.prenumeJucator == prenume)
                {
                    return jucator;
                }
            }
            return null;

        }
    }
}
