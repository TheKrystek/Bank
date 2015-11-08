using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Raporty
{
    interface IRaportHistoryczny : IRaport
    {
        void Odwiedz(Historia historia);
    }
}
