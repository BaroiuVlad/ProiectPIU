using ProiectPIU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AsministrareJucatori_Memorie
    {
        private const int NR_MAX_JUCATORI = 50;

        private Jucator[] jucatori;
        private int nrJucatori;

        public AsministrareJucatori_Memorie()
        {
            jucatori = new Jucator[NR_MAX_JUCATORI];
            nrJucatori = 0;
        }

        public void AddJucator(Jucator jucator)
        {
            jucatori[nrJucatori] = jucator;
            nrJucatori++;
        }

        public Jucator[] GetJucatori(out int nrJucatori)
        {
            nrJucatori = this.nrJucatori;
            return jucatori;
        }

        public Jucator CautareDupaNume(string nume, string prenume)
        {
            int nrJucatori;
            Jucator[] jucatori = GetJucatori(out nrJucatori);

            foreach (var jucator in jucatori)
            {
                if(jucator != null && jucator.numeJucator == nume && jucator.prenumeJucator == prenume)
                {
                    return jucator;
                }
            }
            return null; 

        }
    }
}
