using System;

namespace GraficEditor.Enums.Transformation {
    /// <summary>
    /// Перечисление, определяющее типы преобразования изображения в бинарный формат.
    /// </summary>
    public enum BinaryTransformationType {
        /// <summary>
        /// Преобразование градаций серого в бинарное изображение, основываясь на 40% черных пикселей.
        /// </summary>
        FromGrayscaleFourtPrecent,

        /// <summary>
        /// Преобразование градаций серого в бинарное изображение, используя заданную пользователем границу яркости.
        /// </summary>
        FromGrayscaleInputBorder
    }
}
