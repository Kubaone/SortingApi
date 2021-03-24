using Core.ExtensionMethods;
using Core.Interfaces;
using System;

namespace Core.Helpers
{
    public interface IQuickSorter : ISorter { }

    public class QuickSorter : IQuickSorter
    {
        public int[] SortNumbers(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Array passed to be sorted is null or empty");

            var numbersQuantity = numbers.Length;
            if (numbersQuantity == 1)
                return numbers;

            QuickSort(numbers, 0, numbersQuantity - 1);

            return numbers;
        }

        public int[] QuickSort(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(numbers, left, right);

                if (partitionIndex > 1)
                {
                    QuickSort(numbers, left, partitionIndex - 1);
                }
                if (partitionIndex + 1 < right)
                {
                    QuickSort(numbers, partitionIndex + 1, right);
                }
            }

            return numbers;
        }

        public int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];

            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    numbers.SwapNumbers(left, right);

                    if (numbers[left] == numbers[right])
                        left++;
                }
                else
                    return right;
            }
        }
    }
}
