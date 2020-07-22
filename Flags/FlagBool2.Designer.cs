namespace FF13Randomizer
{
    partial class FlagBool2
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
            this.checkExtra = new System.Windows.Forms.CheckBox();
            this.labelExtra = new System.Windows.Forms.Label();
            this.labelExtra2 = new System.Windows.Forms.Label();
            this.checkExtra2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkExtra
            // 
            this.checkExtra.Location = new System.Drawing.Point(46, 45);
            this.checkExtra.Name = "checkExtra";
            this.checkExtra.Size = new System.Drawing.Size(117, 45);
            this.checkExtra.TabIndex = 1;
            this.checkExtra.Text = "checkExtra";
            this.checkExtra.UseVisualStyleBackColor = true;
            // 
            // labelExtra
            // 
            this.labelExtra.AutoSize = true;
            this.labelExtra.Location = new System.Drawing.Point(169, 45);
            this.labelExtra.Name = "labelExtra";
            this.labelExtra.Size = new System.Drawing.Size(53, 13);
            this.labelExtra.TabIndex = 2;
            this.labelExtra.Text = "labelExtra";
            // 
            // labelExtra2
            // 
            this.labelExtra2.AutoSize = true;
            this.labelExtra2.Location = new System.Drawing.Point(169, 13);
            this.labelExtra2.Name = "labelExtra2";
            this.labelExtra2.Size = new System.Drawing.Size(35, 13);
            this.labelExtra2.TabIndex = 4;
            this.labelExtra2.Text = "label1";
            // 
            // checkExtra2
            // 
            this.checkExtra2.Location = new System.Drawing.Point(46, 13);
            this.checkExtra2.Name = "checkExtra2";
            this.checkExtra2.Size = new System.Drawing.Size(117, 45);
            this.checkExtra2.TabIndex = 3;
            this.checkExtra2.Text = "checkBox1";
            this.checkExtra2.UseVisualStyleBackColor = true;
            // 
            // FlagBool2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelExtra2);
            this.Controls.Add(this.checkExtra2);
            this.Controls.Add(this.labelExtra);
            this.Controls.Add(this.checkExtra);
            this.Name = "FlagBool2";
            this.Controls.SetChildIndex(this.checkExtra, 0);
            this.Controls.SetChildIndex(this.labelExtra, 0);
            this.Controls.SetChildIndex(this.checkExtra2, 0);
            this.Controls.SetChildIndex(this.labelExtra2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkExtra;
        private System.Windows.Forms.Label labelExtra;
        private System.Windows.Forms.Label labelExtra2;
        private System.Windows.Forms.CheckBox checkExtra2;
    }
}
