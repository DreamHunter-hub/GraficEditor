using GraficEditor.Interfaces;
using GraficEditor.Utils;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace GraficEditor.Visualizations.Chart {
    /// <summary>
    /// Класс для визуализации RGB-гистограммы в CartesianChart.
    /// </summary>
    class RGBHistogramVisualization : IVisualization {
        /// <summary>
        /// Метод для выполнения визуализации RGB-гистограммы с отдельными графиками для каждого канала.
        /// </summary>
        /// <param name="control">Объект управления CartesianChart, где будут отображаться гистограммы.</param>
        /// <param name="data">Словарь, содержащий данные гистограммы для каналов R, G и B.</param>
        public void Visualize(object control, object data) {
            // Проверяем, что переданный объект управления является CartesianChart
            if (control is not CartesianChart chart) {
                throw new ArgumentException("Control должен быть типа CartesianChart.");
            }

            // Проверяем, что переданные данные являются Dictionary<string, Dictionary<int, int>>
            if (data is not Dictionary<string, Dictionary<int, int>> rgbHistogram) {
                throw new ArgumentException("Data должен быть типа Dictionary<string, Dictionary<int,int>>.");
            }

            // Инициализируем CartesianChart
            VisualizationUtils.InitializeCartesianChart(chart);

            // Создаем списки значений и меток для каждого канала
            var rValues = rgbHistogram["R"].Values.ToList();
            var gValues = rgbHistogram["G"].Values.ToList();
            var bValues = rgbHistogram["B"].Values.ToList();

            var rLabels = rgbHistogram["R"].Keys.Select(x => x.ToString()).ToList();
            var gLabels = rgbHistogram["G"].Keys.Select(x => x.ToString()).ToList();
            var bLabels = rgbHistogram["B"].Keys.Select(x => x.ToString()).ToList();

            // Устанавливаем серии для графика
            chart.Series = new ISeries[]
            {
        new ColumnSeries<int>
        {
            Values = rValues, // Значения для канала R
            Fill = new SolidColorPaint(SKColors.Red), // Красный цвет для столбцов
            Name = "Красный (R)"
        },
        new ColumnSeries<int>
        {
            Values = gValues, // Значения для канала G
            Fill = new SolidColorPaint(SKColors.Green), // Зеленый цвет для столбцов
            Name = "Зеленый (G)"
        },
        new ColumnSeries<int>
        {
            Values = bValues, // Значения для канала B
            Fill = new SolidColorPaint(SKColors.Blue), // Синий цвет для столбцов
            Name = "Синий (B)"
        }
            };

            // Настраиваем ось X для отображения меток
            chart.XAxes = new Axis[]
            {
        new Axis
        {
            Labels = rLabels, // Метки для оси
            Name = "Яркость (R,G,B)"
        },
            };
        }
    }
}
