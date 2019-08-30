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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("test2", 0);
            this.editorPictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.puzzlePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.resetPropertyButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tetrisTemplatePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.editorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisTemplatePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // editorPictureBox
            // 
            this.editorPictureBox.Location = new System.Drawing.Point(184, 22);
            this.editorPictureBox.Name = "editorPictureBox";
            this.editorPictureBox.Size = new System.Drawing.Size(636, 589);
            this.editorPictureBox.TabIndex = 0;
            this.editorPictureBox.TabStop = false;
            this.editorPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseDown);
            this.editorPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseMove);
            this.editorPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // puzzlePropertyGrid
            // 
            this.puzzlePropertyGrid.Location = new System.Drawing.Point(826, 211);
            this.puzzlePropertyGrid.Name = "puzzlePropertyGrid";
            this.puzzlePropertyGrid.Size = new System.Drawing.Size(177, 371);
            this.puzzlePropertyGrid.TabIndex = 2;
            // 
            // resetPropertyButton
            // 
            this.resetPropertyButton.Location = new System.Drawing.Point(826, 588);
            this.resetPropertyButton.Name = "resetPropertyButton";
            this.resetPropertyButton.Size = new System.Drawing.Size(75, 23);
            this.resetPropertyButton.TabIndex = 3;
            this.resetPropertyButton.Text = "Reset";
            this.resetPropertyButton.UseVisualStyleBackColor = true;
            this.resetPropertyButton.Click += new System.EventHandler(this.ResetPropertyButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "select";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(12, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(155, 589);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListView1_DrawItem);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListView1_DrawSubItem);
            // 
            // tetrisTemplatePictureBox
            // 
            this.tetrisTemplatePictureBox.Location = new System.Drawing.Point(826, 22);
            this.tetrisTemplatePictureBox.Name = "tetrisTemplatePictureBox";
            this.tetrisTemplatePictureBox.Size = new System.Drawing.Size(177, 183);
            this.tetrisTemplatePictureBox.TabIndex = 6;
            this.tetrisTemplatePictureBox.TabStop = false;
            this.tetrisTemplatePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TetrisTemplatePictureBox_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 745);
            this.Controls.Add(this.tetrisTemplatePictureBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.resetPropertyButton);
            this.Controls.Add(this.puzzlePropertyGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.editorPictureBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisTemplatePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox editorPictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PropertyGrid puzzlePropertyGrid;
        private System.Windows.Forms.Button resetPropertyButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox tetrisTemplatePictureBox;
    }
}

