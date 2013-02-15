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
        private List<Panel> timelinePanels;
        private List<Process> jobs;
        private CPU currentCPU;

        private int lastJobNumber;
        private int timelineXPos;
        private int timelineYPos;

        private double avgTurnaroundTime = 0;
        private double avgWaitingTime = 0;
        private double avgResponseTime = 0;

        public MainForm()
        {            
            jobs = new List<Process>();
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

            InitializeComponent();
            InitializeCPU(jobs, 4);
            InitializeTableData();
        }

        private void InitializeCPU(List<Process> jobsQueue, int timeQuantum)
        {
            timelinePanels = new List<Panel>();
            currentCPU = new CPU(jobsQueue, timeQuantum);
            lblCurrentTime.Text = "Current Time: " + currentCPU.CurrentCycle.ToString();
        }

        private void InitializeTableData()
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
                    itemString = new string[]{iProcess.TurnaroundTime.ToString(), iProcess.WaitingTime.ToString()
                                            , iProcess.ResponseTime.ToString()};
                }
                else
                {
                    itemString = new string[]{"0", "0", "0"};
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
            InitializeTableData();
        }

        private void btnCustomData_Click(object sender, EventArgs e)
        {
            CustomDataEntryForm customData = new CustomDataEntryForm(jobs);
            customData.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentCPU.RunNextCycle();
            lblCurrentTime.Text = "Current Time: " + currentCPU.CurrentCycle.ToString();

            Panel iPanel = new Panel();
            Label iLabel = new Label();

            iLabel.Text = currentCPU.RunningProcess.JobNumber.ToString();
            iLabel.Location = new Point(0, 0);
            iPanel.Size = new Size(19, 15);
            iPanel.Location = new Point(20 * timelineXPos, 16*timelineYPos);
            iPanel.Controls.Add(iLabel);
            iPanel.BackColor = Color.White;

            this.pnlTimeline.Controls.Add(iPanel);
            this.timelineXPos++;

            if (timelineXPos * 21 > this.pnlTimeline.Size.Width)
            {
                this.timelineXPos = 0;
                this.timelineYPos++;
            }

            this.InitializeTableData();
            this.lastJobNumber = currentCPU.RunningProcess.JobNumber;

            if (currentCPU.IsFinished)
            {
                this.avgResponseTime = currentCPU.AvgRT;
                this.avgTurnaroundTime = currentCPU.AvgTA;
                this.avgWaitingTime = currentCPU.AvgWT;

                this.btnNext.Enabled = false;
                MessageBox.Show("Avg. Response Time:\t" + this.avgResponseTime + "\nAvg. TA Time:\t"
                            + this.avgTurnaroundTime + "\nAvg. Waiting Time:\t" + this.avgWaitingTime
                            , "Simulation Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnNext.Text = "Start";
                btnStop_Click(null, null);
            }
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Avg. Response Time:\t" + this.avgResponseTime + "\nAvg. TA Time:\t"
                            + this.avgTurnaroundTime + "\nAvg. Waiting Time:\t" + this.avgWaitingTime
                            , "Last Simulation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bool hasValidTimeQuantum = true;
            int newTimeQuantum = 4;
            try
            {
                newTimeQuantum = Convert.ToInt32(tbxTimeQuantum.Text);
              
                if (newTimeQuantum <= 0)
                {
                    MessageBox.Show("Time Quantum needs to be an integer greater than 0.", "Invalid Input", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                    hasValidTimeQuantum = false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Time Quantum needs to be an integer greater than 0.", "Invalid Input", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                hasValidTimeQuantum = false;
            }

            if (hasValidTimeQuantum)
            {
                this.InitializeTableData();
                this.btnNext.Enabled = true;
                
                this.InitializeCPU(jobs, newTimeQuantum);
                this.Reset();

                this.lastJobNumber = -1;
                this.timelineXPos = 0;
                this.timelineYPos = 0;
                this.pnlTimeline.Controls.Clear();

                this.pnlData.Enabled = true;
                this.pnlTimes.Enabled = true;
                this.btnStop.Enabled = true;
                this.btnNext.Enabled = true;

                this.btnStart.Enabled = false;
                this.btnEditData.Enabled = false;
                this.btnShowResults.Enabled = false;
                this.tbxTimeQuantum.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Reset();
            pnlData.Enabled = false;
            pnlTimes.Enabled = false;
            btnStop.Enabled = false;
            btnNext.Enabled = false;

            btnStart.Enabled = true;
            btnEditData.Enabled = true;
            btnShowResults.Enabled = true;
            tbxTimeQuantum.Enabled = true;
        }
    }
}
