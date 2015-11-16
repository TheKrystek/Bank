using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Raporty
{
    class GeneratorRaportow
    {

        #region Historia
        public static bool Generuj(IRaport raport, WpisWHistorii wpis)
        {
            if (raport == null || wpis == null)
                return false;

            wpis.Raportuj(raport);
            return true;
        }

        public static bool Generuj(IRaport raport, Historia historia)
        {
            if (raport == null || historia == null)
                return false;
            foreach (var wpis in historia.Wpisy())
                Generuj(raport, wpis);
            return true;
        }
        #endregion

        #region Klient
        public static bool Generuj(IRaport raport, Klient klient)
        {
            if (raport == null || klient == null)
                return false;

            klient.Raportuj(raport);
            return true;
        }

        public static bool Generuj(IRaport raport, IEnumerable<Klient> klienci)
        {
            if (raport == null || klienci == null)
                return false;
            foreach (var klient in klienci)
                Generuj(raport, klient);
            return true;
        }
        #endregion


        #region Operacja
        public static bool Generuj(IRaport raport, IOperacja operacja)
        {
            if (raport == null || operacja == null)
                return false;
            operacja.Raportuj(raport);
            return true;
        }

        public static bool Generuj(IRaport raport, IEnumerable<IOperacja> operacje)
        {
            if (raport == null || operacje == null)
                return false;
            foreach (var operacja in operacje)
                Generuj(raport, operacja);
            return true;
        }
        #endregion


        #region Produkt bankowy
        public static bool Generuj(IRaport raport, ProduktBankowy produkt)
        {
            if (raport == null || produkt == null)
                return false;

            produkt.Raportuj(raport);
            return true;
        }

        public static bool Generuj(IRaport raport, IEnumerable<ProduktBankowy> produkty)
        {
            if (raport == null || produkty == null)
                return false;
            foreach (var operacja in produkty)
                Generuj(raport, operacja);
            return true;
        }


        #endregion

    }
}
