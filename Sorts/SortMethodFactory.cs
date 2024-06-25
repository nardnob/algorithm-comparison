using nardnob.AlgorithmComparison.Sorting.Sorts;
using System;

namespace nardnob.AlgorithmComparison.Sorting
{
    public static class SortMethodFactory
    {
        public static SortMethod GetSortMethod(SortTypes.SortType sortType)
        {
            switch (sortType)
            {
                case SortTypes.SortType.BubbleSort: return new BubbleSort();
                case SortTypes.SortType.CombSort: return new CombSort();
                case SortTypes.SortType.HeapSort: return new HeapSort();
                case SortTypes.SortType.InsertionSort: return new InsertionSort();
                case SortTypes.SortType.MergeSort: return new MergeSort();
                case SortTypes.SortType.QuickSort: return new QuickSort();
                case SortTypes.SortType.SelectionSort: return new SelectionSort();
                case SortTypes.SortType.StoogeSort: return new StoogeSort();
                case SortTypes.SortType.StupidSort: return new StupidSort();
                default:
                    throw new Exception("Unexpected SortType in Sort().");
            }
        }
    }
}
