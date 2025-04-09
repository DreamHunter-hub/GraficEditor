using GraficEditor.Enums;

namespace GraficEditor.Utils {
    /// <summary>
    /// Класс утилит для обработки изображений.
    /// </summary>
    public static class ImageProccesingUtils {
        /// <summary>
        /// Преобразует изображение в матрицу цветов (Color[,]).
        /// </summary>
        /// <param name="image">Входное изображение (Bitmap).</param>
        /// <returns>Матрица цветов (Color[,]).</returns>
        public static Color[,] ImageToMatrix(Bitmap image) {
            // Получаем ширину и высоту изображения
            int width = image.Width;
            int height = image.Height;

            // Создаем матрицу цветов с размерами изображения
            Color[,] matrix = new Color[width, height];

            // Итерируемся по каждому пикселю изображения
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    // Получаем цвет пикселя и добавляем его в матрицу
                    matrix[x, y] = image.GetPixel(x, y);
                }
            }

            // Возвращаем матрицу цветов
            return matrix;
        }

        /// <summary>
        /// Преобразует матрицу цветов (Color[,]) в изображение (Bitmap).
        /// </summary>
        /// <param name="matrix">Матрица цветов (Color[,]).</param>
        /// <returns>Изображение (Bitmap).</returns>
        public static Bitmap MatrixToImage(Color[,] matrix) {
            // Получаем размеры матрицы цветов
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            // Создаем пустое изображение с размерами матрицы
            Bitmap image = new Bitmap(width, height);

            // Итерируемся по каждой позиции матрицы
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    // Устанавливаем цвет пикселя в изображении на основе матрицы
                    image.SetPixel(x, y, matrix[x, y]);
                }
            }

            // Возвращаем созданное изображение
            return image;
        }

        /// <summary>
        /// Определяет тип изображения на основе его пикселей.
        /// </summary>
        /// <param name="matrix">Матрица цветов (Color[,]).</param>
        /// <returns>Тип изображения (ImageType).</returns>
        public static ImageType GetImageType(Color[,] matrix) {
            // Переменные для определения типов изображений
            bool isRGB = false; // Флаг для RGB
            bool isGrayscale = true; // Флаг для градаций серого
            bool isBinary = true; // Флаг для бинарных изображений

            // Множество для хранения уникальных цветов
            HashSet<Color> uniqueColors = new HashSet<Color>();

            // Получаем размеры матрицы
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            // Итерируемся по каждому пикселю матрицы
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    // Получаем текущий цвет пикселя
                    Color pixel = matrix[x, y];

                    // Проверка, является ли пиксель оттенком серого
                    if (pixel.R != pixel.G || pixel.G != pixel.B) {
                        isGrayscale = false;
                    }

                    // Добавляем цвет пикселя в множество уникальных цветов
                    uniqueColors.Add(pixel);

                    // Проверка, является ли изображение бинарным (только два цвета)
                    if (uniqueColors.Count > 2) {
                        isBinary = false;
                    }

                    // Если изображение не серое и не бинарное, устанавливаем флаг RGB
                    if (!isGrayscale && !isBinary) {
                        isRGB = true;
                        break;
                    }
                }
            }

            // Возвращаем тип изображения на основе флагов
            if (isRGB) return ImageType.RGB;
            if (isBinary) return ImageType.Binary;
            if (isGrayscale) return ImageType.Grayscale;

            // Если тип изображения не определен, возвращаем Unknown
            return ImageType.Unknown;
        }
    }
}
