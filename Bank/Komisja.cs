using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public interface Izba
    {
        void Wykonaj();

        void RejestrujBank(Bank bank);

        void PrzyjmijPrzelewy(Bank bank, PaczkaPrzelewow paczka);
    }
}
