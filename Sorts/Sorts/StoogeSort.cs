using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public class StoogeSort : SortMethod
    {
        public override Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoStoogeSort(sortedNums, 0, sortedNums.Count - 1, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        private static List<int> DoStoogeSort(List<int> nums, int i, int j, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (nums[j] < nums[i])
            {
                var temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            if (j - i > 1)
            {
                var t = (j - i + 1) / 3;

                DoStoogeSort(nums, i, j - t, cancellationToken);
                DoStoogeSort(nums, i + t, j, cancellationToken);
                DoStoogeSort(nums, i, j - t, cancellationToken);
            }

            return nums;
        }
    }
}
