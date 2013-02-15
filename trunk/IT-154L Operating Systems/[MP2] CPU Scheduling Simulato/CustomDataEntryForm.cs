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
        const int LABEL_ROW_MARGIN = 3;
        const int INPUT_ROW_MARGIN = 24;

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
                jobLabel.Location = new Point(5, (i * INPUT_ROW_MARGIN) + LABEL_ROW_MARGIN);
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
                iTxt.Location = new Point(90, i * INPUT_ROW_MARGIN);
                iTxt.Size = new System.Drawing.Size(55, 13);
                textboxArrivalTime[i] = iTxt;
                pnCustomData.Controls.Add(iTxt);
                textboxArrivalTime[i].Text = oldJobs[i].ArrivalTime.ToString();
            }

            //CPU Cycle Input

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                TextBox iTxt = new TextBox();
                //add set the [Input_TechChanged] to be [iTxt] TextChanged Event
                iTxt.Location = new Point(150, i * INPUT_ROW_MARGIN);
                iTxt.Size = new System.Drawing.Size(55, 13);
                textboxCPUCycle[i] = iTxt;
                pnCustomData.Controls.Add(iTxt);
                textboxCPUCycle[i].Text = oldJobs[i].InitialCPUCycle.ToString();
            }

            //Type Input

            for (int i = 0; i < labelJobNumber.Length; i++)
            {
                ComboBox iTxt = new ComboBox();
                iTxt.Items.AddRange(new string[] { "N", "PR", "NPR" }); //Add Type
                iTxt.DropDownStyle = ComboBoxStyle.DropDownList;
                iTxt.Location = new Point(210, i * INPUT_ROW_MARGIN);
                iTxt.Size = new System.Drawing.Size(55, 13);
                textboxType[i] = iTxt;
                pnCustomData.Controls.Add(iTxt);
                textboxType[i].Text = jobs[i].Type.ToString();
            }
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < oldJobs.Count; i++)
                {
                    int newArrivalTime = 0, newCpuCycle = 0;
                    newArrivalTime = int.Parse(textboxArrivalTime[i].Text);
                    newCpuCycle = int.Parse(textboxCPUCycle[i].Text);

                    if (newArrivalTime >= 0 && newCpuCycle > 0)
                    {
                        oldJobs[i].ArrivalTime = newArrivalTime;
                        oldJobs[i].InitialCPUCycle = newCpuCycle;
                        oldJobs[i].Type = (ProcessType)Enum.Parse(typeof(ProcessType), textboxType[i].Text);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }


                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("All text inputs need to be an integer greater than 0.", "Invalid Input", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
            
            
        }
    }
}
