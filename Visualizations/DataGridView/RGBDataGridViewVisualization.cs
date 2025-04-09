using GraficEditor.Interfaces;
using GraficEditor.Utils;

namespace GraficEditor.Visualizations.DataGridView {
    /// <summary>
    /// Класс для визуализации RGB-изображения в DataGridView.
    /// </summary>
    public class RGBDataGridViewVisualization : IVisualization {
        /// <summary>
        /// Метод для выполнения визуализации RGB-изображения.
        /// </summary>
        /// <param name="control">Элемент управления, где будет отображаться визуализация (DataGridView).</param>
        /// <param name="data">Двумерный массив цветов (Color[,]), представляющий данные изображения.</param>
        public void Visualize(object control, object data) {
            // Проверяем, что переданный элемент управления — DataGridView
            if (control is not System.Windows.Forms.DataGridView gridView) {
                throw new ArgumentException("Control должен быть типа DataGridView");
            }

            // Проверяем, что переданные данные — массив Color[,]
            if (data is not Color[,] color) {
                throw new ArgumentException("Data должен быть типа Color[,]");
            }

            // Получаем размеры данных
            int width = color.GetLength(0);
            int height = color.GetLength(1);

            // Настраиваем DataGridView
            VisualizationUtils.InitializeDataGridView(gridView, height, width);

            // Заполняем ячейки DataGridView данными и стилями
            Parallel.For(0, width, x => {
                for (int y = 0; y < height; y++) {
                    if (x < gridView.Columns.Count && y < gridView.Rows.Count) {
                        // Настраиваем стиль ячейки
                        var cellStyle = gridView.Rows[y].Cells[x].Style;
                        cellStyle.BackColor = color[x, y]; // Устанавливаем фон ячейки в соответствии с цветом
                    }
                }
            });
        }
    }
}
