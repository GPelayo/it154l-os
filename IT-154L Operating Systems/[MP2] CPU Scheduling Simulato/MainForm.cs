using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPU_Scheduling_Simulator
{
    public partial class MainForm : Form
    {
        private List<Process> jobs;
        private List<Panel> timelinePanels;
        private CPU currentCPU;
        private int lastJobNumber = -1;
        private int timelineXPos = 0;
        private int timelineYPos = 0;

        public MainForm()
        {
            InitializeComponent();
            InitializeCPU(4);
            InitializeTable();
        }

        private void InitializeCPU(int timeQuantum)
        {
            jobs = new List<Process>();
            timelinePanels = new List<Panel>();
            jobs.Add(new Process(1, 0, 6, ProcessType.N));
            jobs.Add(new Process(2, 3, 2, ProcessType.NPR));
            jobs.Add(new Process(3, 5, 1, ProcessType.PR));
            jobs.Add(new Process(4, 9, 7, ProcessType.PR));
            jobs.Add(new Process(5, 10, 5, ProcessType.N));
            jobs.Add(new Process(6, 12, 3, ProcessType.N));
            jobs.Add(new Process(7, 14, 4, ProcessType.NPR));
            jobs.Add(new Process(8, 16, 5, ProcessType.PR));
            jobs.Add(new Process(9, 17, 7, ProcessType.PR));
            jobs.Add(new Process(10, 19, 2, ProcessType.N));
            currentCPU = new CPU(jobs, timeQuantum);
            currentCPU.RunNextCycle();
            lbCurrentTime.Text = "Current Time: " + currentCPU.CurrentCycle.ToString();
        }

        private void InitializeTable()
        {          

            lvData.Items.Clear();
            lvTimes.Items.Clear();

            foreach (Process iProcess in jobs)
            {
                String[] itemString = {iProcess.JobNumber.ToString(), iProcess.ArrivalTime.ToString()
                                        , iProcess.CurrentCPUCycle.ToString(), iProcess.Type.ToString()};

                lvData.Items.Add(new ListViewItem(itemString));

                switch (iProcess.Status)
                {
                    case ProcessStatus.Hold:
                        lvData.Items[lvData.Items.Count - 1].ForeColor = Color.Red;
                        break;
                    case ProcessStatus.Ready:
                        lvData.Items[lvData.Items.Count - 1].ForeColor = Color.Orange;
                        break;
                    case ProcessStatus.Running:
                        lvData.Items[lvData.Items.Count - 1].ForeColor = Color.Green;
                        break;
                    case ProcessStatus.Waiting:
                        lvData.Items[lvData.Items.Count - 1].ForeColor = Color.Blue;
                        break;
                    case ProcessStatus.Finished:
                        lvData.Items[lvData.Items.Count - 1].ForeColor = Color.Indigo;
                        break;
                }
            }

            foreach (Process iProcess in jobs)
            {
                String[] itemString;
                
                if(iProcess.Status.Equals(ProcessStatus.Finished))
                {
                    itemString = new String[]{iProcess.TurnaroundTime.ToString(), iProcess.WaitingTime.ToString()
                                            , iProcess.ResponseTime.ToString()};
                }
                else
                {
                    itemString = new String[]{"0", "0", "0"};
                }

                lvTimes.Items.Add(new ListViewItem(itemString));

                switch (iProcess.Status)
                {
                    case ProcessStatus.Hold:
                        lvTimes.Items[lvTimes.Items.Count - 1].ForeColor = Color.Red;
                        break;
                    case ProcessStatus.Ready:
                        lvTimes.Items[lvTimes.Items.Count - 1].ForeColor = Color.Orange;
                        break;
                    case ProcessStatus.Running:
                        lvTimes.Items[lvTimes.Items.Count - 1].ForeColor = Color.Green;
                        break;
                    case ProcessStatus.Waiting:
                        lvTimes.Items[lvTimes.Items.Count - 1].ForeColor = Color.Blue;
                        break;
                    case ProcessStatus.Finished:
                        lvTimes.Items[lvTimes.Items.Count - 1].ForeColor = Color.Indigo;
                        break;
                }

            }
        }

        private void Reset()
        {
            currentCPU.Reset();
            timelinePanels.Clear();

            InitializeTable();
        }

        private void btCustomData_Click(object sender, EventArgs e)
        {
            CustomDataEntryForm customData = new CustomDataEntryForm(jobs);
            customData.ShowDialog();
            this.Reset();            
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            lbCurrentTime.Text = "Current Time: " + (currentCPU.CurrentCycle + 1).ToString();
            currentCPU.RunNextCycle();

            Panel iPanel = new Panel();
            Label iLabel = new Label();

            iLabel.Text = currentCPU.RunningProcess.JobNumber.ToString();
            iLabel.Location = new Point(0, 0);
            iPanel.Size = new Size(19, 15);
            iPanel.Location = new Point(20 * timelineXPos, 25*timelineYPos);
            iPanel.Controls.Add(iLabel);
            iPanel.BackColor = Color.White;

            this.pnTimeline.Controls.Add(iPanel);
            this.timelineXPos++;

            if (timelineXPos * 24 > this.pnTimeline.Size.Width)
            {
                this.timelineXPos = 0;
                this.timelineYPos++;
            }

            this.InitializeTable();
            this.lastJobNumber = currentCPU.RunningProcess.JobNumber;

            if (currentCPU.IsFinished)
            {
                this.btNext.Enabled = false;
                MessageBox.Show("Avg. Response Time:\t" + currentCPU.AvgRT + "\nAvg. TA Time:\t" 
                            + currentCPU.AvgTA + "\nAvg. Waiting Time:\t" + currentCPU.AvgWT
                            , "Simulation Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information  );
            }
        }

        private void tBoxTimeQuantum_TextChanged(object sender, EventArgs e)
        {
            InitializeCPU(Convert.ToInt32(tBoxTimeQuantum.Text));

            this.Reset();
        }
    }
}
