#nullable disable

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WellFormedType
{
    public class Pracownik : IEquatable<Pracownik>, IComparable<Pracownik>
    {

        private string _nazwisko;
        private DateTime _dataZatrudnienia;
        private decimal _wynagrodzenie;

        public string Nazwisko
        {
            get => _nazwisko;
            set
            {
                _nazwisko = value.Trim();
            }
        }

        public DateTime DataZatrudnienia
        {
            get => _dataZatrudnienia;
            set
            {
                if (value > DateTime.Today) throw new ArgumentException("100");
                _dataZatrudnienia = value;
            }
        }

        public decimal Wynagrodzenie
        {
            get => _wynagrodzenie;
            set
            {
                if (value < 0) _wynagrodzenie = 0;
                _wynagrodzenie = value;
            }
        }

        public int CzasZatrudnienia
        {
            get
            {
                return (DateTime.Today.Year - DataZatrudnienia.Year) * 12 +
                        (DateTime.Today.Month - DataZatrudnienia.Month) +
                        (DateTime.Today.Day < DataZatrudnienia.Day ? -1 : 0);
            }
        }

        public override string ToString()
        {
            return $"({Nazwisko}, {DataZatrudnienia:d MMM yyyy:}({CzasZatrudnienia}), {Wynagrodzenie} PLN)";
        }

        public override int GetHashCode() =>
            (Nazwisko, DataZatrudnienia, Wynagrodzenie).GetHashCode();


        public bool Equals(Pracownik other)
        {
            if (other == null) return false;
            if (Object.ReferenceEquals(this, other)) return true;

            return (Nazwisko == other.Nazwisko &&
                    DataZatrudnienia == other.DataZatrudnienia &&
                    Wynagrodzenie == other.Wynagrodzenie);
        }

        public override bool Equals(object obj)
        {
            if (obj is Pracownik pracownik)
                return Equals(pracownik);
            else
                return false;
        }

        public static bool Equals(Pracownik some, Pracownik other)
        {
            if (some is null && other is null) return true;
            if (some is null) return false;
            
            return some.Equals(other);
        }

        public static bool operator == (Pracownik some, Pracownik other) => 
            Equals(some, other);

        public static bool operator != (Pracownik some, Pracownik other) => 
            !Equals(some, other);

        public int CompareTo(Pracownik other)
        {
            if (other is null) return 1;
            if (this.Equals(other)) return 0;

            if (this.Nazwisko != other.Nazwisko)
            {
                if (StringComparer(this.Nazwisko, other.Nazwisko) == -1) return -1;
                else if (StringComparer(this.Nazwisko, other.Nazwisko) == 1) return 1;
            }
            else if (this.DataZatrudnienia != other.DataZatrudnienia)
            {
                if (this.DataZatrudnienia < other.DataZatrudnienia) return -1;
                else if (this.DataZatrudnienia > other.DataZatrudnienia) return 1;
            }
            else if (this.Wynagrodzenie != other.Wynagrodzenie)
            {
                if (this.Wynagrodzenie < other.Wynagrodzenie) return -1;
                else if (this.Wynagrodzenie > other.Wynagrodzenie) return 1;
            }
            return 0;

            static int StringComparer(string given, string other)
            {
                
                string shorter;

                if (given.Length < other.Length) shorter = given;
                else shorter = other;

                for (int i = 0; i < shorter.Length; i++)
                {
                    if (given[i] < other[i]) return -1;
                    if (given[i] > other[i]) return 1;
                }
                if (other.Length > given.Length) return 1;
                return 0;
            }
        }

        public Pracownik(string nazwisko,DateTime dataZatrudnienia, decimal wynagrodzenie)
        {
            Nazwisko = nazwisko;
            DataZatrudnienia = dataZatrudnienia;
            Wynagrodzenie = wynagrodzenie;
        }

        public Pracownik()
        {
            Nazwisko = "Anonim";
            DataZatrudnienia = DateTime.Today;
            Wynagrodzenie = 0;
        }

        


    }
}
