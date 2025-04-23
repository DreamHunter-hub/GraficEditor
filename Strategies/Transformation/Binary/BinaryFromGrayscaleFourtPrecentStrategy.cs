using GraficEditor.imageSamples;
using GraficEditor.Interfaces;

namespace GraficEditor.Strategies.Transformation.Binary {
    /// <summary>
    /// Стратегия преобразования градаций серого изображения в бинарное.
    /// Используется пороговое значение для определения черных пикселей, составляющих 40% изображения.
    /// </summary>
    internal class BinaryFromGrayscaleFourtPrecentStrategy : ITransformationStrategy {
        /// <summary>
        /// Преобразует градации серого изображения в бинарное изображение.
        /// </summary>
        /// <param name="image">Исходное изображение типа GrayscaleImage.</param>
        /// <returns>Бинарное изображение.</returns>
        public ImageSample Transform(ImageSample image) {
            // Проверка на соответствие типа изображения
            if (image is not GrayscaleImage binaryImage) {
                throw new ArgumentException("Image должен быть типа GrayscaleImage");
            }

            // Получение матрицы пикселей исходного изображения
            Color[,] pixels = image.Pixels;

            // Получаем гистограмму яркости изображения и переворачиваем её
            Dictionary<double, int> histogram = (Dictionary<double, int>)image.GetHistogram();
            histogram.Reverse();

            // Определение размеров изображения
            int width = image.Width;
            int height = image.Height;

            // Рассчитываем пороговое количество черных пикселей (40% от общего числа пикселей)
            int borderBlackPixels = width * height / 100 * 40;

            // Инициализируем минимальную яркость как самый темный пиксель
            double minBrightImage = histogram.First().Key;

            // Суммируем количество пикселей, начиная с самых темных
            int sumPixels = histogram[minBrightImage];
            foreach (var element in histogram.Skip(1)) {
                sumPixels += element.Value;
                // Если сумма пикселей превысила пороговое значение, прерываем процесс
                if (sumPixels > borderBlackPixels) break;
                // Обновляем минимальную яркость
                minBrightImage = element.Key;
            }

            // Создаем матрицу цветов для бинарного изображения
            Color[,] colors = new Color[width, height];
            Color blackPixel = Color.FromArgb(0, 0, 0); // Черный цвет пикселя
            Color whitePixel = Color.FromArgb(255, 255, 255); // Белый цвет пикселя

            // Параллельная обработка для повышения производительности
            Parallel.For(0, width, x => {
                for (int y = 0; y < height; y++) {
                    // Устанавливаем цвет пикселя: черный или белый в зависимости от яркости
                    colors[x, y] = pixels[x, y].R < minBrightImage ? blackPixel : whitePixel;
                }
            });

            // Возвращаем бинарное изображение
            return new BinaryImage(colors);
        }
    }
}
