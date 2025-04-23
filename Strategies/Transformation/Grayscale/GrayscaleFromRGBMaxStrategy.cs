using GraficEditor.imageSamples;
using GraficEditor.Interfaces;

namespace GraficEditor.Strategies.Transformation.GrayscaleTransformation {
    /// <summary>
    /// Стратегия преобразования RGB изображения в градации серого.
    /// Использует максимальное значение компонентов R, G и B для расчета уровня серого.
    /// </summary>
    public class GrayscaleFromRGBMaxStrategy : ITransformationStrategy {
        /// <summary>
        /// Преобразует RGB изображение в градации серого.
        /// </summary>
        /// <param name="image">Исходное изображение типа RGBImage.</param>
        /// <returns>Изображение в градациях серого.</returns>
        public ImageSample Transform(ImageSample image) {
            // Проверяем, что входное изображение имеет тип RGBImage
            if (image is not RGBImage binaryImage) {
                throw new ArgumentException("Image должен быть типа RGBImage");
            }

            // Получаем размеры изображения
            int width = image.Width;
            int height = image.Height;

            // Извлекаем пиксели исходного изображения
            Color[,] oldPixels = image.Pixels;

            // Создаем матрицу для новых пикселей изображения в градациях серого
            Color[,] pixels = new Color[width, height];

            // Параллельная обработка каждого пикселя для повышения производительности
            Parallel.For(0, width, x => {
                for (int y = 0; y < height; y++) {
                    // Получаем текущий пиксель
                    Color pixelColor = oldPixels[x, y];

                    // Вычисляем максимальное значение среди компонентов R, G и B
                    int MaxRGB = Math.Max(pixelColor.R, Math.Max(pixelColor.G, pixelColor.B));

                    // Создаем новый цвет в градациях серого с использованием максимального значения
                    Color newColor = Color.FromArgb(MaxRGB, MaxRGB, MaxRGB);

                    // Устанавливаем новый цвет пикселя
                    pixels[x, y] = newColor;
                }
            });

            // Возвращаем изображение в градациях серого
            return new GrayscaleImage(pixels);
        }
    }
}
