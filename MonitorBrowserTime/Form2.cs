using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MonitorBrowserTime
{

    public partial class Form2 : Form
    {
    string[][] allDays = new string[2][];
        float[][] dayData;

        string cat1 = "Browser Time";
        string cat2 = "Productive Time";
        float[] time = new float[24];
        float[] time2 = new float[24];

        int viewMode;
        SeriesChartType type = SeriesChartType.Column;
        int[] dayCheck = new int[2];
        bool after;

        Color[] colorSet = new Color[]
        {
            Color.FromArgb(255,255,128,128),
            Color.FromArgb(255,77,121,255),
            Color.FromArgb(255,128,255,128),
        };

        Random rnd = new Random();
        Form1 form1;

        public Form2(Form1 parent)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedToolWindow;

            form1 = parent;

            listBox1.Visible = false;
            label1.Text = "Days Selected: " + ((dayCheck[1]+1) - dayCheck[0]);

            toolStripMenuItem2.Text = "Compare Time";

            //
            dayCheck[0] = form1.days[0][0].Split('\r').Length-1;
            dayCheck[1] = dayCheck[0];

            // 
            GraphSetup(type);

        }

        void GraphSetup(SeriesChartType t)
        {
            int totalDays = (dayCheck[1] - dayCheck[0]) + 1;

            time = new float[24];
            time2 = new float[24];

            // 
            for (int i = 0; i < time.Length; i++)
            {
                // 
                for (int j = dayCheck[0]; j < dayCheck[0] + totalDays; j++)
                {
                    time[i] += GrabData(0, j, i);
                    time2[i] += GrabData(1, j, i);
                }

                time[i] /= totalDays;
                time2[i] /= totalDays;
            }

            // 
            for (int i = 0; i < allDays.Length; i++)
            {
                allDays[i] = form1.loadedData[i].Split('\r');
            }

            // 
            string[] dataDay = new string[2];

            dataDay[0] = allDays[0][dayCheck[0]].Split(',')[0];
            dataDay[1] = allDays[1][dayCheck[1]].Split(',')[0];

            // 
            if (t == SeriesChartType.Column)
            {
                lineGraphToolStripMenuItem.PerformClick();
            }
            else
            {
                toolStripMenuItem1.PerformClick();
            }

            float[] yo = new float[3];

            // 
            for (int i = 0; i < time.Length; i++)
            {
                yo[0] += time[i];
                yo[1] += time2[i];
            }

            // 
            toolStripMenuItem3.Text = dataDay[0].Trim();
            toolStripMenuItem4.Text = dataDay[1].Trim();

            // 
            yo[0] /= 60;
            yo[1] /= 60;
            yo[2] = 24 - (yo[0] + yo[1]);

            // 
            AddToPieGraph(colorSet, chart2, new string[] { "Online", "Prod", "Undefined" }, yo, SeriesChartType.Pie);
        }

        // 
        private void GenerateGraph(SeriesChartType chartType)
        {
            // 
            chart1.Series.Clear();
            
            // 
            chart1.ChartAreas[0].AxisX.Minimum = -1;
            chart1.ChartAreas[0].AxisX.Maximum = 24;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;

            // 
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 60;
            chart1.ChartAreas[0].AxisY.Interval = 6;

            // 
            if (viewMode == 0 || viewMode == 1)
            {
                AddToGraph(colorSet[0], chart1, cat1, time, chartType);
            }
            if (viewMode == 0 || viewMode == 2)
            {
                AddToGraph(colorSet[1], chart1, cat2, time2, chartType);
            }
        }

        private void AddToGraph(Color col, Chart chart, string cat, float[] hourData, SeriesChartType type)
        {
            chart.Series.Add(cat);
            chart.Series[cat].Color = col;

            for (int i = 0; i < hourData.Length; i++)
            {
                chart.Series[cat].Points.AddXY(i, hourData[i]);
                chart.Series[cat].Points[i].Color = col;
                chart.Series[cat].ChartType = type;
                chart1.Series[cat].BorderWidth = 4;
            }
        }

        private void AddToPieGraph(Color[] col, Chart chart, string[] cat, float[] hourData, SeriesChartType type)
        {
            chart.Series.Clear();
            chart.Series.Add("pie");
            chart.Series["pie"].IsValueShownAsLabel = true;

            for (int i = 0; i < hourData.Length; i++)
            {
                chart.Series["pie"].Points.AddXY(i, Math.Round(hourData[i],2));
                chart.Series["pie"].Points[i].AxisLabel = cat[i] + " (" + Math.Round(hourData[i]/24*100) + "%)";
                chart.Series["pie"].Points[i].Color = col[i];
                chart.Series["pie"].ChartType = type;
            }
        }

        float GrabData(int file, int day, int data)
        {
            // 
            allDays[file] = form1.loadedData[file].Split('\r');

            // 
            dayData = new float[allDays.Length][];

            // 
            for (int i = 0; i < dayData.Length; i++)
            {
                dayData[i] = new float[time.Length];
            }

            // 
            string[] temp = allDays[file][day].Split(',');

            // 
            for (int i = 0; i < 24; i++)
            {
                dayData[file][i] = float.Parse(temp[i+1]);
            }

            return dayData[file][data];
        }

        private void lineGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            barGraphToolStripMenuItem.Text = "Bar Graph";
            type = SeriesChartType.Column;
            GenerateGraph(type);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            barGraphToolStripMenuItem.Text = "Line Graph";
            type = SeriesChartType.Line;
            GenerateGraph(type);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
        }

        private void browserTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Text = "Browser Time";
            viewMode = 1;
            GenerateGraph(type);
        }

        private void productiveTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Text = "Productive Time";
            viewMode = 2;
            GenerateGraph(type);
        }

        private void compareTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Text = "Compare Time";
            viewMode = 0;
            GenerateGraph(type);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GenerateAllDaysList(false);
        }

        void GenerateAllDaysList(bool a)
        {
            listBox1.Visible = true;
                    listBox1.Items.Clear();
            int start = (a) ? dayCheck[0] : 0;

            // 
            for (int i = start; i < allDays[0].Length; i++)
            {
                listBox1.Items.Add(allDays[0][i].Split(',')[0]);
            }

            after = a;
        }

        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                if (after)
                {
                    dayCheck[1] = listBox1.SelectedIndex;
                    dayCheck[1] = (dayCheck[0] > dayCheck[1]) ? dayCheck[0] : dayCheck[1];
                    listBox1.Items.Clear();
                    GraphSetup(type);
                }
                else
                {
                    dayCheck[0] = listBox1.SelectedIndex;
                    dayCheck[1] = (dayCheck[0] > dayCheck[1]) ? dayCheck[0] : dayCheck[1];
                    listBox1.Items.Clear();
                    GraphSetup(type);
                }

                label1.Text = "Days Selected: " + ((dayCheck[1]+1) - dayCheck[0]);
            listBox1.Visible = false;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GenerateAllDaysList(true);
        }

        // 
        void print(object test)
        {
            Console.WriteLine(test);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            dayCheck[1] = dayCheck[0];
                    GraphSetup(type);
            label1.Text = "Days Selected: " + ((dayCheck[1] + 1) - dayCheck[0]);
            listBox1.Visible = false;
        }
    }


    internal class RoutedEventArgs
    {
    }
}
