using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
