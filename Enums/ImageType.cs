﻿using System;

namespace GraficEditor.Enums {
    /// <summary>
    /// Перечисление, описывающее различные форматы изображений.
    /// Используется для определения типа изображения.
    /// </summary>
    public enum ImageType {
        /// <summary>
        /// RGB-изображение с цветовым представлением, основанным на компонентах Red, Green и Blue.
        /// </summary>
        RGB,

        /// <summary>
        /// Изображение в градациях серого, где каждый пиксель представлен одной яркостью.
        /// </summary>
        Grayscale,

        /// <summary>
        /// Бинарное изображение, где каждый пиксель имеет только два возможных значения (черный или белый).
        /// </summary>
        Binary,

        /// <summary>
        /// Неопознанный или неподдерживаемый формат изображения.
        /// </summary>
        Unknown
    }
}
