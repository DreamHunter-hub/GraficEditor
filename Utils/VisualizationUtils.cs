using LiveChartsCore.SkiaSharpView.WinForms;

namespace GraficEditor.Utils {
    /// <summary>
    /// Статический класс утилит для визуализации данных.
    /// </summary>
    public static class VisualizationUtils {
        /// <summary>
        /// Инициализирует DataGridView с заданным количеством строк и столбцов.
        /// </summary>
        /// <param name="gridView">Объект DataGridView для инициализации.</param>
        /// <param name="rowCount">Количество строк.</param>
        /// <param name="columnCount">Количество столбцов.</param>
        public static void InitializeDataGridView(DataGridView gridView, int rowCount, int columnCount) {
            // Очищаем текущие данные
            gridView.Rows.Clear();
            gridView.Columns.Clear();

            // Создаём столбцы
            gridView.ColumnCount = columnCount;
            for (int i = 0; i < columnCount; i++) {
                gridView.Columns[i].HeaderText = $"{i + 1}";
            }

            // Создаём строки
            gridView.RowCount = rowCount;
            for (int i = 0; i < rowCount; i++) {
                gridView.Rows[i].HeaderCell.Value = $"{i + 1}";
            }

            // Настраиваем автоизменение размера
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Инициализирует DataGridView с поддержкой ComboBox в ячейках.
        /// </summary>
        /// <param name="gridView">Объект DataGridView для инициализации.</param>
        /// <param name="rowCount">Количество строк.</param>
        /// <param name="columnCount">Количество столбцов.</param>
        /// <param name="comboBoxItems">Массив значений для выпадающих списков.</param>
        public static void InitializeDataGridView(DataGridView gridView, int rowCount, int columnCount, string[] comboBoxItems) {
            // Очищаем текущие данные
            gridView.Rows.Clear();
            gridView.Columns.Clear();

            // Добавляем ComboBox столбцы
            for (int i = 0; i < columnCount; i++) {
                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn {
                    HeaderText = $"{i + 1}",
                    Name = $"ComboBoxColumn_{i + 1}",
                    DataSource = new List<string>(comboBoxItems),
                    ValueType = typeof(string)
                };
                gridView.Columns.Add(comboBoxColumn);
            }

            // Создаём строки
            gridView.RowCount = rowCount;
            for (int i = 0; i < rowCount; i++) {
                gridView.Rows[i].HeaderCell.Value = $"{i + 1}";
            }

            // Настраиваем автоизменение размера
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            SetDefaultComboBoxValues(gridView);
        }

        /// <summary>
        /// Инициализирует CartesianChart, очищая его серии и оси.
        /// </summary>
        /// <param name="chart">Объект CartesianChart для инициализации.</param>
        public static void InitializeCartesianChart(CartesianChart chart) {
            chart.Series = null;
            chart.XAxes = null;
        }

        /// <summary>
        /// Устанавливает значения по умолчанию для ComboBox ячеек.
        /// </summary>
        /// <param name="field">Объект DataGridView.</param>
        private static void SetDefaultComboBoxValues(DataGridView field) {
            foreach (DataGridViewRow row in field.Rows) {
                foreach (DataGridViewCell cell in row.Cells) {
                    if (cell is DataGridViewComboBoxCell comboBoxCell) {
                        comboBoxCell.Value = comboBoxCell.Items[0]; // Устанавливаем первое значение
                    }
                }
            }
        }
    }
}
