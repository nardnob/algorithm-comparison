using System.Text;
using nardnob.AlgorithmComparison.Sorting;
using nardnob.AlgorithmComparison.Sorting.Sorts;

namespace WinForms
{
    public partial class MainView : Form
    {
        #region " Private Members "

        private const int DEFAULT_ITEMS = 1000;
        private const int DEFAULT_BEGIN_RANGE = 0;
        private const int DEFAULT_END_RANGE = 1000;

        private int _beginRange;
        private int _endRange;
        private int _items;

        private List<int> _unsortedNums = new List<int>();
        private List<int> _sortedNums = new List<int>();
        private bool _initialFocusSet = false;
        private bool _sortWasCancelled = false;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken _cancellationToken => _cancellationTokenSource.Token;

        private enum SortType
        {
            BubbleSort,
            CombSort,
            HeapSort,
            InsertionSort,
            MergeSort,
            QuickSort,
            SelectionSort,
            StoogeSort,
            StupidSort
        }

        #region " Mode "

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
                        btnClearSortedList.Enabled = false;
                        btnClearUnsortedList.Enabled = false;

                        btnClearLog.Enabled = false;

                        tsbtnCancelSort.Enabled = false;
                        btnCancelSort.Enabled = false;

                        break;

                    case Mode.Sorting:
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
                        btnClearSortedList.Enabled = false;
                        btnClearUnsortedList.Enabled = false;

                        btnClearLog.Enabled = false;

                        tsbtnCancelSort.Enabled = true;
                        btnCancelSort.Enabled = true;

                        break;

                    case Mode.Ready:
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
                        btnClearSortedList.Enabled = true;
                        btnClearUnsortedList.Enabled = true;

                        btnClearLog.Enabled = true;

                        tsbtnCancelSort.Enabled = false;
                        btnCancelSort.Enabled = false;

                        break;
                }

                _modeValue = value;
            }
        }

        private enum Mode
        {
            Ready,
            LoadingList,
            Sorting
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
            tstxtItems.Text = DEFAULT_ITEMS.ToString();
            tstxtBeginRange.Text = DEFAULT_BEGIN_RANGE.ToString();
            tstxtEndRange.Text = DEFAULT_END_RANGE.ToString();

            await GetAndPopulateList(DEFAULT_ITEMS, DEFAULT_BEGIN_RANGE, DEFAULT_END_RANGE);
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
            txtResults.Text = String.Empty;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void btnClearUnsortedList_Click(object sender, EventArgs e)
        {
            txtUnsortedNums.Text = String.Empty;
            _unsortedNums.Clear();
        }

        private void btnClearSortedList_Click(object sender, EventArgs e)
        {
            txtSortedNums.Text = String.Empty;
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

            var sb = new StringBuilder();

            _items = items;
            _beginRange = beginRange;
            _endRange = endRange;

            txtUnsortedNums.Text = String.Empty;
            txtSortedNums.Text = String.Empty;

            _unsortedNums.Clear();
            _sortedNums.Clear();

            await Task.Factory.StartNew(f =>
            {
                for (int i = 0; i < items; i++)
                {
                    var rand = RandomGenerator.Rand.Next(beginRange, endRange + 1);

                    _unsortedNums.Add(rand);
                    sb.Append(rand.ToString() + "; ");
                }
            }, null);

            txtUnsortedNums.Text = sb.ToString();

            _mode = Mode.Ready;
            tstxtItems.Focus();
        }

        #endregion

        #region " Sort "

        private async Task Sort(SortType sortType)
        {
            if (_unsortedNums.Count == 0)
            {
                MessageBox.Show("There were no items to sort. Please Get List before sorting.", "No Items to Sort");
                tstxtItems.Focus();
                return;
            }

            _mode = Mode.Sorting;

            txtSortedNums.Text = String.Empty;
            _sortedNums.Clear();
            _unsortedNums.ForEach(num => _sortedNums.Add(num));

            var startTime = DateTime.Now;

            List<int>? sortedNums = null;
            switch (sortType)
            {
                case SortType.BubbleSort:
                    sortedNums = await DoBubbleSort();
                    break;
                case SortType.CombSort:
                    sortedNums = await DoCombSort();
                    break;
                case SortType.HeapSort:
                    sortedNums = await DoHeapSort();
                    break;
                case SortType.InsertionSort:
                    sortedNums = await DoInsertionSort();
                    break;
                case SortType.MergeSort:
                    sortedNums = await DoMergeSort();
                    break;
                case SortType.QuickSort:
                    sortedNums = await DoQuickSort();
                    break;
                case SortType.SelectionSort:
                    sortedNums = await DoSelectionSort();
                    break;
                case SortType.StoogeSort:
                    sortedNums = await DoStoogeSort();
                    break;
                case SortType.StupidSort:
                    sortedNums = await DoStupidSort();
                    break;
                default:
                    throw new Exception("Unexpected SortType in Sort().");
            }

            if (_sortWasCancelled)
            {
                HandleCancelledSort(sortType, startTime);
            }
            else if (sortedNums is not null && Verification.VerifySorted(sortedNums))
            {
                HandleSuccessfulSort(sortType, startTime, sortedNums);
            }
            else
            {
                HandleUnsuccessfulSort();
            }

            _sortWasCancelled = false;
        }

        private string GetSortName(SortType sort)
        {
            switch (sort)
            {
                case SortType.BubbleSort: return "Bubble Sort";
                case SortType.CombSort: return "Comb Sort";
                case SortType.HeapSort: return "Heap Sort";
                case SortType.InsertionSort: return "Insertion Sort";
                case SortType.MergeSort: return "Top-down Merge Sort";
                case SortType.QuickSort: return "Quick Sort";
                case SortType.SelectionSort: return "Selection Sort";
                case SortType.StoogeSort: return "Stooge Sort";
                case SortType.StupidSort: return "Stupid Sort";
                default:
                    throw new Exception("Unexpected SortType in GetSortName().");
            }
        }

        private void HandleCancelledSort(SortType sortType, DateTime startTime)
        {
            var endTime = DateTime.Now;
            var resultsSb = new StringBuilder();

            resultsSb.AppendLine("== " + GetSortName(sortType) + " ==");
            resultsSb.AppendLine("Sort Time: " + (endTime - startTime));
            resultsSb.AppendLine("The sort was cancelled.");
            resultsSb.AppendLine("");

            txtResults.Text = resultsSb.ToString() + txtResults.Text;

            _cancellationTokenSource = new CancellationTokenSource();
            _mode = Mode.Ready;
            tstxtItems.Focus();
        }

        private void HandleSuccessfulSort(SortType sortType, DateTime startTime, List<int> sortedNums)
        {
            var endTime = DateTime.Now;
            var resultsSb = new StringBuilder();
            var sortedSb = new StringBuilder();

            sortedNums.ForEach(num => sortedSb.Append(num + "; "));

            resultsSb.AppendLine("== " + GetSortName(sortType) + " ==");
            resultsSb.AppendLine("Sort Time: " + (endTime - startTime));
            resultsSb.AppendLine("Items Sorted: " + _items);
            resultsSb.AppendLine("Begin Range: " + _beginRange);
            resultsSb.AppendLine("End Range: " + _endRange);
            resultsSb.AppendLine("");

            _sortedNums = sortedNums;
            txtResults.Text = resultsSb.ToString() + txtResults.Text;
            txtSortedNums.Text = sortedSb.ToString();

            _mode = Mode.Ready;
            tstxtItems.Focus();
        }

        private void HandleUnsuccessfulSort()
        {
            MessageBox.Show("An unexpected error occurred while sorting.", "Unexpected Error");
            _mode = Mode.Ready;
            tstxtItems.Focus();
        }

        #region " Bubble Sort "

        private async void btnBubbleSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.BubbleSort);
        }

        private async Task<List<int>?> DoBubbleSort()
        {
            try
            {
                var sortedNums = _sortedNums;
                var task = BubbleSort.DoSort(sortedNums, _cancellationToken);
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

        #endregion

        #region " Comb Sort "

        private async void btnCombSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.CombSort);
        }

        private async Task<List<int>?> DoCombSort()
        {
            try
            {
                var sortedNums = _sortedNums;
                var task = CombSort.DoSort(sortedNums, _cancellationToken);
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

        #endregion

        #region " Heap Sort "

        private async void btnHeapSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.HeapSort);
        }

        private async Task<List<int>?> DoHeapSort()
        {
            try
            {
                var sortedNums = _sortedNums;
                var task = HeapSort.DoSort(sortedNums, _cancellationToken);
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

        #endregion

        #region " Insertion Sort "

        private async void btnInsertionSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.InsertionSort);
        }

        private async Task<List<int>?> DoInsertionSort()
        {
            try
            {
                var sortedNums = _sortedNums;
                var task = InsertionSort.DoSort(sortedNums, _cancellationToken);
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

        #endregion

        #region " Merge Sort "

        private async void btnMergeSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.MergeSort);
        }

        private async Task<List<int>?> DoMergeSort()
        {
            try
            {
                var sortedNums = _sortedNums;
                var task = InsertionSort.DoSort(sortedNums, _cancellationToken);
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

        #endregion

        #region " Quick Sort "

        private async void btnQuickSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.QuickSort);
        }

        private async Task<List<int>?> DoQuickSort()
        {
            try
            {
                var sortedNums = _sortedNums;
                var task = QuickSort.DoSort(sortedNums, _cancellationToken);
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

        #endregion

        #region " Selection Sort "

        private async void btnSelectionSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.SelectionSort);
        }

        private async Task<List<int>?> DoSelectionSort()
        {
            try
            {
                var sortedNums = _sortedNums;
                var task = SelectionSort.DoSort(sortedNums, _cancellationToken);
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

        #endregion

        #region " Stooge Sort "

        private async void btnStoogeSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.StoogeSort);
        }

        private async Task<List<int>?> DoStoogeSort()
        {
            try
            {
                var sortedNums = _sortedNums;
                var task = StoogeSort.DoSort(sortedNums, _cancellationToken);
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

        #endregion

        #region " Stupid Sort "

        private async void btnStupidSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.StupidSort);
        }

        private async Task<List<int>?> DoStupidSort()
        {
            try
            {
                var sortedNums = _sortedNums;
                var task = StupidSort.DoSort(sortedNums, _cancellationToken);
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

        #endregion

        #endregion

        #region " Verify Sort "

        private void tsbtnVerifySort_Click(object sender, EventArgs e)
        {
            if (txtSortedNums.Text == String.Empty || !_sortedNums.Any())
            {
                MessageBox.Show("No sorted items to verify.", "Invalid Request");
                return;
            }

            if (Verification.VerifySorted(_sortedNums))
            {
                MessageBox.Show("Items are sorted correctly.", "Valid Sort");
            }
            else
            {
                MessageBox.Show("Items are not sorted correctly.", "Invalid Sort");
            }
        }

        #endregion

        #region " Cancel Sort "

        private void tsbtnCancelSort_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void btnCancelSort_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        #endregion
    }
}
