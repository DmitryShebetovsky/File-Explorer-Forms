﻿namespace FileExplorer
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsl_path = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsb_upLevel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv_files = new System.Windows.Forms.TreeView();
            this.il_ForTree = new System.Windows.Forms.ImageList(this.components);
            this.lv_files = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.il_DiscFoldersFilesIcons_Large = new System.Windows.Forms.ImageList(this.components);
            this.il_DiscFoldersFilesIcons_Small = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsl_path,
            this.toolStripComboBox1,
            this.toolStripLabel2,
            this.tsb_upLevel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(678, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel1.Text = "Текущий путь: ";
            // 
            // tsl_path
            // 
            this.tsl_path.BackColor = System.Drawing.SystemColors.Control;
            this.tsl_path.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tsl_path.Name = "tsl_path";
            this.tsl_path.Size = new System.Drawing.Size(136, 22);
            this.tsl_path.Text = "Тут будет текущий путь";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel2.Text = "Вид: ";
            // 
            // tsb_upLevel
            // 
            this.tsb_upLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_upLevel.Image = global::FileExplorer.Properties.Resources.back;
            this.tsb_upLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_upLevel.Name = "tsb_upLevel";
            this.tsb_upLevel.Size = new System.Drawing.Size(23, 22);
            this.tsb_upLevel.Text = "Вверх";
            this.tsb_upLevel.Click += new System.EventHandler(this.tsb_upLevel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv_files);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lv_files);
            this.splitContainer1.Size = new System.Drawing.Size(654, 308);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
            // 
            // tv_files
            // 
            this.tv_files.AllowDrop = true;
            this.tv_files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_files.ImageIndex = 0;
            this.tv_files.ImageList = this.il_ForTree;
            this.tv_files.LabelEdit = true;
            this.tv_files.Location = new System.Drawing.Point(3, 3);
            this.tv_files.Name = "tv_files";
            this.tv_files.SelectedImageIndex = 0;
            this.tv_files.Size = new System.Drawing.Size(211, 302);
            this.tv_files.TabIndex = 0;
            // 
            // il_ForTree
            // 
            this.il_ForTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_ForTree.ImageStream")));
            this.il_ForTree.TransparentColor = System.Drawing.Color.Transparent;
            this.il_ForTree.Images.SetKeyName(0, "folder.png");
            this.il_ForTree.Images.SetKeyName(1, "file.png");
            this.il_ForTree.Images.SetKeyName(2, "disk.png");
            // 
            // lv_files
            // 
            this.lv_files.AllowDrop = true;
            this.lv_files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_files.LargeImageList = this.il_DiscFoldersFilesIcons_Large;
            this.lv_files.Location = new System.Drawing.Point(3, 3);
            this.lv_files.MultiSelect = false;
            this.lv_files.Name = "lv_files";
            this.lv_files.Size = new System.Drawing.Size(427, 305);
            this.lv_files.SmallImageList = this.il_DiscFoldersFilesIcons_Small;
            this.lv_files.TabIndex = 0;
            this.lv_files.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Размер";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дата создания";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Дата изменения";
            this.columnHeader4.Width = 120;
            // 
            // il_DiscFoldersFilesIcons_Large
            // 
            this.il_DiscFoldersFilesIcons_Large.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_DiscFoldersFilesIcons_Large.ImageStream")));
            this.il_DiscFoldersFilesIcons_Large.TransparentColor = System.Drawing.Color.Transparent;
            this.il_DiscFoldersFilesIcons_Large.Images.SetKeyName(0, "disk.png");
            this.il_DiscFoldersFilesIcons_Large.Images.SetKeyName(1, "folder.png");
            this.il_DiscFoldersFilesIcons_Large.Images.SetKeyName(2, "file.png");
            // 
            // il_DiscFoldersFilesIcons_Small
            // 
            this.il_DiscFoldersFilesIcons_Small.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_DiscFoldersFilesIcons_Small.ImageStream")));
            this.il_DiscFoldersFilesIcons_Small.TransparentColor = System.Drawing.Color.Transparent;
            this.il_DiscFoldersFilesIcons_Small.Images.SetKeyName(0, "disk.png");
            this.il_DiscFoldersFilesIcons_Small.Images.SetKeyName(1, "folder.png");
            this.il_DiscFoldersFilesIcons_Small.Images.SetKeyName(2, "file.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 348);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Form1";
            this.Text = "Проводник";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lv_files;
        private System.Windows.Forms.ImageList il_DiscFoldersFilesIcons_Small;
        private System.Windows.Forms.ImageList il_DiscFoldersFilesIcons_Large;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripButton tsb_upLevel;
        private System.Windows.Forms.ToolStripLabel tsl_path;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.TreeView tv_files;
        private System.Windows.Forms.ImageList il_ForTree;

    }
}

