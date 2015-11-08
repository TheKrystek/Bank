using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Raporty
{
    interface IRaportProdutkow : IRaport
    {
        void Odwiedz(ICollection<ProduktBankowy> produkty);
    }
}
