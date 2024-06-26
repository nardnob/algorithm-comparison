﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public class MergeSort : SortMethod
    {
        #region " Public Methods "

        public override Task<List<int>> DoSort(IEnumerable<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoMergeSort(sortedNums.ToList(), cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        public override string GetName()
        {
            return "Top-Down Merge Sort";
        }

        #endregion

        #region " Private Methods "

        private static List<int> DoMergeSort(List<int> nums, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (nums.Count <= 1)
            {
                return nums;
            }

            var left = new List<int>();
            var right = new List<int>();

            var middle = nums.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                left.Add(nums[i]);
            }

            for (int i = middle; i < nums.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                right.Add(nums[i]);
            }

            left = DoMergeSort(left, cancellationToken);
            right = DoMergeSort(right, cancellationToken);

            return Merge(left, right, cancellationToken);
        }

        private static List<int> Merge(List<int> left, List<int> right, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = new List<int>();

            while (left.Any() && right.Any())
            {
                cancellationToken.ThrowIfCancellationRequested();

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
                cancellationToken.ThrowIfCancellationRequested();

                result.Add(left.First());
                left.Remove(left.First());
            }

            while (right.Any())
            {
                cancellationToken.ThrowIfCancellationRequested();

                result.Add(right.First());
                right.Remove(right.First());
            }

            return result;
        }

        #endregion
    }
}
