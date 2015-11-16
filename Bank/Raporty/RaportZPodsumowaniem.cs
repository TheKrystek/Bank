using Bank.Raporty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Raporty
{
    /// <summary>
    /// Przykładowy raport listujący wpisy i obliczajacy sume w podsumowanu
    /// dla danej waluty i klienta
    /// </summary>
    public class RaportZPodsumowaniem : IRaport
    {
        // Wykorzystaj raport srednia
        SredniaKwota sredniaKwota;

        string naglowek, podsumowanie;
        List<string> wpisy;

        int licznik = 1;

        public RaportZPodsumowaniem(Pieniadze.Waluty waluta)
        {
            wpisy = new List<string>();
            sredniaKwota = new SredniaKwota(waluta);
        }

        public void ObsluzHistorie(WpisWHistorii historia)
        {
            sredniaKwota.ObsluzHistorie(historia);
            string wiersz = string.Format("{0}.\tProdukt: {1}, Operacja: {2} Kwota: {3}", licznik++, historia.Produkt.GetType().Name, historia.Operacja.GetType().Name, historia.Pieniadze);
            wpisy.Add(wiersz);        
        }

        public void ObsluzOperacje(IOperacja operacja)
        {
            throw new NotImplementedException();
        }

        public void ObsluzKlienta(Klient klient)
        {
            if (string.IsNullOrEmpty(naglowek)) {
                naglowek = string.Format("Raport klienta: {0}",klient);
            }

            foreach (var wpis in klient.Historia().Wpisy())
            {
                ObsluzHistorie(wpis);
            }
        }

        public void ObsluzProduktBankowy(ProduktBankowy produkt)
        {
            throw new NotImplementedException();
        }

        public string Wynik()
        {
            // Wygeneruj raport skladowy z suma i srednia
            sredniaKwota.Wynik();

            // Zbuduj raport ze string buildera
            StringBuilder s = new StringBuilder();
            podsumowanie = string.Format("\tSuma {0}, Srednia {1}", sredniaKwota.Suma, sredniaKwota.Srednia);
            s.AppendLine(naglowek);

            // Dodaj kolejne wpisy
            foreach (var wpis in wpisy)
                s.AppendLine(wpis);

            // Dodaj podsumowanie
            s.AppendLine(podsumowanie);
            return s.ToString();
        }
    }
}
