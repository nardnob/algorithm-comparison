using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace nardnob.AlgorithmComparison.Sorting
{
    public interface ISortMethod
    {
        public static abstract Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken);
    }
}
