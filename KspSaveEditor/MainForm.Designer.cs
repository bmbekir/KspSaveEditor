namespace KspSaveEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lstVessels = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstParts = new System.Windows.Forms.ListBox();
            this.trckStorage1 = new System.Windows.Forms.TrackBar();
            this.lblCapacity1 = new System.Windows.Forms.Label();
            this.grpProperty1 = new System.Windows.Forms.GroupBox();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.grpProperty2 = new System.Windows.Forms.GroupBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.lblCapacity2 = new System.Windows.Forms.Label();
            this.trckStorage2 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckStorage1)).BeginInit();
            this.grpProperty1.SuspendLayout();
            this.grpProperty2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckStorage2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1598, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(34, 28);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenFile);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(34, 28);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // lstVessels
            // 
            this.lstVessels.DisplayMember = "Name";
            this.lstVessels.FormattingEnabled = true;
            this.lstVessels.ItemHeight = 25;
            this.lstVessels.Location = new System.Drawing.Point(12, 70);
            this.lstVessels.Name = "lstVessels";
            this.lstVessels.Size = new System.Drawing.Size(405, 504);
            this.lstVessels.TabIndex = 1;
            this.lstVessels.SelectedIndexChanged += new System.EventHandler(this.lstVessels_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vessels";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parts";
            // 
            // lstParts
            // 
            this.lstParts.DisplayMember = "Name";
            this.lstParts.FormattingEnabled = true;
            this.lstParts.ItemHeight = 25;
            this.lstParts.Location = new System.Drawing.Point(576, 70);
            this.lstParts.Name = "lstParts";
            this.lstParts.Size = new System.Drawing.Size(411, 504);
            this.lstParts.TabIndex = 3;
            this.lstParts.SelectedIndexChanged += new System.EventHandler(this.lstParts_SelectedIndexChanged);
            // 
            // trckStorage1
            // 
            this.trckStorage1.Location = new System.Drawing.Point(6, 30);
            this.trckStorage1.Maximum = 1000;
            this.trckStorage1.Name = "trckStorage1";
            this.trckStorage1.Size = new System.Drawing.Size(581, 69);
            this.trckStorage1.TabIndex = 5;
            this.trckStorage1.ValueChanged += new System.EventHandler(this.trckStorage1_ValueChanged);
            // 
            // lblCapacity1
            // 
            this.lblCapacity1.AutoSize = true;
            this.lblCapacity1.Location = new System.Drawing.Point(6, 102);
            this.lblCapacity1.Name = "lblCapacity1";
            this.lblCapacity1.Size = new System.Drawing.Size(83, 25);
            this.lblCapacity1.TabIndex = 6;
            this.lblCapacity1.Text = "Capacity:";
            // 
            // grpProperty1
            // 
            this.grpProperty1.Controls.Add(this.txtValue1);
            this.grpProperty1.Controls.Add(this.lblCapacity1);
            this.grpProperty1.Controls.Add(this.trckStorage1);
            this.grpProperty1.Location = new System.Drawing.Point(993, 81);
            this.grpProperty1.Name = "grpProperty1";
            this.grpProperty1.Size = new System.Drawing.Size(593, 180);
            this.grpProperty1.TabIndex = 8;
            this.grpProperty1.TabStop = false;
            this.grpProperty1.Text = "--";
            // 
            // txtValue1
            // 
            this.txtValue1.Location = new System.Drawing.Point(437, 96);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.ReadOnly = true;
            this.txtValue1.Size = new System.Drawing.Size(150, 31);
            this.txtValue1.TabIndex = 7;
            // 
            // grpProperty2
            // 
            this.grpProperty2.Controls.Add(this.txtValue2);
            this.grpProperty2.Controls.Add(this.lblCapacity2);
            this.grpProperty2.Controls.Add(this.trckStorage2);
            this.grpProperty2.Location = new System.Drawing.Point(999, 267);
            this.grpProperty2.Name = "grpProperty2";
            this.grpProperty2.Size = new System.Drawing.Size(593, 180);
            this.grpProperty2.TabIndex = 9;
            this.grpProperty2.TabStop = false;
            this.grpProperty2.Text = "--";
            // 
            // txtValue2
            // 
            this.txtValue2.Location = new System.Drawing.Point(437, 96);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.ReadOnly = true;
            this.txtValue2.Size = new System.Drawing.Size(150, 31);
            this.txtValue2.TabIndex = 8;
            // 
            // lblCapacity2
            // 
            this.lblCapacity2.AutoSize = true;
            this.lblCapacity2.Location = new System.Drawing.Point(6, 102);
            this.lblCapacity2.Name = "lblCapacity2";
            this.lblCapacity2.Size = new System.Drawing.Size(83, 25);
            this.lblCapacity2.TabIndex = 6;
            this.lblCapacity2.Text = "Capacity:";
            // 
            // trckStorage2
            // 
            this.trckStorage2.Location = new System.Drawing.Point(6, 30);
            this.trckStorage2.Maximum = 1000;
            this.trckStorage2.Name = "trckStorage2";
            this.trckStorage2.Size = new System.Drawing.Size(575, 69);
            this.trckStorage2.TabIndex = 5;
            this.trckStorage2.ValueChanged += new System.EventHandler(this.trckStorage2_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1474, 539);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1598, 585);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpProperty2);
            this.Controls.Add(this.grpProperty1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstParts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstVessels);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckStorage1)).EndInit();
            this.grpProperty1.ResumeLayout(false);
            this.grpProperty1.PerformLayout();
            this.grpProperty2.ResumeLayout(false);
            this.grpProperty2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckStorage2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ListBox lstVessels;
        private Label label1;
        private Label label2;
        private ListBox lstParts;
        private TrackBar trckStorage1;
        private Label lblCapacity1;
        private GroupBox grpProperty1;
        private GroupBox grpProperty2;
        private Label lblCapacity2;
        private TrackBar trckStorage2;
        private TextBox txtValue1;
        private TextBox txtValue2;
        private Button button1;
    }
}