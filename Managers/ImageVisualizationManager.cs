using GraficEditor.Forms.VisualizationMatrix;
using GraficEditor.imageSamples;

namespace GraficEditor.Managers {
    /// <summary>
    /// Менеджер для управления визуализацией изображений.
    /// </summary>
    public class ImageVisualizationManager {
        /// <summary>
        /// Отображает матрицу пикселей изображения в форме DataGridView.
        /// </summary>
        /// <param name="image">Объект изображения, которое нужно визуализировать.</param>
        public static void ShowMatrix(ImageSample image) {
            // Создаем форму для визуализации матрицы изображения
            var visualizationForm = new DataGridViewVisualizationForm(
                image,
                Factories.VisualizationType.DataGridView
            );

            // Отображаем форму на экране
            visualizationForm.Show();
        }

        /// <summary>
        /// Отображает гистограмму пикселей изображения в форме CartesianChart.
        /// </summary>
        /// <param name="image">Объект изображения, для которого нужно построить гистограмму.</param>
        public static void ShowHistogram(ImageSample image) {
            // Создаем форму для отображения гистограммы изображения
            var visualizationForm = new HistogramVisualizationForm(image);

            // Отображаем форму на экране
            visualizationForm.Show();
        }

        /// <summary>
        /// Отображает матрицу расстояний для бинарного изображения в форме DataGridView.
        /// </summary>
        /// <param name="image">Бинарное изображение, для которого нужно построить матрицу расстояний.</param>
        public static void ShowDistanceMatrix(ImageSample image) {
            // Создаем форму для визуализации матрицы расстояний
            var visualizationForm = new DataGridViewVisualizationForm(
                image,
                Factories.VisualizationType.DistanceMatrix
            );

            // Отображаем форму на экране
            visualizationForm.Show();
        }
    }
}
