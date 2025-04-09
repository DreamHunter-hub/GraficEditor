using GraficEditor.Enums;

namespace GraficEditor.imageSamples {
    /// <summary>
    /// Абстрактный класс для работы с изображениями.
    /// Определяет базовые операции и свойства для обработки изображений.
    /// </summary>
    public abstract class ImageSample {
        /// <summary>
        /// Матрица пикселей изображения. Хранит информацию о цвете каждого пикселя.
        /// </summary>
        protected Color[,] _pixels;

        /// <summary>
        /// Ширина изображения (количество пикселей по горизонтали).
        /// </summary>
        public int Width {
            get {
                return _pixels.GetLength(0); // Возвращает количество элементов в первом измерении матрицы.
            }
        }

        /// <summary>
        /// Высота изображения (количество пикселей по вертикали).
        /// </summary>
        public int Height {
            get {
                return _pixels.GetLength(1); // Возвращает количество элементов во втором измерении матрицы.
            }
        }

        /// <summary>
        /// Преобразует изображение в RGB-формат.
        /// </summary>
        /// <param name="transformationType">Тип преобразования RGB.</param>
        /// <returns>Объект изображения в RGB-формате.</returns>
        public abstract ImageSample toRGB(RGBTransformationType transformationType);

        /// <summary>
        /// Преобразует изображение в градации серого.
        /// </summary>
        /// <param name="transformationType">Тип преобразования в градации серого.</param>
        /// <returns>Объект изображения в формате градаций серого.</returns>
        public abstract ImageSample toGrayscale(GrayscaleTransformationType transformationType);

        /// <summary>
        /// Преобразует изображение в бинарный формат.
        /// </summary>
        /// <param name="transformationType">Тип преобразования в бинарное изображение.</param>
        /// <returns>Объект бинарного изображения.</returns>
        public abstract ImageSample toBinary(BinaryTransformationType transformationType);

        /// <summary>
        /// Генерирует гистограмму изображения.
        /// </summary>
        /// <returns>
        /// Словарь с гистограммой, где ключ — значение пикселя (например, яркость), 
        /// а значение — количество пикселей с этим значением.
        /// </returns>
        public abstract object GetHistogram();

        /// <summary>
        /// Получает тип визуализации для DataGridView.
        /// </summary>
        /// <returns>Тип визуализации, подходящей для DataGridView.</returns>
        public abstract Type GetDataGridViewVisualization();

        /// <summary>
        /// Получает тип визуализации гистограммы.
        /// </summary>
        /// <returns>Тип визуализации гистограммы.</returns>
        public abstract Type GetHistogramVisualization();

        /// <summary>
        /// Конструктор для создания объекта ImageSample из матрицы цветов.
        /// </summary>
        /// <param name="image">Матрица пикселей, содержащая информацию о цвете каждого пикселя.</param>
        public ImageSample(Color[,] image) {
            this._pixels = image; // Инициализация внутренней матрицы пикселей.
        }

        /// <summary>
        /// Свойство для получения копии матрицы пикселей.
        /// </summary>
        public Color[,] Pixels {
            get => (Color[,])_pixels.Clone(); // Возвращает копию матрицы, чтобы избежать прямого изменения данных.
        }
    }
}
