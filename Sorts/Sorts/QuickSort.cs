using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public class QuickSort : SortMethod
    {
        #region " Public Methods "

        public override Task<List<int>> DoSort(IEnumerable<int> sortedNums, CancellationToken cancellationToken)
        {
            var sortedNumsList = sortedNums.ToList();

            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoQuickSort(sortedNumsList, 0, sortedNumsList.Count - 1, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        public override string GetName()
        {
            return "Quick Sort";
        }

        #endregion

        #region " Private Methods "

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

        #endregion
    }
}
