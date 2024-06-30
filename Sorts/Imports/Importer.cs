using System;
using System.Collections.Generic;
using System.Linq;
using nardnob.AlgorithmComparison.Sorting.Utilities;

namespace nardnob.AlgorithmComparison.Sorting.Imports
{
    public class Importer
    {
        public ImportFileEntriesResponse ImportFileEntries(List<string> fileEntries)
        {
            var response = new ImportFileEntriesResponse();

            if (fileEntries.Count > Constants.MAX_ENTRIES)
            {
                //TODO: nardnob - handle too few entries (<= 0)
                response.ContainsTooManyEntries = true;
                response.IsValid = false;
            }
            else
            {
                for (response.ItemIndex = 0; response.ItemIndex < fileEntries.Count() && response.IsValid; response.ItemIndex++)
                {
                    try
                    {
                        var entry = fileEntries[response.ItemIndex];
                        entry = entry.Replace(",", "");
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
