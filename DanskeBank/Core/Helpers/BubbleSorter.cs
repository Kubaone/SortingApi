using Core.ExtensionMethods;
using Core.Interfaces;
using System;
namespace Core.Helpers
{
    public interface IBubbleSorter : ISorter { }

    public class BubbleSorter : IBubbleSorter
    {
        public int[] SortNumbers(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Array passed to be sorted is null or empty");

            var numbersQuantity = numbers.Length;
            if (numbersQuantity == 1)
                return numbers;

            for(var i = 0; i < numbersQuantity; i++)
            {
                for (var k = 0; k < numbersQuantity - 1; k++)
                {
                    if (numbers[k] > numbers[k + 1])
                        numbers.SwapNumbers(k, k + 1);
                }
            }
            return numbers;
        }
    }
}
