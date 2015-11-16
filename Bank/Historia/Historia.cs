using Bank.Raporty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Historia
    {

        protected static List<WpisWHistorii> historia;

        public Historia() {
            if (historia == null)
            historia = new List<WpisWHistorii>();
        }

        public bool Dodaj(IOperacja operacja) {
            foreach (var zdarzenie in operacja.Historia())
                zdarzenie.Zapisz();
            
            historia.AddRange(operacja.Historia());
            return true;
        }

        public void Wyswietl() {
            Console.WriteLine("+++HISTORIA+++");
            foreach (var operacja in historia)
                Console.WriteLine(operacja);
        }

        public virtual IEnumerable<WpisWHistorii> Wpisy() {
            return historia;
        }

    } 
}
