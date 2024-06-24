namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public static class QuickSort
    {
        public static Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoQuickSort(sortedNums, 0, sortedNums.Count - 1, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        private static List<int> DoQuickSort(List<int> nums, int left, int right, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pivot = nums[left];
            int lhold = left;
            int rhold = right;

            while (left < right)
            {
                cancellationToken.ThrowIfCancellationRequested();

                while (nums[right] >= pivot && left < right)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    --right;
                }

                if (left != right)
                {
                    nums[left++] = nums[right];
                }

                while (nums[left] <= pivot && left < right)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    ++left;
                }

                if (left != right)
                {
                    nums[right--] = nums[left];
                }
            }

            nums[left] = pivot;

            if (lhold < left - 1)
            {
                DoQuickSort(nums, lhold, left - 1, cancellationToken);
            }

            if (rhold > left + 1)
            {
                DoQuickSort(nums, left + 1, rhold, cancellationToken);
            }

            return nums;
        }
    }
}
