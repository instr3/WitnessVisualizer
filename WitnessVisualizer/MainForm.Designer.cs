﻿namespace WitnessVisualizer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("test2", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.editorPictureBox = new System.Windows.Forms.PictureBox();
            this.puzzlePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.resetPropertyButton = new System.Windows.Forms.Button();
            this.ToolkitListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tetrisTemplatePictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBoardSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDecorationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.bestViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInfoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveInfoFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.createFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.puzzlePropertyLabel = new System.Windows.Forms.Label();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.editorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisTemplatePictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorPictureBox
            // 
            this.editorPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorPictureBox.Location = new System.Drawing.Point(267, 28);
            this.editorPictureBox.Name = "editorPictureBox";
            this.editorPictureBox.Size = new System.Drawing.Size(624, 601);
            this.editorPictureBox.TabIndex = 0;
            this.editorPictureBox.TabStop = false;
            this.editorPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseDown);
            this.editorPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseMove);
            this.editorPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseUp);
            this.editorPictureBox.Resize += new System.EventHandler(this.EditorPictureBox_Resize);
            // 
            // puzzlePropertyGrid
            // 
            this.puzzlePropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.puzzlePropertyGrid.Location = new System.Drawing.Point(897, 235);
            this.puzzlePropertyGrid.Name = "puzzlePropertyGrid";
            this.puzzlePropertyGrid.Size = new System.Drawing.Size(177, 365);
            this.puzzlePropertyGrid.TabIndex = 2;
            this.puzzlePropertyGrid.ToolbarVisible = false;
            this.puzzlePropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PuzzlePropertyGrid_PropertyValueChanged);
            // 
            // resetPropertyButton
            // 
            this.resetPropertyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetPropertyButton.Location = new System.Drawing.Point(897, 606);
            this.resetPropertyButton.Name = "resetPropertyButton";
            this.resetPropertyButton.Size = new System.Drawing.Size(177, 23);
            this.resetPropertyButton.TabIndex = 3;
            this.resetPropertyButton.Text = "Reset Value";
            this.resetPropertyButton.UseVisualStyleBackColor = true;
            this.resetPropertyButton.Click += new System.EventHandler(this.ResetPropertyButton_Click);
            // 
            // ToolkitListView
            // 
            this.ToolkitListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ToolkitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ToolkitListView.GridLines = true;
            this.ToolkitListView.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.ToolkitListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ToolkitListView.Location = new System.Drawing.Point(12, 28);
            this.ToolkitListView.Name = "ToolkitListView";
            this.ToolkitListView.Size = new System.Drawing.Size(249, 601);
            this.ToolkitListView.TabIndex = 5;
            this.ToolkitListView.UseCompatibleStateImageBehavior = false;
            this.ToolkitListView.SelectedIndexChanged += new System.EventHandler(this.ToolkitListView_SelectedIndexChanged);
            // 
            // tetrisTemplatePictureBox
            // 
            this.tetrisTemplatePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tetrisTemplatePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tetrisTemplatePictureBox.Location = new System.Drawing.Point(897, 28);
            this.tetrisTemplatePictureBox.Name = "tetrisTemplatePictureBox";
            this.tetrisTemplatePictureBox.Size = new System.Drawing.Size(177, 183);
            this.tetrisTemplatePictureBox.TabIndex = 6;
            this.tetrisTemplatePictureBox.TabStop = false;
            this.tetrisTemplatePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TetrisTemplatePictureBox_MouseDown);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1082, 25);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(45, 21);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.copyToolStripMenuItem,
            this.changeBoardSizeToolStripMenuItem,
            this.clearDecorationsToolStripMenuItem,
            this.deleteElementsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.bestViewToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(253, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // changeBoardSizeToolStripMenuItem
            // 
            this.changeBoardSizeToolStripMenuItem.Enabled = false;
            this.changeBoardSizeToolStripMenuItem.Name = "changeBoardSizeToolStripMenuItem";
            this.changeBoardSizeToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.changeBoardSizeToolStripMenuItem.Text = "Change Board Size...";
            // 
            // clearDecorationsToolStripMenuItem
            // 
            this.clearDecorationsToolStripMenuItem.Name = "clearDecorationsToolStripMenuItem";
            this.clearDecorationsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.clearDecorationsToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.clearDecorationsToolStripMenuItem.Text = "Clear Decoration(s)";
            this.clearDecorationsToolStripMenuItem.Click += new System.EventHandler(this.ClearDecorationsToolStripMenuItem_Click);
            // 
            // deleteElementsToolStripMenuItem
            // 
            this.deleteElementsToolStripMenuItem.Name = "deleteElementsToolStripMenuItem";
            this.deleteElementsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.deleteElementsToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.deleteElementsToolStripMenuItem.Text = "Delete Element(s)";
            this.deleteElementsToolStripMenuItem.Click += new System.EventHandler(this.DeleteElementsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(253, 6);
            // 
            // bestViewToolStripMenuItem
            // 
            this.bestViewToolStripMenuItem.Name = "bestViewToolStripMenuItem";
            this.bestViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.bestViewToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.bestViewToolStripMenuItem.Text = "Best View";
            this.bestViewToolStripMenuItem.Click += new System.EventHandler(this.BestViewToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.aboutToolStripMenuItem1.Text = "About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // openInfoFileDialog
            // 
            this.openInfoFileDialog.Filter = "The Witness Maps|*.wit";
            // 
            // saveInfoFileDialog
            // 
            this.saveInfoFileDialog.DefaultExt = "wit";
            this.saveInfoFileDialog.Filter = "The Witness Maps|*.wit";
            // 
            // createFileDialog
            // 
            this.createFileDialog.Filter = "The Witness Maps Templates|*.wit";
            // 
            // puzzlePropertyLabel
            // 
            this.puzzlePropertyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.puzzlePropertyLabel.AutoSize = true;
            this.puzzlePropertyLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.puzzlePropertyLabel.Location = new System.Drawing.Point(898, 220);
            this.puzzlePropertyLabel.Name = "puzzlePropertyLabel";
            this.puzzlePropertyLabel.Size = new System.Drawing.Size(124, 12);
            this.puzzlePropertyLabel.TabIndex = 8;
            this.puzzlePropertyLabel.Text = "No Property Shown";
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.DefaultExt = "png";
            this.exportFileDialog.Filter = "PNG Files|*.png";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 641);
            this.Controls.Add(this.puzzlePropertyLabel);
            this.Controls.Add(this.tetrisTemplatePictureBox);
            this.Controls.Add(this.ToolkitListView);
            this.Controls.Add(this.resetPropertyButton);
            this.Controls.Add(this.puzzlePropertyGrid);
            this.Controls.Add(this.editorPictureBox);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisTemplatePictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox editorPictureBox;
        private System.Windows.Forms.PropertyGrid puzzlePropertyGrid;
        private System.Windows.Forms.Button resetPropertyButton;
        private System.Windows.Forms.ListView ToolkitListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox tetrisTemplatePictureBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openInfoFileDialog;
        private System.Windows.Forms.SaveFileDialog saveInfoFileDialog;
        private System.Windows.Forms.OpenFileDialog createFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBoardSizeToolStripMenuItem;
        private System.Windows.Forms.Label puzzlePropertyLabel;
        private System.Windows.Forms.ToolStripMenuItem clearDecorationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteElementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bestViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
    }
}

