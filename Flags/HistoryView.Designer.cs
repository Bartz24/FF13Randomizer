namespace FF13Randomizer
{
    partial class HistoryView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label20 = new System.Windows.Forms.Label();
            this.textFlags = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textSeed = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelInvalid = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 27;
            this.label20.Text = "Flags";
            // 
            // textFlags
            // 
            this.textFlags.Location = new System.Drawing.Point(43, 3);
            this.textFlags.Name = "textFlags";
            this.textFlags.ReadOnly = true;
            this.textFlags.Size = new System.Drawing.Size(172, 20);
            this.textFlags.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Seed";
            // 
            // textSeed
            // 
            this.textSeed.Location = new System.Drawing.Point(43, 29);
            this.textSeed.Name = "textSeed";
            this.textSeed.ReadOnly = true;
            this.textSeed.Size = new System.Drawing.Size(172, 20);
            this.textSeed.TabIndex = 28;
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.Location = new System.Drawing.Point(441, 49);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(134, 23);
            this.button12.TabIndex = 30;
            this.button12.Text = "Pick These Settings";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(221, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Copy Flag String";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(221, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Copy Seed";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.Location = new System.Drawing.Point(374, 6);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(201, 23);
            this.labelVersion.TabIndex = 33;
            this.labelVersion.Text = "Rando Version: X.X.X";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelInvalid
            // 
            this.labelInvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInvalid.AutoSize = true;
            this.labelInvalid.ForeColor = System.Drawing.Color.Red;
            this.labelInvalid.Location = new System.Drawing.Point(341, 54);
            this.labelInvalid.Name = "labelInvalid";
            this.labelInvalid.Size = new System.Drawing.Size(94, 13);
            this.labelInvalid.TabIndex = 34;
            this.labelInvalid.Text = "ERROR: INVALID";
            // 
            // labelTime
            // 
            this.labelTime.Location = new System.Drawing.Point(5, 54);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(307, 18);
            this.labelTime.TabIndex = 35;
            this.labelTime.Text = "Created At: MM/dd/yyyy HH:mm:ss";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HistoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelInvalid);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSeed);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textFlags);
            this.MaximumSize = new System.Drawing.Size(99999, 75);
            this.MinimumSize = new System.Drawing.Size(0, 75);
            this.Name = "HistoryView";
            this.Size = new System.Drawing.Size(578, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textFlags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSeed;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelInvalid;
        private System.Windows.Forms.Label labelTime;
    }
}
