namespace GraficEditor.Enums.Filtration {
    /// <summary>
    /// Перечисление типов фильтров для изображений в градациях серого.
    /// </summary>
    public enum GrayscaleFilterType {
        /// <summary>
        /// Фильтр, использующий усреднение значений для обработки изображения.
        /// </summary>
        Averaging,

        /// <summary>
        /// Фильтр, использующий пороговое значение для обработки изображения.
        /// </summary>
        Threshold
    }
}
