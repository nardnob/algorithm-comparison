using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace nardnob.AlgorithmComparison.Sorting
{
    public abstract class SortMethod
    {
        public abstract Task<List<int>> DoSort(List<int> sortedNums, CancellationToken cancellationToken);
        public abstract string GetName();
    }
}
