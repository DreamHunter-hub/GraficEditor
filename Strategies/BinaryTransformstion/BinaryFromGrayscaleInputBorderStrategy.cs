using GraficEditor.Forms;
using GraficEditor.imageSamples;
using GraficEditor.Interfaces;

namespace GraficEditor.Strategies.BinaryTransformstion {
    /// <summary>
    /// Стратегия преобразования градаций серого изображения в бинарное.
    /// Пороговая яркость пикселей задается пользователем через форму ввода.
    /// </summary>
    internal class BinaryFromGrayscaleInputBorderStrategy : ITransformationStrategy {
        /// <summary>
        /// Преобразует изображение типа GrayscaleImage в бинарное на основе пользовательского порога яркости.
        /// </summary>
        /// <param name="image">Исходное изображение типа GrayscaleImage.</param>
        /// <returns>Бинарное изображение.</returns>
        public ImageSample Transform(ImageSample image) {
            // Используем форму для ввода данных
            using (DataInputForm inputForm = new()) {
                // Показываем форму и обрабатываем результат
                if (inputForm.ShowDialog() == DialogResult.OK) {
                    // Получаем пороговое значение яркости, введенное пользователем
                    int borderPixel = Convert.ToInt32(inputForm.InputData);
                    MessageBox.Show($"Введённые данные: {borderPixel}", "Информация");

                    // Получаем матрицу пикселей исходного изображения
                    Color[,] pixels = image.Pixels;

                    // Определяем размеры изображения
                    int width = pixels.GetLength(0);
                    int height = pixels.GetLength(1);

                    // Создаем матрицу для пикселей бинарного изображения
                    Color[,] newPixels = new Color[width, height];
                    Color blackPixel = Color.FromArgb(0, 0, 0); // Черный пиксель
                    Color whitePixel = Color.FromArgb(255, 255, 255); // Белый пиксель

                    // Параллельная обработка пикселей для улучшения производительности
                    Parallel.For(0, width, x => {
                        for (int y = 0; y < height; y++) {
                            // Определяем цвет пикселя: черный или белый в зависимости от порога яркости
                            newPixels[x, y] = pixels[x, y].R > borderPixel ? blackPixel : whitePixel;
                        }
                    });

                    // Возвращаем новое бинарное изображение
                    return new BinaryImage(newPixels);
                }
                else {
                    // Обработка отмены ввода данных пользователем
                    throw new Exception("Ввод был отменён");
                }
            }
        }
    }
}
