using GraficEditor.Utils;
using System.ComponentModel;

namespace GraficEditor.Forms.Input {
    /// <summary>
    /// Форма для ввода масок данных.
    /// </summary>
    public partial class MaskForm : Form {
        /// <summary>
        /// Количество строк по умолчанию.
        /// </summary>
        private int DefaultRows = 3;

        /// <summary>
        /// Количество столбцов по умолчанию.
        /// </summary>
        private int DefaultColumns = 3;

        /// <summary>
        /// Элементы для выпадающих списков (комбо-боксов) по умолчанию.
        /// </summary>
        private string[] DefalultComboBoxItems = { "0", "1" };

        /// <summary>
        /// Свойство для хранения введенных данных пользователем.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int[,]? InputData { get; private set; } = null;

        /// <summary>
        /// Конструктор формы для ввода данных.
        /// </summary>
        public MaskForm() {
            InitializeComponent();
            // Инициализация DataGridView с параметрами по умолчанию
            VisualizationUtils.InitializeDataGridView(dataGridView1, DefaultRows, DefaultColumns, DefalultComboBoxItems);
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для изменения размеров матрицы.
        /// </summary>
        private void button1_Click(object sender, EventArgs e) {
            try {
                int rows = int.Parse(textBox1.Text); // Получение количества строк от пользователя
                int cols = int.Parse(textBox2.Text); // Получение количества столбцов от пользователя

                // Проверка на нечетность введенных размеров
                if (rows % 2 != 0 && cols % 2 != 0) {
                    // Инициализация DataGridView с новыми размерами
                    VisualizationUtils.InitializeDataGridView(dataGridView1, rows, cols, DefalultComboBoxItems);
                }
                else {
                    MessageBox.Show("Количество строк и столбцов должно быть нечётным.");
                }
            }
            catch {
                MessageBox.Show("Некорректные данные.", "Ошибка");
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для сохранения введенных данных.
        /// </summary>
        private void button2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;

            // Создаем матрицу для хранения значений
            int rowCount = dataGridView1.RowCount;
            int columnCount = dataGridView1.ColumnCount;
            InputData = new int[rowCount, columnCount];

            // Проходим по строкам и столбцам DataGridView
            for (int x = 0; x < rowCount; x++) {
                for (int y = 0; y < columnCount; y++) {
                    // Получаем текущую ячейку
                    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView1.Rows[x].Cells[y];

                    // Сохраняем значение ячейки в матрицу
                    InputData[x, y] = int.Parse(cell.Value?.ToString() ?? string.Empty);
                }
            }

            this.Close(); // Закрытие формы
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для отмены операции.
        /// </summary>
        private void button3_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close(); // Закрытие формы
        }
    }
}
