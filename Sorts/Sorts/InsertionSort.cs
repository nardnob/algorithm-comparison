﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public class InsertionSort : SortMethod
    {
        #region " Public Methods "

        public override Task<List<int>> DoSort(IEnumerable<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoInsertionSort(sortedNums.ToList(), cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        public override string GetName()
        {
            return "Insertion Sort";
        }

        #endregion

        #region " Private Methods "

        private static List<int> DoInsertionSort(List<int> inputArray, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            for (int i = 0; i < inputArray.Count - 1; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                for (int j = i + 1; j > 0; j--)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }

        #endregion
    }
}
