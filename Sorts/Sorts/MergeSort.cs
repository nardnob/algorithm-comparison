namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public static class MergeSort
    {
        public static Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoMergeSort(sortedNums, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        private static List<int> DoMergeSort(List<int> nums, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            if (nums.Count <= 1)
            {
                return nums;
            }

            var left = new List<int>();
            var right = new List<int>();

            var middle = nums.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                left.Add(nums[i]);
            }

            for (int i = middle; i < nums.Count; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                right.Add(nums[i]);
            }

            left = DoMergeSort(left, cancellationToken);
            right = DoMergeSort(right, cancellationToken);

            return Merge(left, right, cancellationToken);
        }

        private static List<int> Merge(List<int> left, List<int> right, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            var result = new List<int>();

            while (left.Any() && right.Any())
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                if (left.First() <= right.First())
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            while (left.Any())
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                result.Add(left.First());
                left.Remove(left.First());
            }

            while (right.Any())
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                result.Add(right.First());
                right.Remove(right.First());
            }

            return result;
        }
    }
}
