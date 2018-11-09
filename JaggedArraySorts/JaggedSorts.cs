using System;

namespace SortJaggedArrayLibrary
{
    internal delegate bool Comparator(SingleRow firstArg, SingleRow secondArg);

    public static class JaggedSorts
    {
        static Comparator solver = null;
        static SingleRow[] keysArray = null;

        /// <summary>
        /// Sort jagged array by sum of the row
        /// </summary>
        /// <param name="jaggedArray">Sortable array</param>
        /// <param name="mode">ASC | DESC mode</param>
        public static void SumOfRowSort(ref int[][] jaggedArray, bool mode)
        {
            keysArray = new SingleRow[jaggedArray.GetLength(0)];

            SumRowValue(jaggedArray);

            SetSortMode(mode);

            BubleSort.Sort(ref keysArray, solver);

            ArraySwapRows(ref jaggedArray);
        }

        /// <summary>
        /// Sort jagged array by max value of the row
        /// </summary>
        /// <param name="jaggedArray">Sortable array</param>
        /// <param name="mode">ASC | DESC mode</param>
        public static void MaxRowValueSort(ref int[][] jaggedArray, bool mode)
        {
            keysArray = new SingleRow[jaggedArray.GetLength(0)];

            MaxRowValue(jaggedArray);

            SetSortMode(mode);

            BubleSort.Sort(ref keysArray, solver);

            ArraySwapRows(ref jaggedArray);
        }


        /// <summary>
        /// Sort jagged array by max value of the row
        /// </summary>
        /// <param name="jaggedArray">Sortable array</param>
        /// <param name="mode">ASC | DESC mode</param>
        public static void MinRowValueSort(ref int[][] jaggedArray, bool mode)
        {
            keysArray = new SingleRow[jaggedArray.GetLength(0)];

            MinRowValue(jaggedArray);

            SetSortMode(mode);

            BubleSort.Sort(ref keysArray, solver);

            ArraySwapRows(ref jaggedArray);
        }

        /// <summary>
        /// Calculates Sum of each row and save it into keys array
        /// </summary>
        /// <param name="jaggedArray">Sirtable array</param>
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

        /// <summary>
        /// Calculates max element of row and save it into keys array
        /// </summary>
        /// <param name="jaggedArray">Sirtable array</param>
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

        /// <summary>
        /// Calculates min element of row and save it into keys array
        /// </summary>
        /// <param name="jaggedArray">Sirtable array</param>
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

        /// <summary>
        /// Custom swap method for put rows on the right place
        /// </summary>
        /// <param name="jaggedArray">Sorted array</param>
        private static void ArraySwapRows(ref int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                jaggedArray[i] = keysArray[i].row;
            }
        }

        /// <summary>
        /// Set ascending or descending sort mode
        /// </summary>
        /// <param name="mode">Sortable array</param>
        private static void SetSortMode(bool mode)
        {
            if (mode)
            {
                solver = AscendingSortRules;
            }
            else
            {
                solver = DescendingSortRules;
            }
        }

        /// <summary>
        /// Set ascending sort mode
        /// </summary>
        /// <param name="firstArg">First comparable object</param>
        /// <param name="secondArg">Second comparable object</param>
        /// <returns>True(firstArg > secondArg) or False(firstArg > secondArg)</returns>
        private static bool AscendingSortRules(SingleRow firstArg, SingleRow secondArg)
        {
            if (firstArg.key > secondArg.key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Set decscending sort mode
        /// </summary>
        /// <param name="firstArg">First comparable object</param>
        /// <param name="secondArg">Second comparable object</param>
        /// <returns>True(firstArg > secondArg) or False(firstArg > secondArg)</returns>
        private static bool DescendingSortRules(SingleRow firstArg, SingleRow secondArg)
        {
            if (firstArg.key > secondArg.key)
            {
                return false;
            }
            else
            {
                return true;
            }
        }     
    }

    internal static class BubleSort
    {
        /// <summary>
        /// Sort one-dimensional array by buble sort
        /// </summary>
        /// <param name="array">Sortable array</param>
        /// <param name="solver">Sort criteria</param>
        public static void Sort(ref SingleRow[] array, Comparator solver)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Object cannot be null!");
            }

            SortLogics(ref array, 0, array.Length, solver);
        }

        /// <summary>
        /// Sort one-dimensional array by buble sort in definite range
        /// </summary>
        /// <param name="array">Sortable array</param>
        /// <param name="startPoint">Point of beginning work sort algorithm</param>
        /// <param name="endPoint">Point of ending work sort algorithm</param>
        /// <param name="solver">Sort criteria</param>
        public static void Sort(ref SingleRow[] array, int startPoint, int endPoint, Comparator solver)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Object cannot be null!");
            }

            SortLogics(ref array, startPoint, endPoint, solver);
        }

        /// <summary>
        /// Main sort method of buble sort
        /// </summary>
        /// <param name="array">Sortable array</param>
        /// <param name="startPoint">Point of beginning work sort algorithm</param>
        /// <param name="endPoint">Point of ending work sort algorithm</param>
        /// <param name="solver">Sort criteria</param>
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

        /// <summary>
        /// Method that swap elements in sortable array
        /// </summary>
        /// <param name="firstArg">First argument</param>
        /// <param name="secondArg">Second argument</param>
        private static void Swap(ref SingleRow firstArg, ref SingleRow secondArg)
        {
            SingleRow tmpArg = firstArg;

            firstArg = secondArg;

            secondArg = tmpArg;
        }
    }

    /// <summary>
    /// Struct for comfortable using one-dimensional buble sort
    /// </summary>
    internal struct SingleRow
    {
        public int key;
        public int[] row;
    }
}
