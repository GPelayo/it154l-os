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
        List<Process> jobs;
        List<Panel> timelinePanels;
        CPU currentCPU;
        int i = 0;
        int lastJobNumber = -1;
        int jobsRan = 0;


        public MainForm()
        {
            InitializeComponent();
            InitializeCPU(4);
            InitializeTable();
        }

        private void InitializeCPU(int timeQuantum)
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
            currentCPU = new CPU(jobs, timeQuantum);
            currentCPU.RunNextCycle();
            lbCurrentTime.Text = "Current Time: " + currentCPU.CurrentCycle.ToString();
        }

        private void InitializeTable()
        {
            timelinePanels = new List<Panel>();

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
                String[] itemString = {iProcess.TurnaroundTime.ToString(), iProcess.WaitingTime.ToString()
                                        , iProcess.ResponseTime.ToString()};

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

        private void btCustomData_Click(object sender, EventArgs e)
        {
            CustomDataEntryForm customData = new CustomDataEntryForm(jobs);
            customData.ShowDialog();

            InitializeTable();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            lbCurrentTime.Text = "Current Time: " + currentCPU.CurrentCycle.ToString();
            currentCPU.RunNextCycle();
            
            if(currentCPU.RunningProcess.JobNumber != lastJobNumber)
            {
                Panel iPanel = new Panel();
                Label iLabel = new Label();

                iLabel.Text = currentCPU.RunningProcess.JobNumber.ToString();
                iLabel.Location = new Point(0, 0);
                iPanel.Size = new Size(15, 15);
                iPanel.Location = new Point(16*jobsRan, 0);
                iPanel.Controls.Add(iLabel);
                pnTimeline.Controls.Add(iPanel);
                jobsRan++;
            }

            InitializeTable();
            lastJobNumber = currentCPU.RunningProcess.JobNumber;
        }

        private void tBoxTimeQuantum_TextChanged(object sender, EventArgs e)
        {
            InitializeCPU(Convert.ToInt32(tBoxTimeQuantum.Text));
        }
    }
}
