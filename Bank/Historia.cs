using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Historia
    {

        protected static List<WpisWHistorii> historia;

        public Historia() {
            historia = new List<WpisWHistorii>();
        }

        public bool Dodaj(Operacja operacja) {
            historia.Add(new WpisWHistorii(operacja.Klient(),operacja));
            return true;
        }

        public void Wyswietl() {

            Console.WriteLine("+++HISTORIA+++");
            foreach (var operacja in historia)
            {
                Console.WriteLine(operacja);
            }
        }

    } 
}
