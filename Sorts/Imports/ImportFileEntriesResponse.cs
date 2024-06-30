using System.Collections.Generic;
using System.Text;
using static nardnob.AlgorithmComparison.Sorting.Imports.Importer;

namespace nardnob.AlgorithmComparison.Sorting.Imports
{
    public class ImportFileEntriesResponse
    {
        public bool IsValid { get; set; } = true;
        public bool ContainsInvalidInteger { get; set; } = false;
        public bool ContainsNoEntries { get; set; } = false;
        public bool ContainsTooManyEntries { get; set; } = false;
        public List<int> ImportedItems { get; set; } = [];
        public StringBuilder ImportedStringBuilder { get; set; } = new StringBuilder();
        public int ItemIndex { get; set; } = 0;
        public ImportTypes ImportType { get; private set; }

        public ImportFileEntriesResponse(ImportTypes importType) => ImportType = importType;
    }
}
