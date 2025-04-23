using GraficEditor.imageSamples;
using GraficEditor.Interfaces;

namespace GraficEditor.Strategies.Morphological.Binary {
    /// <summary>
    /// Класс для выполнения морфологической операции "эрозия" на бинарном изображении.
    /// </summary>
    public class ErosionImage : IMorphologicalStrategy {
        /// <summary>
        /// Выполняет операцию эрозии на бинарном изображении с использованием заданной маски.
        /// </summary>
        /// <param name="image">Изображение, которое нужно обработать.</param>
        /// <param name="mask">Маска (структурный элемент) для операции эрозии.</param>
        /// <returns>Новое изображение после применения операции эрозии.</returns>
        public ImageSample Morphologize(ImageSample image, int[,] mask) {
            // Проверяем, что изображение является BinaryImage
            if (image is not BinaryImage binaryImage) {
                throw new ArgumentException("Image должен быть типа BinaryImage");
            }

            // Проверяем, что маска задана
            if (mask == null) {
                throw new ArgumentException("Mask не задан");
            }

            int rows = image.Width;
            int cols = image.Height;
            int seRows = mask.GetLength(0);
            int seCols = mask.GetLength(1);

            // Координаты центра структурного элемента
            int seCenterRow = seRows / 2;
            int seCenterCol = seCols / 2;

            // Получаем пиксели входного изображения
            Color[,] inputImage = image.Pixels;

            // Создаём выходное изображение с пикселями по умолчанию (белый)
            Color[,] outputImage = new Color[rows, cols];

            Color whitePixel = Color.FromArgb(255, 255, 255);
            Color blackPixel = Color.FromArgb(0, 0, 0);

            // Проход по всем пикселям входного изображения
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < cols; y++) {
                    // Пропуск белых пикселей
                    if (inputImage[x, y].R == whitePixel.R) {
                        outputImage[x, y] = whitePixel;
                        continue;
                    }

                    bool match = true;

                    for (int i = 0; i < seRows; i++) {
                        for (int j = 0; j < seCols; j++) {
                            int neighborX = x + i - seCenterRow;
                            int neighborY = y + j - seCenterCol;

                            // Проверка внутри границ изображения
                            if (neighborX >= 0 && neighborX < rows && neighborY >= 0 && neighborY < cols) {
                                // Если маска активна и соседний пиксель белый — совпадение невозможно
                                if (mask[i, j] == 1 && inputImage[neighborX, neighborY].R == whitePixel.R) {
                                    match = false;
                                    break;
                                }
                            }
                        }

                        if (!match)
                            break;
                    }

                    // Устанавливаем черный пиксель при совпадении маски, иначе белый
                    outputImage[x, y] = match ? blackPixel : whitePixel;
                }
            }
            
            // Возвращаем новое изображение после эрозии
            return new BinaryImage(outputImage);
        }
    }
}
