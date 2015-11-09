using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Klasa pełnomocnik. 
    /// Udostępnia produktowi historię operacji.
    /// </summary>
   public class HistoriaProduktu : Historia
   {
        private ProduktBankowy produkt;

        public HistoriaProduktu(ProduktBankowy produkt)
        {
            this.produkt = produkt;
        }

        public new bool Dodaj(OperacjaProsta operacja) {
            return false;
        }

        public new void Wyswietl() {
            Console.WriteLine("+++HISTORIA {0} +++",produkt.ToString().ToUpper());
            foreach (var operacja in historia.Where(o => o.Produkt == produkt))
                Console.WriteLine(operacja);
        }
    } 
}
