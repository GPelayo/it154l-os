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
            this.pnlData = new System.Windows.Forms.Panel();
            this.lvData = new System.Windows.Forms.ListView();
            this.cJobNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cArrivalTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCPUCycle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbTimeQuantum = new System.Windows.Forms.Label();
            this.tbxTimeQuantum = new System.Windows.Forms.TextBox();
            this.pnlTimes = new System.Windows.Forms.Panel();
            this.lvTimes = new System.Windows.Forms.ListView();
            this.cTurnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cWaitingTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEditData = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlTimeline = new System.Windows.Forms.Panel();
            this.tBxTimeline = new System.Windows.Forms.Label();
            this.btnShowResults = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pnlData.SuspendLayout();
            this.pnlTimes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.lvData);
            this.pnlData.Enabled = false;
            this.pnlData.Location = new System.Drawing.Point(12, 28);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(303, 269);
            this.pnlData.TabIndex = 0;
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
            // lbTimeQuantum
            // 
            this.lbTimeQuantum.AutoSize = true;
            this.lbTimeQuantum.Location = new System.Drawing.Point(79, 308);
            this.lbTimeQuantum.Name = "lbTimeQuantum";
            this.lbTimeQuantum.Size = new System.Drawing.Size(79, 13);
            this.lbTimeQuantum.TabIndex = 2;
            this.lbTimeQuantum.Text = "Time Quantum:";
            // 
            // tbxTimeQuantum
            // 
            this.tbxTimeQuantum.Location = new System.Drawing.Point(163, 305);
            this.tbxTimeQuantum.Name = "tbxTimeQuantum";
            this.tbxTimeQuantum.Size = new System.Drawing.Size(100, 20);
            this.tbxTimeQuantum.TabIndex = 1;
            this.tbxTimeQuantum.Text = "4";
            // 
            // pnlTimes
            // 
            this.pnlTimes.Controls.Add(this.lvTimes);
            this.pnlTimes.Enabled = false;
            this.pnlTimes.Location = new System.Drawing.Point(321, 28);
            this.pnlTimes.Name = "pnlTimes";
            this.pnlTimes.Size = new System.Drawing.Size(281, 269);
            this.pnlTimes.TabIndex = 1;
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
            // btnEditData
            // 
            this.btnEditData.Location = new System.Drawing.Point(92, 331);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(75, 23);
            this.btnEditData.TabIndex = 2;
            this.btnEditData.Text = "Edit Data";
            this.btnEditData.UseVisualStyleBackColor = true;
            this.btnEditData.Click += new System.EventHandler(this.btnCustomData_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(525, 331);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(74, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next Cycle";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Location = new System.Drawing.Point(321, 9);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentTime.TabIndex = 5;
            this.lblCurrentTime.Text = "Current Time: ";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(324, 331);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(74, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlTimeline
            // 
            this.pnlTimeline.AutoScroll = true;
            this.pnlTimeline.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTimeline.Location = new System.Drawing.Point(12, 378);
            this.pnlTimeline.Name = "pnlTimeline";
            this.pnlTimeline.Size = new System.Drawing.Size(587, 78);
            this.pnlTimeline.TabIndex = 4;
            // 
            // tBxTimeline
            // 
            this.tBxTimeline.AutoSize = true;
            this.tBxTimeline.Location = new System.Drawing.Point(15, 360);
            this.tBxTimeline.Name = "tBxTimeline";
            this.tBxTimeline.Size = new System.Drawing.Size(46, 13);
            this.tBxTimeline.TabIndex = 7;
            this.tBxTimeline.Text = "Timeline";
            // 
            // btnShowResults
            // 
            this.btnShowResults.Location = new System.Drawing.Point(173, 331);
            this.btnShowResults.Name = "btnShowResults";
            this.btnShowResults.Size = new System.Drawing.Size(85, 23);
            this.btnShowResults.TabIndex = 8;
            this.btnShowResults.Text = "Show Results";
            this.btnShowResults.UseVisualStyleBackColor = true;
            this.btnShowResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(404, 331);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 468);
            this.Controls.Add(this.lbTimeQuantum);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.tbxTimeQuantum);
            this.Controls.Add(this.btnShowResults);
            this.Controls.Add(this.tBxTimeline);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.pnlTimeline);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnEditData);
            this.Controls.Add(this.pnlTimes);
            this.Controls.Add(this.pnlData);
            this.Name = "MainForm";
            this.Text = "MP2";
            this.pnlData.ResumeLayout(false);
            this.pnlTimes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader cJobNumber;
        private System.Windows.Forms.ColumnHeader cArrivalTime;
        private System.Windows.Forms.ColumnHeader cCPUCycle;
        private System.Windows.Forms.ColumnHeader cType;
        private System.Windows.Forms.Panel pnlTimes;
        private System.Windows.Forms.ListView lvTimes;
        private System.Windows.Forms.ColumnHeader cTurnTime;
        private System.Windows.Forms.ColumnHeader cWaitingTime;
        private System.Windows.Forms.ColumnHeader cResponseTime;
        private System.Windows.Forms.Button btnEditData;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lbTimeQuantum;
        private System.Windows.Forms.TextBox tbxTimeQuantum;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlTimeline;
        private System.Windows.Forms.Label tBxTimeline;
        private System.Windows.Forms.Button btnShowResults;
        private System.Windows.Forms.Button btnStop;
    }
}

