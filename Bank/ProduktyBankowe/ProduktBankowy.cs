﻿using Bank.Raporty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class ProduktBankowy : IRaportowalny
    {
        protected long id;
        protected Klient klient;
        protected DateTime dataUtworzenia;
        protected HistoriaProduktu historia;
        protected IModelOdsetek modelOdsetek;

        public ProduktBankowy() {
            this.historia = new HistoriaProduktu(this);
        }

        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

        public abstract Pieniadze DostepneSrodki();

        public Klient Klient()
        {
            return klient;
        }

        protected DateTime DataUtworzenia
        {
            get { return dataUtworzenia; }
            set { dataUtworzenia = value; }
        }

        public void WyswietlHistorie()
        {
            historia.Wyswietl();
        }

        public Historia Historia()
        {
            return historia;
        }

        public void Raportuj(IRaport raport)
        {
            raport.ObsluzProduktBankowy(this);
        }
    }
}
