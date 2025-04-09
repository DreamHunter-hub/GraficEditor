using GraficEditor.Interfaces;
using GraficEditor.Utils;

namespace GraficEditor.Visualizations.DataGridView
{
    /// <summary>
    /// Класс является сущностью для визуализации BinaryImage
    /// на поле DataGridView
    /// </summary>
    class BinaryDataGridViewVisualization : IVisualization {
        public void Visualize(object control, object data) {
            // Проверяем, что control является DataGridView
            if (control is not System.Windows.Forms.DataGridView gridView) {
                throw new ArgumentException("Control должен быть типа DataGridView");
            }
            // Проверяет, что data является двумерным массивом Color[,]
            if (data is not Color[,] color) {
                throw new ArgumentException("Data должен быть типа Color[,]");
            }

            // Получаем размер данных 
            int width = color.GetLength(0);
            int height = color.GetLength(1);

            // Настраиваем DataGridView
            VisualizationUtils.InitializeDataGridView(gridView, height, width);

            // Обновляем содержимое DataGridView
            Parallel.For(0, width, x => {
                for (int y = 0; y < height; y++) {
                    // Устанавливаем значение ячейки
                    gridView[x, y].Value = color[x, y].R == 255 ? 0 : 1;

                    // Устанавливаем стиль ячеек
                    var cellstyle = gridView.Rows[y].Cells[x].Style;
                    if (color[x,y].R == 255) {
                        // Для Белых пикселей
                        cellstyle.BackColor = Color.White;
                        cellstyle.ForeColor = Color.Black;
                    }
                    else {
                        // Для чёрных пикселей
                        cellstyle.BackColor = Color.Black;
                        cellstyle.ForeColor = Color.White;
                    }
                }
            });

        }
    }
}
