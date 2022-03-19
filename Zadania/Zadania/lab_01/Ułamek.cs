using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_01
{
    /// <summary>
    /// Reprezentuje ułamek, przechowując licznik i mianownik.
    /// </summary>
    public class Ułamek : IEquatable<Ułamek>, IComparable<Ułamek>
    {
        private int licznik;
        private int mianownik;

        /// <summary>
        /// Zwraca licznik ułamka.
        /// </summary>
        public int Licznik { get => licznik;  }
        /// <summary>
        /// Zwraca mianownik ułamka.
        /// </summary>
        public int Mianownik { get => mianownik; }
        /// <summary>
        /// Konstruntor domyślny. Tworzy Ułamek w formie licznik = 0, mianownik = 0.
        /// </summary>
        public Ułamek()
        {
            licznik = default;
            mianownik = default;
        }
        /// <summary>
        /// Tworzy ułamek na podstawie przekazanego licznika i mianownika.
        /// </summary>
        /// <param name="licznik">Wartość licznka.</param>
        /// <param name="mianownik">Wartość mianownika.</param>
        public Ułamek(int licznik ,int mianownik)
        {
            this.licznik = licznik;
            this.mianownik = mianownik;
        }
        /// <summary>
        /// Tworzy ułamek na podstawie przekazanego obieku.
        /// </summary>
        /// <param name="obj">Przekazywany obiekt typu Ułamek.</param>
        public Ułamek(Ułamek obj)
        {
            licznik = obj.licznik;
            mianownik = obj.mianownik;
        }

        /// <summary>
        /// Zaokrągla ułamek w górę.
        /// </summary>
        /// <returns>Pierwsza liczba całkowita, większa od ułamka</returns>
        public int RoundUp() => (int)Math.Ceiling((double)this.licznik / this.mianownik);
        /// <summary>
        /// Zaokrągla ułamek w dół.
        /// </summary>
        /// <returns>Pierwsza liczba całkowita, mniejsza od ułamka</returns>
        public int RoundDown() => (int)Math.Floor((double)this.licznik / this.mianownik);

        /// <summary>
        /// Konwertuje Ułamek na tekst.
        /// </summary>
        /// <returns>Test w formacie "licznik: {licznik}, ,mianownik {mianownik}"</returns>
        public override string ToString() => $"licznik: {licznik}, ,mianownik {mianownik}";
        /// <summary>
        /// Sprawdza czy dwa ułamki mają taką samą wartość.
        /// </summary>
        /// <param name="other">Drógi ułamek.</param>
        /// <returns>Prawdę jeśli dwa ułami mają taką samą wartość</returns>
        public bool Equals(Ułamek other) => (double)this.licznik / this.mianownik == (double)other.licznik / other.mianownik;

        /// <summary>
        /// Porównuje ze sobą dwa ułamki.
        /// </summary>
        /// <param name="other">Drógi ułamek.</param>
        /// <returns>1 jeśli ułamnek jest większy, 0 jeśli są takie same, -1 jeśli jest mniejszy.</returns>
        public int CompareTo(Ułamek other)
        {
            if (this.Equals(other))
                return 0;
            if ((double)this.licznik / this.mianownik < (double)other.licznik / other.mianownik)
                return -1;
            else
                return 1;

        }
        /// <summary>
        /// Dodaje ze sobą dwa ułamki
        /// </summary>
        /// <param name="a">Ułamek a</param>
        /// <param name="b">Ułamek b</param>
        /// <returns>Sumę dwóch ułamków</returns>
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
