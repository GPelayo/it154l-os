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
    public partial class CustomDataEntryForm : Form
    {

        Label[] labelJobNumber = new Label[10];
        TextBox[] textboxArrivalTime = new TextBox[10];
        TextBox[] textboxCPUCycle = new TextBox[10];
        ComboBox[] textboxType = new ComboBox[10];
        List<Process> oldJobs = new List<Process>();

        public CustomDataEntryForm(List<Process> jobs)
        {
            InitializeComponent();
            oldJobs = jobs;
            //Job Number Label

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                Label jobLabel = new Label();
                jobLabel.Location = new Point(5, (i * 20) + 3);
                jobLabel.Size = new System.Drawing.Size(80, 13);
                labelJobNumber[i] = jobLabel;
                pnCustomData.Controls.Add(jobLabel);
            }

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                labelJobNumber[i].Text = "Job Number " + oldJobs[i].JobNumber.ToString();
            }

            //Arrival Time Input

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                TextBox iTxt = new TextBox();
                iTxt.TextChanged += TextboxInput_TextChanged;
                iTxt.Location = new Point(90, i * 20);
                iTxt.Size = new System.Drawing.Size(55, 13);
                textboxArrivalTime[i] = iTxt;
                pnCustomData.Controls.Add(iTxt);
            }

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                textboxArrivalTime[i].Text = oldJobs[i].ArrivalTime.ToString();
            }

            //CPU Cycle Input

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                TextBox iTxt = new TextBox();
                //add set the [Input_TechChanged] to be [iTxt] TextChanged Event
                iTxt.TextChanged += this.TextboxInput_TextChanged;
                iTxt.Location = new Point(150, i * 20);
                iTxt.Size = new System.Drawing.Size(55, 13);
                textboxCPUCycle[i] = iTxt;
                pnCustomData.Controls.Add(iTxt);
            }

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                textboxCPUCycle[i].Text = oldJobs[i].InitialCPUCycle.ToString();
            }

            //Type Input

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                ComboBox iTxt = new ComboBox();
                iTxt.Items.AddRange(new string[] { "N", "PR", "NPR" }); //Add Type
                iTxt.DropDownStyle = ComboBoxStyle.DropDownList;
                iTxt.Location = new Point(210, i * 20);
                iTxt.Size = new System.Drawing.Size(55, 13);
                textboxType[i] = iTxt;
                pnCustomData.Controls.Add(iTxt);
            }

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                textboxType[i].Text = jobs[i].Type.ToString();
            }
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < oldJobs.Count; i++ )
            {
                oldJobs[i].ArrivalTime = int.Parse(textboxArrivalTime[i].Text);
                oldJobs[i].InitialCPUCycle = int.Parse(textboxCPUCycle[i].Text);
                oldJobs[i].Type = (ProcessType)Enum.Parse(typeof(ProcessType), textboxType[i].Text);
            }

            this.Close();
        }        

        private void TextboxInput_TextChanged(object sender, EventArgs e)
        {
            //Put tbxInput_TextChanged() Method here
            //if wrong
            //Show Error in MessageBox
            //Revert It using old Data (oldJobs[])
        }
    }
}
