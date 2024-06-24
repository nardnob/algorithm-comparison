using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public static class InsertionSort
    {
        public static Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoInsertionSort(sortedNums, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

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
    }
}
