using System;

namespace nardnob.AlgorithmComparison.Sorting
{
    public static class SortTypes
    {
        public enum SortType
        {
            BubbleSort,
            CombSort,
            HeapSort,
            InsertionSort,
            MergeSort,
            QuickSort,
            SelectionSort,
            StoogeSort,
            StupidSort
        }

        public static string GetSortName(SortTypes.SortType sort)
        {
            switch (sort)
            {
                case SortTypes.SortType.BubbleSort: return "Bubble Sort";
                case SortTypes.SortType.CombSort: return "Comb Sort";
                case SortTypes.SortType.HeapSort: return "Heap Sort";
                case SortTypes.SortType.InsertionSort: return "Insertion Sort";
                case SortTypes.SortType.MergeSort: return "Top-down Merge Sort";
                case SortTypes.SortType.QuickSort: return "Quick Sort";
                case SortTypes.SortType.SelectionSort: return "Selection Sort";
                case SortTypes.SortType.StoogeSort: return "Stooge Sort";
                case SortTypes.SortType.StupidSort: return "Stupid Sort";
                default:
                    throw new Exception("Unexpected SortType in GetSortName().");
            }
        }
    }
}
