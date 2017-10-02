namespace MonitorBrowserTime
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.canBeProductiveOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addProductiveTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeDataGraphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDataFilrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canBeProductiveOnlineToolStripMenuItem,
            this.toolStripSeparator2,
            this.addProductiveTagsToolStripMenuItem,
            this.seeDataGraphsToolStripMenuItem,
            this.updateDataFilrToolStripMenuItem,
            this.toolStripSeparator1,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(398, 276);
            // 
            // canBeProductiveOnlineToolStripMenuItem
            // 
            this.canBeProductiveOnlineToolStripMenuItem.CheckOnClick = true;
            this.canBeProductiveOnlineToolStripMenuItem.Name = "canBeProductiveOnlineToolStripMenuItem";
            this.canBeProductiveOnlineToolStripMenuItem.Size = new System.Drawing.Size(397, 36);
            this.canBeProductiveOnlineToolStripMenuItem.Text = "Can Be Productive Online";
            this.canBeProductiveOnlineToolStripMenuItem.ToolTipText = "Toggle if you want your marked software to be considered productive while online";
            this.canBeProductiveOnlineToolStripMenuItem.Click += new System.EventHandler(this.canBeProductiveOnlineToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(394, 6);
            // 
            // addProductiveTagsToolStripMenuItem
            // 
            this.addProductiveTagsToolStripMenuItem.Name = "addProductiveTagsToolStripMenuItem";
            this.addProductiveTagsToolStripMenuItem.Size = new System.Drawing.Size(397, 36);
            this.addProductiveTagsToolStripMenuItem.Text = "Manage Productive Software";
            this.addProductiveTagsToolStripMenuItem.ToolTipText = "Mark & Remove software that you define as \'\'Productive\'\'";
            this.addProductiveTagsToolStripMenuItem.Click += new System.EventHandler(this.addProductiveTagsToolStripMenuItem_Click);
            // 
            // seeDataGraphsToolStripMenuItem
            // 
            this.seeDataGraphsToolStripMenuItem.Name = "seeDataGraphsToolStripMenuItem";
            this.seeDataGraphsToolStripMenuItem.Size = new System.Drawing.Size(397, 36);
            this.seeDataGraphsToolStripMenuItem.Text = "See Data Graphs";
            this.seeDataGraphsToolStripMenuItem.ToolTipText = "See your data presented to you as graphs!";
            this.seeDataGraphsToolStripMenuItem.Click += new System.EventHandler(this.seeDataGraphsToolStripMenuItem_Click);
            // 
            // updateDataFilrToolStripMenuItem
            // 
            this.updateDataFilrToolStripMenuItem.AutoToolTip = true;
            this.updateDataFilrToolStripMenuItem.Name = "updateDataFilrToolStripMenuItem";
            this.updateDataFilrToolStripMenuItem.Size = new System.Drawing.Size(397, 36);
            this.updateDataFilrToolStripMenuItem.Text = "Update Data Files";
            this.updateDataFilrToolStripMenuItem.ToolTipText = "This will update your data files in My Documents/Monitor Browser Data";
            this.updateDataFilrToolStripMenuItem.Click += new System.EventHandler(this.updateDataFilrToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(394, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.resetDataToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(397, 36);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click_1);
            // 
            // resetDataToolStripMenuItem1
            // 
            this.resetDataToolStripMenuItem1.Name = "resetDataToolStripMenuItem1";
            this.resetDataToolStripMenuItem1.Size = new System.Drawing.Size(280, 38);
            this.resetDataToolStripMenuItem1.Text = "Reset Data";
            this.resetDataToolStripMenuItem1.Click += new System.EventHandler(this.resetDataToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(397, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 359);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(336, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(488, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(331, 329);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mark";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Software Marked as \"Productive\"";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox1.Image = global::MonitorBrowserTime.Properties.Resources.Bokehlicia_Captiva_Browser_web;
            this.pictureBox1.Location = new System.Drawing.Point(121, 98);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Software Name?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 52);
            this.button2.TabIndex = 8;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(585, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 52);
            this.button3.TabIndex = 9;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(441, 48);
            this.label3.TabIndex = 10;
            this.label3.Text = "Monitor Browser Time";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 493);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor Browswer Time";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem updateDataFilrToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addProductiveTagsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem canBeProductiveOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeDataGraphsToolStripMenuItem;
    }
}

