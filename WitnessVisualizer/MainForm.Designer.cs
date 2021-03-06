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
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.bestViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.flipXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.editShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitCreatingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.regularTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularSquareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularPentagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularHexagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tetrisTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regenerateFromGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolkitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.mergeSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInfoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveInfoFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.createFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.puzzlePropertyLabel = new System.Windows.Forms.Label();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolkitAdd = new System.Windows.Forms.Button();
            this.toolkitRemove = new System.Windows.Forms.Button();
            this.toolkitLeft = new System.Windows.Forms.Button();
            this.toolkitRight = new System.Windows.Forms.Button();
            this.toolkitTextBox = new System.Windows.Forms.TextBox();
            this.openToolkitFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveToolkitFileDialog = new System.Windows.Forms.SaveFileDialog();
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
            this.editorPictureBox.Size = new System.Drawing.Size(438, 505);
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
            this.puzzlePropertyGrid.Location = new System.Drawing.Point(711, 235);
            this.puzzlePropertyGrid.Name = "puzzlePropertyGrid";
            this.puzzlePropertyGrid.Size = new System.Drawing.Size(177, 270);
            this.puzzlePropertyGrid.TabIndex = 2;
            this.puzzlePropertyGrid.ToolbarVisible = false;
            this.puzzlePropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PuzzlePropertyGrid_PropertyValueChanged);
            // 
            // resetPropertyButton
            // 
            this.resetPropertyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetPropertyButton.Location = new System.Drawing.Point(711, 510);
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
            this.ToolkitListView.Size = new System.Drawing.Size(249, 478);
            this.ToolkitListView.TabIndex = 5;
            this.ToolkitListView.UseCompatibleStateImageBehavior = false;
            this.ToolkitListView.SelectedIndexChanged += new System.EventHandler(this.ToolkitListView_SelectedIndexChanged);
            this.ToolkitListView.Click += new System.EventHandler(this.ToolkitListView_Click);
            // 
            // tetrisTemplatePictureBox
            // 
            this.tetrisTemplatePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tetrisTemplatePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tetrisTemplatePictureBox.Location = new System.Drawing.Point(711, 28);
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
            this.toolkitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(896, 25);
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
            this.toolStripMenuItem2,
            this.bestViewToolStripMenuItem,
            this.toolStripMenuItem3,
            this.flipXYToolStripMenuItem,
            this.flipHorizontallyToolStripMenuItem,
            this.flipVerticallyToolStripMenuItem,
            this.rotateBoardToolStripMenuItem,
            this.toolStripMenuItem4,
            this.editShapesToolStripMenuItem,
            this.tetrisTemplatesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.EditToolStripMenuItem_DropDownOpening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(230, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // changeBoardSizeToolStripMenuItem
            // 
            this.changeBoardSizeToolStripMenuItem.Enabled = false;
            this.changeBoardSizeToolStripMenuItem.Name = "changeBoardSizeToolStripMenuItem";
            this.changeBoardSizeToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.changeBoardSizeToolStripMenuItem.Text = "Change Board Size...";
            // 
            // clearDecorationsToolStripMenuItem
            // 
            this.clearDecorationsToolStripMenuItem.Name = "clearDecorationsToolStripMenuItem";
            this.clearDecorationsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.clearDecorationsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.clearDecorationsToolStripMenuItem.Text = "Clear Decoration(s)";
            this.clearDecorationsToolStripMenuItem.Click += new System.EventHandler(this.ClearDecorationsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(230, 6);
            // 
            // bestViewToolStripMenuItem
            // 
            this.bestViewToolStripMenuItem.Name = "bestViewToolStripMenuItem";
            this.bestViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.bestViewToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.bestViewToolStripMenuItem.Text = "Best View";
            this.bestViewToolStripMenuItem.Click += new System.EventHandler(this.BestViewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(230, 6);
            // 
            // flipXYToolStripMenuItem
            // 
            this.flipXYToolStripMenuItem.Name = "flipXYToolStripMenuItem";
            this.flipXYToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.flipXYToolStripMenuItem.Text = "Flip X/Y";
            this.flipXYToolStripMenuItem.Click += new System.EventHandler(this.FlipXYToolStripMenuItem_Click);
            // 
            // flipHorizontallyToolStripMenuItem
            // 
            this.flipHorizontallyToolStripMenuItem.Name = "flipHorizontallyToolStripMenuItem";
            this.flipHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.flipHorizontallyToolStripMenuItem.Text = "Flip Horizontally";
            this.flipHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.FlipHorizontallyToolStripMenuItem_Click);
            // 
            // flipVerticallyToolStripMenuItem
            // 
            this.flipVerticallyToolStripMenuItem.Name = "flipVerticallyToolStripMenuItem";
            this.flipVerticallyToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.flipVerticallyToolStripMenuItem.Text = "Flip Vertically";
            this.flipVerticallyToolStripMenuItem.Click += new System.EventHandler(this.FlipVerticallyToolStripMenuItem_Click);
            // 
            // rotateBoardToolStripMenuItem
            // 
            this.rotateBoardToolStripMenuItem.Name = "rotateBoardToolStripMenuItem";
            this.rotateBoardToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.rotateBoardToolStripMenuItem.Text = "Rotate Board...";
            this.rotateBoardToolStripMenuItem.Click += new System.EventHandler(this.RotateBoardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(230, 6);
            // 
            // editShapesToolStripMenuItem
            // 
            this.editShapesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creatingModeToolStripMenuItem,
            this.exitCreatingModeToolStripMenuItem,
            this.toolStripMenuItem6,
            this.regularTriangleToolStripMenuItem,
            this.regularSquareToolStripMenuItem,
            this.regularPentagonToolStripMenuItem,
            this.regularHexagonToolStripMenuItem,
            this.toolStripMenuItem5,
            this.deleteElementsToolStripMenuItem});
            this.editShapesToolStripMenuItem.Name = "editShapesToolStripMenuItem";
            this.editShapesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.editShapesToolStripMenuItem.Text = "Edit Shapes";
            // 
            // creatingModeToolStripMenuItem
            // 
            this.creatingModeToolStripMenuItem.Name = "creatingModeToolStripMenuItem";
            this.creatingModeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.creatingModeToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.creatingModeToolStripMenuItem.Text = "Enter Creating Mode";
            this.creatingModeToolStripMenuItem.Click += new System.EventHandler(this.CreatingModeToolStripMenuItem_Click);
            // 
            // exitCreatingModeToolStripMenuItem
            // 
            this.exitCreatingModeToolStripMenuItem.Name = "exitCreatingModeToolStripMenuItem";
            this.exitCreatingModeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.exitCreatingModeToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.exitCreatingModeToolStripMenuItem.Text = "Exit Creating Mode";
            this.exitCreatingModeToolStripMenuItem.Click += new System.EventHandler(this.ExitCreatingModeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(253, 6);
            // 
            // regularTriangleToolStripMenuItem
            // 
            this.regularTriangleToolStripMenuItem.Name = "regularTriangleToolStripMenuItem";
            this.regularTriangleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.regularTriangleToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.regularTriangleToolStripMenuItem.Text = "Regular Triangle";
            this.regularTriangleToolStripMenuItem.Click += new System.EventHandler(this.RegularPolygonToolStripMenuItem_Click);
            // 
            // regularSquareToolStripMenuItem
            // 
            this.regularSquareToolStripMenuItem.Name = "regularSquareToolStripMenuItem";
            this.regularSquareToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.regularSquareToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.regularSquareToolStripMenuItem.Text = "Regular Square";
            this.regularSquareToolStripMenuItem.Click += new System.EventHandler(this.RegularPolygonToolStripMenuItem_Click);
            // 
            // regularPentagonToolStripMenuItem
            // 
            this.regularPentagonToolStripMenuItem.Name = "regularPentagonToolStripMenuItem";
            this.regularPentagonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.regularPentagonToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.regularPentagonToolStripMenuItem.Text = "Regular Pentagon";
            this.regularPentagonToolStripMenuItem.Click += new System.EventHandler(this.RegularPolygonToolStripMenuItem_Click);
            // 
            // regularHexagonToolStripMenuItem
            // 
            this.regularHexagonToolStripMenuItem.Name = "regularHexagonToolStripMenuItem";
            this.regularHexagonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.regularHexagonToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.regularHexagonToolStripMenuItem.Text = "Regular Hexagon";
            this.regularHexagonToolStripMenuItem.Click += new System.EventHandler(this.RegularPolygonToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(253, 6);
            // 
            // deleteElementsToolStripMenuItem
            // 
            this.deleteElementsToolStripMenuItem.Name = "deleteElementsToolStripMenuItem";
            this.deleteElementsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.deleteElementsToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.deleteElementsToolStripMenuItem.Text = "Delete Element(s)";
            this.deleteElementsToolStripMenuItem.Click += new System.EventHandler(this.DeleteElementsToolStripMenuItem_Click);
            // 
            // tetrisTemplatesToolStripMenuItem
            // 
            this.tetrisTemplatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regenerateFromGraphToolStripMenuItem});
            this.tetrisTemplatesToolStripMenuItem.Name = "tetrisTemplatesToolStripMenuItem";
            this.tetrisTemplatesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.tetrisTemplatesToolStripMenuItem.Text = "Tetris Templates";
            // 
            // regenerateFromGraphToolStripMenuItem
            // 
            this.regenerateFromGraphToolStripMenuItem.Name = "regenerateFromGraphToolStripMenuItem";
            this.regenerateFromGraphToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.regenerateFromGraphToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.regenerateFromGraphToolStripMenuItem.Text = "Regenerate from Graph";
            this.regenerateFromGraphToolStripMenuItem.Click += new System.EventHandler(this.RegenerateFromGraphToolStripMenuItem_Click);
            // 
            // toolkitToolStripMenuItem
            // 
            this.toolkitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSchemeToolStripMenuItem,
            this.loadSchemeToolStripMenuItem,
            this.resetToDefaultToolStripMenuItem,
            this.toolStripMenuItem7,
            this.mergeSchemeToolStripMenuItem});
            this.toolkitToolStripMenuItem.Name = "toolkitToolStripMenuItem";
            this.toolkitToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.toolkitToolStripMenuItem.Text = "Toolkit";
            // 
            // saveSchemeToolStripMenuItem
            // 
            this.saveSchemeToolStripMenuItem.Name = "saveSchemeToolStripMenuItem";
            this.saveSchemeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveSchemeToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.saveSchemeToolStripMenuItem.Text = "Save Scheme...";
            this.saveSchemeToolStripMenuItem.Click += new System.EventHandler(this.SaveSchemeToolStripMenuItem_Click);
            // 
            // loadSchemeToolStripMenuItem
            // 
            this.loadSchemeToolStripMenuItem.Name = "loadSchemeToolStripMenuItem";
            this.loadSchemeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.loadSchemeToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.loadSchemeToolStripMenuItem.Text = "Load Scheme...";
            this.loadSchemeToolStripMenuItem.Click += new System.EventHandler(this.LoadSchemeToolStripMenuItem_Click);
            // 
            // resetToDefaultToolStripMenuItem
            // 
            this.resetToDefaultToolStripMenuItem.Name = "resetToDefaultToolStripMenuItem";
            this.resetToDefaultToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.resetToDefaultToolStripMenuItem.Text = "Reset To Default";
            this.resetToDefaultToolStripMenuItem.Click += new System.EventHandler(this.ResetToDefaultToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(231, 6);
            // 
            // mergeSchemeToolStripMenuItem
            // 
            this.mergeSchemeToolStripMenuItem.Name = "mergeSchemeToolStripMenuItem";
            this.mergeSchemeToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.mergeSchemeToolStripMenuItem.Text = "Merge Scheme...";
            this.mergeSchemeToolStripMenuItem.Click += new System.EventHandler(this.MergeSchemeToolStripMenuItem_Click);
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
            this.puzzlePropertyLabel.Location = new System.Drawing.Point(712, 220);
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
            // toolkitAdd
            // 
            this.toolkitAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolkitAdd.Location = new System.Drawing.Point(88, 511);
            this.toolkitAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolkitAdd.Name = "toolkitAdd";
            this.toolkitAdd.Size = new System.Drawing.Size(21, 22);
            this.toolkitAdd.TabIndex = 9;
            this.toolkitAdd.Text = "+";
            this.toolkitAdd.UseVisualStyleBackColor = true;
            this.toolkitAdd.Click += new System.EventHandler(this.ToolkitAdd_Click);
            // 
            // toolkitRemove
            // 
            this.toolkitRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolkitRemove.Location = new System.Drawing.Point(63, 511);
            this.toolkitRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolkitRemove.Name = "toolkitRemove";
            this.toolkitRemove.Size = new System.Drawing.Size(21, 22);
            this.toolkitRemove.TabIndex = 10;
            this.toolkitRemove.Text = "-";
            this.toolkitRemove.UseVisualStyleBackColor = true;
            this.toolkitRemove.Click += new System.EventHandler(this.ToolkitRemove_Click);
            // 
            // toolkitLeft
            // 
            this.toolkitLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolkitLeft.Location = new System.Drawing.Point(12, 510);
            this.toolkitLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolkitLeft.Name = "toolkitLeft";
            this.toolkitLeft.Size = new System.Drawing.Size(21, 22);
            this.toolkitLeft.TabIndex = 11;
            this.toolkitLeft.Text = "<";
            this.toolkitLeft.UseVisualStyleBackColor = true;
            this.toolkitLeft.Click += new System.EventHandler(this.ToolkitLeft_Click);
            // 
            // toolkitRight
            // 
            this.toolkitRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolkitRight.Location = new System.Drawing.Point(38, 510);
            this.toolkitRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolkitRight.Name = "toolkitRight";
            this.toolkitRight.Size = new System.Drawing.Size(21, 22);
            this.toolkitRight.TabIndex = 12;
            this.toolkitRight.Text = ">";
            this.toolkitRight.UseVisualStyleBackColor = true;
            this.toolkitRight.Click += new System.EventHandler(this.ToolkitRight_Click);
            // 
            // toolkitTextBox
            // 
            this.toolkitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolkitTextBox.Location = new System.Drawing.Point(114, 513);
            this.toolkitTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolkitTextBox.Name = "toolkitTextBox";
            this.toolkitTextBox.Size = new System.Drawing.Size(147, 21);
            this.toolkitTextBox.TabIndex = 13;
            this.toolkitTextBox.Click += new System.EventHandler(this.ToolkitTextBox_Click);
            this.toolkitTextBox.TextChanged += new System.EventHandler(this.ToolkitTextBox_TextChanged);
            // 
            // openToolkitFileDialog
            // 
            this.openToolkitFileDialog.DefaultExt = "toolkit";
            this.openToolkitFileDialog.FileName = "openFileDialog1";
            this.openToolkitFileDialog.Filter = "Toolkit Scheme|*.toolkit";
            // 
            // saveToolkitFileDialog
            // 
            this.saveToolkitFileDialog.DefaultExt = "toolkit";
            this.saveToolkitFileDialog.Filter = "Toolkit Scheme|*.toolkit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 545);
            this.Controls.Add(this.toolkitTextBox);
            this.Controls.Add(this.toolkitRight);
            this.Controls.Add(this.toolkitLeft);
            this.Controls.Add(this.toolkitRemove);
            this.Controls.Add(this.toolkitAdd);
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bestViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
        private System.Windows.Forms.ToolStripMenuItem flipXYToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipVerticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem editShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularSquareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularPentagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularHexagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tetrisTemplatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regenerateFromGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem deleteElementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creatingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem exitCreatingModeToolStripMenuItem;
        private System.Windows.Forms.Button toolkitAdd;
        private System.Windows.Forms.Button toolkitRemove;
        private System.Windows.Forms.Button toolkitLeft;
        private System.Windows.Forms.Button toolkitRight;
        private System.Windows.Forms.TextBox toolkitTextBox;
        private System.Windows.Forms.ToolStripMenuItem toolkitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSchemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSchemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem mergeSchemeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openToolkitFileDialog;
        private System.Windows.Forms.SaveFileDialog saveToolkitFileDialog;
    }
}

