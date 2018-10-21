using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortJaggedArrayLibrary
{
    delegate bool Comparator(SingleRow firstArg, SingleRow secondArg);
    public static class JaggedSorts
    {
        static Comparator solver = null;
        static SingleRow[] keysArray = null;
        public static void SumOfRowSort(ref int[][] jaggedArray, bool mode)
        {
            keysArray = new SingleRow[jaggedArray.GetLength(0)];
            SumRowValue(jaggedArray);
            SetSortMode(mode);
            BubleSort.Sort(ref keysArray, solver);
            ArraySwapRows(ref jaggedArray);
        }
        public static void MaxRowValueSort(ref int[][] jaggedArray, bool mode)
        {
            keysArray = new SingleRow[jaggedArray.GetLength(0)];
            MaxRowValue(jaggedArray);
            SetSortMode(mode);
            BubleSort.Sort(ref keysArray, solver);
            ArraySwapRows(ref jaggedArray);
        }
        public static void MinRowValueSort(ref int[][] jaggedArray, bool mode)
        {
            keysArray = new SingleRow[jaggedArray.GetLength(0)];
            MinRowValue(jaggedArray);
            SetSortMode(mode);
            BubleSort.Sort(ref keysArray, solver);
            ArraySwapRows(ref jaggedArray);
        }
        private static void SumRowValue(int[][] jaggedArray)
        {
            for(int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                keysArray[i].row = jaggedArray[i];
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    keysArray[i].key += jaggedArray[i][j];
                }
            }
        }
        private static void MaxRowValue(int[][] jaggedArray)
        {
            int maxValue = 0;
            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                maxValue = jaggedArray[i][0];
                keysArray[i].row = jaggedArray[i];
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (maxValue < jaggedArray[i][j])
                    {
                        maxValue = jaggedArray[i][j]; 
                    }
                }
                keysArray[i].key = maxValue;
            }
        }
        private static void MinRowValue(int[][] jaggedArray)
        {
            int minValue = 0;
            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                minValue = jaggedArray[i][0];
                keysArray[i].row = jaggedArray[i];
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (minValue > jaggedArray[i][j])
                    {
                        minValue = jaggedArray[i][j];
                    }
                }
                keysArray[i].key = minValue;
            }
        }
        private static void ArraySwapRows(ref int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                jaggedArray[i] = keysArray[i].row;
            }
        }
        private static void SetSortMode(bool mode)
        {
            if (mode)
                solver = AscendingSortRules;
            else
                solver = DescendingSortRules;
        }
        private static bool AscendingSortRules(SingleRow firstArg, SingleRow secondArg)
        {
            if (firstArg.key > secondArg.key)
                return true;
            else
                return false;
        }
        private static bool DescendingSortRules(SingleRow firstArg, SingleRow secondArg)
        {
            if (firstArg.key > secondArg.key)
                return false;
            else
                return true;
        }     
    }
    internal static class BubleSort
    {
        public static void Sort(ref SingleRow[] array, Comparator solver)
        {
            if (array == null)
                throw new ArgumentNullException("Object cannot be null!");
            SortLogics(ref array, 0, array.Length, solver);
        }
        public static void Sort(ref SingleRow[] array, int startPoint, int endPoint, Comparator solver)
        {
            if (array == null)
                throw new ArgumentNullException("Object cannot be null!");
            SortLogics(ref array, startPoint, endPoint, solver);
        }
        private static void SortLogics(ref SingleRow[] array, int startPoint, int endPoint, Comparator solver)
        {
            for (int i = startPoint; i < endPoint; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (solver(array[j], array[j + 1]))
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
        private static void Swap(ref SingleRow firstArg, ref SingleRow secondArg)
        {
            SingleRow tmpArg = firstArg;
            firstArg = secondArg;
            secondArg = tmpArg;
        }
    }
    internal struct SingleRow
    {
        public int key;
        public int[] row;
    }
}
