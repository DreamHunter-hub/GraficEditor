using GraficEditor.Enums.Transformation;
using GraficEditor.Factories;
using GraficEditor.Strategies.Visualization.DataGridView;
using GraficEditor.Strategies.Visualization.Histogram;

namespace GraficEditor.imageSamples {
    /// <summary>
    /// Класс для работы с бинарным изображением.
    /// Содержит методы для обработки и анализа бинарных изображений.
    /// </summary>
    public class BinaryImage : ImageSample {
        // Ленивая инициализация матрицы расстояний
        private int[,]? _distanceMatrix = null;

        /// <summary>
        /// Свойство для получения матрицы расстояний до ближайших противоположных пикселей.
        /// При первом вызове матрица расстояний будет вычислена.
        /// </summary>
        public int[,] Distance {
            get {
                if (_distanceMatrix == null) {
                    _distanceMatrix = GetDistanceMatrix();
                }
                return _distanceMatrix;
            }
        }

        /// <summary>
        /// Конструктор, создающий объект бинарного изображения.
        /// </summary>
        /// <param name="image">Матрица цветов, представляющая бинарное изображение.</param>
        public BinaryImage(Color[,] image) : base(image) { }

        /// <summary>
        /// Генерирует гистограмму бинарного изображения.
        /// </summary>
        /// <returns>Словарь, содержащий количество черных (0) и белых (1) пикселей.</returns>
        public override Dictionary<double, int> GetHistogram() {
            Dictionary<double, int> histogram = new Dictionary<double, int>
            {
                { 0, 0 }, // Черные пиксели
                { 1, 0 }  // Белые пиксели
            };

            // Получение размеров изображения
            int width = _pixels.GetLength(0);
            int height = _pixels.GetLength(1);

            // Подсчет количества пикселей каждого типа
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    if (_pixels[x, y].R == 255) { // Белый пиксель
                        histogram[0]++;
                    }
                }
            }

            // Количество белых пикселей вычисляется из общего числа пикселей
            histogram[1] = width * height - histogram[0];
            return histogram;
        }

        /// <summary>
        /// Преобразует бинарное изображение в бинарный формат.
        /// </summary>
        /// <exception cref="Exception">Выбрасывается, если изображение уже бинарное.</exception>
        public override ImageSample toBinary(BinaryTransformationType transformationType) {
            throw new Exception("Изображение уже в бинарном формате.");
        }

        /// <summary>
        /// Преобразует бинарное изображение в оттенки серого.
        /// </summary>
        public override ImageSample toGrayscale(GrayscaleTransformationType transformationType) {
            var strategy = TransformationFactory.GetStrategy(transformationType);
            return strategy.Transform(this);
        }

        /// <summary>
        /// Преобразует бинарное изображение в RGB-формат.
        /// </summary>
        /// <exception cref="Exception">Выбрасывается, если метод не реализован.</exception>
        public override ImageSample toRGB(RGBTransformationType transformationType) {
            throw new Exception("Метод преобразования в RGB пока что не реализован.");
        }

        /// <summary>
        /// Вычисляет матрицу расстояний до ближайших противоположных пикселей.
        /// </summary>
        /// <returns>Двумерная матрица расстояний.</returns>
        private int[,] GetDistanceMatrix() {
            int width = _pixels.GetLength(0);
            int height = _pixels.GetLength(1);
            int[,] distanceMatrix = new int[width, height];

            // Построение матрицы расстояний для каждого пикселя
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    if (_pixels[x, y].R == 255) { // Белый пиксель
                        int distance = FindNearestOppositePixel(x, y);
                        if (distance == -1) throw new Exception("Черные пиксели отсутствуют в изображении.");
                        distanceMatrix[x, y] = -distance;
                    }
                    else if (_pixels[x, y].R == 0) { // Черный пиксель
                        int distance = FindNearestOppositePixel(x, y, false);
                        if (distance == -1) throw new Exception("Белые пиксели отсутствуют в изображении.");
                        distanceMatrix[x, y] = distance;
                    }
                }
            }

            return distanceMatrix;
        }

        /// <summary>
        /// Получает тип визуализации для DataGridView.
        /// </summary>
        /// <returns>Тип визуализации для DataGridView.</returns>
        public override Type GetDataGridViewVisualization() => typeof(BinaryDataGridViewVisualization);

        /// <summary>
        /// Получает тип визуализации для гистограммы.
        /// </summary>
        /// <returns>Тип визуализации для гистограммы.</returns>
        public override Type GetHistogramVisualization() => typeof(BinaryHistogramVisualization);

        /// <summary>
        /// Находит ближайший противоположный пиксель (белый или черный) для указанной точки.
        /// </summary>
        private int FindNearestOppositePixel(int centerX, int centerY, bool isWhite = true) {
            int otherPixel = isWhite ? 0 : 255; // Определяем тип противоположного пикселя
            int width = _pixels.GetLength(0);
            int height = _pixels.GetLength(1);
            int minDistance = int.MaxValue;

            // Проверяем корректность координат пикселя
            bool IsValid(int x, int y) => x >= 0 && x < width && y >= 0 && y < height;

            // Поиск ближайшего противоположного пикселя
            for (int radius = 1; radius < Math.Max(width, height); radius++) {
                for (int dx = -radius; dx <= radius; dx++) {
                    int dy = radius - Math.Abs(dx);

                    if (IsValid(centerX + dx, centerY + dy) && _pixels[centerX + dx, centerY + dy].R == otherPixel) {
                        minDistance = radius;
                        goto Exit;
                    }
                    if (IsValid(centerX + dx, centerY - dy) && _pixels[centerX + dx, centerY - dy].R == otherPixel) {
                        minDistance = radius;
                        goto Exit;
                    }
                }
            }
        Exit:
            return minDistance == int.MaxValue ? -1 : minDistance;
        }

        /// <summary>
        /// Находит уникальные элементы в матрице и их порядок.
        /// </summary>
        public Dictionary<int, int> GetUniqueElementsWithOrder(int[,] matrix) {
            HashSet<int> uniqueElements = new HashSet<int>();

            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            // Собираем уникальные элементы из матрицы
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    uniqueElements.Add(matrix[x, y]);
                }
            }

            // Сортировка элементов в обратном порядке
            List<int> sortedElements = uniqueElements.ToList();
            sortedElements.Sort();
            sortedElements.Reverse();

            // Составление словаря с порядком элементов
            Dictionary<int, int> elementOrderDict = new Dictionary<int, int>();
            for (int i = 0; i < sortedElements.Count; i++) {
                elementOrderDict[sortedElements[i]] = i;
            }

            return elementOrderDict;
        }
    }
}
