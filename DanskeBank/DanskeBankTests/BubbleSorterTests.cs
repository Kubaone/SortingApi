using Core.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace DanskeBankTests
{
    public class BubbleSorterTests
    {
        [Theory]
        [InlineData(null)]
        public void SortNumbers_Null_ThrowsArgumentException(int[] numbers)
        {
            var bubbleSorter = new BubbleSorter();

            Assert.Throws<ArgumentException>(() => bubbleSorter.SortNumbers(numbers));
        }

        [Theory]
        [InlineData(new int[] { })]
        public void SortNumbers_EmptyArray_ThrowsArgumentException(int[] numbers)
        {
            var bubbleSorter = new BubbleSorter();

            Assert.Throws<ArgumentException>(() => bubbleSorter.SortNumbers(numbers));
        }

        [Theory]
        [InlineData(new int[] { 5, 2, 8, 10, 1 })]
        [InlineData(new int[] { 132, 23, 31, 163, 88, 171, 42, 7, 151, 96, 154, 34, 0, 0, 30, 28, 165, 41, 48, 74 })]
        public void SortNumbers_PositiveIntegers_Sorted(int[] numbers)
        {
            var bubbleSorter = new BubbleSorter();
            var expectedResult = new List<int>(numbers);
            expectedResult.Sort();

            var result = bubbleSorter.SortNumbers(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { -8, -177, -1, -43, -148, -77, -49, -169, -13, -155, -166, -67, -79, -69, -17, -23, -124, -31, -140, -183 })]
        [InlineData(new int[] { -117, -197, -185, -11, -69, -120, -19, -190, -30, -127, -118, -145, -38, -90, -53, -78, -28, 0, -164, -149 })]
        public void SortNumbers_NegativeIntegers_Sorted(int[] numbers)
        {
            var bubbleSorter = new BubbleSorter();
            var expectedResult = new List<int>(numbers);
            expectedResult.Sort();

            var result = bubbleSorter.SortNumbers(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 14, 16, -25, -131, -79, -90, -118, 176, -111, 82, -57, 131, -5, 126, 192, -86, 79, -104, 37, 88 })]
        [InlineData(new int[] { -46, 12, -17, -150, -37, -14, 137, 17, -96, 89, -101, -164, 182, 124, 96, -115, -139, 133, 195, 121 })]
        public void SortNumbers_MixedIntegers_Sorted(int[] numbers)
        {
            var bubbleSorter = new BubbleSorter();
            var expectedResult = new List<int>(numbers);
            expectedResult.Sort();

            var result = bubbleSorter.SortNumbers(numbers);

            Assert.Equal(expectedResult, result);
        }
    }
}
