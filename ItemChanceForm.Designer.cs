namespace FF13Randomizer
{
    partial class ItemChanceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.radioTreasure = new System.Windows.Forms.RadioButton();
            this.radioEnemy = new System.Windows.Forms.RadioButton();
            this.numericLevel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericCount = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioTreasure
            // 
            this.radioTreasure.AutoSize = true;
            this.radioTreasure.Location = new System.Drawing.Point(12, 46);
            this.radioTreasure.Name = "radioTreasure";
            this.radioTreasure.Size = new System.Drawing.Size(67, 17);
            this.radioTreasure.TabIndex = 0;
            this.radioTreasure.TabStop = true;
            this.radioTreasure.Text = "Treasure";
            this.radioTreasure.UseVisualStyleBackColor = true;
            // 
            // radioEnemy
            // 
            this.radioEnemy.AutoSize = true;
            this.radioEnemy.Location = new System.Drawing.Point(103, 46);
            this.radioEnemy.Name = "radioEnemy";
            this.radioEnemy.Size = new System.Drawing.Size(83, 17);
            this.radioEnemy.TabIndex = 1;
            this.radioEnemy.TabStop = true;
            this.radioEnemy.Text = "Enemy Drop";
            this.radioEnemy.UseVisualStyleBackColor = true;
            // 
            // numericLevel
            // 
            this.numericLevel.Location = new System.Drawing.Point(266, 46);
            this.numericLevel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLevel.Name = "numericLevel";
            this.numericLevel.Size = new System.Drawing.Size(67, 20);
            this.numericLevel.TabIndex = 2;
            this.numericLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enemy Level";
            // 
            // comboItem
            // 
            this.comboItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboItem.FormattingEnabled = true;
            this.comboItem.Location = new System.Drawing.Point(86, 12);
            this.comboItem.Name = "comboItem";
            this.comboItem.Size = new System.Drawing.Size(121, 21);
            this.comboItem.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Original Item";
            // 
            // numericCount
            // 
            this.numericCount.Location = new System.Drawing.Point(254, 13);
            this.numericCount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCount.Name = "numericCount";
            this.numericCount.Size = new System.Drawing.Size(79, 20);
            this.numericCount.TabIndex = 6;
            this.numericCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Count,
            this.Chance});
            this.dataGridView1.Location = new System.Drawing.Point(12, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(548, 215);
            this.dataGridView1.TabIndex = 7;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // Chance
            // 
            dataGridViewCellStyle1.Format = "P";
            dataGridViewCellStyle1.NullValue = null;
            this.Chance.DefaultCellStyle = dataGridViewCellStyle1;
            this.Chance.HeaderText = "Chance";
            this.Chance.Name = "Chance";
            this.Chance.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(485, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Count";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "NOTES: Based on current Flag settings\r\n              Based on 10000 tests. Not 10" +
    "0% accurate results";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Enemy Type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Normal",
            "Rare",
            "Boss"});
            this.comboBox1.Location = new System.Drawing.Point(411, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Normal";
            // 
            // ItemChanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 332);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.numericCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericLevel);
            this.Controls.Add(this.radioEnemy);
            this.Controls.Add(this.radioTreasure);
            this.Name = "ItemChanceForm";
            this.Text = "Item Chance Tool";
            ((System.ComponentModel.ISupportInitialize)(this.numericLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioTreasure;
        private System.Windows.Forms.RadioButton radioEnemy;
        private System.Windows.Forms.NumericUpDown numericLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}