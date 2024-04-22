#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellFormedType
{
    public class WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer : IComparer<Pracownik>
    {
        public int Compare(Pracownik one, Pracownik other)
        {
            if (one is null && other is null) return 0;
            if (one is null && !(other is null)) return -1;
            if (!(one is null) && other is null) return +1;

            if (one.CzasZatrudnienia != other.CzasZatrudnienia)
                return (one.CzasZatrudnienia).CompareTo(other.CzasZatrudnienia); 

            return one.Wynagrodzenie.CompareTo(other.Wynagrodzenie);
        }
    }
}
