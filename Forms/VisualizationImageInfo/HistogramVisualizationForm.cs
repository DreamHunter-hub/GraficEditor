using LiveChartsCore.SkiaSharpView.WinForms;
using GraficEditor.imageSamples;
using GraficEditor.Interfaces;
using GraficEditor.Factories;

namespace GraficEditor.Forms.VisualizationImageInfo {
    /// <summary>
    /// Форма для визуализации гистограммы.
    /// </summary>
    public partial class HistogramVisualizationForm : Form {
        // Поле для графика
        private CartesianChart _chart;

        /// <summary>
        /// Конструктор формы визуализации гистограммы.
        /// Инициализирует компоненты формы, график и кнопку "Закрыть".
        /// </summary>
        /// <param name="data">Образец данных изображения</param>
        public HistogramVisualizationForm(ImageSample data) {
            InitializeComponent();

            // Создание компонента графика
            _chart = new CartesianChart {
                Dock = DockStyle.Fill // Устанавливает график для заполнения формы
            };

            // Создание кнопки "Закрыть"
            var closeButton = new Button() {
                Text = "Закрыть",    // Текст на кнопке
                Dock = DockStyle.Bottom, // Расположение кнопки внизу формы
                Height = 40         // Высота кнопки
            };

            // Подписка на событие нажатия кнопки для закрытия формы
            closeButton.Click += (sender, e) => this.Close();

            // Добавление компонентов на форму
            this.Controls.Add(_chart);
            this.Controls.Add(closeButton);

            // Создание объекта визуализации и отображение гистограммы
            IVisualization visualizator = VisualizationFactory.CreateVisualization(data, VisualizationType.CartesianChart);
            visualizator.Visualize(_chart, data.GetHistogram());
        }
    }
}
