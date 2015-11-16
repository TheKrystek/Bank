using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Wartosc przechowywana jest w int i dzielona przez 100 dla uzyskania czesci ulamkowej
    /// </summary>
    public class Pieniadze : ICloneable
    {
        public enum Waluty
        {
            PLN, USD
        }

        private int wartosc;

        public int Wartosc
        {
            get { return wartosc; }
            set { wartosc = value; }
        }
        private Waluty waluta;

        public Waluty Waluta
        {
            get { return waluta; }
            set { waluta = value; }
        }
       
        public Pieniadze(int wartosc = 0, Waluty waluta = Waluty.PLN)
        {
            Wartosc = wartosc;
            Waluta = waluta;
        }

        public override string ToString()
        {
        
            return String.Format("{0},{1} {2}", Wartosc/100,Wartosc%100, Waluta);
        }

        /// <summary>
        /// Sprawdza czy waluty sa rózne
        /// </summary>
        /// <param name="pieniadze"></param>
        /// <returns></returns>
        public static bool RozneWaluty(Pieniadze p1, Pieniadze p2)
        {
            return (p1.Waluta != p2.Waluta);
        }

  
        public bool Dodaj(Pieniadze pieniadze)
        {
            if (RozneWaluty(this,pieniadze))
                return false;

            Wartosc += pieniadze.Wartosc;
            return true;
        }


        internal bool Odejmij(Pieniadze pieniadze)
        {
            if (RozneWaluty(this,pieniadze) && Wartosc >= pieniadze.Wartosc)
                return false;

            Wartosc -= pieniadze.Wartosc;
            return true;
        }

     


        #region Operatory
        public static Pieniadze operator +(Pieniadze p1, Pieniadze p2)
        {
            if (RozneWaluty(p1, p2))
                throw new RozneWalutyException("Waluty muszą być takie same!");

            return new Pieniadze(p1.Wartosc + p2.Wartosc, p1.Waluta);
        }

        public static Pieniadze operator -(Pieniadze p1, Pieniadze p2)
        {
            if (RozneWaluty(p1, p2))
                throw new RozneWalutyException("Waluty muszą być takie same!");

            if (p1.Wartosc < p2.Wartosc)
                throw new ArgumentException(String.Format("Wartosc {0} powinna być od {1}",p2,p1));

            return new Pieniadze(p1.Wartosc - p2.Wartosc, p1.Waluta);
        }

        public static bool operator <(Pieniadze p1, Pieniadze p2)
        {
            if (RozneWaluty(p1, p2))
                throw new RozneWalutyException("Waluty muszą być takie same!");

            return p1.Wartosc < p2.Wartosc;
        }


        public static bool operator <=(Pieniadze p1, Pieniadze p2)
        {
            if (RozneWaluty(p1, p2))
                throw new RozneWalutyException("Waluty muszą być takie same!");

            return p1.Wartosc <= p2.Wartosc;
        }

        public static bool operator >(Pieniadze p1, Pieniadze p2)
        {
            if (RozneWaluty(p1, p2))
                throw new RozneWalutyException("Waluty muszą być takie same!");

            return p1.Wartosc > p2.Wartosc;
        }


        public static bool operator >=(Pieniadze p1, Pieniadze p2)
        {
            if (RozneWaluty(p1, p2))
                throw new RozneWalutyException("Waluty muszą być takie same!");

            return p1.Wartosc >= p2.Wartosc;
        }


        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Pieniadze p = obj as Pieniadze;
            if ((Object)p == null)
                return false;

            return (Wartosc == p.Wartosc) && (Waluta == p.Waluta);
        }

        public bool Equals(Pieniadze p)
        {
            if ((object)p == null)
                return false;
            return (Wartosc == p.Wartosc) && (Waluta == p.Waluta);
        }

        public override int GetHashCode()
        {
            return Wartosc ^ Waluta.GetHashCode();
        }

        #endregion


        public object Clone()
        {
            return new Pieniadze(wartosc,waluta);
        }
    }
}
