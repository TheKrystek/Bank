using Bank.Raporty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Interfejs definiujący operacje
    /// </summary>
    public interface IOperacja : IRaportowalny
    {
        bool Wykonaj();
        List<WpisWHistorii> Historia();
        string Opis();
        DateTime DataWykonania { get; set; }

        void Raportuj(IRaport raport);
    }
}
