namespace WinForms
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            toolStrip1 = new ToolStrip();
            toolStripLabel6 = new ToolStripLabel();
            toolStripLabel1 = new ToolStripLabel();
            tstxtItems = new ToolStripTextBox();
            toolStripLabel4 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            tstxtBeginRange = new ToolStripTextBox();
            toolStripLabel5 = new ToolStripLabel();
            toolStripLabel3 = new ToolStripLabel();
            tstxtEndRange = new ToolStripTextBox();
            toolStripLabel7 = new ToolStripLabel();
            tsbtnGetList = new ToolStripButton();
            toolStripLabel10 = new ToolStripLabel();
            tsbtnClearLog = new ToolStripButton();
            toolStripLabel8 = new ToolStripLabel();
            tsbtnClearSortedList = new ToolStripButton();
            toolStripLabel9 = new ToolStripLabel();
            tsbtnVerifySort = new ToolStripButton();
            txtUnsortedNums = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtSortedNums = new TextBox();
            btnBubbleSort = new Button();
            btnMergeSort = new Button();
            btnQuickSort = new Button();
            btnInsertionSort = new Button();
            btnSelectionSort = new Button();
            btnHeapSort = new Button();
            btnCombSort = new Button();
            btnStoogeSort = new Button();
            btnStupidSort = new Button();
            label3 = new Label();
            txtResults = new TextBox();
            splitContainer1 = new SplitContainer();
            btnClearLog = new Button();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel6, toolStripLabel1, tstxtItems, toolStripLabel4, toolStripLabel2, tstxtBeginRange, toolStripLabel5, toolStripLabel3, tstxtEndRange, toolStripLabel7, tsbtnGetList, toolStripLabel10, tsbtnClearLog, toolStripLabel8, tsbtnClearSortedList, toolStripLabel9, tsbtnVerifySort });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1051, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(10, 22);
            toolStripLabel6.Text = " ";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(39, 22);
            toolStripLabel1.Text = "Items:";
            // 
            // tstxtItems
            // 
            tstxtItems.Name = "tstxtItems";
            tstxtItems.Size = new Size(100, 25);
            tstxtItems.KeyDown += tstxt_KeyDown;
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(13, 22);
            toolStripLabel4.Text = "  ";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(76, 22);
            toolStripLabel2.Text = "Begin Range:";
            // 
            // tstxtBeginRange
            // 
            tstxtBeginRange.Name = "tstxtBeginRange";
            tstxtBeginRange.Size = new Size(100, 25);
            tstxtBeginRange.KeyDown += tstxt_KeyDown;
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(13, 22);
            toolStripLabel5.Text = "  ";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(66, 22);
            toolStripLabel3.Text = "End Range:";
            // 
            // tstxtEndRange
            // 
            tstxtEndRange.Name = "tstxtEndRange";
            tstxtEndRange.Size = new Size(100, 25);
            tstxtEndRange.KeyDown += tstxt_KeyDown;
            // 
            // toolStripLabel7
            // 
            toolStripLabel7.Name = "toolStripLabel7";
            toolStripLabel7.Size = new Size(13, 22);
            toolStripLabel7.Text = "  ";
            // 
            // tsbtnGetList
            // 
            tsbtnGetList.Image = (Image)resources.GetObject("tsbtnGetList.Image");
            tsbtnGetList.ImageTransparentColor = Color.Magenta;
            tsbtnGetList.Name = "tsbtnGetList";
            tsbtnGetList.Size = new Size(66, 22);
            tsbtnGetList.Text = "Get List";
            tsbtnGetList.TextImageRelation = TextImageRelation.TextBeforeImage;
            tsbtnGetList.Click += tsbtnGetList_Click;
            // 
            // toolStripLabel10
            // 
            toolStripLabel10.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel10.Name = "toolStripLabel10";
            toolStripLabel10.Size = new Size(10, 22);
            toolStripLabel10.Text = " ";
            // 
            // tsbtnClearLog
            // 
            tsbtnClearLog.Alignment = ToolStripItemAlignment.Right;
            tsbtnClearLog.Image = (Image)resources.GetObject("tsbtnClearLog.Image");
            tsbtnClearLog.ImageTransparentColor = Color.Magenta;
            tsbtnClearLog.Name = "tsbtnClearLog";
            tsbtnClearLog.Size = new Size(77, 22);
            tsbtnClearLog.Text = "Clear Log";
            tsbtnClearLog.Click += tsbtnClearLog_Click;
            // 
            // toolStripLabel8
            // 
            toolStripLabel8.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel8.Name = "toolStripLabel8";
            toolStripLabel8.Size = new Size(13, 22);
            toolStripLabel8.Text = "  ";
            // 
            // tsbtnClearSortedList
            // 
            tsbtnClearSortedList.Alignment = ToolStripItemAlignment.Right;
            tsbtnClearSortedList.Image = (Image)resources.GetObject("tsbtnClearSortedList.Image");
            tsbtnClearSortedList.ImageTransparentColor = Color.Magenta;
            tsbtnClearSortedList.Name = "tsbtnClearSortedList";
            tsbtnClearSortedList.Size = new Size(112, 22);
            tsbtnClearSortedList.Text = "Clear Sorted List";
            tsbtnClearSortedList.Click += tsbtnClearSortedList_Click;
            // 
            // toolStripLabel9
            // 
            toolStripLabel9.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel9.Name = "toolStripLabel9";
            toolStripLabel9.Size = new Size(13, 22);
            toolStripLabel9.Text = "  ";
            // 
            // tsbtnVerifySort
            // 
            tsbtnVerifySort.Alignment = ToolStripItemAlignment.Right;
            tsbtnVerifySort.Image = (Image)resources.GetObject("tsbtnVerifySort.Image");
            tsbtnVerifySort.ImageTransparentColor = Color.Magenta;
            tsbtnVerifySort.Name = "tsbtnVerifySort";
            tsbtnVerifySort.Size = new Size(80, 22);
            tsbtnVerifySort.Text = "Verify Sort";
            tsbtnVerifySort.Click += tsbtnVerifySort_Click;
            // 
            // txtUnsortedNums
            // 
            txtUnsortedNums.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUnsortedNums.Location = new Point(3, 18);
            txtUnsortedNums.Multiline = true;
            txtUnsortedNums.Name = "txtUnsortedNums";
            txtUnsortedNums.ReadOnly = true;
            txtUnsortedNums.ScrollBars = ScrollBars.Vertical;
            txtUnsortedNums.Size = new Size(1021, 165);
            txtUnsortedNums.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 2;
            label1.Text = "Unsorted List";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 4;
            label2.Text = "Sorted List";
            // 
            // txtSortedNums
            // 
            txtSortedNums.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSortedNums.Location = new Point(3, 18);
            txtSortedNums.Multiline = true;
            txtSortedNums.Name = "txtSortedNums";
            txtSortedNums.ReadOnly = true;
            txtSortedNums.ScrollBars = ScrollBars.Vertical;
            txtSortedNums.Size = new Size(1021, 164);
            txtSortedNums.TabIndex = 3;
            // 
            // btnBubbleSort
            // 
            btnBubbleSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBubbleSort.Location = new Point(12, 409);
            btnBubbleSort.Name = "btnBubbleSort";
            btnBubbleSort.Size = new Size(140, 50);
            btnBubbleSort.TabIndex = 2;
            btnBubbleSort.Text = "Bubble Sort";
            btnBubbleSort.UseVisualStyleBackColor = true;
            btnBubbleSort.Click += btnBubbleSort_Click;
            // 
            // btnMergeSort
            // 
            btnMergeSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnMergeSort.Location = new Point(158, 409);
            btnMergeSort.Name = "btnMergeSort";
            btnMergeSort.Size = new Size(140, 50);
            btnMergeSort.TabIndex = 3;
            btnMergeSort.Text = "Top-Down Merge Sort";
            btnMergeSort.UseVisualStyleBackColor = true;
            btnMergeSort.Click += btnMergeSort_Click;
            // 
            // btnQuickSort
            // 
            btnQuickSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnQuickSort.Location = new Point(304, 409);
            btnQuickSort.Name = "btnQuickSort";
            btnQuickSort.Size = new Size(140, 50);
            btnQuickSort.TabIndex = 4;
            btnQuickSort.Text = "Quick Sort";
            btnQuickSort.UseVisualStyleBackColor = true;
            btnQuickSort.Click += btnQuickSort_Click;
            // 
            // btnInsertionSort
            // 
            btnInsertionSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnInsertionSort.Location = new Point(12, 465);
            btnInsertionSort.Name = "btnInsertionSort";
            btnInsertionSort.Size = new Size(140, 50);
            btnInsertionSort.TabIndex = 5;
            btnInsertionSort.Text = "Insertion Sort";
            btnInsertionSort.UseVisualStyleBackColor = true;
            btnInsertionSort.Click += btnInsertionSort_Click;
            // 
            // btnSelectionSort
            // 
            btnSelectionSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectionSort.Location = new Point(158, 465);
            btnSelectionSort.Name = "btnSelectionSort";
            btnSelectionSort.Size = new Size(140, 50);
            btnSelectionSort.TabIndex = 6;
            btnSelectionSort.Text = "Selection Sort";
            btnSelectionSort.UseVisualStyleBackColor = true;
            btnSelectionSort.Click += btnSelectionSort_Click;
            // 
            // btnHeapSort
            // 
            btnHeapSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHeapSort.Location = new Point(304, 465);
            btnHeapSort.Name = "btnHeapSort";
            btnHeapSort.Size = new Size(140, 50);
            btnHeapSort.TabIndex = 7;
            btnHeapSort.Text = "Heap Sort";
            btnHeapSort.UseVisualStyleBackColor = true;
            btnHeapSort.Click += btnHeapSort_Click;
            // 
            // btnCombSort
            // 
            btnCombSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCombSort.Location = new Point(12, 521);
            btnCombSort.Name = "btnCombSort";
            btnCombSort.Size = new Size(140, 50);
            btnCombSort.TabIndex = 8;
            btnCombSort.Text = "Insertion Sort";
            btnCombSort.UseVisualStyleBackColor = true;
            btnCombSort.Click += btnInsertionSort_Click;
            // 
            // btnStoogeSort
            // 
            btnStoogeSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStoogeSort.Location = new Point(158, 521);
            btnStoogeSort.Name = "btnStoogeSort";
            btnStoogeSort.Size = new Size(140, 50);
            btnStoogeSort.TabIndex = 9;
            btnStoogeSort.Text = "Stooge Sort";
            btnStoogeSort.UseVisualStyleBackColor = true;
            btnStoogeSort.Click += btnStoogeSort_Click;
            // 
            // btnStupidSort
            // 
            btnStupidSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStupidSort.Location = new Point(304, 521);
            btnStupidSort.Name = "btnStupidSort";
            btnStupidSort.Size = new Size(140, 50);
            btnStupidSort.TabIndex = 10;
            btnStupidSort.Text = "Stupid Sort";
            btnStupidSort.UseVisualStyleBackColor = true;
            btnStupidSort.Click += btnStupidSort_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(450, 417);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 14;
            label3.Text = "Results Log";
            // 
            // txtResults
            // 
            txtResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtResults.Location = new Point(450, 438);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(589, 133);
            txtResults.TabIndex = 11;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 28);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(txtUnsortedNums);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(txtSortedNums);
            splitContainer1.Size = new Size(1027, 375);
            splitContainer1.SplitterDistance = 186;
            splitContainer1.TabIndex = 16;
            // 
            // btnClearLog
            // 
            btnClearLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearLog.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.delete_24;
            btnClearLog.ImageAlign = ContentAlignment.MiddleRight;
            btnClearLog.Location = new Point(951, 412);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(88, 23);
            btnClearLog.TabIndex = 17;
            btnClearLog.Text = "Clear Log";
            btnClearLog.TextAlign = ContentAlignment.MiddleLeft;
            btnClearLog.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 582);
            Controls.Add(btnClearLog);
            Controls.Add(txtResults);
            Controls.Add(label3);
            Controls.Add(btnStupidSort);
            Controls.Add(btnStoogeSort);
            Controls.Add(btnCombSort);
            Controls.Add(btnHeapSort);
            Controls.Add(btnSelectionSort);
            Controls.Add(btnInsertionSort);
            Controls.Add(btnQuickSort);
            Controls.Add(btnMergeSort);
            Controls.Add(btnBubbleSort);
            Controls.Add(toolStrip1);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(1067, 621);
            Name = "MainView";
            Text = "Algorithm Comparison";
            Load += MainView_Load;
            Shown += MainView_Shown;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tstxtItems;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox tstxtBeginRange;
        private ToolStripLabel toolStripLabel3;
        private ToolStripTextBox tstxtEndRange;
        private ToolStripButton tsbtnGetList;
        private ToolStripLabel toolStripLabel6;
        private ToolStripLabel toolStripLabel4;
        private ToolStripLabel toolStripLabel5;
        private ToolStripLabel toolStripLabel7;
        private ToolStripButton tsbtnClearLog;
        private ToolStripButton tsbtnClearSortedList;
        private ToolStripButton tsbtnVerifySort;
        private ToolStripLabel toolStripLabel10;
        private ToolStripLabel toolStripLabel8;
        private ToolStripLabel toolStripLabel9;
        private TextBox txtUnsortedNums;
        private Label label1;
        private Label label2;
        private TextBox txtSortedNums;
        private Button btnBubbleSort;
        private Button btnMergeSort;
        private Button btnQuickSort;
        private Button btnInsertionSort;
        private Button btnSelectionSort;
        private Button btnHeapSort;
        private Button btnCombSort;
        private Button btnStoogeSort;
        private Button btnStupidSort;
        private Label label3;
        private TextBox txtResults;
        private SplitContainer splitContainer1;
        private Button btnClearLog;
    }
}
