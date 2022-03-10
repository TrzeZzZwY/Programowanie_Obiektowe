using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_01
{
    public class Ułamek : IEquatable<Ułamek>, IComparable<Ułamek>
    {
        private int licznik;
        private int mianownik;
        public int Licznik { get => licznik; }
        public int Mianownik { get => Mianownik; }
        public Ułamek()
        {
            licznik = default;
            mianownik = default;
        }
        public Ułamek(int licznik,int mianownik)
        {
            this.licznik = licznik;
            this.mianownik = mianownik;
        }

        public Ułamek(Ułamek obj)
        {
            licznik = obj.licznik;
            mianownik = obj.mianownik;
        }

        public int RoundUp() => (int)Math.Ceiling((double)this.licznik / this.mianownik);
        public int RoundDown() => (int)Math.Floor((double)this.licznik / this.mianownik);

        public override string ToString() => $"licznik: {licznik}, ,mianownik {mianownik}";

        public bool Equals(Ułamek other) => (double)this.licznik / this.mianownik == (double)other.licznik / other.mianownik;


        public int CompareTo(Ułamek other)
        {
            if (this.Equals(other))
                return 0;
            if ((double)this.licznik / this.mianownik < (double)other.licznik / other.mianownik)
                return -1;
            else
                return 1;

        }

        public static Ułamek operator +(Ułamek a, Ułamek b)
        {
            if(a.mianownik == b.mianownik)
                return new Ułamek(a.licznik + b.licznik, a.mianownik);
            else
                return new Ułamek((a.licznik * b.mianownik) + (b.licznik * a.mianownik) , a.mianownik * b.mianownik);
        }
        public static Ułamek operator -(Ułamek a, Ułamek b)
        {
            if (a.mianownik == b.mianownik)
                return new Ułamek(a.licznik - b.licznik, a.mianownik);
            else
                return new Ułamek((a.licznik * b.mianownik) - (b.licznik * a.mianownik), a.mianownik * b.mianownik);
        }
        public static Ułamek operator *(Ułamek a, Ułamek b) => (new Ułamek(a.licznik * b.licznik, a.mianownik * b.mianownik));
        public static Ułamek operator /(Ułamek a, Ułamek b) => (new Ułamek(a.licznik * b.mianownik, a.mianownik * b.licznik));
    }
}
