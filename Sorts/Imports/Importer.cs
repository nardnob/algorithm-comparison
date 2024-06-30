using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nardnob.AlgorithmComparison.Sorting.Utilities;

namespace nardnob.AlgorithmComparison.Sorting.Imports
{
    public class Importer
    {
        bool _isValid = true;
        bool _containsInvalidInteger = false;
        bool _containsTooManyEntries = false;
        List<int> _importedItems = new List<int>();
        StringBuilder _importedStringBuilder = new StringBuilder();
        int _i = 0;
        /*
        public Importer() 
        { 
        }

        public void Import(List<string> fileEntries)
        {
            if (fileEntries.Count > Constants.MAX_ENTRIES)
            {
                containsTooManyEntries = true;
                isValid = false;
            }
            else
            {
                for (i = 0; i < fileEntries.Count() && isValid; i++)
                {
                    try
                    {
                        var entry = fileEntries[i];
                        entry = entry.Replace(",", "");
                        var importedItem = Convert.ToInt32(entry);

                        if (importedItem < Constants.MIN_ITEM || importedItem > Constants.MAX_ITEM)
                        {
                            //TODO: Display validation message to user
                            throw new FormatException($"Imported item ({importedItem}) was out of the valid range ({Constants.MIN_ITEM} - {Constants.MAX_ITEM}).");
                        }

                        importedItems.Add(importedItem);
                        importedStringBuilder.Append($"{importedItem.ToString()}; ");
                    }
                    catch (FormatException)
                    {
                        isValid = false;
                        containsInvalidInteger = true;
                    }
                    catch (OverflowException)
                    {
                        isValid = false;
                        containsInvalidInteger = true;
                    }
                    catch (Exception)
                    {
                        isValid = false;
                    }
                }
            }

            if (isValid)
            {
                _unsortedNums = importedItems;
                txtUnsortedNums.Text = importedStringBuilder.ToString();
            }
            else
            {
                if (containsTooManyEntries)
                {
                    MessageBox.Show($"There were too many entries to import.{Environment.NewLine + Environment.NewLine}The max number of entries is: {Constants.MAX_ENTRIES}.", "Invalid Input");
                }
                else if (containsInvalidInteger)
                {
                    var invalidIntegerSb = new StringBuilder();

                    invalidIntegerSb.AppendLine("Failed to import.");
                    invalidIntegerSb.AppendLine();
                    invalidIntegerSb.AppendLine("All entries must be integers on new lines between -999,999 and 999,999.");
                    invalidIntegerSb.AppendLine();
                    invalidIntegerSb.AppendLine("The only special characters allowed are negative signs and commas.");
                    invalidIntegerSb.AppendLine();
                    invalidIntegerSb.AppendLine($"The first invalid input was on line: {i}.");

                    MessageBox.Show(invalidIntegerSb.ToString(), "Invalid Input");
                }
                else
                {
                    MessageBox.Show("Failed to import. An unexpected error occurred.", "Unexpected Error");
                }
            }
        }*/
    }
}
