
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
            фильтрацияToolStripMenuItem = new ToolStripMenuItem();
            среднееЗначениеToolStripMenuItem = new ToolStripMenuItem();
            пороговаяФильтрацияToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            морфологическаяОбработкаToolStripMenuItem = new ToolStripMenuItem();
            эToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem, преобразоватьToolStripMenuItem, матрицыToolStripMenuItem, гистограммыToolStripMenuItem, фильтрацияToolStripMenuItem, морфологическаяОбработкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(839, 28);
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
            цветноеToolStripMenuItem.Size = new Size(185, 26);
            цветноеToolStripMenuItem.Text = "Цветное";
            // 
            // полутоновоеToolStripMenuItem
            // 
            полутоновоеToolStripMenuItem.Name = "полутоновоеToolStripMenuItem";
            полутоновоеToolStripMenuItem.Size = new Size(185, 26);
            полутоновоеToolStripMenuItem.Text = "Полутоновое";
            // 
            // бинарноеToolStripMenuItem
            // 
            бинарноеToolStripMenuItem.Name = "бинарноеToolStripMenuItem";
            бинарноеToolStripMenuItem.Size = new Size(185, 26);
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
            // фильтрацияToolStripMenuItem
            // 
            фильтрацияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { среднееЗначениеToolStripMenuItem, пороговаяФильтрацияToolStripMenuItem });
            фильтрацияToolStripMenuItem.Name = "фильтрацияToolStripMenuItem";
            фильтрацияToolStripMenuItem.Size = new Size(108, 24);
            фильтрацияToolStripMenuItem.Text = "Фильтрация";
            // 
            // среднееЗначениеToolStripMenuItem
            // 
            среднееЗначениеToolStripMenuItem.Name = "среднееЗначениеToolStripMenuItem";
            среднееЗначениеToolStripMenuItem.Size = new Size(257, 26);
            среднееЗначениеToolStripMenuItem.Text = "Среднее значение";
            среднееЗначениеToolStripMenuItem.Click += среднееЗначениеToolStripMenuItem_Click;
            // 
            // пороговаяФильтрацияToolStripMenuItem
            // 
            пороговаяФильтрацияToolStripMenuItem.Name = "пороговаяФильтрацияToolStripMenuItem";
            пороговаяФильтрацияToolStripMenuItem.Size = new Size(257, 26);
            пороговаяФильтрацияToolStripMenuItem.Text = "Пороговая фильтрация";
            пороговаяФильтрацияToolStripMenuItem.Click += пороговаяФильтрацияToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 39);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(815, 453);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // морфологическаяОбработкаToolStripMenuItem
            // 
            морфологическаяОбработкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { эToolStripMenuItem });
            морфологическаяОбработкаToolStripMenuItem.Name = "морфологическаяОбработкаToolStripMenuItem";
            морфологическаяОбработкаToolStripMenuItem.Size = new Size(229, 24);
            морфологическаяОбработкаToolStripMenuItem.Text = "Морфологическая обработка";
            // 
            // эToolStripMenuItem
            // 
            эToolStripMenuItem.Name = "эToolStripMenuItem";
            эToolStripMenuItem.Size = new Size(224, 26);
            эToolStripMenuItem.Text = "Эрозия";
            эToolStripMenuItem.Click += эToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 505);
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
        private ToolStripMenuItem фильтрацияToolStripMenuItem;
        private ToolStripMenuItem среднееЗначениеToolStripMenuItem;
        private ToolStripMenuItem пороговаяФильтрацияToolStripMenuItem;
        private ToolStripMenuItem морфологическаяОбработкаToolStripMenuItem;
        private ToolStripMenuItem эToolStripMenuItem;
    }
}

