namespace CPU_Scheduling_Simulator
{
    partial class MainForm
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
            this.pnData = new System.Windows.Forms.Panel();
            this.lbTimeQuantum = new System.Windows.Forms.Label();
            this.tBoxTimeQuantum = new System.Windows.Forms.TextBox();
            this.lvData = new System.Windows.Forms.ListView();
            this.cJobNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cArrivalTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCPUCycle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnTimes = new System.Windows.Forms.Panel();
            this.lvTimes = new System.Windows.Forms.ListView();
            this.cTurnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cWaitingTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btCustomData = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.pnTimeline = new System.Windows.Forms.Panel();
            this.lbCurrentTime = new System.Windows.Forms.Label();
            this.pnData.SuspendLayout();
            this.pnTimes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnData
            // 
            this.pnData.Controls.Add(this.lbTimeQuantum);
            this.pnData.Controls.Add(this.tBoxTimeQuantum);
            this.pnData.Controls.Add(this.lvData);
            this.pnData.Location = new System.Drawing.Point(12, 28);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(303, 297);
            this.pnData.TabIndex = 0;
            // 
            // lbTimeQuantum
            // 
            this.lbTimeQuantum.AutoSize = true;
            this.lbTimeQuantum.Location = new System.Drawing.Point(53, 271);
            this.lbTimeQuantum.Name = "lbTimeQuantum";
            this.lbTimeQuantum.Size = new System.Drawing.Size(79, 13);
            this.lbTimeQuantum.TabIndex = 2;
            this.lbTimeQuantum.Text = "Time Quantum:";
            // 
            // tBoxTimeQuantum
            // 
            this.tBoxTimeQuantum.Location = new System.Drawing.Point(138, 268);
            this.tBoxTimeQuantum.Name = "tBoxTimeQuantum";
            this.tBoxTimeQuantum.Size = new System.Drawing.Size(100, 20);
            this.tBoxTimeQuantum.TabIndex = 1;
            this.tBoxTimeQuantum.Text = "4";
            this.tBoxTimeQuantum.TextChanged += new System.EventHandler(this.tBoxTimeQuantum_TextChanged);
            // 
            // lvData
            // 
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cJobNumber,
            this.cArrivalTime,
            this.cCPUCycle,
            this.cType});
            this.lvData.Location = new System.Drawing.Point(3, 3);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(295, 255);
            this.lvData.TabIndex = 0;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // cJobNumber
            // 
            this.cJobNumber.Text = "Job Number";
            this.cJobNumber.Width = 80;
            // 
            // cArrivalTime
            // 
            this.cArrivalTime.Text = "Arrival Time";
            this.cArrivalTime.Width = 80;
            // 
            // cCPUCycle
            // 
            this.cCPUCycle.Text = "CPU Cycle";
            this.cCPUCycle.Width = 80;
            // 
            // cType
            // 
            this.cType.Text = "Type";
            this.cType.Width = 50;
            // 
            // pnTimes
            // 
            this.pnTimes.Controls.Add(this.lvTimes);
            this.pnTimes.Location = new System.Drawing.Point(321, 28);
            this.pnTimes.Name = "pnTimes";
            this.pnTimes.Size = new System.Drawing.Size(281, 297);
            this.pnTimes.TabIndex = 1;
            // 
            // lvTimes
            // 
            this.lvTimes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cTurnTime,
            this.cWaitingTime,
            this.cResponseTime});
            this.lvTimes.Location = new System.Drawing.Point(3, 3);
            this.lvTimes.Name = "lvTimes";
            this.lvTimes.Size = new System.Drawing.Size(275, 255);
            this.lvTimes.TabIndex = 0;
            this.lvTimes.UseCompatibleStateImageBehavior = false;
            this.lvTimes.View = System.Windows.Forms.View.Details;
            // 
            // cTurnTime
            // 
            this.cTurnTime.Text = "Turnaround Time";
            this.cTurnTime.Width = 100;
            // 
            // cWaitingTime
            // 
            this.cWaitingTime.Text = "Waiting Time";
            this.cWaitingTime.Width = 80;
            // 
            // cResponseTime
            // 
            this.cResponseTime.Text = "Response Time";
            this.cResponseTime.Width = 90;
            // 
            // btCustomData
            // 
            this.btCustomData.Location = new System.Drawing.Point(114, 336);
            this.btCustomData.Name = "btCustomData";
            this.btCustomData.Size = new System.Drawing.Size(98, 23);
            this.btCustomData.TabIndex = 2;
            this.btCustomData.Text = "Custom Data";
            this.btCustomData.UseVisualStyleBackColor = true;
            this.btCustomData.Click += new System.EventHandler(this.btCustomData_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(412, 337);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(98, 23);
            this.btNext.TabIndex = 3;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // pnTimeline
            // 
            this.pnTimeline.Location = new System.Drawing.Point(12, 371);
            this.pnTimeline.Name = "pnTimeline";
            this.pnTimeline.Size = new System.Drawing.Size(587, 48);
            this.pnTimeline.TabIndex = 4;
            // 
            // lbCurrentTime
            // 
            this.lbCurrentTime.AutoSize = true;
            this.lbCurrentTime.Location = new System.Drawing.Point(321, 9);
            this.lbCurrentTime.Name = "lbCurrentTime";
            this.lbCurrentTime.Size = new System.Drawing.Size(73, 13);
            this.lbCurrentTime.TabIndex = 5;
            this.lbCurrentTime.Text = "Current Time: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 468);
            this.Controls.Add(this.lbCurrentTime);
            this.Controls.Add(this.pnTimeline);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btCustomData);
            this.Controls.Add(this.pnTimes);
            this.Controls.Add(this.pnData);
            this.Name = "MainForm";
            this.Text = "MP2";
            this.pnData.ResumeLayout(false);
            this.pnData.PerformLayout();
            this.pnTimes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnData;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader cJobNumber;
        private System.Windows.Forms.ColumnHeader cArrivalTime;
        private System.Windows.Forms.ColumnHeader cCPUCycle;
        private System.Windows.Forms.ColumnHeader cType;
        private System.Windows.Forms.Panel pnTimes;
        private System.Windows.Forms.ListView lvTimes;
        private System.Windows.Forms.ColumnHeader cTurnTime;
        private System.Windows.Forms.ColumnHeader cWaitingTime;
        private System.Windows.Forms.ColumnHeader cResponseTime;
        private System.Windows.Forms.Button btCustomData;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Panel pnTimeline;
        private System.Windows.Forms.Label lbCurrentTime;
        private System.Windows.Forms.Label lbTimeQuantum;
        private System.Windows.Forms.TextBox tBoxTimeQuantum;
    }
}

