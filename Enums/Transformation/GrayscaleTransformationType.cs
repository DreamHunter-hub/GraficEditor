using System;

namespace GraficEditor.Enums.Transformation {
    /// <summary>
    /// Перечисление, определяющее типы преобразования изображения в градации серого.
    /// </summary>
    public enum GrayscaleTransformationType {
        /// <summary>
        /// Преобразование изображения в градации серого на основе среднего значения компонентов R, G и B.
        /// </summary>
        FromRGBAverage,

        /// <summary>
        /// Преобразование изображения в градации серого на основе максимального значения компонентов R, G и B.
        /// </summary>
        FromRGBMax,

        /// <summary>
        /// Преобразование бинарного изображения в градации серого с использованием матрицы расстояний.
        /// </summary>
        FromBinaryUrbanDistance
    }
}
