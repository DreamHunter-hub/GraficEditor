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
            // Очищаем существующие строки и столбцы
            gridView.Rows.Clear();
            gridView.Columns.Clear();

            // Устанавливаем количество столбцов
            gridView.ColumnCount = columnCount;
            for (int i = 0; i < columnCount; i++) {
                gridView.Columns[i].HeaderText = $"{i + 1}"; // Задаем заголовки столбцов
            }

            // Устанавливаем количество строк
            gridView.RowCount = rowCount;
            for (int i = 0; i < rowCount; i++) {
                gridView.Rows[i].HeaderCell.Value = $"{i + 1}"; // Задаем заголовки строк
            }

            // Автоматическая настройка ширины столбцов
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Инициализирует CartesianChart, очищая его серии и оси.
        /// </summary>
        /// <param name="chart">Объект CartesianChart для инициализации.</param>
        public static void InitializeCartesianChart(CartesianChart chart) {
            // Очищаем серии и оси графика
            chart.Series = null;
            chart.XAxes = null;
        }
    }
}
