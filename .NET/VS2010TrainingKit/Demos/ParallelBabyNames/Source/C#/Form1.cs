// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlinqMvpDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ProcessorsToUse.Minimum = 1;
            ProcessorsToUse.Maximum = Environment.ProcessorCount;
            ProcessorsToUse.Value = Environment.ProcessorCount; // Use all processors.

            LinqYearStartLabel.Text = yearStart.ToString();
            PlinqYearStartLabel.Text = yearStart.ToString();
            LinqYearEndLabel.Text = yearEnd.ToString();
            PlinqYearEndLabel.Text = yearEnd.ToString();
            LinqValueEndLabel.Text = yscaleMax.ToString();
            PlinqValueEndLabel.Text = yscaleMax.ToString();

            InitializeQueries();

            // Eliminate startup costs from the equation.
            System.Threading.ThreadPool.SetMinThreads(Environment.ProcessorCount, Environment.ProcessorCount);

            // Now load 250MB of data by default.
            LoadNames(250);
        }

        private List<PopName> names = new List<PopName>();
        private QueryInfo queryInfo = new QueryInfo();
        private static IEnumerable<PopName> seqQuery;
        private static ParallelQuery<PopName> parQuery;
        const int yearStart = 1960;
        const int yearEnd = 2000;
        const int yscaleMax = 1000;

        class QueryInfo
        {
            internal string Name;
            internal string State;
        }


        private void InitializeQueries()
        {
            seqQuery = from n in names
                       where n.Name.Equals(queryInfo.Name, StringComparison.InvariantCultureIgnoreCase) &&
                             n.State == queryInfo.State && 
                             n.Year >= yearStart && n.Year <= yearEnd
                       orderby n.Year ascending
                       select n;

            parQuery = from n in names.AsParallel().WithDegreeOfParallelism(ProcessorsToUse.Value)
                       where n.Name.Equals(queryInfo.Name, StringComparison.InvariantCultureIgnoreCase) &&
                             n.State == queryInfo.State && 
                             n.Year >= yearStart && n.Year <= yearEnd
                       orderby n.Year ascending
                       select n;
        }


        void LoadNames(float mbSize)
        {
            const int recordSize = 32; // approx. 32 bytes per record.
            int count = (int)((mbSize*1024*1024) / recordSize);

            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                LinqTimeLabel.Visible = false;
                PlinqTimeLabel.Visible = false;
                SpeedupLabel.Visible = false;
                LastSeqRun = 0;
                LastParRun = 0;
                // Clear the screen.
                LinqPicture.Image = null;
                PlinqPicture.Image = null;
                Refresh();

                names.Clear();
                
                Console.Write("Loading XML names...");
                XDocument doc = XDocument.Load("popnames.xml");
                XElement root = doc.Root;
                foreach (XElement child in root.Elements())
                {
                    PopName name = new PopName();
                    name.Name = child.Attribute("Name").Value;
                    name.Gender = (NameGender)Enum.Parse(typeof(NameGender), child.Attribute("Gender").Value);
                    name.State = child.Attribute("State").Value;
                    name.Year = int.Parse(child.Attribute("Year").Value);
                    name.Rank = int.Parse(child.Attribute("Rank").Value);
                    name.Count = int.Parse(child.Attribute("Count").Value);
                    names.Add(name);
                    if (names.Count == count) break;
                }

                while (count > names.Count)
                {
                    names.AddRange(names);
                }
                if (names.Count > count)
                {
                    int remCount = names.Count - count;
                    names.RemoveRange(names.Count - remCount - 1, remCount);
                }

                // "Prime" the queries.
                seqQuery.ToList();
                parQuery.ToList();

                //MessageBox.Show(names.Count.ToString());
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private const int RunMultiplier = 10;
        private long LastSeqRun = 0;
        private long LastParRun = 0;

        private void DrawResults(List<PopName> names, Graphics g, int width, int height)
        {
            // Clear background to be white.
            g.Clear(Color.Black);

            if (names.Count > 0)
            {
                int maxValue = names.Select((n)=>n.Count).Max();
                int minYear = names.Select((n)=>n.Year).Min();
                int maxYear = names.Select((n)=>n.Year).Max();

                LinqYearStartLabel.Text = minYear.ToString();
                PlinqYearStartLabel.Text = minYear.ToString();
                LinqYearEndLabel.Text = maxYear.ToString();
                PlinqYearEndLabel.Text = maxYear.ToString();
                LinqValueEndLabel.Text = maxValue.ToString();
                PlinqValueEndLabel.Text = maxValue.ToString();

                if (minYear != maxYear)
                {
                    // Note: X axis is years, Y axis is the counts per year.
                    // These are the dimensions everything will be scaled to.
                    float per_x = (float)width / (maxYear - minYear);
                    float per_y = (float)height / maxValue;

                    //MessageBox.Show(String.Format("count = {0}, xscale = {1}, per_x = {2}",
                    //    names.Count.ToString(), xscale_max, per_x));

                    // Draw axis lines:
                    Pen paxis = new Pen(Color.FromArgb(64, 64, 64), 1);
                    for (float i = (height / 10); i < height; i += (height / 10))
                    {
                        g.DrawLine(paxis, 0, i, width, i);
                    }
                    int xvalues = (maxYear - minYear);
                    float xincrement = (float)width / xvalues;
                    for (float i = xincrement; i < width; i += xincrement)
                    {
                        g.DrawLine(paxis, i, 0, i, height);
                    }

                    //g.DrawLine(paxis, 0, 0, width, height);

                    // Draw data:
                    Pen p = new Pen(Color.Chartreuse, 4);
                    float curr_x = 0.0f;
                    float curr_y = 0.0f;
                    float last_x = -1;
                    float last_y = -1;
                    int last_year = -1;

                    foreach (PopName n in names)
                    {
                        if (n.Year != last_year)
                        {
                            if (LineRadioButton.Checked)
                            {
                                curr_x = (maxYear - n.Year) * per_x;
                                curr_y = height - (n.Count * per_y);
                                if (last_x != -1 && last_y != -1)
                                {
                                    g.DrawLine(p, last_x, last_y, curr_x, curr_y);
                                }
                                last_x = curr_x;
                                last_y = curr_y;
                                last_year = n.Year;
                            }
                            else
                            {
                                curr_x = (maxYear - n.Year) * per_x;
                                curr_y = height - (n.Count * per_y);
                                if (last_x != -1 && last_y != -1)
                                {
                                    g.DrawLine(p, curr_x, height, curr_x, curr_y);
                                }
                                last_x = curr_x;
                                last_y = curr_y;
                                last_year = n.Year;
                            }
                        }
                    }
                }
            }
        }

        private void RunLinqButton_Click(object sender, EventArgs e)
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            // Set query info values based on text box.
            queryInfo.Name = NameTextBox.Text.Trim();
            queryInfo.State = StateTextBox.Text.Trim();

            try
            {
                // Clear the screen.
                LinqPicture.Image = null;
                Refresh();

                // Execute and time the query:
                List<PopName> names = null;
                Stopwatch sw = new Stopwatch();

                System.Threading.ManualResetEvent mre = new System.Threading.ManualResetEvent(false);
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    sw.Start();
                    for (int i = 0; i < RunMultiplier; i++)
                        names = seqQuery.ToList();
                    sw.Stop();
                    LastSeqRun = sw.ElapsedTicks;
                    mre.Set();
                });
                mre.WaitOne();

                // And draw:
                LinqPicture.Image = new Bitmap(LinqPicture.Width, LinqPicture.Height);
                Graphics g = Graphics.FromImage(LinqPicture.Image);
                DrawResults(names, g, LinqPicture.Image.Width, LinqPicture.Image.Height);

                // Note execution time:
                LinqTimeLabel.Text = string.Format("{0:F2} seconds", (sw.ElapsedMilliseconds / 1000.0));
                LinqTimeLabel.Visible = true;

                if (LastSeqRun != 0 && LastParRun != 0)
                {
                    SpeedupLabel.Text = string.Format("{0:F2}x speedup", ((float)LastSeqRun) / LastParRun);
                    SpeedupLabel.Visible = true;
                }
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private void RunPlinqButton_Click(object sender, EventArgs e)
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            // Set query info values based on text box.
            queryInfo.Name = NameTextBox.Text.Trim();
            queryInfo.State = StateTextBox.Text.Trim();

            try
            {
                // Clear the screen.
                PlinqPicture.Image = null;
                Refresh();

                // Execute and time the query:
                List<PopName> names = null;
                Stopwatch sw = new Stopwatch();

                System.Threading.ManualResetEvent mre = new System.Threading.ManualResetEvent(false);
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    sw.Start();
                    for (int i = 0; i < RunMultiplier; i++)
                        names = parQuery.ToList();
                    sw.Stop();
                    LastParRun = sw.ElapsedTicks;
                    mre.Set();
                });
                mre.WaitOne();

                // And draw:
                PlinqPicture.Image = new Bitmap(PlinqPicture.Width, PlinqPicture.Height);
                Graphics g = Graphics.FromImage(PlinqPicture.Image);
                DrawResults(names, g, PlinqPicture.Image.Width, PlinqPicture.Image.Height);

                // Note execution time:
                PlinqTimeLabel.Text = string.Format("{0:F2} seconds", (sw.ElapsedMilliseconds / 1000.0));
                PlinqTimeLabel.Visible = true;

                if (LastSeqRun != 0 && LastParRun != 0)
                {
                    SpeedupLabel.Text = string.Format("{0:F2}x speedup", ((float)LastSeqRun) / LastParRun);
                    SpeedupLabel.Visible = true;
                }
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private void InputSize1MB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                LoadNames(1);
        }

        private void InputSize5MB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                LoadNames(5);
        }

        private void InputSize10MB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                LoadNames(10);
        }

        private void InputSize50MB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                LoadNames(50);
        }

        private void InputSize100MB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                LoadNames(100);
        }

        private void InputSize250MB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                LoadNames(250);
        }

        private void InputSize500MB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                LoadNames(500);
        }

        private void InputSize1GB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                LoadNames(1000);
        }

        private void ProcessorsToUse_Scroll(object sender, EventArgs e)
        {
            InitializeQueries();
        }
    }

    enum NameGender { Male, Female }

    class PopName
    {
        // Fields:
        private string m_name;
        private NameGender m_gender;
        private string m_state;
        private int m_year;
        private int m_rank;
        private int m_count;

        // Properties:
        internal string Name { get { return m_name; } set { m_name = value; } }
        internal NameGender Gender { get { return m_gender; } set { m_gender = value; } }
        internal string State { get { return m_state; } set { m_state = value; } }
        internal int Year { get { return m_year; } set { m_year = value; } }
        internal int Rank { get { return m_rank; } set { m_rank = value; } }
        internal int Count { get { return m_count; } set { m_count = value; } }

        public override string ToString()
        {
            return string.Format("{{ Name={0}, Gender={1}, State={2}, Year={3}, Rank={4}, Count={5} }}",
                Name, Gender, State, Year, Rank, Count);
        }
    }
}