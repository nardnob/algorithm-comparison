﻿namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public static class CombSort
    {
        public static Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoCombSort(sortedNums, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        private static List<int> DoCombSort(List<int> nums, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            var gap = nums.Count;
            var shrink = 1.3;
            bool swapped = false;

            while (!(gap == 1 && !swapped))
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                gap = (int)(gap / shrink);
                if (gap < 1)
                {
                    gap = 1;
                }

                int i = 0;
                swapped = false;

                while (!(i + gap >= nums.Count))
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }

                    if (nums[i] > nums[i + gap])
                    {
                        var temp = nums[i];
                        nums[i] = nums[i + gap];
                        nums[i + gap] = temp;

                        swapped = true;
                    }

                    i++;
                }
            }

            return nums;
        }
    }
}