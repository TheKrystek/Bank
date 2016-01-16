using Bank.Raporty;
using System;

namespace Bank
{
    public class WpisWHistorii : IRaportowalny
    {
        private Pieniadze pieniadze;
        private Klient klient;
        private ProduktBankowy produkt;
        private IOperacja operacja;
        private Pieniadze saldoPrzed;
        private Pieniadze saldoPo;

        public WpisWHistorii(IOperacja operacja, ProduktBankowy produkt, Pieniadze pieniadze = null, Klient klient = null)
        {
            this.operacja = operacja;
            this.klient = klient;

            if (this.klient == null)
                this.klient = produkt.Klient();

            this.pieniadze = pieniadze.Clone() as Pieniadze;
            this.produkt = produkt;
            saldoPrzed = produkt.DostepneSrodki().Clone() as Pieniadze;
        }

        public Pieniadze Pieniadze
        {
            get { return pieniadze; }
        }


        public Klient Klient
        {
            get { return klient; }
        }

        public ProduktBankowy Produkt
        {
            get { return produkt; }
        }

        public IOperacja Operacja
        {
            get { return operacja; }
        }

        public void Zapisz() {
            saldoPo = produkt.DostepneSrodki().Clone() as Pieniadze;
        }

        public override string ToString()
        {
            return String.Format("[{0:dd.MM.yy HH:mm:ss}] {2}\r\n\tKwota operacji={1}\r\n\tSaldo przed: {3}\r\n\tSaldo po: {4}\r\n", operacja.DataWykonania, pieniadze, operacja.Opis(), saldoPrzed, saldoPo);
        }

        public void Raportuj(IRaport raport)
        {
            raport.ObsluzHistorie(this);
        }
    }
}
