using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public class BubbleSort : ISortMethod
    {
        public static Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoBubbleSort(sortedNums, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        private static List<int> DoBubbleSort(List<int> nums, CancellationToken cancellationToken)
        {
            bool swapped = true;
            while (swapped)
            {
                cancellationToken.ThrowIfCancellationRequested();

                swapped = false;

                for (int i = 1; i < nums.Count; i++)
                {
                    if (nums[i - 1] > nums[i])
                    {
                        var temp = nums[i - 1];
                        nums[i - 1] = nums[i];
                        nums[i] = temp;

                        swapped = true;
                    }
                }
            }

            return nums;
        }
    }
}
