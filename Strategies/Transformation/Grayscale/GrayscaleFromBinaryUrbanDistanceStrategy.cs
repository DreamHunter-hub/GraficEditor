using GraficEditor.imageSamples;
using GraficEditor.Interfaces;

namespace GraficEditor.Strategies.Transformation.GrayscaleTransformation {
    /// <summary>
    /// Стратегия преобразования бинарного изображения в градации серого.
    /// Используется матрица расстояний для расчета уровней серого.
    /// </summary>
    internal class GrayscaleFromBinaryUrbanDistanceStrategy : ITransformationStrategy {
        /// <summary>
        /// Преобразует бинарное изображение в градации серого на основе матрицы расстояний.
        /// </summary>
        /// <param name="image">Исходное изображение типа BinaryImage.</param>
        /// <returns>Изображение в градациях серого.</returns>
        public ImageSample Transform(ImageSample image) {
            // Проверяем, что входное изображение является бинарным
            if (image is not BinaryImage binaryImage) {
                throw new ArgumentException("Image должен быть типа BinaryImage");
            }

            // Получаем размеры изображения
            int width = image.Width;
            int height = image.Height;

            // Извлекаем матрицу расстояний из бинарного изображения
            int[,] distanceMatrix = ((BinaryImage)image).Distance;

            // Получаем уникальные элементы матрицы и их порядок
            Dictionary<int, int> uniqueElements = ((BinaryImage)image).GetUniqueElementsWithOrder(distanceMatrix);

            // Вычисляем множитель для преобразования расстояния в уровень серого
            double multiple = 255.0 / (uniqueElements.Count - 1);

            // Создаем матрицу цветов для градаций серого
            Color[,] pixels = new Color[width, height];

            // Параллельная обработка для расчета уровня серого каждого пикселя
            Parallel.For(0, width, x => {
                for (int y = 0; y < height; y++) {
                    // Получаем значение яркости на основе расстояния
                    double grayValueD = uniqueElements[distanceMatrix[x, y]] * multiple;
                    // Преобразуем значение в целое число, ограничивая максимум 255
                    int grayValueI = Math.Min(Math.Abs((int)grayValueD), 255);
                    // Устанавливаем уровень серого для текущего пикселя
                    pixels[x, y] = Color.FromArgb(grayValueI, grayValueI, grayValueI);
                }
            });

            // Возвращаем изображение в градациях серого
            return new GrayscaleImage(pixels);
        }
    }
}
