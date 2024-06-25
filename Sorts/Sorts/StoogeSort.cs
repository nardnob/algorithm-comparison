using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public class StoogeSort : SortMethod
    {
        #region " Public Methods "

        public override Task<List<int>> DoSort(IEnumerable<int> sortedNums, CancellationToken cancellationToken)
        {
            var sortedNumsList = sortedNums.ToList();

            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoStoogeSort(sortedNumsList, 0, sortedNumsList.Count - 1, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        public override string GetName()
        {
            return "Stooge Sort";
        }

        #endregion

        #region " Private Methods "

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

        #endregion
    }
}
