using GraficEditor.imageSamples;
using GraficEditor.Interfaces;

namespace GraficEditor.Strategies.Transformation.GrayscaleTransformation {
    /// <summary>
    /// Стратегия преобразования RGB изображения в градации серого.
    /// Используется среднее значение компонентов R, G и B для расчета уровня серого.
    /// </summary>
    public class GrayscaleFromRGBAverageStrategy : ITransformationStrategy {
        /// <summary>
        /// Преобразует RGB изображение в градации серого.
        /// </summary>
        /// <param name="image">Исходное изображение типа RGBImage.</param>
        /// <returns>Изображение в градациях серого.</returns>
        public ImageSample Transform(ImageSample image) {
            // Проверка на соответствие типа изображения
            if (image is not RGBImage binaryImage) {
                throw new ArgumentException("Image должен быть типа RGBImage");
            }

            // Получение ширины и высоты изображения
            int width = image.Width;
            int height = image.Height;

            // Извлечение пикселей исходного изображения
            Color[,] oldePixels = image.Pixels;

            // Создание матрицы для новых пикселей изображения в градациях серого
            Color[,] pixels = new Color[width, height];

            // Параллельная обработка каждого пикселя
            Parallel.For(0, width, x => {
                for (int y = 0; y < height; y++) {
                    // Получаем текущий пиксель
                    Color pixelColor = oldePixels[x, y];

                    // Вычисляем среднее значение цветовых компонентов R, G и B
                    int averageRGB = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    // Создаем новый цвет в градациях серого с использованием среднего значения
                    Color newColor = Color.FromArgb(averageRGB, averageRGB, averageRGB);

                    // Устанавливаем новый цвет пикселя
                    pixels[x, y] = newColor;
                }
            });

            // Возвращаем изображение в градациях серого
            return new GrayscaleImage(pixels);
        }
    }
}
