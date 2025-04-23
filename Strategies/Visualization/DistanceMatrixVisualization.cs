using GraficEditor.Interfaces;
using GraficEditor.Utils;

namespace GraficEditor.Strategies.Visualization {
    /// <summary>
    /// Класс визуализации для отображения матрицы расстояний в DataGridView.
    /// </summary>
    internal class DistanceMatrixVisualization : IVisualization {
        /// <summary>
        /// Метод для выполнения визуализации матрицы расстояний.
        /// </summary>
        /// <param name="control">Элемент управления DataGridView, где будет отображаться матрица.</param>
        /// <param name="data">Двумерная матрица расстояний (int[,]).</param>
        public void Visualize(object control, object data) {
            // Проверяем, что переданный объект управления является DataGridView
            if (control is not System.Windows.Forms.DataGridView gridView) {
                throw new ArgumentException("Control должен быть типа DataGridView.");
            }

            // Проверяем, что переданные данные являются матрицей int[,]
            if (data is not int[,] distance) {
                throw new ArgumentException("Data должен быть типа int[,].");
            }

            // Получаем размеры матрицы расстояний
            int width = distance.GetLength(0);
            int height = distance.GetLength(1);

            // Настраиваем DataGridView
            VisualizationUtils.InitializeDataGridView(gridView, height, width);

            // Заполняем ячейки DataGridView данными из матрицы расстояний
            Parallel.For(0, width, x => {
                for (int y = 0; y < height; y++) {
                    gridView.Rows[y].Cells[x].Value = distance[x, y]; // Заполнение значением из матрицы
                }
            });
        }
    }
}
