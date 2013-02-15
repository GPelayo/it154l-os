namespace CPU_Scheduling_Simulator
{
    partial class CustomDataEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnCustomData = new System.Windows.Forms.Panel();
            this.btSubmit = new System.Windows.Forms.Button();
            this.lbArrivalTime = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.lbCPUCycle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnCustomData
            // 
            this.pnCustomData.Location = new System.Drawing.Point(12, 25);
            this.pnCustomData.Name = "pnCustomData";
            this.pnCustomData.Size = new System.Drawing.Size(272, 238);
            this.pnCustomData.TabIndex = 0;
            // 
            // btSubmit
            // 
            this.btSubmit.Location = new System.Drawing.Point(113, 269);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(75, 23);
            this.btSubmit.TabIndex = 0;
            this.btSubmit.Text = "Submit";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // lbArrivalTime
            // 
            this.lbArrivalTime.AutoSize = true;
            this.lbArrivalTime.Location = new System.Drawing.Point(99, 10);
            this.lbArrivalTime.Name = "lbArrivalTime";
            this.lbArrivalTime.Size = new System.Drawing.Size(62, 13);
            this.lbArrivalTime.TabIndex = 1;
            this.lbArrivalTime.Text = "Arrival Time";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(234, 10);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(31, 13);
            this.lbType.TabIndex = 2;
            this.lbType.Text = "Type";
            // 
            // lbCPUCycle
            // 
            this.lbCPUCycle.AutoSize = true;
            this.lbCPUCycle.Location = new System.Drawing.Point(163, 10);
            this.lbCPUCycle.Name = "lbCPUCycle";
            this.lbCPUCycle.Size = new System.Drawing.Size(58, 13);
            this.lbCPUCycle.TabIndex = 3;
            this.lbCPUCycle.Text = "CPU Cycle";
            // 
            // CustomDataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 301);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.lbCPUCycle);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbArrivalTime);
            this.Controls.Add(this.pnCustomData);
            this.Name = "CustomDataEntryForm";
            this.Text = "Custom Data Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnCustomData;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.Label lbArrivalTime;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbCPUCycle;
    }
}