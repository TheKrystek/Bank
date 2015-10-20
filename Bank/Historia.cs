using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Historia
    {

        public List<Operacja> historia;

        public Historia() {
            historia = new List<Operacja>();
        }

        public bool Dodaj(Operacja operacja) {
            historia.Add(operacja);
            return true;
        }

        public void Wyswietl() {

            Console.WriteLine("+++HISTORIA+++");
            foreach (var operacja in historia)
            {
                Console.WriteLine(" [{0}] {1}",operacja.DataWykonania,operacja.Opis());
            }
   
        }

    } 
}
