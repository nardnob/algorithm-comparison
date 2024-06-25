﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public class StupidSort : SortMethod
    {
        #region " Public Methods "

        public override Task<List<int>> DoSort(IEnumerable<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoStupidSort(sortedNums.ToList(), cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        public override string GetName()
        {
            return "Stupid Sort";
        }

        #endregion

        #region " Private Methods "

        private static List<int> DoStupidSort(List<int> nums, CancellationToken cancellationToken)
        {
            while (!Verification.VerifySorted(nums, cancellationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();

                for (var i = 0; i < nums.Count; i++)
                {
                    var rand = RandomGenerator.Rand.Next(i, nums.Count);
                    var temp = nums[i];
                    nums[i] = nums[rand];
                    nums[rand] = temp;
                }
            }

            return nums;
        }

        #endregion
    }
}
