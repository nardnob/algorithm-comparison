﻿using System.Drawing;
using System.Windows.Forms;

namespace nardnob.AlgorithmComparison.WinForms.Views
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
            tsbtnVerifyFileSort = new ToolStripButton();
            toolStripLabel9 = new ToolStripLabel();
            tsbtnVerifySort = new ToolStripButton();
            toolStripLabel8 = new ToolStripLabel();
            tsbtnCancelSort = new ToolStripButton();
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
            btnBogoSort = new Button();
            label3 = new Label();
            txtResults = new TextBox();
            splitContainer1 = new SplitContainer();
            btnSaveUnsortedList = new Button();
            btnImportUnsortedList = new Button();
            btnClearUnsortedList = new Button();
            btnSaveSortedList = new Button();
            btnClearSortedList = new Button();
            btnClearLog = new Button();
            btnCancelSort = new Button();
            groupBox1 = new GroupBox();
            btnSaveLog = new Button();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel6, toolStripLabel1, tstxtItems, toolStripLabel4, toolStripLabel2, tstxtBeginRange, toolStripLabel5, toolStripLabel3, tstxtEndRange, toolStripLabel7, tsbtnGetList, toolStripLabel10, tsbtnVerifyFileSort, toolStripLabel9, tsbtnVerifySort, toolStripLabel8, tsbtnCancelSort });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1051, 25);
            toolStrip1.TabIndex = 0;
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
            tstxtItems.MaxLength = 6;
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
            tstxtBeginRange.MaxLength = 7;
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
            tstxtEndRange.MaxLength = 6;
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
            // tsbtnVerifyFileSort
            // 
            tsbtnVerifyFileSort.Alignment = ToolStripItemAlignment.Right;
            tsbtnVerifyFileSort.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.import_16;
            tsbtnVerifyFileSort.ImageTransparentColor = Color.Magenta;
            tsbtnVerifyFileSort.Name = "tsbtnVerifyFileSort";
            tsbtnVerifyFileSort.Size = new Size(118, 22);
            tsbtnVerifyFileSort.Text = "Verify a File's Sort";
            tsbtnVerifyFileSort.Click += tsbtnVerifyFileSort_Click;
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
            // toolStripLabel8
            // 
            toolStripLabel8.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel8.Name = "toolStripLabel8";
            toolStripLabel8.Size = new Size(13, 22);
            toolStripLabel8.Text = "  ";
            // 
            // tsbtnCancelSort
            // 
            tsbtnCancelSort.Alignment = ToolStripItemAlignment.Right;
            tsbtnCancelSort.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.delete_24;
            tsbtnCancelSort.ImageTransparentColor = Color.Magenta;
            tsbtnCancelSort.Name = "tsbtnCancelSort";
            tsbtnCancelSort.Size = new Size(87, 22);
            tsbtnCancelSort.Text = "Cancel Sort";
            tsbtnCancelSort.Click += tsbtnCancelSort_Click;
            // 
            // txtUnsortedNums
            // 
            txtUnsortedNums.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUnsortedNums.Location = new Point(3, 30);
            txtUnsortedNums.Multiline = true;
            txtUnsortedNums.Name = "txtUnsortedNums";
            txtUnsortedNums.ReadOnly = true;
            txtUnsortedNums.ScrollBars = ScrollBars.Vertical;
            txtUnsortedNums.Size = new Size(1021, 153);
            txtUnsortedNums.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 2;
            label1.Text = "Unsorted List";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 7);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 4;
            label2.Text = "Sorted List";
            // 
            // txtSortedNums
            // 
            txtSortedNums.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSortedNums.Location = new Point(3, 29);
            txtSortedNums.Multiline = true;
            txtSortedNums.Name = "txtSortedNums";
            txtSortedNums.ReadOnly = true;
            txtSortedNums.ScrollBars = ScrollBars.Vertical;
            txtSortedNums.Size = new Size(1021, 153);
            txtSortedNums.TabIndex = 2;
            // 
            // btnBubbleSort
            // 
            btnBubbleSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBubbleSort.Location = new Point(6, 22);
            btnBubbleSort.Name = "btnBubbleSort";
            btnBubbleSort.Size = new Size(91, 26);
            btnBubbleSort.TabIndex = 2;
            btnBubbleSort.Text = "Bubble Sort";
            btnBubbleSort.UseVisualStyleBackColor = true;
            btnBubbleSort.Click += btnBubbleSort_Click;
            // 
            // btnMergeSort
            // 
            btnMergeSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnMergeSort.Location = new Point(103, 22);
            btnMergeSort.Name = "btnMergeSort";
            btnMergeSort.Size = new Size(94, 26);
            btnMergeSort.TabIndex = 3;
            btnMergeSort.Text = "Merge Sort";
            btnMergeSort.UseVisualStyleBackColor = true;
            btnMergeSort.Click += btnMergeSort_Click;
            // 
            // btnQuickSort
            // 
            btnQuickSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnQuickSort.Location = new Point(203, 22);
            btnQuickSort.Name = "btnQuickSort";
            btnQuickSort.Size = new Size(94, 26);
            btnQuickSort.TabIndex = 4;
            btnQuickSort.Text = "Quick Sort";
            btnQuickSort.UseVisualStyleBackColor = true;
            btnQuickSort.Click += btnQuickSort_Click;
            // 
            // btnInsertionSort
            // 
            btnInsertionSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnInsertionSort.Location = new Point(303, 22);
            btnInsertionSort.Name = "btnInsertionSort";
            btnInsertionSort.Size = new Size(94, 26);
            btnInsertionSort.TabIndex = 5;
            btnInsertionSort.Text = "Insertion Sort";
            btnInsertionSort.UseVisualStyleBackColor = true;
            btnInsertionSort.Click += btnInsertionSort_Click;
            // 
            // btnSelectionSort
            // 
            btnSelectionSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectionSort.Location = new Point(6, 54);
            btnSelectionSort.Name = "btnSelectionSort";
            btnSelectionSort.Size = new Size(91, 26);
            btnSelectionSort.TabIndex = 6;
            btnSelectionSort.Text = "Selection Sort";
            btnSelectionSort.UseVisualStyleBackColor = true;
            btnSelectionSort.Click += btnSelectionSort_Click;
            // 
            // btnHeapSort
            // 
            btnHeapSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHeapSort.Location = new Point(103, 54);
            btnHeapSort.Name = "btnHeapSort";
            btnHeapSort.Size = new Size(94, 26);
            btnHeapSort.TabIndex = 7;
            btnHeapSort.Text = "Heap Sort";
            btnHeapSort.UseVisualStyleBackColor = true;
            btnHeapSort.Click += btnHeapSort_Click;
            // 
            // btnCombSort
            // 
            btnCombSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCombSort.Location = new Point(203, 54);
            btnCombSort.Name = "btnCombSort";
            btnCombSort.Size = new Size(94, 26);
            btnCombSort.TabIndex = 8;
            btnCombSort.Text = "Comb Sort";
            btnCombSort.UseVisualStyleBackColor = true;
            btnCombSort.Click += btnCombSort_Click;
            // 
            // btnStoogeSort
            // 
            btnStoogeSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStoogeSort.Location = new Point(303, 54);
            btnStoogeSort.Name = "btnStoogeSort";
            btnStoogeSort.Size = new Size(94, 26);
            btnStoogeSort.TabIndex = 9;
            btnStoogeSort.Text = "Stooge Sort";
            btnStoogeSort.UseVisualStyleBackColor = true;
            btnStoogeSort.Click += btnStoogeSort_Click;
            // 
            // btnBogoSort
            // 
            btnBogoSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBogoSort.Location = new Point(6, 86);
            btnBogoSort.Name = "btnBogoSort";
            btnBogoSort.Size = new Size(91, 26);
            btnBogoSort.TabIndex = 10;
            btnBogoSort.Text = "Bogo Sort";
            btnBogoSort.UseVisualStyleBackColor = true;
            btnBogoSort.Click += btnBogoSort_Click;
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
            txtResults.TabIndex = 7;
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
            splitContainer1.Panel1.Controls.Add(btnSaveUnsortedList);
            splitContainer1.Panel1.Controls.Add(btnImportUnsortedList);
            splitContainer1.Panel1.Controls.Add(btnClearUnsortedList);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(txtUnsortedNums);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnSaveSortedList);
            splitContainer1.Panel2.Controls.Add(btnClearSortedList);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(txtSortedNums);
            splitContainer1.Size = new Size(1027, 375);
            splitContainer1.SplitterDistance = 186;
            splitContainer1.TabIndex = 2;
            // 
            // btnSaveUnsortedList
            // 
            btnSaveUnsortedList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveUnsortedList.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.download_16;
            btnSaveUnsortedList.ImageAlign = ContentAlignment.MiddleRight;
            btnSaveUnsortedList.Location = new Point(752, 3);
            btnSaveUnsortedList.Name = "btnSaveUnsortedList";
            btnSaveUnsortedList.Size = new Size(129, 23);
            btnSaveUnsortedList.TabIndex = 1;
            btnSaveUnsortedList.Text = "Save Unsorted List";
            btnSaveUnsortedList.TextAlign = ContentAlignment.MiddleLeft;
            btnSaveUnsortedList.UseVisualStyleBackColor = true;
            btnSaveUnsortedList.Click += btnSaveUnsortedList_Click;
            // 
            // btnImportUnsortedList
            // 
            btnImportUnsortedList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImportUnsortedList.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.import_16;
            btnImportUnsortedList.ImageAlign = ContentAlignment.MiddleRight;
            btnImportUnsortedList.Location = new Point(601, 3);
            btnImportUnsortedList.Name = "btnImportUnsortedList";
            btnImportUnsortedList.Size = new Size(145, 23);
            btnImportUnsortedList.TabIndex = 0;
            btnImportUnsortedList.Text = "Import Unsorted List";
            btnImportUnsortedList.TextAlign = ContentAlignment.MiddleLeft;
            btnImportUnsortedList.UseVisualStyleBackColor = true;
            btnImportUnsortedList.Click += btnImportUnsortedList_Click;
            // 
            // btnClearUnsortedList
            // 
            btnClearUnsortedList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearUnsortedList.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.delete_24;
            btnClearUnsortedList.ImageAlign = ContentAlignment.MiddleRight;
            btnClearUnsortedList.Location = new Point(887, 3);
            btnClearUnsortedList.Name = "btnClearUnsortedList";
            btnClearUnsortedList.Size = new Size(137, 23);
            btnClearUnsortedList.TabIndex = 2;
            btnClearUnsortedList.Text = "Clear Unsorted List";
            btnClearUnsortedList.TextAlign = ContentAlignment.MiddleLeft;
            btnClearUnsortedList.UseVisualStyleBackColor = true;
            btnClearUnsortedList.Click += btnClearUnsortedList_Click;
            // 
            // btnSaveSortedList
            // 
            btnSaveSortedList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveSortedList.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.download_16;
            btnSaveSortedList.ImageAlign = ContentAlignment.MiddleRight;
            btnSaveSortedList.Location = new Point(785, 2);
            btnSaveSortedList.Name = "btnSaveSortedList";
            btnSaveSortedList.Size = new Size(115, 23);
            btnSaveSortedList.TabIndex = 0;
            btnSaveSortedList.Text = "Save Sorted List";
            btnSaveSortedList.TextAlign = ContentAlignment.MiddleLeft;
            btnSaveSortedList.UseVisualStyleBackColor = true;
            btnSaveSortedList.Click += btnSaveSortedList_Click;
            // 
            // btnClearSortedList
            // 
            btnClearSortedList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearSortedList.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.delete_24;
            btnClearSortedList.ImageAlign = ContentAlignment.MiddleRight;
            btnClearSortedList.Location = new Point(906, 2);
            btnClearSortedList.Name = "btnClearSortedList";
            btnClearSortedList.Size = new Size(121, 23);
            btnClearSortedList.TabIndex = 1;
            btnClearSortedList.Text = "Clear Sorted List";
            btnClearSortedList.TextAlign = ContentAlignment.MiddleLeft;
            btnClearSortedList.UseVisualStyleBackColor = true;
            btnClearSortedList.Click += btnClearSortedList_Click;
            // 
            // btnClearLog
            // 
            btnClearLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearLog.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.delete_24;
            btnClearLog.ImageAlign = ContentAlignment.MiddleRight;
            btnClearLog.Location = new Point(951, 412);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(88, 23);
            btnClearLog.TabIndex = 6;
            btnClearLog.Text = "Clear Log";
            btnClearLog.TextAlign = ContentAlignment.MiddleLeft;
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // btnCancelSort
            // 
            btnCancelSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelSort.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.delete_24;
            btnCancelSort.ImageAlign = ContentAlignment.MiddleRight;
            btnCancelSort.Location = new Point(764, 412);
            btnCancelSort.Name = "btnCancelSort";
            btnCancelSort.Size = new Size(95, 23);
            btnCancelSort.TabIndex = 4;
            btnCancelSort.Text = "Cancel Sort";
            btnCancelSort.TextAlign = ContentAlignment.MiddleLeft;
            btnCancelSort.UseVisualStyleBackColor = true;
            btnCancelSort.Click += btnCancelSort_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(btnBubbleSort);
            groupBox1.Controls.Add(btnMergeSort);
            groupBox1.Controls.Add(btnQuickSort);
            groupBox1.Controls.Add(btnInsertionSort);
            groupBox1.Controls.Add(btnSelectionSort);
            groupBox1.Controls.Add(btnHeapSort);
            groupBox1.Controls.Add(btnBogoSort);
            groupBox1.Controls.Add(btnCombSort);
            groupBox1.Controls.Add(btnStoogeSort);
            groupBox1.Location = new Point(12, 417);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(432, 154);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sorting Methods";
            // 
            // btnSaveLog
            // 
            btnSaveLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveLog.Image = nardnob.AlgorithmComparison.WinForms.Properties.Resources.download_16;
            btnSaveLog.ImageAlign = ContentAlignment.MiddleRight;
            btnSaveLog.Location = new Point(864, 412);
            btnSaveLog.Name = "btnSaveLog";
            btnSaveLog.Size = new Size(81, 23);
            btnSaveLog.TabIndex = 5;
            btnSaveLog.Text = "Save Log";
            btnSaveLog.TextAlign = ContentAlignment.MiddleLeft;
            btnSaveLog.UseVisualStyleBackColor = true;
            btnSaveLog.Click += btnSaveLog_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 582);
            Controls.Add(btnSaveLog);
            Controls.Add(groupBox1);
            Controls.Add(btnCancelSort);
            Controls.Add(btnClearLog);
            Controls.Add(txtResults);
            Controls.Add(label3);
            Controls.Add(toolStrip1);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
            groupBox1.ResumeLayout(false);
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
        private ToolStripButton tsbtnCancelSort;
        private ToolStripLabel toolStripLabel10;
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
        private Button btnBogoSort;
        private Label label3;
        private TextBox txtResults;
        private SplitContainer splitContainer1;
        private Button btnClearLog;
        private ToolStripButton tsbtnVerifySort;
        private Button btnCancelSort;
        private ToolStripLabel toolStripLabel8;
        private Button btnClearSortedList;
        private Button btnClearUnsortedList;
        private GroupBox groupBox1;
        private Button btnImportUnsortedList;
        private Button btnSaveSortedList;
        private Button btnSaveUnsortedList;
        private Button btnSaveLog;
        private ToolStripButton tsbtnVerifyFileSort;
        private ToolStripLabel toolStripLabel9;
    }
}
