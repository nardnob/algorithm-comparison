using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public class CombSort : SortMethod
    {
        #region " Public Methods "

        public override Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoCombSort(sortedNums, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        public override string GetName()
        {
            return "Comb Sort";
        }

        #endregion

        #region " Private Methods "

        private static List<int> DoCombSort(List<int> nums, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var gap = nums.Count;
            var shrink = 1.3;
            bool swapped = false;

            while (!(gap == 1 && !swapped))
            {
                cancellationToken.ThrowIfCancellationRequested();

                gap = (int)(gap / shrink);
                if (gap < 1)
                {
                    gap = 1;
                }

                int i = 0;
                swapped = false;

                while (!(i + gap >= nums.Count))
                {
                    cancellationToken.ThrowIfCancellationRequested();

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

        #endregion
    }
}
