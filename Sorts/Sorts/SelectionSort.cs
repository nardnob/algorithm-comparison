using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public class SelectionSort : SortMethod
    {
        #region " Public Methods "

        public override Task<List<int>> DoSort(IEnumerable<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoSelectionSort(sortedNums.ToList(), cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        public override string GetName()
        {
            return "Selection Sort";
        }

        #endregion

        #region " Private Methods "

        private static List<int> DoSelectionSort(List<int> nums, CancellationToken cancellationToken)
        {
            for (int j = 0; j < nums.Count - 1; j++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var iMin = j;

                for (int i = j + 1; i < nums.Count; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (nums[i] < nums[iMin])
                    {
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    var temp = nums[j];
                    nums[j] = nums[iMin];
                    nums[iMin] = temp;
                }
            }

            return nums;
        }

        #endregion
    }
}
