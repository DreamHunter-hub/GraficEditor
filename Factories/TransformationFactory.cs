using GraficEditor.Enums.Transformation;
using GraficEditor.Interfaces;
using GraficEditor.Strategies.Transformation.Binary;
using GraficEditor.Strategies.Transformation.GrayscaleTransformation;

namespace GraficEditor.Factories {
    /// <summary>
    /// Фабрика для получения стратегий преобразования изображений.
    /// Содержит методы для создания стратегий преобразования в различные форматы.
    /// </summary>
    public static class TransformationFactory {
        /// <summary>
        /// Возвращает стратегию преобразования изображения в градации серого.
        /// </summary>
        /// <param name="transformationType">Тип преобразования в градации серого.</param>
        /// <returns>Объект стратегии преобразования.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если тип преобразования неизвестен.</exception>
        public static ITransformationStrategy GetStrategy(GrayscaleTransformationType transformationType) {
            // Выбор стратегии преобразования в зависимости от типа
            return transformationType switch {
                GrayscaleTransformationType.FromRGBAverage => new GrayscaleFromRGBAverageStrategy(), // Среднее значение RGB
                GrayscaleTransformationType.FromRGBMax => new GrayscaleFromRGBMaxStrategy(), // Максимальное значение RGB
                GrayscaleTransformationType.FromBinaryUrbanDistance => new GrayscaleFromBinaryUrbanDistanceStrategy(), // Городское расстояние для Binary
                _ => throw new ArgumentException("Неизвестный метод преобразования в Grayscale.") // Обработка неизвестного типа
            };
        }

        /// <summary>
        /// Возвращает стратегию преобразования изображения в RGB.
        /// </summary>
        /// <param name="transformationType">Тип преобразования в RGB.</param>
        /// <returns>Объект стратегии преобразования.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если тип преобразования неизвестен.</exception>
        public static ITransformationStrategy GetStrategy(RGBTransformationType transformationType) {
            // Поскольку стратегии для RGB пока не реализованы, обрабатывается как неизвестный тип
            return transformationType switch {
                _ => throw new ArgumentException("Неизвестный метод преобразования в RGB.") // Обработка неизвестного типа
            };
        }

        /// <summary>
        /// Возвращает стратегию преобразования изображения в бинарный формат.
        /// </summary>
        /// <param name="transformationType">Тип преобразования в бинарное изображение.</param>
        /// <returns>Объект стратегии преобразования.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если тип преобразования неизвестен.</exception>
        public static ITransformationStrategy GetStrategy(BinaryTransformationType transformationType) {
            // Выбор стратегии преобразования в зависимости от типа
            return transformationType switch {
                BinaryTransformationType.FromGrayscaleFourtPrecent => new BinaryFromGrayscaleFourtPrecentStrategy(), // 40% пикселей в черный
                BinaryTransformationType.FromGrayscaleInputBorder => new BinaryFromGrayscaleInputBorderStrategy(), // Граница яркости
                _ => throw new ArgumentException("Неизвестный метод преобразования в Binary.") // Обработка неизвестного типа
            };
        }
    }
}
