using System.Collections.Generic;
using System.Text;

namespace nardnob.AlgorithmComparison.Sorting.Imports
{
    public class ImportFileEntriesResponse
    {
        public bool IsValid { get; set; } = true;
        public bool ContainsInvalidInteger { get; set; } = false;
        public bool ContainsTooManyEntries { get; set; } = false;
        public List<int> ImportedItems { get; set; } = [];
        public StringBuilder ImportedStringBuilder { get; set; } = new StringBuilder();
        public int ItemIndex { get; set; } = 0;
    }
}
