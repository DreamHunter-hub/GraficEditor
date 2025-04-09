using GraficEditor.imageSamples;
using GraficEditor.Interfaces;
using GraficEditor.Visualizations;

namespace GraficEditor.Factories {
    /// <summary>
    /// Типы визуализации, поддерживаемые фабрикой
    /// </summary>
    public enum VisualizationType {
        DataGridView,    // Визуализация в виде таблицы
        CartesianChart,   // Визуализация в виде диаграммы
        DistanceMatrix    // Визуализация матрицы дистанций
    }

    /// <summary>
    /// Фабрика для создания объектов визуализации
    /// </summary>
    public static class VisualizationFactory {
        /// <summary>
        /// Создает объект визуализации на основе типа изображения и типа визуализации
        /// </summary>
        /// <param name="imageType">Тип изображения</param>
        /// <param name="visualizationType">Тип визуализации</param>
        /// <returns>Объект визуализации</returns>
        public static IVisualization CreateVisualization(ImageSample imageType, VisualizationType visualizationType) {
            // Используем оператор switch для определения типа визуализации
            return visualizationType switch {
                VisualizationType.DataGridView => Activator.CreateInstance(imageType.GetDataGridViewVisualization()) as IVisualization,
                VisualizationType.CartesianChart => Activator.CreateInstance(imageType.GetHistogramVisualization()) as IVisualization,
                VisualizationType.DistanceMatrix when imageType is BinaryImage binaryImage => new DistanceMatrixVisualization(),

                // Исключение для неподдерживаемых типов визуализации
                _ => throw new ArgumentException("Тип визуализации не поддерживается"),
            };
        }
    }
}
