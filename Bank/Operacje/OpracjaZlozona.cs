using Bank.Raporty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Klasa rozszerzająca operację 
    /// </summary>
    public abstract class OpracjaZlozona : OperacjaProsta
    {
        protected OperacjaProsta operacjaPierwsza, operacjaDruga;

        public override List<WpisWHistorii> Historia() {
            historia.Clear();
            historia.AddRange(operacjaPierwsza.Historia());
            historia.AddRange(operacjaDruga.Historia());
            return historia;
        }

        public void Raportuj(IRaport raport)
        {
            raport.ObsluzOperacje(operacjaPierwsza);
            raport.ObsluzOperacje(operacjaDruga);
        }
    }
}
