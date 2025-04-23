using GraficEditor.Interfaces;
using GraficEditor.Utils;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;

namespace GraficEditor.Strategies.Visualization.Histogram {
    /// <summary>
    /// Класс для визуализации гистограммы градаций серого в CartesianChart.
    /// </summary>
    class GrayscaleHistogramVisualization : IVisualization {
        /// <summary>
        /// Метод для выполнения визуализации гистограммы градаций серого.
        /// </summary>
        /// <param name="control">Объект управления CartesianChart, где будет отображаться гистограмма.</param>
        /// <param name="data">Словарь, содержащий данные гистограммы (значение — количество).</param>
        public void Visualize(object control, object data) {
            // Проверяем, что переданный объект управления является CartesianChart
            if (control is not CartesianChart chart) {
                throw new ArgumentException("Control должен быть типа CartesianChart.");
            }

            // Проверяем, что переданные данные являются Dictionary<double, int>
            if (data is not Dictionary<double, int> histogram) {
                throw new ArgumentException("Data должен быть типа Dictionary<double,int>.");
            }

            // Инициализируем CartesianChart
            VisualizationUtils.InitializeCartesianChart(chart);

            // Преобразуем данные гистограммы в списки значений и меток
            var values = histogram.Values.ToList(); // Количество элементов
            var labels = histogram.Keys.Select(x => x.ToString()).ToList(); // Метки значений

            // Устанавливаем серии для графика
            chart.Series = new ISeries[] {
                new ColumnSeries<int> {
                    Values = values // Устанавливаем значения для столбцов
                }
            };

            // Настраиваем ось X для отображения меток
            chart.XAxes = new Axis[] {
                new Axis {
                    Labels = labels // Устанавливаем текстовые метки оси X
                }
            };
        }
    }
}
