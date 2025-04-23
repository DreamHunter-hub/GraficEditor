namespace GraficEditor.Forms {
    partial class DataInputForm {
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
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(297, 27);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 98);
            button1.Name = "button1";
            button1.Size = new Size(148, 42);
            button1.TabIndex = 1;
            button1.Text = "Подтвердить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(166, 98);
            button2.Name = "button2";
            button2.Size = new Size(143, 42);
            button2.TabIndex = 2;
            button2.Text = "Отменить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(235, 28);
            label1.TabIndex = 3;
            label1.Text = "Поле для текста запроса";
            // 
            // DataInputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 152);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "DataInputForm";
            Text = "DataInputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label1;
    }
}