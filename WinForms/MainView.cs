using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using nardnob.AlgorithmComparison.Sorting;
using nardnob.AlgorithmComparison.Sorting.Imports;
using nardnob.AlgorithmComparison.Sorting.Utilities;
using static nardnob.AlgorithmComparison.Sorting.Imports.Importer;

namespace WinForms
{
    public partial class MainView : Form
    {
        #region " Private Members "

        private int _beginRange;
        private int _endRange;
        private int _items;

        private List<int> _unsortedNums = new List<int>();
        private List<int> _sortedNums = new List<int>();
        private bool _initialFocusSet = false;
        private bool _sortWasCancelled = false;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken _cancellationToken => _cancellationTokenSource.Token;

        #region " Mode "

        private enum Mode
        {
            Ready,
            LoadingList,
            Sorting
        }

        private Mode _modeValue;
        private Mode _mode
        {
            get
            {
                return _modeValue;
            }
            set
            {
                switch (value)
                {
                    case Mode.LoadingList:
                        ToggleControls_LoadingList();
                        break;

                    case Mode.Sorting:
                        ToggleControls_Sorting();
                        break;

                    case Mode.Ready:
                        ToggleControls_Ready();
                        break;
                }

                _modeValue = value;
            }
        }

        #endregion

        #endregion

        #region " MainView "

        public MainView()
        {
            InitializeComponent();
        }

        private async void MainView_Load(object sender, EventArgs e)
        {
            tstxtItems.Text = Constants.DEFAULT_ITEMS.ToString();
            tstxtBeginRange.Text = Constants.DEFAULT_BEGIN_RANGE.ToString();
            tstxtEndRange.Text = Constants.DEFAULT_END_RANGE.ToString();

            await GetAndPopulateList(Constants.DEFAULT_ITEMS, Constants.DEFAULT_BEGIN_RANGE, Constants.DEFAULT_END_RANGE);
        }

        private void MainView_Shown(object sender, EventArgs e)
        {
            if (!_initialFocusSet)
            {
                tstxtItems.Focus();
                _initialFocusSet = true;
            }
        }

        #endregion

        #region " Clear "

        private void ClearLog()
        {
            txtResults.Text = string.Empty;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void btnClearUnsortedList_Click(object sender, EventArgs e)
        {
            ClearUnsortedItems();
        }

        private void ClearUnsortedItems()
        {
            txtUnsortedNums.Text = string.Empty;
            _unsortedNums.Clear();
        }

        private void btnClearSortedList_Click(object sender, EventArgs e)
        {
            ClearSortedItems();
        }

        private void ClearSortedItems()
        {
            txtSortedNums.Text = string.Empty;
            _sortedNums.Clear();
        }

        #endregion

        #region " Get List "

        private void tsbtnGetList_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void tstxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetList();
            }
        }

        private async void GetList()
        {
            int items, beginRange, endRange;

            try
            {
                items = Convert.ToInt32(tstxtItems.Text);
                beginRange = Convert.ToInt32(tstxtBeginRange.Text);
                endRange = Convert.ToInt32(tstxtEndRange.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input entered.", "Invalid Input");
                return;
            }

            if (beginRange > endRange)
            {
                MessageBox.Show("Begin Range cannot be greater than End Range.", "Invalid Input");
                return;
            }

            await GetAndPopulateList(items, beginRange, endRange);
        }

        private async Task GetAndPopulateList(int items, int beginRange, int endRange)
        {
            _mode = Mode.LoadingList;

            _items = items;
            _beginRange = beginRange;
            _endRange = endRange;

            ClearSortedItems();
            ClearUnsortedItems();

            var sb = new StringBuilder();
            await Task.Factory.StartNew(f =>
            {
                for (int i = 0; i < items; i++)
                {
                    var rand = RandomGenerator.Rand.Next(beginRange, endRange + 1);

                    _unsortedNums.Add(rand);
                    sb.Append($"{rand}; ");
                }
            }, null);

            txtUnsortedNums.Text = sb.ToString();

            SetIsReady();
        }

        #endregion

        #region " Mode "

        private void ToggleControls_LoadingList()
        {
            btnBubbleSort.Enabled = false;
            btnCombSort.Enabled = false;
            btnHeapSort.Enabled = false;
            btnInsertionSort.Enabled = false;
            btnMergeSort.Enabled = false;
            btnQuickSort.Enabled = false;
            btnSelectionSort.Enabled = false;
            btnStoogeSort.Enabled = false;
            btnStupidSort.Enabled = false;

            tstxtItems.Enabled = false;
            tstxtBeginRange.Enabled = false;
            tstxtEndRange.Enabled = false;
            tsbtnGetList.Enabled = false;
            tsbtnVerifySort.Enabled = false;
            tsbtnVerifyFileSort.Enabled = false;
            btnClearSortedList.Enabled = false;
            btnClearUnsortedList.Enabled = false;

            btnClearLog.Enabled = false;

            tsbtnCancelSort.Enabled = false;
            btnCancelSort.Enabled = false;

            btnImportUnsortedList.Enabled = false;
            btnSaveLog.Enabled = false;
            btnSaveSortedList.Enabled = false;
            btnSaveUnsortedList.Enabled = false;
        }

        private void ToggleControls_Sorting()
        {
            btnBubbleSort.Enabled = false;
            btnCombSort.Enabled = false;
            btnHeapSort.Enabled = false;
            btnInsertionSort.Enabled = false;
            btnMergeSort.Enabled = false;
            btnQuickSort.Enabled = false;
            btnSelectionSort.Enabled = false;
            btnStoogeSort.Enabled = false;
            btnStupidSort.Enabled = false;

            tstxtItems.Enabled = false;
            tstxtBeginRange.Enabled = false;
            tstxtEndRange.Enabled = false;
            tsbtnGetList.Enabled = false;
            tsbtnVerifySort.Enabled = false;
            tsbtnVerifyFileSort.Enabled = false;
            btnClearSortedList.Enabled = false;
            btnClearUnsortedList.Enabled = false;

            btnClearLog.Enabled = false;

            tsbtnCancelSort.Enabled = true;
            btnCancelSort.Enabled = true;

            btnImportUnsortedList.Enabled = false;
            btnSaveLog.Enabled = false;
            btnSaveSortedList.Enabled = false;
            btnSaveUnsortedList.Enabled = false;
        }

        private void ToggleControls_Ready()
        {
            btnBubbleSort.Enabled = true;
            btnCombSort.Enabled = true;
            btnHeapSort.Enabled = true;
            btnInsertionSort.Enabled = true;
            btnMergeSort.Enabled = true;
            btnQuickSort.Enabled = true;
            btnSelectionSort.Enabled = true;
            btnStoogeSort.Enabled = true;
            btnStupidSort.Enabled = true;

            tstxtItems.Enabled = true;
            tstxtBeginRange.Enabled = true;
            tstxtEndRange.Enabled = true;
            tsbtnGetList.Enabled = true;
            tsbtnVerifySort.Enabled = true;
            tsbtnVerifyFileSort.Enabled = true;
            btnClearSortedList.Enabled = true;
            btnClearUnsortedList.Enabled = true;

            btnClearLog.Enabled = true;

            tsbtnCancelSort.Enabled = false;
            btnCancelSort.Enabled = false;

            btnImportUnsortedList.Enabled = true;
            btnSaveLog.Enabled = true;
            btnSaveSortedList.Enabled = true;
            btnSaveUnsortedList.Enabled = true;
        }

        public void SetIsReady()
        {
            _mode = Mode.Ready;
            tstxtItems.Focus();
        }

        #endregion

        #region " Import, Verify "

        private void tsbtnVerifyFileSort_Click(object sender, EventArgs e)
        {
            var fileEntries = ImportFileEntries(ImportTypes.ToVerifySort);
            if (fileEntries is not null)
            {
                var fileIsSorted = Verification.VerifySorted(fileEntries);
                if (fileIsSorted)
                {
                    MessageBox.Show("The files entries are sorted correctly.", "File is Sorted");
                }
                else
                {
                    MessageBox.Show("The files entries are not sorted correctly.", "File is not Sorted");
                }
            }
        }

        private void btnImportUnsortedList_Click(object sender, EventArgs e)
        {
            ImportFileEntries(ImportTypes.LoadUnsorted);
        }

        private List<int>? ImportFileEntries(ImportTypes importType)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    var fileEntries = fileContent.Split([Environment.NewLine], StringSplitOptions.TrimEntries);
                    return AttemptImportFileEntries(fileEntries.ToList(), importType);
                }
            }

            return null;
        }

        private List<int>? AttemptImportFileEntries(List<string> fileEntries, ImportTypes importType)
        {
            var importResponse = new Importer().ImportFileEntries(fileEntries, importType);

            if (importResponse.IsValid)
            {
                switch (importResponse.ImportType)
                {
                    case ImportTypes.ToVerifySort:
                        return importResponse.ImportedItems;

                    case ImportTypes.LoadUnsorted:
                        _unsortedNums = importResponse.ImportedItems;
                        txtUnsortedNums.Text = importResponse.ImportedStringBuilder.ToString();
                        return null;

                    default:
                        throw new ArgumentOutOfRangeException("Unhandled ImportType.");
                }
            }

            if (importResponse.ContainsTooManyEntries)
            {
                MessageBox.Show($"There were too many entries to import.{Environment.NewLine + Environment.NewLine}The max number of entries is: {Constants.MAX_ENTRIES}.", "Invalid Input");
            }
            else if (importResponse.ContainsNoEntries)
            {
                MessageBox.Show($"The file contained no entries to import.", "Invalid Input");
            }
            else if (importResponse.ContainsInvalidInteger)
            {
                var invalidIntegerSb = new StringBuilder();

                invalidIntegerSb.AppendLine("Failed to import.");
                invalidIntegerSb.AppendLine();
                invalidIntegerSb.AppendLine("All entries must be integers on new lines between -999,999 and 999,999.");
                invalidIntegerSb.AppendLine();
                invalidIntegerSb.AppendLine("The only special characters allowed are negative signs and commas.");
                invalidIntegerSb.AppendLine();
                invalidIntegerSb.AppendLine($"The first invalid input was on line: {importResponse.ItemIndex}.");

                MessageBox.Show(invalidIntegerSb.ToString(), "Invalid Input");
            }
            else
            {
                MessageBox.Show("Failed to import. An unexpected error occurred.", "Unexpected Error");
            }

            return null;
        }

        #endregion

        #region " Cancel Sort "

        private void tsbtnCancelSort_Click(object sender, EventArgs e)
        {
            CancelSort();
        }

        private void btnCancelSort_Click(object sender, EventArgs e)
        {
            CancelSort();
        }

        private void CancelSort()
        {
            _cancellationTokenSource.Cancel();
        }

        #endregion

        #region " Export "

        private void btnSaveSortedList_Click(object sender, EventArgs e)
        {
            ExportItemsList(_sortedNums);
        }

        private void btnSaveUnsortedList_Click(object sender, EventArgs e)
        {
            ExportItemsList(_unsortedNums);
        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            ExportLog();
        }

        private void ExportItemsList(List<int> listToSave)
        {
            try
            {
                if (listToSave is null || listToSave.Count == 0)
                {
                    MessageBox.Show("There were no items to save.", "No Items to Save");
                    return;
                }
                else if (listToSave.Count > Constants.MAX_ENTRIES)
                {
                    MessageBox.Show($"There were too many items to save.{Environment.NewLine + Environment.NewLine}Max number of items allowed: {Constants.MAX_ENTRIES}.", "Too Many Items to Save");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var listStringBuilder = new StringBuilder();

                    foreach (var item in listToSave)
                    {
                        listStringBuilder.AppendLine(item.ToString());
                    }

                    File.WriteAllText(saveFileDialog.FileName, listStringBuilder.ToString().Trim());
                }

                MessageBox.Show($"The file was successfully saved.{Environment.NewLine + Environment.NewLine}{saveFileDialog.FileName}", "Successfully Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected error occurred while saving. Please try again.", "Unexpected Error");
            }
        }

        private void ExportLog()
        {
            try
            {
                if (txtResults.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("There were no results to save.", "No Results to Save");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, txtResults.Text.Trim());
                }

                MessageBox.Show($"The file was successfully saved.{Environment.NewLine + Environment.NewLine}{saveFileDialog.FileName}", "Successfully Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected error occurred while saving. Please try again.", "Unexpected Error");
            }
        }

        #endregion

        #region " Sorts "

        private async Task Sort(SortTypes.SortType sortType)
        {
            if (_unsortedNums.Count == 0)
            {
                HandleNoItemsToSort();
                return;
            }

            _mode = Mode.Sorting;

            txtSortedNums.Text = string.Empty;
            _sortedNums.Clear();

            var startTime = DateTime.Now;

            var sortMethod = SortMethodFactory.GetSortMethod(sortType);
            var numsToSort = _unsortedNums.Select(num => num);

            var sortedNums = await DoSort(sortMethod, numsToSort);

            if (_sortWasCancelled)
            {
                HandleCancelledSort(sortMethod, startTime);
            }
            else if (sortedNums is not null && Verification.VerifySorted(sortedNums))
            {
                HandleSuccessfulSort(sortMethod, startTime, sortedNums);
            }
            else
            {
                HandleUnsuccessfulSort();
            }

            _sortWasCancelled = false;
        }

        private async Task<List<int>?> DoSort(SortMethod sortMethod, IEnumerable<int> numsToSort)
        {
            try
            {
                var task = sortMethod.DoSort(numsToSort, _cancellationToken);
                var sortedResult = await task;

                return sortedResult;
            }
            catch (OperationCanceledException)
            {
                _sortWasCancelled = true;
            }
            catch (Exception)
            {
            }

            return null;
        }

        private void HandleNoItemsToSort()
        {
            MessageBox.Show("There were no items to sort. Please Get List before sorting.", "No Items to Sort");
            tstxtItems.Focus();
        }

        private void HandleCancelledSort(SortMethod sortMethod, DateTime startTime)
        {
            var endTime = DateTime.Now;
            var resultsSb = new StringBuilder();

            resultsSb.AppendLine($"== {sortMethod.GetName()} ==");
            resultsSb.AppendLine($"Sort Time: {endTime - startTime}");
            resultsSb.AppendLine($"The sort was cancelled.");
            resultsSb.AppendLine();

            txtResults.Text = resultsSb.ToString() + txtResults.Text;

            _cancellationTokenSource = new CancellationTokenSource();
            SetIsReady();
        }

        private void HandleSuccessfulSort(SortMethod sortMethod, DateTime startTime, List<int> sortedNums)
        {
            var endTime = DateTime.Now;
            var resultsSb = new StringBuilder();
            var sortedSb = new StringBuilder();

            sortedNums.ForEach(num => sortedSb.Append($"{num}; "));

            resultsSb.AppendLine($"== {sortMethod.GetName()} ==");
            resultsSb.AppendLine($"Sort Time: {endTime - startTime}");
            resultsSb.AppendLine($"Items Sorted: {_items}");
            resultsSb.AppendLine($"Begin Range: {_beginRange}");
            resultsSb.AppendLine($"End Range: {_endRange}");
            resultsSb.AppendLine();

            _sortedNums = sortedNums;
            txtResults.Text = resultsSb.ToString() + txtResults.Text;
            txtSortedNums.Text = sortedSb.ToString();

            SetIsReady();
        }

        private void HandleUnsuccessfulSort()
        {
            MessageBox.Show("An unexpected error occurred while sorting.", "Unexpected Error");
            SetIsReady();
        }

        private async void btnBubbleSort_Click(object sender, EventArgs e)
        {
            await Sort(SortTypes.SortType.BubbleSort);
        }

        private async void btnCombSort_Click(object sender, EventArgs e)
        {
            await Sort(SortTypes.SortType.CombSort);
        }

        private async void btnHeapSort_Click(object sender, EventArgs e)
        {
            await Sort(SortTypes.SortType.HeapSort);
        }

        private async void btnInsertionSort_Click(object sender, EventArgs e)
        {
            await Sort(SortTypes.SortType.InsertionSort);
        }

        private async void btnMergeSort_Click(object sender, EventArgs e)
        {
            await Sort(SortTypes.SortType.MergeSort);
        }

        private async void btnQuickSort_Click(object sender, EventArgs e)
        {
            await Sort(SortTypes.SortType.QuickSort);
        }

        private async void btnSelectionSort_Click(object sender, EventArgs e)
        {
            await Sort(SortTypes.SortType.SelectionSort);
        }

        private async void btnStoogeSort_Click(object sender, EventArgs e)
        {
            await Sort(SortTypes.SortType.StoogeSort);
        }

        private async void btnStupidSort_Click(object sender, EventArgs e)
        {
            await Sort(SortTypes.SortType.StupidSort);
        }

        #endregion
    }
}
