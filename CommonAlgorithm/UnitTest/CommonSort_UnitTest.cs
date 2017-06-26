using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonAlgorithm;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class CommonSort_UnitTest
    {
        int[] data = new int[] { 5, 8, 0, 4, 2, 7, 6, 1, 9, 3 };
        int[] rightData = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        [TestMethod]
        public void BubbleSort_asc_true()
        {
            CommonSort.BubbleSort(data);
            Assert.IsTrue(Compare(data, rightData));
        }
        [TestMethod]
        public void SelectionSort_asc_true()
        {
            CommonSort.SelectionSort(data);
            Assert.IsTrue(Compare(data, rightData));
        }
        [TestMethod]
        public void InsertionSort_asc_true()
        {
            CommonSort.InsertionSort(data);
            Assert.IsTrue(Compare(data, rightData));
        }
        [TestMethod]
        public void BinaryInsertionSort_asc_true()
        {
            CommonSort.BinaryInsertionSort(data);
            Assert.IsTrue(Compare(data, rightData));
        }
        [TestMethod]
        public void ShellSort_asc_true()
        {
            CommonSort.ShellSort(data);
            Assert.IsTrue(Compare(data, rightData));
        }
        [TestMethod]
        public void MergeSort_asc_true()
        {
            CommonSort.MergeSort(data);
            Assert.IsTrue(Compare(data, rightData));
        }
        [TestMethod]
        public void HeapSort_asc_true()
        {
            List<int> listData = new List<int>() { 5, 8, 0, 4, 2, 7, 6, 1, 9, 3 };
            CommonSort.HeapSort(listData);
            listData.RemoveAt(0);
            Assert.IsTrue(Compare(listData.ToArray(), rightData));
        }
        
        bool Compare(int[] data, int[] rightData)
        {
            if (data == null || data.Length != rightData.Length)
            {
                return false;
            }
            for (int i = 0; i < rightData.Length; i++)
            {
                if (rightData[i] != data[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
