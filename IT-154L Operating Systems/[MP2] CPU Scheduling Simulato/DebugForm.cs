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
    public partial class DebugForm : Form
    {
        CPU currentCpu;

        public DebugForm()
        {
            InitializeComponent();
            InitializeCPU();
        }

        private void InitializeCPU()
        {
            List<Process> initialJobs = new List<Process>();
            
            initialJobs.Add(new Process(1, 0, 6, ProcessType.N));
            initialJobs.Add(new Process(2, 3, 2, ProcessType.NPR));
            initialJobs.Add(new Process(3, 5, 1, ProcessType.PR));
            initialJobs.Add(new Process(4, 9, 7, ProcessType.PR));
            initialJobs.Add(new Process(5, 10, 5, ProcessType.N));
            initialJobs.Add(new Process(6, 12, 3, ProcessType.N));
            initialJobs.Add(new Process(7, 14, 4, ProcessType.NPR));
            initialJobs.Add(new Process(8, 16, 5, ProcessType.PR));
            initialJobs.Add(new Process(9, 17, 7, ProcessType.PR));
            initialJobs.Add(new Process(10, 19, 2, ProcessType.N));
            currentCpu = new CPU(initialJobs, 4);
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentCpu.RunNextCycle();
            StringBuilder debugOutput = new StringBuilder("FIFO Sched \n");
            debugOutput.AppendLine("Current Cycle:" + currentCpu.CurrentCycle.ToString());
            debugOutput.AppendLine("Fifo Schedule: \n");
            foreach (Process iProcess in currentCpu.FifoSched)
            {
                debugOutput.AppendLine("Job#:  " + iProcess.JobNumber + "  AT: " 
                    + iProcess.ArrivalTime + "  CPU Cycle:  " + iProcess.CurrentCPUCycle
                    + "  Type:  " + iProcess.Type.ToString() + "  Status:  " + iProcess.Status.ToString());
            }
            debugOutput.AppendLine("\n Round Robin Schedule: \n");
            foreach (Process iProcess in currentCpu.RRSched)
            {
                debugOutput.AppendLine("Job#:  " + iProcess.JobNumber + "  AT:  "
                    + iProcess.ArrivalTime + "  CPU Cycle:  " + iProcess.CurrentCPUCycle
                    + "  Type:  " + iProcess.Type.ToString() + "  Status:  " + iProcess.Status.ToString());
            }
            debugOutput.AppendLine("\n Normal Schedule: \n");
            foreach (Process iProcess in currentCpu.NormalSched)
            {
                debugOutput.AppendLine("Job#:  " + iProcess.JobNumber + "  AT:   "
                    + iProcess.ArrivalTime + "  CPU Cycle:  " + iProcess.CurrentCPUCycle
                    + "  Type:  " + iProcess.Type.ToString() + "  Status:  " + iProcess.Status.ToString());
            }

            lblDisplay.Text = debugOutput.ToString();
        }
    }
}