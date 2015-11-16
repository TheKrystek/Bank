using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Raporty
{
    public interface IRaportowalny
    {
        void Raportuj(IRaport raport);
    }
}
