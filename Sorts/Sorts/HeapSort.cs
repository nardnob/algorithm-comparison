using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public static class HeapSort
    {
        public static Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoHeapSort(sortedNums, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        private static List<int> DoHeapSort(List<int> nums, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            nums = Heapify(nums, cancellationToken);

            var end = nums.Count - 1;
            while (end > 0)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var temp = nums[end];
                nums[end] = nums[0];
                nums[0] = temp;

                end--;

                nums = SiftDown(nums, 0, end, cancellationToken);
            }

            return nums;
        }

        private static List<int> Heapify(List<int> nums, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int start = (int)Math.Floor((nums.Count - 2) / 2.0);

            while (start >= 0)
            {
                cancellationToken.ThrowIfCancellationRequested();

                SiftDown(nums, start, nums.Count - 1, cancellationToken);
                start--;
            }

            return nums;
        }

        private static List<int> SiftDown(List<int> nums, int start, int end, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int root = start;

            while (root * 2 + 1 <= end)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var child = root * 2 + 1;
                var swap = root;

                if (nums[swap] < nums[child])
                {
                    swap = child;
                }

                if (child + 1 <= end && nums[swap] < nums[child + 1])
                {
                    swap = child + 1;
                }

                if (swap == root)
                {
                    return nums;
                }

                var temp = nums[root];
                nums[root] = nums[swap];
                nums[swap] = temp;

                root = swap;
            }

            return nums;
        }

    }
}
