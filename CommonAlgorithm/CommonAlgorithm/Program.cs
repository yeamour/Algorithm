using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 5, 8, 0, 4, 2, 7, 6, 1, 9, 3 };
            List<int> lData = new List<int>() { 5, 8, 0, 4, 2, 7, 6, 1, 9, 3 };
            CommonSort.QuickSort(data);
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }
            Console.ReadLine();
        }
    }
    
    public class CommonSort
    {
        public static bool BubbleSort(int[] data)
        {
            if (data == null || data.Length < 2)
            {
                return false;
            }
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        Exchange(data, j, j + 1);
                    }
                }
            }
            return true;
        }

        public static bool SelectionSort(int[] data)
        {
            if(data == null || data.Length < 2)
            {
                return false;
            }
            for (int i = 0; i < data.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[min] > data[j])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Exchange(data, min, i);
                }
            }
            return true;
        }

        public static bool InsertionSort(int[] data)
        {
            if (data == null || data.Length < 2)
            {
                return false;
            }
            for (int i = 1; i < data.Length; i++)
            {
                int num = data[i];
                int j = i - 1;
                while ( j >= 0 && data[j] > num)
                {
                    data[j + 1] = data[j];
                    j--;
                }
                data[j + 1] = num;
            }
            return true;
        }

        public static bool BinaryInsertionSort(int[] data)
        {
            if (data == null || data.Length < 2)
            {
                return false;
            }
            int num, left, right, middle;
            for (int i = 1; i < data.Length; i++)
            {
                num = data[i];
                left = 0;
                right = i - 1;
                while (left <= right)
                {
                    middle = (left + right) / 2;
                    if (data[middle] > num)
                    {
                        right = middle - 1;
                    }
                    else
                        left = middle + 1;
                }
                for (int j = i - 1; j >= left; j--)
                {
                    data[j + 1] = data[j];
                }
                data[left] = num;
            }
            return true;
        }

        public static bool ShellSort(int[] data)
        {
            if (data == null || data.Length < 2)
            {
                return false;
            }
            int step = 0;
            while (step < data.Length)
            {
                step = step * 3 + 1;
            }
            while (step >= 1)
            {
                for (int i = step; i < data.Length; i++)
                {
                    int num = data[i];
                    int j = i - step;
                    while (j >= 0 && data[j] > num)
                    {
                        data[j + step] = data[j];
                        j -= step;
                    }
                    if (i != j + step)
                    {
                        data[j + step] = num;
                    }
                }
                step = (step - 1) / 3;
            }
            
            return true;
        }

        public static bool MergeSort(int[] data)
        {
            if (data == null || data.Length < 2)
            {
                return false;
            }
            leftCache = new int[data.Length / 2 + 2];
            rightCache = new int[data.Length / 2 + 1];
            MergeSortSplit(data, 0, data.Length - 1);
            return true;
        }
        private static void MergeSortSplit(int[] data, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSortSplit(data, left, middle);
                MergeSortSplit(data, middle + 1, right);
                Merge(data, left, middle, right);
            }
        }
        static int[] leftCache;
        static int[] rightCache;
        private static void  Merge(int[] data, int left, int middle, int right)
        {
            int leftLength = middle - left + 1;
            int rightLength = right - middle;
            for (int i = 0; i < leftLength; i++)
            {
                leftCache[i] = data[left + i];
            }
            for (int j = 0; j < rightLength; j++)
            {
                rightCache[j] = data[middle + 1 + j];
            }
            leftCache[leftLength] = int.MaxValue;
            rightCache[rightLength] = int.MaxValue;

            int leftIdx = 0;
            int rightIdx = 0;
            for (int k = left; k <= right; k++)
            {
                if (rightCache[rightIdx] < leftCache[leftIdx])
                {
                    data[k] = rightCache[rightIdx];
                    rightIdx++;
                }
                else
                {
                    data[k] = leftCache[leftIdx];
                    leftIdx++;
                }
            }
        }

        public static bool HeapSort(List<int> data)
        {
            if (data == null || data.Count < 2)
            {
                return false;
            }
            data.Add(data[0]);
            data[0] = -1;
            for (int i = 2; i < data.Count; i++)
            {
                SiftUp(data, i);
            }
            for (int j = data.Count - 1; j > 1; j--)
            {
                Exchange(data, 1, j);
                SiftDown(data, j - 1);
            }
            return true;
        }
        private static void SiftUp(List<int> data, int idx)
        {
            int p = idx / 2;
            while (idx > 1 && data[idx] > data[p])
            {
                Exchange(data, idx, p);
                idx = p;
                p = idx / 2;
            }
        }
        private static void SiftDown(List<int> data, int idx)
        {
            int child;
            for (int i = 1; (child = i * 2) <= idx; i = child)
            {
                if (child + 1 <= idx && data[child + 1] > data[child])
                {
                    child++;
                }
                if (data[i] >= data[child])
                {
                    break;
                }
                Exchange(data, i, child);
            }
        }
        public static bool QuickSort(int[] data)
        {
            if (data == null || data.Length < 2)
            {
                return false;
            }
            QuickSort(data, 0, data.Length - 1);
            return true;
        }
        private static void QuickSort(int[] data, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int m = left;
            for (int i = left + 1; i <= right; i++)
            {
                if (data[i] < data[left])
                {
                    Exchange(data, i, ++m);
                }
            }
            Exchange(data, left, m);
            QuickSort(data, left, m - 1);
            QuickSort(data, m + 1, right);
        }

        private static void Exchange(int[] data, int i, int j)
        {
            int tmp = data[i];
            data[i] = data[j];
            data[j] = tmp;
        }
        private static void Exchange(List<int> data, int i, int j)
        {
            int tmp = data[i];
            data[i] = data[j];
            data[j] = tmp;
        }
    }

}
