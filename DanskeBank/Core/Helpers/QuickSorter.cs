using Core.Interfaces;
using System;

namespace Core.Helpers
{
    public interface IQuickSorter : ISorter { }

    public class QuickSorter : IQuickSorter
    {
        public int[] SortNumbers(int[] numbers)
        {
            throw new NotImplementedException();
        }
    }
}
