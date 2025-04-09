namespace GraficEditor.Forms.VisualizationImageInfo {
    partial class DataGridViewVisualizationForm {
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
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            panel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 543);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;
            // 
            // button1
            // 
            button1.Location = new Point(12, 561);
            button1.Name = "button1";
            button1.Size = new Size(776, 52);
            button1.TabIndex = 1;
            button1.Text = "Закрыть";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new Point(795, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(178, 123);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выделеный пиксель";
            // 
            // panel1
            // 
            panel1.Location = new Point(6, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(166, 91);
            panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(panel4);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(panel3);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(panel2);
            groupBox2.Location = new Point(795, 141);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(178, 472);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Значения каналов";
            // 
            // panel2
            // 
            panel2.Location = new Point(6, 53);
            panel2.Name = "panel2";
            panel2.Size = new Size(166, 115);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 1;
            label1.Text = "Красный : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 171);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 3;
            label2.Text = "Зелёный : ";
            // 
            // panel3
            // 
            panel3.Location = new Point(6, 201);
            panel3.Name = "panel3";
            panel3.Size = new Size(166, 115);
            panel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 319);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 5;
            label3.Text = "Синий : ";
            // 
            // panel4
            // 
            panel4.Location = new Point(6, 349);
            panel4.Name = "panel4";
            panel4.Size = new Size(166, 115);
            panel4.TabIndex = 4;
            // 
            // DataGridViewVisualizationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 618);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "DataGridViewVisualizationForm";
            Text = "DataGridViewVisualizationForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private GroupBox groupBox1;
        private Panel panel1;
        private GroupBox groupBox2;
        private Label label3;
        private Panel panel4;
        private Label label2;
        private Panel panel3;
        private Label label1;
        private Panel panel2;
    }
}