
namespace GraficEditor.Forms {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            загрузитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            преобразоватьToolStripMenuItem = new ToolStripMenuItem();
            цветноеToolStripMenuItem = new ToolStripMenuItem();
            полутоновоеToolStripMenuItem = new ToolStripMenuItem();
            бинарноеToolStripMenuItem = new ToolStripMenuItem();
            матрицыToolStripMenuItem = new ToolStripMenuItem();
            яркостиToolStripMenuItem = new ToolStripMenuItem();
            расстоянийToolStripMenuItem = new ToolStripMenuItem();
            гистограммыToolStripMenuItem = new ToolStripMenuItem();
            построитьToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem, преобразоватьToolStripMenuItem, матрицыToolStripMenuItem, гистограммыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(734, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { загрузитьToolStripMenuItem, сохранитьToolStripMenuItem });
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(65, 24);
            менюToolStripMenuItem.Text = "Меню";
            // 
            // загрузитьToolStripMenuItem
            // 
            загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            загрузитьToolStripMenuItem.Size = new Size(166, 26);
            загрузитьToolStripMenuItem.Text = "Загрузить";
            загрузитьToolStripMenuItem.Click += загрузитьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(166, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // преобразоватьToolStripMenuItem
            // 
            преобразоватьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { цветноеToolStripMenuItem, полутоновоеToolStripMenuItem, бинарноеToolStripMenuItem });
            преобразоватьToolStripMenuItem.Name = "преобразоватьToolStripMenuItem";
            преобразоватьToolStripMenuItem.Size = new Size(132, 24);
            преобразоватьToolStripMenuItem.Text = "Преобразовать";
            // 
            // цветноеToolStripMenuItem
            // 
            цветноеToolStripMenuItem.Name = "цветноеToolStripMenuItem";
            цветноеToolStripMenuItem.Size = new Size(224, 26);
            цветноеToolStripMenuItem.Text = "Цветное";
            // 
            // полутоновоеToolStripMenuItem
            // 
            полутоновоеToolStripMenuItem.Name = "полутоновоеToolStripMenuItem";
            полутоновоеToolStripMenuItem.Size = new Size(224, 26);
            полутоновоеToolStripMenuItem.Text = "Полутоновое";
            // 
            // бинарноеToolStripMenuItem
            // 
            бинарноеToolStripMenuItem.Name = "бинарноеToolStripMenuItem";
            бинарноеToolStripMenuItem.Size = new Size(224, 26);
            бинарноеToolStripMenuItem.Text = "Бинарное";
            // 
            // матрицыToolStripMenuItem
            // 
            матрицыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { яркостиToolStripMenuItem, расстоянийToolStripMenuItem });
            матрицыToolStripMenuItem.Name = "матрицыToolStripMenuItem";
            матрицыToolStripMenuItem.Size = new Size(88, 24);
            матрицыToolStripMenuItem.Text = "Матрицы";
            // 
            // яркостиToolStripMenuItem
            // 
            яркостиToolStripMenuItem.Name = "яркостиToolStripMenuItem";
            яркостиToolStripMenuItem.Size = new Size(172, 26);
            яркостиToolStripMenuItem.Text = "Яркости";
            яркостиToolStripMenuItem.Click += яркостиToolStripMenuItem_Click;
            // 
            // расстоянийToolStripMenuItem
            // 
            расстоянийToolStripMenuItem.Name = "расстоянийToolStripMenuItem";
            расстоянийToolStripMenuItem.Size = new Size(172, 26);
            расстоянийToolStripMenuItem.Text = "Расстояний";
            расстоянийToolStripMenuItem.Click += расстоянийToolStripMenuItem_Click;
            // 
            // гистограммыToolStripMenuItem
            // 
            гистограммыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { построитьToolStripMenuItem });
            гистограммыToolStripMenuItem.Name = "гистограммыToolStripMenuItem";
            гистограммыToolStripMenuItem.Size = new Size(117, 24);
            гистограммыToolStripMenuItem.Text = "Гистограммы";
            // 
            // построитьToolStripMenuItem
            // 
            построитьToolStripMenuItem.Name = "построитьToolStripMenuItem";
            построитьToolStripMenuItem.Size = new Size(166, 26);
            построитьToolStripMenuItem.Text = "Построить";
            построитьToolStripMenuItem.Click += построитьToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 39);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(710, 453);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 505);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Графический редактор Санчук-Пестрякова";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
            //
            // InitializeMenu
            //
            // Добавляем методы для Цветное
            //
            // Добовляем методы для Полутоновое
            полутоновоеToolStripMenuItem.DropDownItems.Add("Метод максимального", null, ConvertToGrayscaleMax_Click);
            полутоновоеToolStripMenuItem.DropDownItems.Add("Метод среднего", null, ConvertToGrayscaleAverage_Click);
            // Добавляем методы для Бинарное
            бинарноеToolStripMenuItem.DropDownItems.Add("40%", null, ConvertToBinary40Percent_Click);
            бинарноеToolStripMenuItem.DropDownItems.Add("Порог с экрана", null, ConvertToBinaryBorder_Click);
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem преобразоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem полутоновоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бинарноеToolStripMenuItem;
        private ToolStripMenuItem матрицыToolStripMenuItem;
        private ToolStripMenuItem яркостиToolStripMenuItem;
        private ToolStripMenuItem расстоянийToolStripMenuItem;
        private ToolStripMenuItem гистограммыToolStripMenuItem;
        private ToolStripMenuItem построитьToolStripMenuItem;
        private ToolStripMenuItem цветноеToolStripMenuItem;
    }
}

