using GraficEditor.Interfaces;
using GraficEditor.Utils;

namespace GraficEditor.Strategies.Visualization.DataGridView {
    /// <summary>
    /// Класс визуализации для градаций серого в DataGridView.
    /// </summary>
    public class GrayScaleDataGridViewVisualization : IVisualization {
        /// <summary>
        /// Метод для выполнения визуализации изображения в градациях серого.
        /// </summary>
        /// <param name="control">Элемент управления DataGridView, в котором отображаются данные.</param>
        /// <param name="data">Двумерный массив цветов (Color[,]), представляющий данные изображения.</param>
        public void Visualize(object control, object data) {
            // Проверяем, что переданный элемент управления — DataGridView
            if (control is not System.Windows.Forms.DataGridView gridView) {
                throw new ArgumentException("Control должен быть типа DataGridView.");
            }

            // Проверяем, что переданные данные — массив Color[,]
            if (data is not Color[,] color) {
                throw new ArgumentException("Data должен быть типа Color[,].");
            }

            // Получаем размер данных
            int width = color.GetLength(0);
            int height = color.GetLength(1);

            // Настраиваем DataGridView
            VisualizationUtils.InitializeDataGridView(gridView, height, width);

            // Заполняем ячейки DataGridView данными
            Parallel.For(0, width, x => {
                for (int y = 0; y < height; y++) {
                    if (x < gridView.Columns.Count && y < gridView.Rows.Count) {
                        int intensity = color[x, y].R; // Предполагаем, что оттенок серого хранится в канале R

                        // Устанавливаем значение ячейки — интенсивность (от 0 до 255)
                        gridView.Rows[y].Cells[x].Value = intensity;

                        // Создаем цвет в градациях серого в зависимости от интенсивности
                        Color grayColor = Color.FromArgb(intensity, intensity, intensity);

                        // Применяем стиль ячейки
                        var cellStyle = gridView.Rows[y].Cells[x].Style;
                        cellStyle.BackColor = grayColor;

                        // Устанавливаем цвет текста: черный для светлых фонов, белый для темных
                        cellStyle.ForeColor = intensity > 128 ? Color.Black : Color.White;
                    }
                }
            });
        }
    }
}
