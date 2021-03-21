using System;
using System.Collections.Generic;

namespace HomeWorkAl8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 3, 6, 8, 82, 46, 13, 67, 89, -24, 115, 23, 58, 69, 14, 0, -12, -82 };

            Console.Write("Исходный массив - ");
            Console.WriteLine(String.Join(" ", array));
            BucketSort(array);
            Console.Write("Отсортированный массив - ");
            Console.WriteLine(String.Join(" ", array));
            Console.WriteLine($"Ожидаемый массив  -      -82 -24 -12 0 3 5 6 8 13 14 23 46 58 67 69 82 89 115");

            var mas = GetArray(10);
            Console.WriteLine(String.Join(" ", mas));
            BucketSort(mas);
            Console.WriteLine(String.Join(" ", mas));
        }
        static void BucketSort(int[] a)
        {
            List<int>[] aux = new List<int>[3];

            for (int i = 0; i < aux.Length; ++i)
                aux[i] = new List<int>();

            for (int i = 0; i < a.Length; ++i)
            {
                int index = 1;
                if (a[i] < 0) index = 0;
                if (a[i] <= 100 && a[i] >= 0) index = 1;
                if (a[i] > 100) index = 2;

                aux[index].Add(a[i]);
            }

            for (int i = 0; i < aux.Length; ++i)
                aux[i].Sort();

            int idx = 0;

            for (int i = 0; i < aux.Length; ++i)
            {
                for (int j = 0; j < aux[i].Count; ++j)
                    a[idx++] = aux[i][j];
            }
        }

        static int[] GetArray(int n)
        {
            var array = new int[n];
            var rand = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-99, 100);
            }
            return array;
        }
        

        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                if (highIndex - lowIndex == 1)
                {
                    if (array[highIndex] < array[lowIndex])
                    {
                        var t = array[lowIndex];
                        array[lowIndex] = array[highIndex];
                        array[highIndex] = t;
                    }
                }
                else
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    MergeSort(array, lowIndex, middleIndex);
                    MergeSort(array, middleIndex + 1, highIndex);
                    Merge(array, lowIndex, middleIndex, highIndex);
                }
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }


        public static void QuickSort(int[] array, int first, int last)
        {
            int i = first;
            int j = last;
            int x = array[(first + last) / 2];

            do
            {
                while (array[i] < x)
                {
                    i++;
                }
                while (array[j] > x)
                {
                    j--;
                }
                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
            {
                QuickSort(array, i, last);
            }
            if (first < j)
            {
                QuickSort(array, first, j);
            } 
        }

        static void HeapSort(int[] array, int n) //основной метод
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);
            }
        }

        static void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = (i * 2) + 1;
            int right = (i * 2) + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, n, largest);
            }
        }
    }
}
