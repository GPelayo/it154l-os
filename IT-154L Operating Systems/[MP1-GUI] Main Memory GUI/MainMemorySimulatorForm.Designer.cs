namespace WindowsFormsApplication4
{
    partial class Form1
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
            this.jobPanel = new System.Windows.Forms.Panel();
            this.lblJobNumber = new System.Windows.Forms.Label();
            this.lblJobSize = new System.Windows.Forms.Label();
            this.lblJobTime = new System.Windows.Forms.Label();
            this.memoryPanel = new System.Windows.Forms.Panel();
            this.lblMemorySize = new System.Windows.Forms.Label();
            this.lblMemoryJobSize = new System.Windows.Forms.Label();
            this.lblMemoryJobNo = new System.Windows.Forms.Label();
            this.lblMemoryJobTime = new System.Windows.Forms.Label();
            this.lblRunType = new System.Windows.Forms.Label();
            this.lblAllocationType = new System.Windows.Forms.Label();
            this.cBxRunType = new System.Windows.Forms.ComboBox();
            this.cBxAllocationType = new System.Windows.Forms.ComboBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jobPanel
            // 
            this.jobPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.jobPanel.AutoScroll = true;
            this.jobPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jobPanel.Location = new System.Drawing.Point(12, 25);
            this.jobPanel.Name = "jobPanel";
            this.jobPanel.Size = new System.Drawing.Size(177, 413);
            this.jobPanel.TabIndex = 0;
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.AutoSize = true;
            this.lblJobNumber.Location = new System.Drawing.Point(15, 9);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(20, 13);
            this.lblJobNumber.TabIndex = 1;
            this.lblJobNumber.Text = "JN";
            // 
            // lblJobSize
            // 
            this.lblJobSize.AutoSize = true;
            this.lblJobSize.Location = new System.Drawing.Point(51, 9);
            this.lblJobSize.Name = "lblJobSize";
            this.lblJobSize.Size = new System.Drawing.Size(47, 13);
            this.lblJobSize.TabIndex = 2;
            this.lblJobSize.Text = "Job Size";
            // 
            // lblJobTime
            // 
            this.lblJobTime.AutoSize = true;
            this.lblJobTime.Location = new System.Drawing.Point(113, 9);
            this.lblJobTime.Name = "lblJobTime";
            this.lblJobTime.Size = new System.Drawing.Size(50, 13);
            this.lblJobTime.TabIndex = 3;
            this.lblJobTime.Text = "Job Time";
            // 
            // memoryPanel
            // 
            this.memoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memoryPanel.Location = new System.Drawing.Point(195, 25);
            this.memoryPanel.Name = "memoryPanel";
            this.memoryPanel.Size = new System.Drawing.Size(281, 207);
            this.memoryPanel.TabIndex = 4;
            // 
            // lblMemorySize
            // 
            this.lblMemorySize.AutoSize = true;
            this.lblMemorySize.Location = new System.Drawing.Point(225, 9);
            this.lblMemorySize.Name = "lblMemorySize";
            this.lblMemorySize.Size = new System.Drawing.Size(67, 13);
            this.lblMemorySize.TabIndex = 5;
            this.lblMemorySize.Text = "Memory Size";
            // 
            // lblMemoryJobSize
            // 
            this.lblMemoryJobSize.AutoSize = true;
            this.lblMemoryJobSize.Location = new System.Drawing.Point(295, 9);
            this.lblMemoryJobSize.Name = "lblMemoryJobSize";
            this.lblMemoryJobSize.Size = new System.Drawing.Size(47, 13);
            this.lblMemoryJobSize.TabIndex = 6;
            this.lblMemoryJobSize.Text = "Job Size";
            // 
            // lblMemoryJobNo
            // 
            this.lblMemoryJobNo.AutoSize = true;
            this.lblMemoryJobNo.Location = new System.Drawing.Point(355, 9);
            this.lblMemoryJobNo.Name = "lblMemoryJobNo";
            this.lblMemoryJobNo.Size = new System.Drawing.Size(49, 13);
            this.lblMemoryJobNo.TabIndex = 7;
            this.lblMemoryJobNo.Text = "Job Num";
            // 
            // lblMemoryJobTime
            // 
            this.lblMemoryJobTime.AutoSize = true;
            this.lblMemoryJobTime.Location = new System.Drawing.Point(411, 9);
            this.lblMemoryJobTime.Name = "lblMemoryJobTime";
            this.lblMemoryJobTime.Size = new System.Drawing.Size(50, 13);
            this.lblMemoryJobTime.TabIndex = 8;
            this.lblMemoryJobTime.Text = "Job Time";
            // 
            // lblRunType
            // 
            this.lblRunType.AutoSize = true;
            this.lblRunType.Location = new System.Drawing.Point(295, 235);
            this.lblRunType.Name = "lblRunType";
            this.lblRunType.Size = new System.Drawing.Size(54, 13);
            this.lblRunType.TabIndex = 15;
            this.lblRunType.Text = "Run Type";
            // 
            // lblAllocationType
            // 
            this.lblAllocationType.AutoSize = true;
            this.lblAllocationType.Location = new System.Drawing.Point(195, 235);
            this.lblAllocationType.Name = "lblAllocationType";
            this.lblAllocationType.Size = new System.Drawing.Size(80, 13);
            this.lblAllocationType.TabIndex = 14;
            this.lblAllocationType.Text = "Allocation Type";
            // 
            // cBxRunType
            // 
            this.cBxRunType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBxRunType.FormattingEnabled = true;
            this.cBxRunType.Items.AddRange(new object[] {
            "First In, First Serve",
            "Fastest Job, First Serve"});
            this.cBxRunType.Location = new System.Drawing.Point(298, 251);
            this.cBxRunType.Name = "cBxRunType";
            this.cBxRunType.Size = new System.Drawing.Size(121, 21);
            this.cBxRunType.TabIndex = 13;
            // 
            // cBxAllocationType
            // 
            this.cBxAllocationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBxAllocationType.FormattingEnabled = true;
            this.cBxAllocationType.Items.AddRange(new object[] {
            "First-Fit",
            "Best-Fit"});
            this.cBxAllocationType.Location = new System.Drawing.Point(198, 251);
            this.cBxAllocationType.Name = "cBxAllocationType";
            this.cBxAllocationType.Size = new System.Drawing.Size(75, 21);
            this.cBxAllocationType.TabIndex = 12;
            this.cBxAllocationType.SelectedIndexChanged += new System.EventHandler(this.cBxAllocationType_SelectedIndexChanged);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(195, 415);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 11;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(401, 415);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 450);
            this.Controls.Add(this.lblRunType);
            this.Controls.Add(this.lblAllocationType);
            this.Controls.Add(this.cBxRunType);
            this.Controls.Add(this.cBxAllocationType);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblMemoryJobTime);
            this.Controls.Add(this.lblMemoryJobNo);
            this.Controls.Add(this.lblMemoryJobSize);
            this.Controls.Add(this.lblMemorySize);
            this.Controls.Add(this.memoryPanel);
            this.Controls.Add(this.lblJobTime);
            this.Controls.Add(this.lblJobSize);
            this.Controls.Add(this.lblJobNumber);
            this.Controls.Add(this.jobPanel);
            this.Name = "Form1";
            this.Text = "MP1";
            this.Load += new System.EventHandler(this.MainMemorySimulatorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel jobPanel;
        private System.Windows.Forms.Label lblJobNumber;
        private System.Windows.Forms.Label lblJobSize;
        private System.Windows.Forms.Label lblJobTime;
        private System.Windows.Forms.Panel memoryPanel;
        private System.Windows.Forms.Label lblMemorySize;
        private System.Windows.Forms.Label lblMemoryJobSize;
        private System.Windows.Forms.Label lblMemoryJobNo;
        private System.Windows.Forms.Label lblMemoryJobTime;
        private System.Windows.Forms.Label lblRunType;
        private System.Windows.Forms.Label lblAllocationType;
        private System.Windows.Forms.ComboBox cBxRunType;
        private System.Windows.Forms.ComboBox cBxAllocationType;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button btnNext;
    }
}

