using System;
using NUnit.Framework;

namespace SortJaggedArrayLibrary.Tests
{
    [TestFixture]

    public class JaggedSortsTests
    {
        int[][] jaggedArray = new int[][]
        {
            new int[] { 1, 3, 5, 7, 9 },
            new int[] { 0, 2, 4, 6 },
            new int[] { 11, 22 }
        };
        
        [Test]

        public void SumOfRowSort_SortByRowSum_SotrtedArray()
        {
            int[][] expected = new int[][]
            {
                new int[] { 11, 22 },
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 0, 2, 4, 6 },
            };

            Helper(expected, false);
        }

        [Test]

        public void MaxRowValueSort_SortByMaxRowValue_SotrtedArray()
        {
            int[][] expected = new int[][]
            {
                new int[] { 0, 2, 4, 6 },
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 11, 22 }
            };

            Helper(expected, true);
        }

        [Test]

        public void MinRowValueSort_SortByMinRowValue_SotrtedArray()
        {
            int[][] expected = new int[][]
            {
                new int[] { 11, 22 },
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 0, 2, 4, 6 },
            };

            Helper(expected, false);
        }

        private void Helper(int[][] expected, bool mode)
        {
            int[][] localJagged = new int[jaggedArray.GetLength(0)][];

            Array.Copy(jaggedArray, localJagged, jaggedArray.Length);

            JaggedSorts.SumOfRowSort(ref localJagged, mode);

            Assert.AreEqual(expected, localJagged);
        }
    }
}
