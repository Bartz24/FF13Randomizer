﻿namespace FF13Randomizer
{
    partial class FlagBool
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
            // FlagBool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelExtra);
            this.Controls.Add(this.checkExtra);
            this.Name = "FlagBool";
            this.Controls.SetChildIndex(this.checkExtra, 0);
            this.Controls.SetChildIndex(this.labelExtra, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkExtra;
        private System.Windows.Forms.Label labelExtra;
    }
}
