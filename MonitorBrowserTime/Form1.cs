using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MonitorBrowserTime
{
    public partial class Form1 : Form
    {
        bool run = true, debuggin = false, canGraph = true, canBeBrowserProductive;
        float[] seconds;
        int thePrevHour = -1;
        int theHour;
        int oneSec = 1000;
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string[] dataFileName;
        string[] dataFile;
        string pyFile = "Time Visualized.py";
        string docFolder = "Monitor Browser Time";
        string sysPath = "";
        string lastWindow;
        string settingData;
        public string[][] days, todayData;
        public string[] loadedData;

        List<string> allProductive;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        // 
        public Form1()
        {
            docFolder = (debuggin) ? "Monitor Browser Time 2" : "Monitor Browser Time";
            sysPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), docFolder);
            settingData = Path.Combine(sysPath, "settings.cfg");
            MakeDirectoryIfNone();
            seconds = new float[2];

            todayData = new string[2][]
                {
            new string[24],
            new string[24],
                };

            days = new string[2][]
            {
                new string[24],
            new string[24],
            };

            allProductive = new List<string>();

            // 
            dataFileName = new string[]
            {
                "Browser Data.csv",
                "Productivity Data.csv",
            };

            // 
            dataFile = new string[]
            {
            Path.Combine(sysPath, dataFileName[0]),
            Path.Combine(sysPath, dataFileName[1]),
            };

            // Default stuff
            InitializeComponent();

            // Initialize the app, hide it & what not
            IniApp();

            // Check to see if we have a CSV Data file that already exists or not
            CSVDataExists();

            // Get how ever many seconds are accumulated for this hour & start there
            UpdateSeconds();

            // Update whatever hour we're at
            UpdateTheHour();

            // Loop our Time Log
            Thread Th1 = new Thread(new ThreadStart(TimeLog));
            Th1.Start();

            // Loop our Time Log
            Thread Th2 = new Thread(new ThreadStart(UpdateDataFile));
            Th2.Start();

            // for debugging
            //Form2 f = new Form2(this);
            //f.Show();

        }

        void UpdateSeconds()
        {
            seconds[0] = GetSecondsForHour(0);
            seconds[1] = GetSecondsForHour(1);
        }

        private void MakeDirectoryIfNone()
        {
            // If there is no folder in documents to store this data, then make that folder
            if (!Directory.Exists(sysPath))
            {
                try
                {
                    Directory.CreateDirectory(sysPath);
                }
                catch(IOException ex)
                {
                    CouldntData(debuggin, true, ex);
                }
            }
        }

        // 
        void TimeLog()
        {
            while (run)
            {
                canBeBrowserProductive = canBeProductiveOnlineToolStripMenuItem.Checked;
                if (canBeBrowserProductive)
                {
                    if (IsProductiveFocused())
                    {
                        seconds[1]++;
                        todayData[1][theHour + 1] = ((Math.Round((seconds[1] / 60) * 100)) / 100).ToString();
                    }
                    if (IsBrowsersFocused())
                    {
                        seconds[0]++;
                        todayData[0][theHour + 1] = ((Math.Round((seconds[0] / 60) * 100)) / 100).ToString();
                    }
                }
                else
                {
                    if (IsBrowsersFocused())
                    {
                        seconds[0]++;
                        todayData[0][theHour + 1] = ((Math.Round((seconds[0] / 60) * 100)) / 100).ToString();
                    }
                    else if (IsProductiveFocused())
                    {
                        seconds[1]++;
                        todayData[1][theHour + 1] = ((Math.Round((seconds[1] / 60) * 100)) / 100).ToString();
                    }
                }

                string bMins = ((Math.Round((seconds[0] / 60) * 100)) / 100).ToString() + "m";
                string pMins = ((Math.Round((seconds[1] / 60) * 100)) / 100).ToString() + "m";
                string bAv = (Math.Round(((seconds[0]/60) / DateTime.Now.Minute) * 100)).ToString() + "%";
                string pAv = (Math.Round(((seconds[1]/60) / DateTime.Now.Minute) * 100)).ToString() + "%";

                notifyIcon1.Text = "Monitor Browser Time"
                    + "\nH: " + theHour
                    + "\nB: " + bMins + " - " + bAv
                    + "\nP: " + pMins + " - " + pAv
                    ;

                lastWindow = (GetActiveWindowTitle() == "") ? lastWindow : GetActiveWindowTitle();
                Thread.Sleep(oneSec);
            }
        }

        // 
        void UpdateDataFile()
        {
            while (run)
            {
                CSVDataExists();
                SaveDataToFile();
                UpdateTheHour();
                Thread.Sleep(oneSec * 10);
            }
        }

        // 
        private void IniApp()
        {
            Opacity = 0;
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            notifyIcon1.Text = "Monitor Browser Time";
            LoadSettings();
        }

        // 
        float GetSecondsForHour(int what)
        {
            LoadDataFile();
            float secs = 0;
            try
            {
                secs = (float.Parse(todayData[what][theHour + 1])) * 60;
            }
            catch(IOException ex)
            {
                if (debuggin)
                {
                    MessageBox.Show(ex.ToString(), "Time Not Set");
                }
            }
            return secs;
        }

        // 
        void UpdateTheHour()
        {

            // If the min = 59, then take some action: Save the data, graph the data, update the time in software, then update the previous hour
            if (DateTime.Now.Minute == 59 && canGraph)
            {
                SaveDataToFile();
            }

            theHour = DateTime.Now.Hour;

            // 
            if (thePrevHour != theHour)
            {
                UpdateSeconds();
                UpdateLocalData();
                canGraph = true;
                thePrevHour = theHour;
            }
        }

        // 
        void CSVDataExists()
        {
            MakeDirectoryIfNone();
            for (int i = 0; i < dataFile.Length; i++)
            {
                if (!File.Exists(dataFile[i]))
                {
                    MakeCSVDataFile(dataFile[i]);
                    seconds[i] = GetSecondsForHour(i);
                    SaveSettings();
                }
            }
        }

        // 
        void MakeCSVDataFile(string theDataFile)
        {
            try
            {
                StreamWriter data = new StreamWriter(theDataFile);
                data.Write(IniNewCVS());
                data.Close();

                File.SetAttributes(theDataFile, FileAttributes.Hidden);
            }
            catch (IOException ex)
            {
                CouldntData(true, true, ex);
            }
        }

        // 
        void CheckForSettingFile()
        {
            if (!File.Exists(settingData))
            {
                try
                {
                    StreamWriter data = new StreamWriter(settingData);
                    data.Write(SettingFirstLine());
                    data.Close();
                }
                catch (IOException ex)
                {
                    CouldntData(debuggin, true, ex);
                }
            }
        }

        // 
        void SaveSettings()
        {
            CheckForSettingFile();

            string toWrite = "";
            toWrite += SettingFirstLine();

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                toWrite += "\r\n";
                toWrite += listBox1.Items[i];
            }

            try
            {
                File.SetAttributes(settingData, FileAttributes.Normal);

                StreamWriter data = new StreamWriter(settingData);
                data.Write(toWrite);
                data.Close();

                File.SetAttributes(settingData, FileAttributes.Hidden);
            }
            catch (IOException ex)
            {
                CouldntData(debuggin, true, ex);
            }
        }

        // 
        string SettingFirstLine()
        {
            return ""+canBeProductiveOnlineToolStripMenuItem.Checked;
        }

        // 
        void CouldntData(bool showUser, bool Writing, IOException ex)
        {
            string theCase = "";

            if (Writing)
            {
                theCase = "Could Not Save!";
            }
            else if (!Writing)
            {
                theCase = "Could Not Read!";
            }
            else
            {
                theCase = "Monitor Browser Time";
            }

            if (showUser)
            {
                MessageBox.Show(theCase + "\r\n\r\n" + ex.Message, theCase, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                print(theCase+"\r\n\r\n" + ex.Message);
            }
        }

        // 
        void LoadSettings()
        {
            CheckForSettingFile();

            try
            {
                File.SetAttributes(settingData, FileAttributes.Normal);

                StreamReader data = new StreamReader(settingData);
                string temp1 = data.ReadToEnd();
                data.Close();

                string[] temp2 = temp1.Split('\r');

                for (int i = 1; i < temp2.Length; i++)
                {
                    listBox1.Items.Add(temp2[i]);
                }

                string[] temp3 = temp2[0].Split(',');

                canBeProductiveOnlineToolStripMenuItem.Checked = (temp3[0] == "True") ? true : false;

                File.SetAttributes(settingData, FileAttributes.Hidden);
            }
            catch(IOException ex)
            {
                CouldntData(true, false, ex);
            }
        }

        // 
        string IniNewCVS()
        {
            int hours = 24;
            string output = GetTodaysDate() + ",";

            for (int i = 0; i < hours; i++)
            {
                output += (i < hours - 1) ? "0," : "0";
            }
            return output;
        }

        // 
        string GetTodaysDate()
        {
            return DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString();
        }

        // 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDataToFile();

            run = false;
            Application.Exit();
        }

        // 
        void SaveDataToFile()
        {
            for (int j = 0; j < dataFile.Length; j++)
            {
                string saveableData = "";
                string theSave = "";

                // Generate new savable data by concatenating today's data into on string, including all new data
                for (int i = 0; i < todayData[j].Length; i++)
                {
                    string comma = ",";
                    if (i == todayData[j].Length - 1)
                    {
                        comma = "";
                    }
                    saveableData += todayData[j][i] + comma;
                }

                try
                {
                    // 
                    File.SetAttributes(dataFile[j], FileAttributes.Normal);

                    // 
                    StreamWriter save = new StreamWriter(dataFile[j]);

                    // Make a string comprised of all previous days to prepare it to be added to savable data
                    for (int i = 0; i < days[j].Length - 1; i++)
                    {
                        theSave += days[j][i];
                    }

                    // If the loaded data is blank, then don't line break, else line break
                    string breakOrNot = (theSave == "") ? "" : "\n";
                    theSave += breakOrNot + saveableData;
                    save.Write(theSave);
                    save.Close();

                    // 
                    File.SetAttributes(dataFile[j], FileAttributes.Hidden);
                }
                catch (IOException ex)
                {
                    CouldntData(debuggin, true, ex);
                }
            }
        }

        // 
        void UpdateLocalData()
        {
            try
            {
                string tPath = sysPath + "/Your Browser Data.csv";
                File.Delete(tPath);
                File.Copy(dataFile[0], tPath);
                File.SetAttributes(tPath, FileAttributes.Normal);

                string tPath2 = sysPath + "/Your Productivity Data.csv";
                File.Delete(tPath2);
                File.Copy(dataFile[1], tPath2);
                File.SetAttributes(tPath2, FileAttributes.Normal);
            }
            catch(IOException ex)
            {
                if (debuggin)
                {
                    MessageBox.Show(ex.ToString(), "UPDATE LOCAL DATA Method");
                }
            }
        }

        // 
        void LoadDataFile()
        {
            loadedData = new string[2];

            for (int i = 0; i < dataFile.Length; i++)
            {
                if (File.Exists(dataFile[i]))
                {
                    try
                    {
                        File.SetAttributes(dataFile[i], FileAttributes.Normal);
                        StreamReader load = new StreamReader(dataFile[i]);
                        loadedData[i] = load.ReadToEnd();
                        load.Close();

                        // Days is an array of data from each day
                        days[i] = loadedData[i].Split('\n');

                        // Today Data is the data from today only, thats the day, & the 24 hours
                        todayData[i] = days[i][days[i].Length - 1].Split(',');

                        // 
                        string newDate = loadedData[i] + "\r\n" + IniNewCVS();

                        // If today's date doesnt match with the latest entry, then make a fresh entry with today's date
                        if (todayData[i][0] != GetTodaysDate())
                        {
                            StreamWriter save = new StreamWriter(dataFile[i]);
                            save.Write(newDate);
                            save.Close();
                            LoadDataFile();
                        }

                        // 
                        File.SetAttributes(dataFile[i], FileAttributes.Hidden);
                    }
                    catch(IOException ex)
                    {
                        CouldntData(true, false, ex);
                    }
                }
            }
        }

        // 
        void print(object test)
        {
            Debug.WriteLine(test);
        }

        // 
        string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString().ToLower
                    ();
            }
            return "";
        }

        // 
        private void updateDataFilrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateLocalData();
        }

        // 
        private void autoDataImagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 
        private void makeGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDataToFile();
        }

        private void addProductiveTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowMode(true);
        }

        void WindowMode(bool which)
        {
            if (which)
            {
                Opacity = 100;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                Text = "Monitor Browswer Time - Mark Productive Software";
            }
            else



            {
                Opacity = 0;
                WindowState = FormWindowState.Minimized;
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
                Text = "Monitor Browswer Time";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This is the string well be adding to our productive list
            string adding = "";

            // First we take the textbox input & split it for every space
            string[] add = textBox1.Text.Split(' ');

            // Then we take all of the words from the split, remove all of the spaces, then lowercase the entire thing
            for (int i = 0; i < add.Length; i++)
            {
                add[i] = add[i].Replace(" ", String.Empty);
                add[i] = add[i].ToLower();
            }

            // Then we re-create the word by stitching it back together using the adding string
            for (int i = 0; i < add.Length; i++)
            {
                // We are using this variable to not add an extra space to the end of full sofware names, its not needed
                string end = "";

                // if not at the end of the word, then we can add a space
                if (i != add.Length-1)
                {
                    end = " ";
                }

                // 
                adding += UppercaseFirst(add[i]) + end;
            }

            // 
            if (!listBox1.Items.Contains(adding) && adding != "")
            {
                listBox1.Items.Add(adding);
            }
            textBox1.Text = "";
            SaveSettings();
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        string[] SplitCaseSens(string source)
        {
            return Regex.Split(source, @"(?=[A-Z])");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowMode(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            object selI = listBox1.SelectedItem;
            if (selI != null)
            {
                listBox1.Items.Remove(selI);
                SaveSettings();
            }
        }

        private void canBeProductiveOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.Show();
        }

        private void seeDataGraphsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.Show();
        }

        private void documentationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Process.Start("http://sefdstuff.com/monitorbrowsertime");
        }

        private void resetDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Are you sure you want to delete all your data?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (delete == DialogResult.Yes)
            {
                for (int i = 0; i < dataFile.Length; i++)
                {
                    try
                    {
                        File.Delete(dataFile[i]);
                        CSVDataExists();
                    }
                    catch(IOException ex)
                    {
                        CouldntData(true, false, ex);
                    }
                }
            }
        }

        // 
        bool IsBrowsersFocused()
        {
            string[] allBrowsers = new string[]
            {
                "google chrome",
                "firefox",
                "safari",
                "opera",
                "microsoft edge",
                "internet explorer",
            };


            for (int i = 0; i < allBrowsers.Length; i++)
            {
                {
                    if (GetActiveWindowTitle().Contains(allBrowsers[i]))
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        // 
        bool IsProductiveFocused()
        {
            allProductive.Clear();
            for (int j = 0; j < listBox1.Items.Count; j++)
            {
                allProductive.Add(listBox1.GetItemText(listBox1.Items[j]));
            }

            for (int i = 0; i < allProductive.Count; i++)
            {
                {
                    //print("''" + allProductive[i].ToLower().Trim()+ "''");
                    if (GetActiveWindowTitle().Contains(allProductive[i].ToLower().Trim()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
