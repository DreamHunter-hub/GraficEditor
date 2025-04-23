namespace GraficEditor.Forms.Input {
    partial class MaskForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            textBox2 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(9, 8);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(458, 207);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(473, 173);
            button1.Name = "button1";
            button1.Size = new Size(184, 42);
            button1.TabIndex = 1;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(473, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(184, 70);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Количество строк";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(164, 27);
            textBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(473, 97);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(184, 70);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Количество столбцов";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(14, 26);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(164, 27);
            textBox2.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(9, 225);
            button2.Name = "button2";
            button2.Size = new Size(304, 37);
            button2.TabIndex = 4;
            button2.Text = "Подтвердить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(353, 225);
            button3.Name = "button3";
            button3.Size = new Size(304, 37);
            button3.TabIndex = 5;
            button3.Text = "Отменить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // MaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 274);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "MaskForm";
            Text = "MaskForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private TextBox textBox2;
        private Button button2;
        private Button button3;
    }
}