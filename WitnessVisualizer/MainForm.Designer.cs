namespace WitnessVisualizer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.propertyGridMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.combineDecorationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.customTetrisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rescaleCurrentTetrisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openToolkitFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveToolkitFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolkitTextBox = new System.Windows.Forms.TextBox();
            this.toolkitRight = new System.Windows.Forms.Button();
            this.toolkitLeft = new System.Windows.Forms.Button();
            this.toolkitRemove = new System.Windows.Forms.Button();
            this.toolkitAdd = new System.Windows.Forms.Button();
            this.ToolkitListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.editorPictureBox = new System.Windows.Forms.PictureBox();
            this.decoratorPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.puzzlePropertyLabel = new System.Windows.Forms.Label();
            this.tetrisTemplatePictureBox = new System.Windows.Forms.PictureBox();
            this.puzzlePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.playTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGridMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decoratorPreviewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisTemplatePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyGridMenuStrip
            // 
            this.propertyGridMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.propertyGridMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem});
            this.propertyGridMenuStrip.Name = "propertyGridMenuStrip";
            resources.ApplyResources(this.propertyGridMenuStrip, "propertyGridMenuStrip");
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resources.ApplyResources(this.resetToolStripMenuItem, "resetToolStripMenuItem");
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolkitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.playTestToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            resources.ApplyResources(this.filesToolStripMenuItem, "filesToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
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
            this.combineDecorationsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.bestViewToolStripMenuItem,
            this.toolStripMenuItem3,
            this.flipXYToolStripMenuItem,
            this.flipHorizontallyToolStripMenuItem,
            this.flipVerticallyToolStripMenuItem,
            this.rotateBoardToolStripMenuItem,
            this.toolStripMenuItem4,
            this.editShapesToolStripMenuItem,
            this.tetrisTemplatesToolStripMenuItem,
            this.customTetrisToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.DropDownClosed += new System.EventHandler(this.EditToolStripMenuItem_DropDownClosed);
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.EditToolStripMenuItem_DropDownOpening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            resources.ApplyResources(this.undoToolStripMenuItem, "undoToolStripMenuItem");
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            resources.ApplyResources(this.redoToolStripMenuItem, "redoToolStripMenuItem");
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // changeBoardSizeToolStripMenuItem
            // 
            resources.ApplyResources(this.changeBoardSizeToolStripMenuItem, "changeBoardSizeToolStripMenuItem");
            this.changeBoardSizeToolStripMenuItem.Name = "changeBoardSizeToolStripMenuItem";
            // 
            // clearDecorationsToolStripMenuItem
            // 
            this.clearDecorationsToolStripMenuItem.Name = "clearDecorationsToolStripMenuItem";
            resources.ApplyResources(this.clearDecorationsToolStripMenuItem, "clearDecorationsToolStripMenuItem");
            this.clearDecorationsToolStripMenuItem.Click += new System.EventHandler(this.ClearDecorationsToolStripMenuItem_Click);
            // 
            // combineDecorationsToolStripMenuItem
            // 
            this.combineDecorationsToolStripMenuItem.Name = "combineDecorationsToolStripMenuItem";
            resources.ApplyResources(this.combineDecorationsToolStripMenuItem, "combineDecorationsToolStripMenuItem");
            this.combineDecorationsToolStripMenuItem.Click += new System.EventHandler(this.CombineDecorationsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // bestViewToolStripMenuItem
            // 
            this.bestViewToolStripMenuItem.Name = "bestViewToolStripMenuItem";
            resources.ApplyResources(this.bestViewToolStripMenuItem, "bestViewToolStripMenuItem");
            this.bestViewToolStripMenuItem.Click += new System.EventHandler(this.BestViewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // flipXYToolStripMenuItem
            // 
            this.flipXYToolStripMenuItem.Name = "flipXYToolStripMenuItem";
            resources.ApplyResources(this.flipXYToolStripMenuItem, "flipXYToolStripMenuItem");
            this.flipXYToolStripMenuItem.Click += new System.EventHandler(this.FlipXYToolStripMenuItem_Click);
            // 
            // flipHorizontallyToolStripMenuItem
            // 
            this.flipHorizontallyToolStripMenuItem.Name = "flipHorizontallyToolStripMenuItem";
            resources.ApplyResources(this.flipHorizontallyToolStripMenuItem, "flipHorizontallyToolStripMenuItem");
            this.flipHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.FlipHorizontallyToolStripMenuItem_Click);
            // 
            // flipVerticallyToolStripMenuItem
            // 
            this.flipVerticallyToolStripMenuItem.Name = "flipVerticallyToolStripMenuItem";
            resources.ApplyResources(this.flipVerticallyToolStripMenuItem, "flipVerticallyToolStripMenuItem");
            this.flipVerticallyToolStripMenuItem.Click += new System.EventHandler(this.FlipVerticallyToolStripMenuItem_Click);
            // 
            // rotateBoardToolStripMenuItem
            // 
            this.rotateBoardToolStripMenuItem.Name = "rotateBoardToolStripMenuItem";
            resources.ApplyResources(this.rotateBoardToolStripMenuItem, "rotateBoardToolStripMenuItem");
            this.rotateBoardToolStripMenuItem.Click += new System.EventHandler(this.RotateBoardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
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
            resources.ApplyResources(this.editShapesToolStripMenuItem, "editShapesToolStripMenuItem");
            // 
            // creatingModeToolStripMenuItem
            // 
            this.creatingModeToolStripMenuItem.Name = "creatingModeToolStripMenuItem";
            resources.ApplyResources(this.creatingModeToolStripMenuItem, "creatingModeToolStripMenuItem");
            this.creatingModeToolStripMenuItem.Click += new System.EventHandler(this.CreatingModeToolStripMenuItem_Click);
            // 
            // exitCreatingModeToolStripMenuItem
            // 
            this.exitCreatingModeToolStripMenuItem.Name = "exitCreatingModeToolStripMenuItem";
            resources.ApplyResources(this.exitCreatingModeToolStripMenuItem, "exitCreatingModeToolStripMenuItem");
            this.exitCreatingModeToolStripMenuItem.Click += new System.EventHandler(this.ExitCreatingModeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // regularTriangleToolStripMenuItem
            // 
            this.regularTriangleToolStripMenuItem.Name = "regularTriangleToolStripMenuItem";
            resources.ApplyResources(this.regularTriangleToolStripMenuItem, "regularTriangleToolStripMenuItem");
            this.regularTriangleToolStripMenuItem.Click += new System.EventHandler(this.RegularPolygonToolStripMenuItem_Click);
            // 
            // regularSquareToolStripMenuItem
            // 
            this.regularSquareToolStripMenuItem.Name = "regularSquareToolStripMenuItem";
            resources.ApplyResources(this.regularSquareToolStripMenuItem, "regularSquareToolStripMenuItem");
            this.regularSquareToolStripMenuItem.Click += new System.EventHandler(this.RegularPolygonToolStripMenuItem_Click);
            // 
            // regularPentagonToolStripMenuItem
            // 
            this.regularPentagonToolStripMenuItem.Name = "regularPentagonToolStripMenuItem";
            resources.ApplyResources(this.regularPentagonToolStripMenuItem, "regularPentagonToolStripMenuItem");
            this.regularPentagonToolStripMenuItem.Click += new System.EventHandler(this.RegularPolygonToolStripMenuItem_Click);
            // 
            // regularHexagonToolStripMenuItem
            // 
            this.regularHexagonToolStripMenuItem.Name = "regularHexagonToolStripMenuItem";
            resources.ApplyResources(this.regularHexagonToolStripMenuItem, "regularHexagonToolStripMenuItem");
            this.regularHexagonToolStripMenuItem.Click += new System.EventHandler(this.RegularPolygonToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // deleteElementsToolStripMenuItem
            // 
            this.deleteElementsToolStripMenuItem.Name = "deleteElementsToolStripMenuItem";
            resources.ApplyResources(this.deleteElementsToolStripMenuItem, "deleteElementsToolStripMenuItem");
            this.deleteElementsToolStripMenuItem.Click += new System.EventHandler(this.DeleteElementsToolStripMenuItem_Click);
            // 
            // tetrisTemplatesToolStripMenuItem
            // 
            this.tetrisTemplatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regenerateFromGraphToolStripMenuItem});
            this.tetrisTemplatesToolStripMenuItem.Name = "tetrisTemplatesToolStripMenuItem";
            resources.ApplyResources(this.tetrisTemplatesToolStripMenuItem, "tetrisTemplatesToolStripMenuItem");
            // 
            // regenerateFromGraphToolStripMenuItem
            // 
            this.regenerateFromGraphToolStripMenuItem.Name = "regenerateFromGraphToolStripMenuItem";
            resources.ApplyResources(this.regenerateFromGraphToolStripMenuItem, "regenerateFromGraphToolStripMenuItem");
            this.regenerateFromGraphToolStripMenuItem.Click += new System.EventHandler(this.RegenerateFromGraphToolStripMenuItem_Click);
            // 
            // customTetrisToolStripMenuItem
            // 
            this.customTetrisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rescaleCurrentTetrisToolStripMenuItem});
            this.customTetrisToolStripMenuItem.Name = "customTetrisToolStripMenuItem";
            resources.ApplyResources(this.customTetrisToolStripMenuItem, "customTetrisToolStripMenuItem");
            // 
            // rescaleCurrentTetrisToolStripMenuItem
            // 
            this.rescaleCurrentTetrisToolStripMenuItem.Name = "rescaleCurrentTetrisToolStripMenuItem";
            resources.ApplyResources(this.rescaleCurrentTetrisToolStripMenuItem, "rescaleCurrentTetrisToolStripMenuItem");
            this.rescaleCurrentTetrisToolStripMenuItem.Click += new System.EventHandler(this.RescaleCurrentTetrisToolStripMenuItem_Click);
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
            resources.ApplyResources(this.toolkitToolStripMenuItem, "toolkitToolStripMenuItem");
            // 
            // saveSchemeToolStripMenuItem
            // 
            this.saveSchemeToolStripMenuItem.Name = "saveSchemeToolStripMenuItem";
            resources.ApplyResources(this.saveSchemeToolStripMenuItem, "saveSchemeToolStripMenuItem");
            this.saveSchemeToolStripMenuItem.Click += new System.EventHandler(this.SaveSchemeToolStripMenuItem_Click);
            // 
            // loadSchemeToolStripMenuItem
            // 
            this.loadSchemeToolStripMenuItem.Name = "loadSchemeToolStripMenuItem";
            resources.ApplyResources(this.loadSchemeToolStripMenuItem, "loadSchemeToolStripMenuItem");
            this.loadSchemeToolStripMenuItem.Click += new System.EventHandler(this.LoadSchemeToolStripMenuItem_Click);
            // 
            // resetToDefaultToolStripMenuItem
            // 
            this.resetToDefaultToolStripMenuItem.Name = "resetToDefaultToolStripMenuItem";
            resources.ApplyResources(this.resetToDefaultToolStripMenuItem, "resetToDefaultToolStripMenuItem");
            this.resetToDefaultToolStripMenuItem.Click += new System.EventHandler(this.ResetToDefaultToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            // 
            // mergeSchemeToolStripMenuItem
            // 
            this.mergeSchemeToolStripMenuItem.Name = "mergeSchemeToolStripMenuItem";
            resources.ApplyResources(this.mergeSchemeToolStripMenuItem, "mergeSchemeToolStripMenuItem");
            this.mergeSchemeToolStripMenuItem.Click += new System.EventHandler(this.MergeSchemeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // openInfoFileDialog
            // 
            resources.ApplyResources(this.openInfoFileDialog, "openInfoFileDialog");
            // 
            // saveInfoFileDialog
            // 
            this.saveInfoFileDialog.DefaultExt = "wit";
            resources.ApplyResources(this.saveInfoFileDialog, "saveInfoFileDialog");
            // 
            // createFileDialog
            // 
            resources.ApplyResources(this.createFileDialog, "createFileDialog");
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.DefaultExt = "png";
            resources.ApplyResources(this.exportFileDialog, "exportFileDialog");
            // 
            // openToolkitFileDialog
            // 
            this.openToolkitFileDialog.DefaultExt = "toolkit";
            this.openToolkitFileDialog.FileName = "openFileDialog1";
            resources.ApplyResources(this.openToolkitFileDialog, "openToolkitFileDialog");
            // 
            // saveToolkitFileDialog
            // 
            this.saveToolkitFileDialog.DefaultExt = "toolkit";
            resources.ApplyResources(this.saveToolkitFileDialog, "saveToolkitFileDialog");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolkitTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.toolkitRight);
            this.splitContainer1.Panel1.Controls.Add(this.toolkitLeft);
            this.splitContainer1.Panel1.Controls.Add(this.toolkitRemove);
            this.splitContainer1.Panel1.Controls.Add(this.toolkitAdd);
            this.splitContainer1.Panel1.Controls.Add(this.ToolkitListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer_SplitterMoved);
            // 
            // toolkitTextBox
            // 
            resources.ApplyResources(this.toolkitTextBox, "toolkitTextBox");
            this.toolkitTextBox.Name = "toolkitTextBox";
            this.toolkitTextBox.Click += new System.EventHandler(this.ToolkitTextBox_Click);
            this.toolkitTextBox.TextChanged += new System.EventHandler(this.ToolkitTextBox_TextChanged);
            // 
            // toolkitRight
            // 
            resources.ApplyResources(this.toolkitRight, "toolkitRight");
            this.toolkitRight.Name = "toolkitRight";
            this.toolkitRight.UseVisualStyleBackColor = true;
            this.toolkitRight.Click += new System.EventHandler(this.ToolkitRight_Click);
            // 
            // toolkitLeft
            // 
            resources.ApplyResources(this.toolkitLeft, "toolkitLeft");
            this.toolkitLeft.Name = "toolkitLeft";
            this.toolkitLeft.UseVisualStyleBackColor = true;
            this.toolkitLeft.Click += new System.EventHandler(this.ToolkitLeft_Click);
            // 
            // toolkitRemove
            // 
            resources.ApplyResources(this.toolkitRemove, "toolkitRemove");
            this.toolkitRemove.Name = "toolkitRemove";
            this.toolkitRemove.UseVisualStyleBackColor = true;
            this.toolkitRemove.Click += new System.EventHandler(this.ToolkitRemove_Click);
            // 
            // toolkitAdd
            // 
            resources.ApplyResources(this.toolkitAdd, "toolkitAdd");
            this.toolkitAdd.Name = "toolkitAdd";
            this.toolkitAdd.UseVisualStyleBackColor = true;
            this.toolkitAdd.Click += new System.EventHandler(this.ToolkitAdd_Click);
            // 
            // ToolkitListView
            // 
            resources.ApplyResources(this.ToolkitListView, "ToolkitListView");
            this.ToolkitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ToolkitListView.GridLines = true;
            this.ToolkitListView.HideSelection = false;
            this.ToolkitListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("ToolkitListView.Items")))});
            this.ToolkitListView.Name = "ToolkitListView";
            this.ToolkitListView.UseCompatibleStateImageBehavior = false;
            this.ToolkitListView.SelectedIndexChanged += new System.EventHandler(this.ToolkitListView_SelectedIndexChanged);
            this.ToolkitListView.Click += new System.EventHandler(this.ToolkitListView_Click);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.editorPictureBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.decoratorPreviewPictureBox);
            this.splitContainer2.Panel2.Controls.Add(this.puzzlePropertyLabel);
            this.splitContainer2.Panel2.Controls.Add(this.tetrisTemplatePictureBox);
            this.splitContainer2.Panel2.Controls.Add(this.puzzlePropertyGrid);
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer_SplitterMoved);
            // 
            // editorPictureBox
            // 
            resources.ApplyResources(this.editorPictureBox, "editorPictureBox");
            this.editorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorPictureBox.Name = "editorPictureBox";
            this.editorPictureBox.TabStop = false;
            this.editorPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseDown);
            this.editorPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseMove);
            this.editorPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseUp);
            this.editorPictureBox.Resize += new System.EventHandler(this.EditorPictureBox_Resize);
            // 
            // decoratorPreviewPictureBox
            // 
            resources.ApplyResources(this.decoratorPreviewPictureBox, "decoratorPreviewPictureBox");
            this.decoratorPreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decoratorPreviewPictureBox.Name = "decoratorPreviewPictureBox";
            this.decoratorPreviewPictureBox.TabStop = false;
            // 
            // puzzlePropertyLabel
            // 
            resources.ApplyResources(this.puzzlePropertyLabel, "puzzlePropertyLabel");
            this.puzzlePropertyLabel.Name = "puzzlePropertyLabel";
            // 
            // tetrisTemplatePictureBox
            // 
            resources.ApplyResources(this.tetrisTemplatePictureBox, "tetrisTemplatePictureBox");
            this.tetrisTemplatePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tetrisTemplatePictureBox.Name = "tetrisTemplatePictureBox";
            this.tetrisTemplatePictureBox.TabStop = false;
            this.tetrisTemplatePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TetrisTemplatePictureBox_MouseDown);
            this.tetrisTemplatePictureBox.Resize += new System.EventHandler(this.EditorPictureBox_Resize);
            // 
            // puzzlePropertyGrid
            // 
            resources.ApplyResources(this.puzzlePropertyGrid, "puzzlePropertyGrid");
            this.puzzlePropertyGrid.ContextMenuStrip = this.propertyGridMenuStrip;
            this.puzzlePropertyGrid.Name = "puzzlePropertyGrid";
            this.puzzlePropertyGrid.ToolbarVisible = false;
            this.puzzlePropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PuzzlePropertyGrid_PropertyValueChanged);
            // 
            // playTestToolStripMenuItem
            // 
            this.playTestToolStripMenuItem.Name = "playTestToolStripMenuItem";
            resources.ApplyResources(this.playTestToolStripMenuItem, "playTestToolStripMenuItem");
            this.playTestToolStripMenuItem.Click += new System.EventHandler(this.playTestToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.propertyGridMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decoratorPreviewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisTemplatePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.ToolStripMenuItem toolkitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSchemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSchemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem mergeSchemeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openToolkitFileDialog;
        private System.Windows.Forms.SaveFileDialog saveToolkitFileDialog;
        private System.Windows.Forms.ToolStripMenuItem combineDecorationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customTetrisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rescaleCurrentTetrisToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip propertyGridMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox toolkitTextBox;
        private System.Windows.Forms.Button toolkitRight;
        private System.Windows.Forms.Button toolkitLeft;
        private System.Windows.Forms.Button toolkitRemove;
        private System.Windows.Forms.Button toolkitAdd;
        private System.Windows.Forms.ListView ToolkitListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox decoratorPreviewPictureBox;
        private System.Windows.Forms.Label puzzlePropertyLabel;
        private System.Windows.Forms.PictureBox tetrisTemplatePictureBox;
        private System.Windows.Forms.PropertyGrid puzzlePropertyGrid;
        private System.Windows.Forms.PictureBox editorPictureBox;
        private System.Windows.Forms.ToolStripMenuItem playTestToolStripMenuItem;
    }
}

