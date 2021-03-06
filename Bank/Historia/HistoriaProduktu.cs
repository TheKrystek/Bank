﻿using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool Dodaj(OperacjaProsta operacja) {
            return false;
        }

        public override IEnumerable<WpisWHistorii> Wpisy()
        {
            return historia.Where(o => o.Produkt == produkt);
        }

        public new void Wyswietl() {
            Console.WriteLine("+++HISTORIA {0} +++",produkt.ToString().ToUpper());
            foreach (var operacja in Wpisy())
                Console.WriteLine(operacja);
        }
    } 
}
