namespace FF13Randomizer
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBasics = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSeed = new System.Windows.Forms.TextBox();
            this.tabPageFlags = new System.Windows.Forms.TabPage();
            this.tabPageFinish = new System.Windows.Forms.TabPage();
            this.labelFlagsSelected = new System.Windows.Forms.Label();
            this.buttonRandomize = new System.Windows.Forms.Button();
            this.tabPageUninstall = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonFullUninstall = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUninstall = new System.Windows.Forms.Button();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.flagInfo1 = new FF13Randomizer.FlagInfo();
            this.label7 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageBasics.SuspendLayout();
            this.tabPageFinish.SuspendLayout();
            this.tabPageUninstall.SuspendLayout();
            this.tabPageDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(345, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(183, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(183, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(183, 149);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageBasics);
            this.tabControl1.Controls.Add(this.tabPageFlags);
            this.tabControl1.Controls.Add(this.tabPageFinish);
            this.tabControl1.Controls.Add(this.tabPageUninstall);
            this.tabControl1.Controls.Add(this.tabPageDebug);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(40, 100);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 525);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 7;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.TabControl1_TabIndexChanged);
            // 
            // tabPageBasics
            // 
            this.tabPageBasics.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageBasics.Controls.Add(this.label5);
            this.tabPageBasics.Controls.Add(this.button8);
            this.tabPageBasics.Controls.Add(this.button7);
            this.tabPageBasics.Controls.Add(this.label2);
            this.tabPageBasics.Controls.Add(this.textBox2);
            this.tabPageBasics.Controls.Add(this.label1);
            this.tabPageBasics.Controls.Add(this.textBoxSeed);
            this.tabPageBasics.Location = new System.Drawing.Point(104, 4);
            this.tabPageBasics.Name = "tabPageBasics";
            this.tabPageBasics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasics.Size = new System.Drawing.Size(493, 517);
            this.tabPageBasics.TabIndex = 0;
            this.tabPageBasics.Text = "Basics";
            this.tabPageBasics.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Steam path required for randomization.";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(349, 46);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(134, 23);
            this.button8.TabIndex = 5;
            this.button8.Text = "Select FF13 Folder";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(349, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(134, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "Random Seed";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "FF13 Steam Path";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(104, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(239, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seed";
            // 
            // textBoxSeed
            // 
            this.textBoxSeed.Location = new System.Drawing.Point(104, 6);
            this.textBoxSeed.Name = "textBoxSeed";
            this.textBoxSeed.Size = new System.Drawing.Size(239, 20);
            this.textBoxSeed.TabIndex = 0;
            // 
            // tabPageFlags
            // 
            this.tabPageFlags.AutoScroll = true;
            this.tabPageFlags.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageFlags.Location = new System.Drawing.Point(104, 4);
            this.tabPageFlags.Name = "tabPageFlags";
            this.tabPageFlags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFlags.Size = new System.Drawing.Size(493, 517);
            this.tabPageFlags.TabIndex = 1;
            this.tabPageFlags.Text = "Flags";
            this.tabPageFlags.UseVisualStyleBackColor = true;
            // 
            // tabPageFinish
            // 
            this.tabPageFinish.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageFinish.Controls.Add(this.labelFlagsSelected);
            this.tabPageFinish.Controls.Add(this.buttonRandomize);
            this.tabPageFinish.Location = new System.Drawing.Point(104, 4);
            this.tabPageFinish.Name = "tabPageFinish";
            this.tabPageFinish.Size = new System.Drawing.Size(493, 517);
            this.tabPageFinish.TabIndex = 3;
            this.tabPageFinish.Text = "Finish";
            this.tabPageFinish.UseVisualStyleBackColor = true;
            // 
            // labelFlagsSelected
            // 
            this.labelFlagsSelected.AutoSize = true;
            this.labelFlagsSelected.Location = new System.Drawing.Point(166, 33);
            this.labelFlagsSelected.Name = "labelFlagsSelected";
            this.labelFlagsSelected.Size = new System.Drawing.Size(90, 13);
            this.labelFlagsSelected.TabIndex = 6;
            this.labelFlagsSelected.Text = "Flags Selected: X";
            // 
            // buttonRandomize
            // 
            this.buttonRandomize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandomize.Location = new System.Drawing.Point(26, 28);
            this.buttonRandomize.Name = "buttonRandomize";
            this.buttonRandomize.Size = new System.Drawing.Size(134, 23);
            this.buttonRandomize.TabIndex = 5;
            this.buttonRandomize.Text = "RANDOMIZE!";
            this.buttonRandomize.UseVisualStyleBackColor = true;
            this.buttonRandomize.Click += new System.EventHandler(this.button9_Click);
            // 
            // tabPageUninstall
            // 
            this.tabPageUninstall.Controls.Add(this.label6);
            this.tabPageUninstall.Controls.Add(this.button9);
            this.tabPageUninstall.Controls.Add(this.label4);
            this.tabPageUninstall.Controls.Add(this.buttonFullUninstall);
            this.tabPageUninstall.Controls.Add(this.label3);
            this.tabPageUninstall.Controls.Add(this.buttonUninstall);
            this.tabPageUninstall.Location = new System.Drawing.Point(104, 4);
            this.tabPageUninstall.Name = "tabPageUninstall";
            this.tabPageUninstall.Size = new System.Drawing.Size(493, 517);
            this.tabPageUninstall.TabIndex = 4;
            this.tabPageUninstall.Text = "Uninstall";
            this.tabPageUninstall.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Replaces with the truly original compressed files\r\nand re-extracts all the files " +
    "for rando.";
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Location = new System.Drawing.Point(34, 81);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(157, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "Full Uninstall and Reextract";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Replaces with the truly original compressed files.";
            // 
            // buttonFullUninstall
            // 
            this.buttonFullUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFullUninstall.Location = new System.Drawing.Point(34, 52);
            this.buttonFullUninstall.Name = "buttonFullUninstall";
            this.buttonFullUninstall.Size = new System.Drawing.Size(157, 23);
            this.buttonFullUninstall.TabIndex = 8;
            this.buttonFullUninstall.Text = "Full Uninstall";
            this.buttonFullUninstall.Click += new System.EventHandler(this.button11_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Inserts original files.";
            // 
            // buttonUninstall
            // 
            this.buttonUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUninstall.Location = new System.Drawing.Point(34, 23);
            this.buttonUninstall.Name = "buttonUninstall";
            this.buttonUninstall.Size = new System.Drawing.Size(157, 23);
            this.buttonUninstall.TabIndex = 6;
            this.buttonUninstall.Text = "Uninstall";
            this.buttonUninstall.UseVisualStyleBackColor = true;
            this.buttonUninstall.Click += new System.EventHandler(this.button10_Click);
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageDebug.Controls.Add(this.label7);
            this.tabPageDebug.Controls.Add(this.button10);
            this.tabPageDebug.Controls.Add(this.button6);
            this.tabPageDebug.Controls.Add(this.button1);
            this.tabPageDebug.Controls.Add(this.button5);
            this.tabPageDebug.Controls.Add(this.button2);
            this.tabPageDebug.Controls.Add(this.button3);
            this.tabPageDebug.Controls.Add(this.textBox1);
            this.tabPageDebug.Controls.Add(this.button4);
            this.tabPageDebug.Location = new System.Drawing.Point(104, 4);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Size = new System.Drawing.Size(493, 517);
            this.tabPageDebug.TabIndex = 2;
            this.tabPageDebug.Text = "DEBUG";
            this.tabPageDebug.UseVisualStyleBackColor = true;
            // 
            // flagInfo1
            // 
            this.flagInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flagInfo1.Location = new System.Drawing.Point(619, 12);
            this.flagInfo1.Name = "flagInfo1";
            this.flagInfo1.Size = new System.Drawing.Size(317, 525);
            this.flagInfo1.TabIndex = 8;
            this.flagInfo1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(272, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Import flags and seed from a rando generated .ff13fs file.";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(316, 245);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(134, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "Import Flags and Seed";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 549);
            this.Controls.Add(this.flagInfo1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "FF13 Randomizer";
            this.tabControl1.ResumeLayout(false);
            this.tabPageBasics.ResumeLayout(false);
            this.tabPageBasics.PerformLayout();
            this.tabPageFinish.ResumeLayout(false);
            this.tabPageFinish.PerformLayout();
            this.tabPageUninstall.ResumeLayout(false);
            this.tabPageUninstall.PerformLayout();
            this.tabPageDebug.ResumeLayout(false);
            this.tabPageDebug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBasics;
        private System.Windows.Forms.TabPage tabPageFlags;
        private System.Windows.Forms.TabPage tabPageFinish;
        private System.Windows.Forms.TabPage tabPageDebug;
        private FlagInfo flagInfo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSeed;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button buttonRandomize;
        private System.Windows.Forms.TabPage tabPageUninstall;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonFullUninstall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUninstall;
        private System.Windows.Forms.Label labelFlagsSelected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button10;
    }
}

