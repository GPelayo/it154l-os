using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainMemorySimulator;
namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        private const int OUTPUTS_TOP_MARGIN = 2;
        private const int TEXTBOX_Y_LOCATION_INTERVAL = 19;

        Memory memory;
        Label[] labelJobNumber = new Label[25];
        TextBox[] tbxJobSize = new TextBox[25];
        TextBox[] tbxJobTime = new TextBox[25];
        Label[] labelMemoryBlock = new Label[10];
        TextBox[] tbxParitionSize = new TextBox[10];
        TextBox[] tbxParitionJobSize = new TextBox[10];
        TextBox[] tbxPartitionJobNo = new TextBox[10];
        TextBox[] tbxPartitionJobTime = new TextBox[10];

        public Form1()
        {
            InitializeComponent();

            //Job Panel

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                Label jobLabel = new Label();
                jobLabel.Location = new Point(5, (i * TEXTBOX_Y_LOCATION_INTERVAL) + 3 + OUTPUTS_TOP_MARGIN);
                jobLabel.Size = new System.Drawing.Size(20, 13);
                labelJobNumber[i] = jobLabel;
                jobPanel.Controls.Add(jobLabel);
            }

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                labelJobNumber[i].Text = (i+1).ToString();
            }

            for (int i = 0; i < tbxJobSize.Length; i++)
            {
                TextBox iTxt = new TextBox();
                iTxt.Location = new Point(35, (i * TEXTBOX_Y_LOCATION_INTERVAL) + OUTPUTS_TOP_MARGIN);
                iTxt.Size = new System.Drawing.Size(55,13);
                iTxt.GotFocus += this.ouputTextBox_GotFocus;
                jobPanel.Controls.Add(iTxt);
                tbxJobSize[i] = iTxt;
            }

            for (int i = 0; i < tbxJobTime.Length; i++)
            {
                TextBox iTxt = new TextBox();
                iTxt.Location = new Point(105, (i * TEXTBOX_Y_LOCATION_INTERVAL) + OUTPUTS_TOP_MARGIN);
                iTxt.Size = new System.Drawing.Size(40, 13);
                iTxt.GotFocus += this.ouputTextBox_GotFocus;
                jobPanel.Controls.Add(iTxt);
                tbxJobTime[i] = iTxt;
            }

            //Memory Panel

            for (int i = 0; i < labelMemoryBlock.Length; i++)
            {
                Label memoryBlock = new Label();
                memoryBlock.Location = new Point(5, (i * TEXTBOX_Y_LOCATION_INTERVAL) + 3 + OUTPUTS_TOP_MARGIN);
                memoryBlock.Size = new System.Drawing.Size(20, 13);
                labelMemoryBlock[i] = memoryBlock;
                memoryPanel.Controls.Add(memoryBlock);
            }

            for (int i = 0; i < labelMemoryBlock.Length; i++)
            {
                labelMemoryBlock[i].Text = (i + 1).ToString();
            }

            for (int i = 0; i < tbxParitionSize.Length; i++)
            {
                TextBox iTxt = new TextBox();
                iTxt.Location = new Point(35, (i * TEXTBOX_Y_LOCATION_INTERVAL) + OUTPUTS_TOP_MARGIN);
                iTxt.Size = new System.Drawing.Size(55, 13);
                iTxt.GotFocus += this.ouputTextBox_GotFocus;
                tbxParitionSize[i] = iTxt;
                memoryPanel.Controls.Add(iTxt);
            }

            for (int i = 0; i < tbxParitionJobSize.Length; i++)
            {
                TextBox iTxt = new TextBox();
                iTxt.Location = new Point(95, (i * TEXTBOX_Y_LOCATION_INTERVAL) + OUTPUTS_TOP_MARGIN);
                iTxt.Size = new System.Drawing.Size(55, 13);
                iTxt.GotFocus += this.ouputTextBox_GotFocus;
                memoryPanel.Controls.Add(iTxt);
                tbxParitionJobSize[i] = iTxt;
            }

            for (int i = 0; i < tbxPartitionJobNo.Length; i++)
            {
                TextBox iTxt = new TextBox();
                iTxt.Location = new Point(155, (i * TEXTBOX_Y_LOCATION_INTERVAL) + OUTPUTS_TOP_MARGIN);
                iTxt.Size = new System.Drawing.Size(55, 13);
                iTxt.GotFocus += this.ouputTextBox_GotFocus;
                memoryPanel.Controls.Add(iTxt);
                tbxPartitionJobNo[i] = iTxt;
            }

            for (int i = 0; i < tbxPartitionJobTime.Length; i++)
            {
                TextBox iTxt = new TextBox();
                iTxt.Location = new Point(215, (i * TEXTBOX_Y_LOCATION_INTERVAL) + OUTPUTS_TOP_MARGIN);
                iTxt.Size = new System.Drawing.Size(55, 13);
                iTxt.GotFocus += this.ouputTextBox_GotFocus;
                tbxPartitionJobTime[i] = iTxt;
                memoryPanel.Controls.Add(iTxt);
            }
        }

        private void MainMemorySimulatorForm_Load(object sender, EventArgs e)
        {
            this.cBxAllocationType.SelectedIndex = 0;
            this.cBxRunType.SelectedIndex = 0;

            this.ResetMemory();
        }

        private void ResetMemory()
        {
            List<Job> jobQueue = LabFixedParitionQueue();
            List<Partition> partitions = LabFixedParitions();            

            this.memory = new FixedPartitionMemory(partitions, jobQueue, cBxAllocationType.Text == "Best-Fit", cBxRunType.Text == "Fastest Job, First Serve");
            this.ResetDisplay();
        }

        private void ResetDisplay()
        {
            foreach(Job iJob in memory.JobQueue)
            {
                tbxJobSize[iJob.Number - 1].Text = iJob.MemorySpace.ToString();
                tbxJobSize[iJob.Number -1].BackColor = iJob.WasAllocated ? Color.MistyRose : Color.MintCream;
                tbxJobTime[iJob.Number -1].Text = iJob.Time.ToString();
                tbxJobTime[iJob.Number -1].BackColor = iJob.WasAllocated ? Color.MistyRose : Color.MintCream;
            }

            for (int i = 0; i < memory.MemoryBlocks.Length; i++)
            {
                tbxParitionSize[i].Text = ((FixedPartition)memory.MemoryBlocks[i]).MemoryCapacity.ToString();
                tbxParitionJobSize[i].Text = memory.MemoryBlocks[i].CurrentJob.Number == int.MaxValue
                    ? "Empty" : memory.MemoryBlocks[i].CurrentJob.MemorySpace.ToString();
                tbxPartitionJobNo[i].Text = memory.MemoryBlocks[i].CurrentJob.Number == int.MaxValue 
                    ? "Empty" : memory.MemoryBlocks[i].CurrentJob.Number.ToString();
                tbxPartitionJobTime[i].Text = memory.MemoryBlocks[i].CurrentJob.Number == int.MaxValue 
                    ? "Empty" : memory.MemoryBlocks[i].CurrentJob.TimeLeft.ToString();
                
            }
        }

        static List<Job> LabFixedParitionQueue()
        {
            List<Job> jobQueue = new List<Job>();

            jobQueue.Add(new Job(1, 5, 5760));
            jobQueue.Add(new Job(2, 4, 4190));
            jobQueue.Add(new Job(3, 8, 3290));
            jobQueue.Add(new Job(4, 2, 2030));
            jobQueue.Add(new Job(5, 2, 2550));
            jobQueue.Add(new Job(6, 6, 6990));
            jobQueue.Add(new Job(7, 8, 8940));
            jobQueue.Add(new Job(8, 10, 740));
            jobQueue.Add(new Job(9, 7, 3930));
            jobQueue.Add(new Job(10, 6, 6890));
            jobQueue.Add(new Job(11, 5, 6580));
            jobQueue.Add(new Job(12, 8, 3280));
            jobQueue.Add(new Job(13, 9, 9140));
            jobQueue.Add(new Job(14, 10, 420));
            jobQueue.Add(new Job(15, 10, 220));
            jobQueue.Add(new Job(16, 7, 7540));
            jobQueue.Add(new Job(17, 3, 3210));
            jobQueue.Add(new Job(18, 1, 1380));
            jobQueue.Add(new Job(19, 9, 9850));
            jobQueue.Add(new Job(20, 3, 3610));
            jobQueue.Add(new Job(21, 7, 7540));
            jobQueue.Add(new Job(22, 2, 2710));
            jobQueue.Add(new Job(23, 8, 8390));
            jobQueue.Add(new Job(24, 5, 5950));
            jobQueue.Add(new Job(25, 10, 1760));
            return jobQueue;
        }

        static List<Partition> LabFixedParitions()
        {
            List<Partition> partition = new List<Partition>();

            partition.Add(new FixedPartition(9500));
            partition.Add(new FixedPartition(7000));
            partition.Add(new FixedPartition(4500));
            partition.Add(new FixedPartition(8500));
            partition.Add(new FixedPartition(3000));
            partition.Add(new FixedPartition(9000));
            partition.Add(new FixedPartition(1000));
            partition.Add(new FixedPartition(5500));
            partition.Add(new FixedPartition(1500));
            partition.Add(new FixedPartition(500));

            return partition;
        }

        private void cBxAllocationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ResetMemory();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.memory.Update();
            this.ResetDisplay();
        }

        private void ouputTextBox_GotFocus(object sender, EventArgs e)
        {
            this.lblMemorySize.Select();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.ResetMemory();
        }
    }
}
