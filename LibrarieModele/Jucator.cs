using LibrarieModele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPIU
{
   public class Jucator
    {
        // constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int INALTIME = 3;
        private const int POZITIE = 4;

        // proprietati auto-implemented
        public int IdJucator { get; set; }
        public string numeJucator { get; set; }
        public string prenumeJucator { get; set; }
        public double inaltimeJucator { get; set; }
        public Pozitie_jucator pozitieJucator { get; set; }


        // Constructor implicit
        public Jucator()
        {
            numeJucator = prenumeJucator = string.Empty;
            inaltimeJucator = 0;
        }

        // Constructorul cu parametri
        public Jucator(int IdJucator, string numeJucator, string prenumeJucator, float inaltimeJucator) 
        {
            this.IdJucator = IdJucator;
            this.numeJucator = numeJucator;
            this.prenumeJucator = prenumeJucator;
            this.inaltimeJucator = inaltimeJucator;
        }

        // Constructorul care reprezinta o singure lnie dintr-un fisier text 

        public Jucator(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            this.IdJucator = Convert.ToInt32(dateFisier[ID]);
            this.numeJucator = dateFisier[NUME];
            this.prenumeJucator = dateFisier[PRENUME];
            this.inaltimeJucator = Convert.ToDouble(dateFisier[INALTIME]);
            this.pozitieJucator = (Pozitie_jucator)Enum.Parse(typeof(Pozitie_jucator), dateFisier[POZITIE]);
        }

        public string Info()
        {
            string info = $"Id: {IdJucator} Nume: {numeJucator ?? "Necunoscut"} Prenume: {prenumeJucator ?? "Necunoscut"} Inaltime: {inaltimeJucator:F2} Pozitie in teren: {pozitieJucator}";
            return info;
        }

        public string ConversieLaSir_PentruFisier()
        {
            string jucatorPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4:F2}{0}{5}",
             SEPARATOR_PRINCIPAL_FISIER,
             IdJucator.ToString(),
             numeJucator,
             prenumeJucator,
             inaltimeJucator,
             pozitieJucator);
            return jucatorPentruFisier;
        }
    }
}
