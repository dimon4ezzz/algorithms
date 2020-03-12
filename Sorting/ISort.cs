using System;
using System.Collections.Generic;

namespace Sorting
{
    public interface ISort
    {
        void Sort<T> (List<T> sortingList) where T : IComparable;
    }
}
