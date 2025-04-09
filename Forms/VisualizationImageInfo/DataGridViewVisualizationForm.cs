using GraficEditor.Factories;
using GraficEditor.imageSamples;
using GraficEditor.Interfaces;

namespace GraficEditor.Forms.VisualizationImageInfo {
    /// <summary>
    /// Форма для визуализации данных в DataGridView.
    /// </summary>
    public partial class DataGridViewVisualizationForm : Form {
        /// <summary>
        /// Конструктор формы визуализации DataGridView.
        /// Создает объект визуализации и отображает данные на основе типа визуализации.
        /// </summary>
        /// <param name="data">Образец данных изображения.</param>
        /// <param name="visualizationType">Тип визуализации (например, матрица дистанций).</param>
        public DataGridViewVisualizationForm(ImageSample data, VisualizationType visualizationType) {
            InitializeComponent();

            // Если изображение не является RGBImage, скрываем элементы интерфейса, связанные с RGB
            if (data is not RGBImage) {
                groupBox1.Visible = false;
                groupBox2.Visible = false;

                dataGridView1.Dock = DockStyle.Fill;
                button1.Dock = DockStyle.Bottom;

                dataGridView1.CellMouseEnter -= dataGridView1_CellMouseEnter;
            }

            // Если выбран тип визуализации "матрица дистанций"
            if (visualizationType == VisualizationType.DistanceMatrix) {
                if (data is BinaryImage binaryImage) {
                    IVisualization visualizer = VisualizationFactory.CreateVisualization(binaryImage, visualizationType);
                    visualizer.Visualize(dataGridView1, binaryImage.Distance);
                }
                else {
                    throw new ArgumentException("Матрицу дистанций можно визуализировать только для BinaryImage.");
                }
            }
            else {
                // Создаем объект визуализации и визуализируем пиксели изображения
                IVisualization visualizer = VisualizationFactory.CreateVisualization(data, VisualizationType.DataGridView);
                visualizer.Visualize(dataGridView1, data.Pixels);
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для закрытия формы.
        /// </summary>
        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// Обработчик события наведения указателя мыши на ячейки таблицы.
        /// Обновляет панели и метки цветовых каналов на основе цвета выбранной ячейки.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Данные события о выбранной ячейке.</param>
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var cellStyle = cell.Style;
                Color backgroundColor = cellStyle.BackColor;

                // Обновление панели с отображением цвета ячейки
                panel1.BackColor = backgroundColor;

                // Обновление красного канала
                panel2.BackColor = Color.FromArgb(backgroundColor.R, 0, 0);
                label1.Text = $"Красный: {backgroundColor.R}";

                // Обновление зеленого канала
                panel3.BackColor = Color.FromArgb(0, backgroundColor.G, 0);
                label2.Text = $"Зелёный: {backgroundColor.G}";

                // Обновление синего канала
                panel4.BackColor = Color.FromArgb(0, 0, backgroundColor.B);
                label3.Text = $"Синий: {backgroundColor.B}";
            }
        }
    }
}

