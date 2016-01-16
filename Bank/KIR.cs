using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class KIR : Izba
    {
        Dictionary<int, Bank> banki = new Dictionary<int, Bank>();
        Dictionary<Bank, PaczkaPrzelewow> przelewyWychodzace = new Dictionary<Bank, PaczkaPrzelewow>();

        public void RejestrujBank(Bank bank)
        {
            bank.DodajKomisje(this);
            banki.Add(bank.Kod, bank);
            przelewyWychodzace.Add(bank, new PaczkaPrzelewow());
        }

        public void PrzyjmijPrzelewy(Bank bank, PaczkaPrzelewow paczka)
        {
            paczka.ustawBank(bank);
            // Przejrzyj paczke otrzymana z banku i dodaj do odpowiednich list
            foreach (var przelew in paczka.Przelewy)
            {
                Bank bankDocelowy = okreslBank(przelew.id);
                if (bankDocelowy == null)
                    throw new NullReferenceException("Nieznany bank");

                przelewyWychodzace[bankDocelowy].Dodaj(przelew);
            }
        }

        public void Wykonaj()
        {
            foreach (KeyValuePair<Bank, PaczkaPrzelewow> p in przelewyWychodzace)
                if (p.Value.Przelewy.Count > 0)
                {
                    wysllijPaczke(p.Key, p.Value);
                    przelewyWychodzace[p.Key].Przelewy.Clear();
                }
        }

        public void wysllijPaczke(Bank bank, PaczkaPrzelewow paczka)
        {
            bank.OdbierzPrzelewy(paczka);
        }


        private Bank okreslBank(int idKonta)
        {
            int kodBanku = idKonta / Const.magicNumber;
            if (banki.ContainsKey(kodBanku))
                return banki[kodBanku];
            return null;
        }

        public Dictionary<int, Bank> Banki
        {
            get
            {
                return banki;
            }

            set
            {
                banki = value;
            }
        }
    }
}
