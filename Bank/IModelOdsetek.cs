using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Przykładowy interfejs modelu odsetek
    /// Niestety nie mam pojęcia co wypadałoby jeszcze dodać tzn. na jakiej podstawie wyliczane są odestki
    /// </summary>
    public interface IModelOdsetek
    {
        double DajOprocentowania(int rata = 0);
        double DajKapitalizacje();

        Pieniadze Oblicz(Pieniadze kwota, int rata = 0);
    }
}
