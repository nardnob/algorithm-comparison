namespace nardnob.AlgorithmComparison.Sorting
{
    public static class Verification
    {
        public static bool VerifySorted(List<int> nums, CancellationToken? cancellationToken = null)
        {
            cancellationToken?.ThrowIfCancellationRequested();

            if (nums.Count < 2)
            {
                return true;
            }

            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i + 1] < nums[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
