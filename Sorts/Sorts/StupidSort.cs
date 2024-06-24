namespace nardnob.AlgorithmComparison.Sorting.Sorts
{
    public static class StupidSort
    {
        private static Random _rand = new Random();

        public static Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(f =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = DoStupidSort(sortedNums, cancellationToken);
                return result;
            }, cancellationToken);

            return task;
        }

        private static List<int> DoStupidSort(List<int> nums, CancellationToken cancellationToken)
        {
            while (!Verification.VerifySorted(nums, cancellationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();

                for (var i = 0; i < nums.Count; i++)
                {
                    var rand = _rand.Next(i, nums.Count);
                    var temp = nums[i];
                    nums[i] = nums[rand];
                    nums[rand] = temp;
                }
            }

            return nums;
        }
    }
}
