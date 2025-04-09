using GraficEditor.Enums;
using GraficEditor.imageSamples;
using GraficEditor.Utils;

namespace GraficEditor.Factories {
    /// <summary>
    /// Фабрика для создания объектов изображения на основе входного Bitmap.
    /// </summary>
    public static class ImageFactory {
        /// <summary>
        /// Создает объект ImageSample на основе входного изображения Bitmap.
        /// </summary>
        /// <param name="bitmap">Входное изображение в формате Bitmap.</param>
        /// <returns>Объект ImageSample, соответствующий типу изображения.</returns>
        public static ImageSample CreateImage(Bitmap bitmap) {
            // Преобразуем изображение Bitmap в матрицу пикселей
            Color[,] pixels = ImageProccesingUtils.ImageToMatrix(bitmap);

            // Определяем тип изображения на основе его пикселей
            ImageType type = ImageProccesingUtils.GetImageType(pixels);

            // Создаем соответствующий объект изображения
            return type switch {
                ImageType.RGB => new RGBImage(pixels),          // RGB изображение
                ImageType.Grayscale => new GrayscaleImage(pixels), // Изображение в градациях серого
                ImageType.Binary => new BinaryImage(pixels),       // Бинарное изображение
                _ => throw new Exception("Тип изображения не поддерживается.") // Исключение для неподдерживаемых типов
            };
        }
    }
}
