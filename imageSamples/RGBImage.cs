using GraficEditor.Enums;
using GraficEditor.Factories;
using GraficEditor.Visualizations.Chart;
using GraficEditor.Visualizations.DataGridView;

namespace GraficEditor.imageSamples {
    /// <summary>
    /// Класс для работы с изображениями в RGB-формате.
    /// </summary>
    class RGBImage : ImageSample {
        /// <summary>
        /// Конструктор, инициализирующий объект изображения RGB-формата.
        /// </summary>
        /// <param name="image">Массив цветов, представляющий изображение.</param>
        public RGBImage(Color[,] image) : base(image) { }

        /// <summary>
        /// Получает тип визуализации гистограммы для RGB-изображения.
        /// </summary>
        public override Type GetHistogramVisualization() => typeof(RGBHistogramVisualization);

        /// <summary>
        /// Получает тип визуализации для DataGridView.
        /// </summary>
        public override Type GetDataGridViewVisualization() => typeof(RGBDataGridViewVisualization);

        /// <summary>
        /// Генерация гистограммы для RGB-изображения.
        /// Создает три отдельных канала (R, G, B) и их частотное распределение.
        /// </summary>
        /// <returns>Гистограмма с распределением значений для каждого канала.</returns>
        public override Dictionary<string, Dictionary<int, int>> GetHistogram() {
            // Создаем словарь для хранения гистограмм каждого канала
            Dictionary<string, Dictionary<int, int>> histogram = new Dictionary<string, Dictionary<int, int>>()
            {
                { "R", new Dictionary<int, int>() },
                { "G", new Dictionary<int, int>() },
                { "B", new Dictionary<int, int>() }
            };

            // Получаем размеры изображения
            int width = Width;
            int height = Height;

            // Итерируемся по каждому пикселю изображения
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Color pixel = _pixels[x, y];

                    // Обработка канала R
                    if (histogram["R"].ContainsKey(pixel.R)) {
                        histogram["R"][pixel.R]++;
                    }
                    else {
                        histogram["R"].Add(pixel.R, 1);
                    }

                    // Обработка канала G
                    if (histogram["G"].ContainsKey(pixel.G)) {
                        histogram["G"][pixel.G]++;
                    }
                    else {
                        histogram["G"].Add(pixel.G, 1);
                    }

                    // Обработка канала B
                    if (histogram["B"].ContainsKey(pixel.B)) {
                        histogram["B"][pixel.B]++;
                    }
                    else {
                        histogram["B"].Add(pixel.B, 1);
                    }
                }
            }

            // Сортировка значений гистограммы для каждого канала
            histogram["R"] = histogram["R"].OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
            histogram["G"] = histogram["G"].OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
            histogram["B"] = histogram["B"].OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);

            return histogram;
        }

        /// <summary>
        /// Преобразует RGB-изображение в бинарный формат.
        /// </summary>
        /// <param name="transformationType">Тип преобразования в бинарное изображение.</param>
        /// <returns>Бинарное изображение.</returns>
        public override ImageSample toBinary(BinaryTransformationType transformationType) {
            // Сначала преобразуем RGB в градации серого
            var grayscaleImage = this.toGrayscale(GrayscaleTransformationType.FromRGBAverage) as GrayscaleImage;

            // Проверяем, успешно ли было преобразование в Grayscale
            if (grayscaleImage == null) {
                throw new InvalidOperationException("Не удалось преобразовать RGB в Grayscale.");
            }

            // Затем преобразуем Grayscale в Binary с заданным типом трансформации
            return grayscaleImage.toBinary(transformationType);
        }

        /// <summary>
        /// Преобразует RGB-изображение в градации серого.
        /// </summary>
        /// <param name="transformationType">Тип преобразования в градации серого.</param>
        /// <returns>Изображение в градациях серого.</returns>
        public override ImageSample toGrayscale(GrayscaleTransformationType transformationType) {
            // Получаем стратегию трансформации из фабрики
            var strategy = TransformationFactory.GetStrategy(transformationType);
            return strategy.Transform(this);
        }

        /// <summary>
        /// Преобразует изображение в RGB-формат (уже в RGB-формате).
        /// </summary>
        /// <param name="transformationType">Тип преобразования в RGB формат.</param>
        /// <exception cref="Exception">Выбрасывается, так как изображение уже является RGB.</exception>
        public override ImageSample toRGB(RGBTransformationType transformationType) {
            throw new Exception("Изображение уже в RGB формате.");
        }
    }
}
