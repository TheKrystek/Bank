using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class HistoriaKlienta : Historia
    {

        private Klient klient;

        public HistoriaKlienta(Klient klient)
        {
            this.klient = klient;
        }

        public bool Dodaj(Operacja operacja) {
            return false;
        }

        public void Wyswietl() {
            Console.WriteLine("+++HISTORIA {0} +++",klient.ToString().ToUpper());
            foreach (var operacja in historia.Where(o => o.Klient == klient))
                Console.WriteLine(operacja);
        }

    } 
}
