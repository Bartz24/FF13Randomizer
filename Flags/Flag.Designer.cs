namespace FF13Randomizer
{
    partial class Flag
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
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.labelDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.Location = new System.Drawing.Point(6, 3);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(117, 41);
            this.checkBoxEnabled.TabIndex = 0;
            this.checkBoxEnabled.Text = "Flag Name";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.Location = new System.Drawing.Point(127, 3);
            this.labelDesc.MaximumSize = new System.Drawing.Size(620, 0);
            this.labelDesc.MinimumSize = new System.Drawing.Size(620, 0);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(620, 26);
            this.labelDesc.TabIndex = 0;
            this.labelDesc.Text = "Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test T" +
    "est Test Test Test Test Test Test Test Test Test Test Test ";
            // 
            // Flag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.checkBoxEnabled);
            this.MaximumSize = new System.Drawing.Size(760, 75);
            this.MinimumSize = new System.Drawing.Size(760, 75);
            this.Name = "Flag";
            this.Size = new System.Drawing.Size(760, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.Label labelDesc;
    }
}
