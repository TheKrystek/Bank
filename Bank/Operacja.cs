﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class Operacja: IOperacja
    {


        private DateTime dataWykonania;

        public DateTime DataWykonania
        {
            get { return dataWykonania; }
            set { dataWykonania = value; }
        }


        public abstract String Opis();

        public abstract bool Wykonaj();
    }
}
