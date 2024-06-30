using System;
using System.Collections.Generic;
using System.Linq;
using nardnob.AlgorithmComparison.Sorting.Utilities;

namespace nardnob.AlgorithmComparison.Sorting.Imports
{
    public class Importer
    {
        public enum ImportTypes
        {
            LoadUnsorted,
            ToVerifySort
        }

        public ImportFileEntriesResponse ImportFileEntries(List<string> fileEntries, ImportTypes importType)
        {
            var response = new ImportFileEntriesResponse(importType);

            if (fileEntries.Count > Constants.MAX_ENTRIES)
            {
                response.ContainsTooManyEntries = true;
                response.IsValid = false;
            }
            else if (fileEntries.Count == 1 && fileEntries[0].Trim() == string.Empty)
            {
                response.ContainsNoEntries = true;
                response.IsValid = false;
            }
            else
            {
                for (response.ItemIndex = 0; response.ItemIndex < fileEntries.Count() && response.IsValid; response.ItemIndex++)
                {
                    try
                    {
                        var entry = fileEntries[response.ItemIndex];
                        entry = entry.Replace(",", "").Trim();
                        var importedItem = Convert.ToInt32(entry);

                        if (importedItem < Constants.MIN_ITEM || importedItem > Constants.MAX_ITEM)
                        {
                            throw new FormatException($"Imported item ({importedItem}) was out of the valid range ({Constants.MIN_ITEM} - {Constants.MAX_ITEM}).");
                        }

                        response.ImportedItems.Add(importedItem);
                        response.ImportedStringBuilder.Append($"{importedItem.ToString()}; ");
                    }
                    catch (FormatException)
                    {
                        response.IsValid = false;
                        response.ContainsInvalidInteger = true;
                    }
                    catch (OverflowException)
                    {
                        response.IsValid = false;
                        response.ContainsInvalidInteger = true;
                    }
                    catch (Exception)
                    {
                        response.IsValid = false;
                    }
                }
            }

            return response;
        }
    }
}
