using GraficEditor.Enums.Transformation;
using GraficEditor.Factories;
using GraficEditor.Strategies.Visualization.DataGridView;
using GraficEditor.Strategies.Visualization.Histogram;

namespace GraficEditor.imageSamples {
    /// <summary>
    /// Класс для работы с изображениями в градациях серого.
    /// Содержит методы для обработки и визуализации таких изображений.
    /// </summary>
    public class GrayscaleImage : ImageSample {
        /// <summary>
        /// Конструктор, инициализирующий объект изображения в градациях серого.
        /// </summary>
        /// <param name="image">Двумерный массив цветов, представляющий изображение.</param>
        public GrayscaleImage(Color[,] image) : base(image) { }

        /// <summary>
        /// Получает тип визуализации гистограммы для изображения в градациях серого.
        /// </summary>
        /// <returns>Тип визуализации гистограммы.</returns>
        public override Type GetHistogramVisualization() => typeof(GrayscaleHistogramVisualization);

        /// <summary>
        /// Получает тип визуализации для DataGridView.
        /// </summary>
        /// <returns>Тип визуализации для DataGridView.</returns>
        public override Type GetDataGridViewVisualization() => typeof(GrayScaleDataGridViewVisualization);

        /// <summary>
        /// Генерирует гистограмму значений яркости изображения.
        /// </summary>
        /// <returns>Словарь, где ключ — значение яркости, а значение — количество пикселей с таким значением.</returns>
        public override Dictionary<double, int> GetHistogram() {
            // Инициализация гистограммы
            Dictionary<double, int> histogram = new Dictionary<double, int>();

            // Получение размеров изображения
            int width = _pixels.GetLength(0);
            int height = _pixels.GetLength(1);

            // Построение гистограммы
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    // Проверяем, если значение уже есть в гистограмме
                    if (histogram.ContainsKey(_pixels[x, y].R)) {
                        histogram[_pixels[x, y].R]++;
                    }
                    else {
                        histogram.Add(_pixels[x, y].R, 1);
                    }
                }
            }

            // Сортировка значений в гистограмме
            return histogram.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        /// <summary>
        /// Преобразует изображение в бинарный формат с использованием заданного типа преобразования.
        /// </summary>
        /// <param name="transformationType">Тип преобразования в бинарное изображение.</param>
        /// <returns>Объект бинарного изображения.</returns>
        public override ImageSample toBinary(BinaryTransformationType transformationType) {
            // Получение стратегии преобразования из фабрики
            var strategy = TransformationFactory.GetStrategy(transformationType);

            // Применение стратегии к текущему изображению
            return strategy.Transform(this);
        }

        /// <summary>
        /// Преобразует изображение в градации серого.
        /// </summary>
        /// <param name="transformationType">Тип преобразования (не используется, т.к. изображение уже в градациях серого).</param>
        /// <exception cref="Exception">Выбрасывается, так как изображение уже в формате градаций серого.</exception>
        public override ImageSample toGrayscale(GrayscaleTransformationType transformationType) {
            throw new Exception("Изображение уже в формате градаций серого.");
        }

        /// <summary>
        /// Преобразует изображение в RGB-формат.
        /// </summary>
        /// <param name="transformationType">Тип преобразования в RGB.</param>
        /// <exception cref="Exception">Выбрасывается, так как метод преобразования в RGB не реализован.</exception>
        public override ImageSample toRGB(RGBTransformationType transformationType) {
            throw new Exception("Метод преобразования в RGB пока что не реализован.");
        }
    }
}
