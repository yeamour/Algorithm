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
            CommonSort.InsertionSort(data);
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

        private static void Exchange(int[] data, int i, int j)
        {
            int tmp = data[i];
            data[i] = data[j];
            data[j] = tmp;
        }
    }

}
