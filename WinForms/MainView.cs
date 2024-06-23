using System.Text;

namespace WinForms
{
    public partial class MainView : Form
    {
        private Random _rand = new Random();
        private List<int> _unsortedNums = new List<int>();
        private List<int> _sortedNums = new List<int>();
        private bool _initialFocusSet = false;
        private bool _sortWasCancelled = false;
        private bool _isSorting = false;

        private const int DEFAULT_ITEMS = 1000;
        private const int DEFAULT_BEGIN_RANGE = 0;
        private const int DEFAULT_END_RANGE = 1000;

        private int _beginRange, _endRange, _items;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken _cancellationToken => _cancellationTokenSource.Token;

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
                    case Mode.Loading:
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
                        tsbtnClearLog.Enabled = false;
                        tsbtnClearSortedList.Enabled = false;
                        tsbtnVerifySort.Enabled = false;

                        btnClearLog.Enabled = false;

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
                        tsbtnClearLog.Enabled = true;
                        tsbtnClearSortedList.Enabled = true;
                        tsbtnVerifySort.Enabled = true;

                        btnClearLog.Enabled = true;

                        break;
                }

                _modeValue = value;
            }
        }

        private enum Mode
        {
            Ready,
            Loading
        }

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



        #region " Clear "

        private void ClearLog()
        {
            txtResults.Text = String.Empty;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            ClearLog();
        }
        private void tsbtnClearLog_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void tsbtnClearSortedList_Click(object sender, EventArgs e)
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
            _mode = Mode.Loading;

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
                    var rand = _rand.Next(beginRange, endRange + 1);

                    _unsortedNums.Add(rand);
                    sb.Append(rand.ToString() + "; ");
                }
            }, null);

            txtUnsortedNums.Text = sb.ToString();

            _mode = Mode.Ready;
            tstxtItems.Focus();
        }

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
            tsbtnCancelSort.Enabled = false;
            btnCancelSort.Enabled = false;

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

        #region " Sort "

        private async Task Sort(SortType sort)
        {
            _mode = Mode.Loading;

            txtSortedNums.Text = String.Empty;
            _sortedNums.Clear();
            _unsortedNums.ForEach(num => _sortedNums.Add(num));

            var startTime = DateTime.Now;
            tsbtnCancelSort.Enabled = true;
            btnCancelSort.Enabled = true;

            switch (sort)
            {
                case SortType.BubbleSort:
                    await DoBubbleSort();
                    break;
                case SortType.CombSort:
                    await DoCombSort();
                    break;
                case SortType.HeapSort:
                    await DoHeapSort();
                    break;
                case SortType.InsertionSort:
                    await DoInsertionSort();
                    break;
                case SortType.MergeSort:
                    await DoMergeSort();
                    break;
                case SortType.QuickSort:
                    await DoQuickSort();
                    break;
                case SortType.SelectionSort:
                    await DoSelectionSort();
                    break;
                case SortType.StoogeSort:
                    await DoStoogeSort();
                    break;
                case SortType.StupidSort:
                    await DoStupidSort();
                    break;
                default:
                    throw new Exception("Unexpected SortType in Sort().");
            }

            var endTime = DateTime.Now;
            var resultsSb = new StringBuilder();

            if (_sortWasCancelled)
            {
                resultsSb.AppendLine("== " + GetSortName(sort) + " ==");
                resultsSb.AppendLine("Sort Time: " + (endTime - startTime));
                resultsSb.AppendLine("The sort was cancelled.");
                resultsSb.AppendLine("");

                txtResults.Text = resultsSb.ToString() + txtResults.Text;

                _cancellationTokenSource = new CancellationTokenSource();
                _mode = Mode.Ready;
                tstxtItems.Focus();
            }
            else
            {

                var sortedSb = new StringBuilder();

                _sortedNums.ForEach(num => sortedSb.Append(num + "; "));

                resultsSb.AppendLine("== " + GetSortName(sort) + " ==");
                resultsSb.AppendLine("Sort Time: " + (endTime - startTime));
                resultsSb.AppendLine("Items Sorted: " + _items);
                resultsSb.AppendLine("Begin Range: " + _beginRange);
                resultsSb.AppendLine("End Range: " + _endRange);
                resultsSb.AppendLine("");

                txtResults.Text = resultsSb.ToString() + txtResults.Text;
                txtSortedNums.Text = sortedSb.ToString();

                _mode = Mode.Ready;
                tstxtItems.Focus();
            }

            _sortWasCancelled = false;
            tsbtnCancelSort.Enabled = false;
            btnCancelSort.Enabled = false;
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

        #region " Bubble Sort "

        private async void btnBubbleSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.BubbleSort);
        }

        private async Task DoBubbleSort()
        {
            _isSorting = true;

            var sortedNums = _sortedNums;
            var task = Task.Factory.StartNew(f =>
            {
                _cancellationToken.ThrowIfCancellationRequested();

                var result = BubbleSort(sortedNums);
                return result;
            }, _cancellationToken);

            try
            {
                var sortedResult = await task;
                _sortedNums = sortedResult;
            }
            catch (OperationCanceledException ex)
            {
                _sortWasCancelled = true;
            }
        }

        private List<int> BubbleSort(List<int> nums)
        {
            bool swapped = true;
            while (swapped)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }

                swapped = false;

                for (int i = 1; i < nums.Count; i++)
                {
                    if (nums[i - 1] > nums[i])
                    {
                        var temp = nums[i - 1];
                        nums[i - 1] = nums[i];
                        nums[i] = temp;

                        swapped = true;
                    }
                }
            }

            return nums;
        }

        #endregion

        #region " Comb Sort "

        private async void btnCombSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.CombSort);
        }

        private async Task DoCombSort()
        {
            await Task.Factory.StartNew(f =>
            {
                _sortedNums = CombSort(_sortedNums);
            }, null);
        }

        private List<int> CombSort(List<int> nums)
        {
            var gap = nums.Count;
            var shrink = 1.3;
            bool swapped = false;

            while (!(gap == 1 && !swapped))
            {
                gap = (int)(gap / shrink);
                if (gap < 1)
                    gap = 1;

                int i = 0;
                swapped = false;

                while (!(i + gap >= nums.Count))
                {
                    if (nums[i] > nums[i + gap])
                    {
                        var temp = nums[i];
                        nums[i] = nums[i + gap];
                        nums[i + gap] = temp;

                        swapped = true;
                    }

                    i++;
                }
            }

            return nums;
        }

        #endregion

        #region " Heap Sort "

        private async void btnHeapSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.HeapSort);
        }

        private async Task DoHeapSort()
        {
            await Task.Factory.StartNew(f =>
            {
                _sortedNums = HeapSort(_sortedNums);
            }, null);
        }

        private List<int> HeapSort(List<int> nums)
        {
            nums = Heapify(nums);

            var end = nums.Count - 1;
            while (end > 0)
            {
                var temp = nums[end];
                nums[end] = nums[0];
                nums[0] = temp;

                end--;

                nums = SiftDown(nums, 0, end);
            }

            return nums;
        }

        private List<int> Heapify(List<int> nums)
        {
            int start = (int)Math.Floor((nums.Count - 2) / 2.0);

            while (start >= 0)
            {
                SiftDown(nums, start, nums.Count - 1);
                start--;
            }

            return nums;
        }

        private List<int> SiftDown(List<int> nums, int start, int end)
        {
            int root = start;

            while (root * 2 + 1 <= end)
            {
                var child = root * 2 + 1;
                var swap = root;

                if (nums[swap] < nums[child])
                    swap = child;

                if (child + 1 <= end && nums[swap] < nums[child + 1])
                    swap = child + 1;

                if (swap == root)
                    return nums;

                var temp = nums[root];
                nums[root] = nums[swap];
                nums[swap] = temp;

                root = swap;
            }

            return nums;
        }

        #endregion

        #region " Insertion Sort "

        private async void btnInsertionSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.InsertionSort);
        }

        private async Task DoInsertionSort()
        {
            await Task.Factory.StartNew(f =>
            {
                _sortedNums = InsertionSort(_sortedNums);
            }, null);
        }

        private List<int> InsertionSort(List<int> inputArray)
        {
            for (int i = 0; i < inputArray.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }

        #endregion

        #region " Merge Sort "

        private async void btnMergeSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.MergeSort);
        }

        private async Task DoMergeSort()
        {
            var sortedNums = _sortedNums;
            var task = Task.Factory.StartNew(f =>
            {
                _cancellationToken.ThrowIfCancellationRequested();

                var result = MergeSort(sortedNums);
                return result;
            }, _cancellationToken);

            try
            {
                var sortedResult = await task;
                _sortedNums = sortedResult;
            }
            catch (OperationCanceledException ex)
            {
                _sortWasCancelled = true;
            }
        }

        private List<int> MergeSort(List<int> nums)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.ThrowIfCancellationRequested();
            }

            if (nums.Count <= 1)
            { 
                return nums;
            }

            var left = new List<int>();
            var right = new List<int>();

            var middle = nums.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }

                left.Add(nums[i]);
            }

            for (int i = middle; i < nums.Count; i++)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }

                right.Add(nums[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private List<int> Merge(List<int> left, List<int> right)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.ThrowIfCancellationRequested();
            }

            var result = new List<int>();

            while (left.Any() && right.Any())
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }

                if (left.First() <= right.First())
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            while (left.Any())
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }

                result.Add(left.First());
                left.Remove(left.First());
            }

            while (right.Any())
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }

                result.Add(right.First());
                right.Remove(right.First());
            }

            return result;
        }

        #endregion

        #region " Quick Sort "

        private async void btnQuickSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.QuickSort);
        }

        private async Task DoQuickSort()
        {
            var sortedNums = _sortedNums;
            var task = Task.Factory.StartNew(f =>
            {
                _cancellationToken.ThrowIfCancellationRequested();

                var result = QuickSort(sortedNums, 0, sortedNums.Count - 1);
                return result;
            }, _cancellationToken);

            try
            {
                var sortedResult = await task;
                _sortedNums = sortedResult;
            }
            catch (OperationCanceledException ex)
            {
                _sortWasCancelled = true;
            }
        }

        private List<int> QuickSort(List<int> nums, int left, int right)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.ThrowIfCancellationRequested();
            }

            int pivot = nums[left],
                        lhold = left,
                        rhold = right;

            while (left < right)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }

                while (nums[right] >= pivot && left < right)
                {
                    if (_cancellationToken.IsCancellationRequested)
                    {
                        _cancellationToken.ThrowIfCancellationRequested();
                    }

                    --right;
                }

                if (left != right)
                {
                    nums[left++] = nums[right];
                }

                while (nums[left] <= pivot && left < right)
                {
                    if (_cancellationToken.IsCancellationRequested)
                    {
                        _cancellationToken.ThrowIfCancellationRequested();
                    }

                    ++left;
                }

                if (left != right)
                { 
                    nums[right--] = nums[left];
                }
            }

            nums[left] = pivot;

            if (lhold < left - 1)
            { 
                QuickSort(nums, lhold, left - 1);
            }

            if (rhold > left + 1)
            { 
                QuickSort(nums, left + 1, rhold);
            }

            return nums;
        }

        #endregion

        #region " Selection Sort "

        private async void btnSelectionSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.SelectionSort);
        }

        private async Task DoSelectionSort()
        {
            var sortedNums = _sortedNums;
            var task = Task.Factory.StartNew(f =>
            {
                _cancellationToken.ThrowIfCancellationRequested();

                var result = SelectionSort(sortedNums);
                return result;
            }, _cancellationToken);

            try
            {
                var sortedResult = await task;
                _sortedNums = sortedResult;
            }
            catch (OperationCanceledException ex)
            {
                _sortWasCancelled = true;
            }
        }

        private List<int> SelectionSort(List<int> nums)
        {
            for (int j = 0; j < nums.Count - 1; j++)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }

                var iMin = j;

                for (int i = j + 1; i < nums.Count; i++)
                {
                    if (_cancellationToken.IsCancellationRequested)
                    {
                        _cancellationToken.ThrowIfCancellationRequested();
                    }

                    if (nums[i] < nums[iMin])
                    { 
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    var temp = nums[j];
                    nums[j] = nums[iMin];
                    nums[iMin] = temp;
                }
            }

            return nums;
        }

        #endregion

        #region " Stooge Sort "

        private async void btnStoogeSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.StoogeSort);
        }

        private async Task DoStoogeSort()
        {
            var sortedNums = _sortedNums;
            var task = Task.Factory.StartNew(f =>
            {
                _cancellationToken.ThrowIfCancellationRequested();

                var result = StoogeSort(sortedNums, 0, sortedNums.Count - 1);
                return result;
            }, _cancellationToken);

            try
            {
                var sortedResult = await task;
                _sortedNums = sortedResult;
            }
            catch (OperationCanceledException ex)
            {
                _sortWasCancelled = true;
            }
        }

        private List<int> StoogeSort(List<int> nums, int i, int j)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.ThrowIfCancellationRequested();
            }

            if (nums[j] < nums[i])
            {
                var temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            if (j - i > 1)
            {
                var t = (j - i + 1) / 3;

                StoogeSort(nums, i, j - t);
                StoogeSort(nums, i + t, j);
                StoogeSort(nums, i, j - t);
            }

            return nums;
        }

        #endregion

        #region " Stupid Sort "

        private async void btnStupidSort_Click(object sender, EventArgs e)
        {
            await Sort(SortType.StupidSort);
        }

        private async Task DoStupidSort()
        {
            var sortedNums = _sortedNums;
            var task = Task.Factory.StartNew(f =>
            {
                _cancellationToken.ThrowIfCancellationRequested();

                var result = StupidSort(sortedNums);
                return result;
            }, _cancellationToken);

            try
            {
                var sortedResult = await task;
                _sortedNums = sortedResult;
            }
            catch (OperationCanceledException ex)
            {
                _sortWasCancelled = true;
            }
        }

        private List<int> StupidSort(List<int> nums)
        {
            while (!VerifySorted(nums))
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }

                for (var i = 0; i < nums.Count; i++)
                {
                    var rand = _rand.Next(i, nums.Count);
                    var temp = nums[i];
                    nums[i] = nums[rand];
                    nums[rand] = temp;
                }
            }

            return nums;
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

            if (VerifySorted(_sortedNums))
            {
                MessageBox.Show("Items are sorted correctly.", "Valid Sort");
            }
            else
            {
                MessageBox.Show("Items are not sorted correctly.", "Invalid Sort");
            }
        }

        private bool VerifySorted(List<int> nums)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.ThrowIfCancellationRequested();
            }

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
