using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Raporty
{
   public class RaportHistorycznyZliczajacy : IRaportHistoryczny
    {
        int liczbaWystapien = 0;
        Historia historia;

        public RaportHistorycznyZliczajacy(Historia historia)
        {
            this.historia = historia;
        }

        public void Odwiedz(Historia historia)
        {
            foreach (var item in historia.Wpisy())
            {
                liczbaWystapien++;
            }
        }

        public string Wynik()
        {
           
            return string.Format("Historia zawiera {0} wpisów");
        }

        public int LiczbaWpisow {
            get { return liczbaWystapien; }
        }



        public void Generuj()
        {
            Odwiedz(historia);
        }
    }
}
