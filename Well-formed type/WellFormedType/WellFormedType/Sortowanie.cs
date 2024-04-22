#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellFormedType
{
    public static class Sortowanie 
    {
        public static void Sortuj<T>(this IList<T> lista) where T : IComparable<T>
        {
            int n = lista.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (lista[i].CompareTo(lista[i + 1]) > 0)
                        lista.SwapElements(i, i + 1);
                }
                n--;
            }
            while (n > 1);
        }

        public static void Sortuj<T>(this IList<T> lista, IComparer<T> comparer) where T : IComparable<T>
        {
            int n = lista.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (comparer.Compare(lista[i], lista[i + 1]) > 0)
                        lista.SwapElements(i, i + 1);
                }
                n--;
            }
            while (n > 1);
        }

        public static void Sortuj<T>(this IList<T> lista, Comparison<T> comparison ) where T : IComparable<T>
        {
            int n = lista.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (comparison(lista[i], lista[i + 1]) > 0)
                        lista.SwapElements(i, i + 1);
                }
                n--;
            }
            while (n > 1);
        }

        static void SwapElements<T>(this IList<T> list, int firstIndex, int secondIndex) where T : IComparable<T>
        {
            Contract.Requires(list != null);
            Contract.Requires(firstIndex >= 0 && firstIndex < list.Count);
            Contract.Requires(secondIndex >= 0 && secondIndex < list.Count);

            if (firstIndex == secondIndex) return;

            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        //the function serves testing purposes and is equipped with respective debugging control output statements
         
        //public static void Sortuj<T>(this IList<T> lista) where T : IComparable<T>
        //{
        //    int n = lista.Count;
        //    do
        //    {
        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            //Console.WriteLine("i = " + i + " ; i - 1 = " +  (i + 1));
        //            //Console.WriteLine("lista[i] = " + lista[i] + " ; lista[i - 1] = " + lista[i + 1]);
        //            //Console.Write($"---is {lista[i]} > then {lista[i + 1]} ?");
        //            if (lista[i].CompareTo(lista[i + 1]) > 0)
        //            {
        //                //Console.WriteLine(" Yes"); Console.WriteLine();
        //                lista.SwapElements(i + 1, i);
        //            }
        //            else
        //            {
        //                //Console.WriteLine(" No"); Console.WriteLine();
        //            }
        //        }
        //        n--;
        //        //Console.WriteLine("n decremented by 1: n = " + n); Console.WriteLine();
        //    }
        //    while (n > 1);
        //}        
    }
}