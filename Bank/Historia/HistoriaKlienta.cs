﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    /// <summary>
    /// Klasa pełnomocnik. 
    /// Udostępnia klientowi historię wyłącznie jego operacji
    /// </summary>
    public class HistoriaKlienta : Historia
    {

        private Klient klient;

        public HistoriaKlienta(Klient klient)
        {
            this.klient = klient;
        }

        public bool Dodaj(OperacjaProsta operacja)
        {
            return false;
        }

        public override IEnumerable<WpisWHistorii> Wpisy()
        {
            return historia.Where(o => o.Klient == klient);
        }

        public new void Wyswietl()
        {
            Console.WriteLine("+++HISTORIA {0} +++", klient.ToString().ToUpper());
            foreach (var operacja in Wpisy())
                Console.WriteLine(operacja);
        }
    }
}
