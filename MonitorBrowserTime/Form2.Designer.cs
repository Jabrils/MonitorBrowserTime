using System;
using System.Windows.Forms;

namespace MonitorBrowserTime
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.barGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.browserTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productiveTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 527);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1594, 562);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barGraphToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.menuStrip1.Location = new System.Drawing.Point(12, 482);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // barGraphToolStripMenuItem
            // 
            this.barGraphToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.barGraphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineGraphToolStripMenuItem,
            this.toolStripMenuItem1});
            this.barGraphToolStripMenuItem.Name = "barGraphToolStripMenuItem";
            this.barGraphToolStripMenuItem.Size = new System.Drawing.Size(162, 38);
            this.barGraphToolStripMenuItem.Text = "Select Graph";
            // 
            // lineGraphToolStripMenuItem
            // 
            this.lineGraphToolStripMenuItem.Name = "lineGraphToolStripMenuItem";
            this.lineGraphToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.lineGraphToolStripMenuItem.Text = "Bar Graph";
            this.lineGraphToolStripMenuItem.Click += new System.EventHandler(this.lineGraphToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(268, 38);
            this.toolStripMenuItem1.Text = "Line Graph";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browserTimeToolStripMenuItem,
            this.productiveTimeToolStripMenuItem,
            this.compareTimeToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(132, 38);
            this.toolStripMenuItem2.Text = "Start Date";
            // 
            // browserTimeToolStripMenuItem
            // 
            this.browserTimeToolStripMenuItem.Name = "browserTimeToolStripMenuItem";
            this.browserTimeToolStripMenuItem.Size = new System.Drawing.Size(287, 38);
            this.browserTimeToolStripMenuItem.Text = "Browser Time";
            this.browserTimeToolStripMenuItem.Click += new System.EventHandler(this.browserTimeToolStripMenuItem_Click);
            // 
            // productiveTimeToolStripMenuItem
            // 
            this.productiveTimeToolStripMenuItem.Name = "productiveTimeToolStripMenuItem";
            this.productiveTimeToolStripMenuItem.Size = new System.Drawing.Size(287, 38);
            this.productiveTimeToolStripMenuItem.Text = "Productive Time";
            this.productiveTimeToolStripMenuItem.Click += new System.EventHandler(this.productiveTimeToolStripMenuItem_Click);
            // 
            // compareTimeToolStripMenuItem
            // 
            this.compareTimeToolStripMenuItem.Name = "compareTimeToolStripMenuItem";
            this.compareTimeToolStripMenuItem.Size = new System.Drawing.Size(287, 38);
            this.compareTimeToolStripMenuItem.Text = "Compare Time";
            this.compareTimeToolStripMenuItem.Click += new System.EventHandler(this.compareTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(132, 38);
            this.toolStripMenuItem3.Text = "Start Date";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(124, 38);
            this.toolStripMenuItem4.Text = "End Date";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(134, 38);
            this.toolStripMenuItem5.Text = "Same Day";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            this.chart2.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(657, 40);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(949, 449);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "chart2";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(33, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(675, 429);
            this.listBox1.TabIndex = 3;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1260, 482);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1619, 1096);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Monitor Browser Time: Data Visualization";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem barGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem browserTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productiveTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareTimeToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private ToolStripMenuItem toolStripMenuItem4;
        private Label label1;
        private ToolStripMenuItem toolStripMenuItem5;
    }

    internal class RoutedEventHandler
    {
        private Action<object, MouseEventArgs> listBox1_MouseDoubleClick;

        public RoutedEventHandler(Action<object, MouseEventArgs> listBox1_MouseDoubleClick)
        {
            this.listBox1_MouseDoubleClick = listBox1_MouseDoubleClick;
        }
    }
}