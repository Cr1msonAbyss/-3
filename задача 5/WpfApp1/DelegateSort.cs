using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public delegate int[] SortDelegate(int[] data);

    public class Sorter
    {
        public static int[] BubbleSort(int[] data)
        {
            int n = data.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        // Swap
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
            return data;
        }

        public static int[] QuickSort(int[] data)
        {
            if (data.Length <= 1) return data;

            int pivot = data[data.Length / 2];
            var left = Array.FindAll(data, x => x < pivot);
            var middle = Array.FindAll(data, x => x == pivot);
            var right = Array.FindAll(data, x => x > pivot);

            return Combine(QuickSort(left), middle, QuickSort(right));
        }

        private static int[] Combine(int[] left, int[] middle, int[] right)
        {
            int[] result = new int[left.Length + middle.Length + right.Length];
            Array.Copy(left, 0, result, 0, left.Length);
            Array.Copy(middle, 0, result, left.Length, middle.Length);
            Array.Copy(right, 0, result, left.Length + middle.Length, right.Length);
            return result;
        }
    }
}
