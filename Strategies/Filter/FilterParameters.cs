namespace GraficEditor.Strategies.Filter {
    /// <summary>
    /// Класс, представляющий параметры для фильтров изображений.
    /// </summary>
    public class FilterParameters {
        /// <summary>
        /// Пороговое значение для фильтрации (используется, например, в пороговых фильтрах).
        /// </summary>
        public double? ThresholdValue { get; set; }

        /// <summary>
        /// Радиус фильтрации (используется, например, в усредняющих фильтрах).
        /// </summary>
        public int? Radius { get; set; }

        /// <summary>
        /// Создает параметры фильтра с настройками по умолчанию для усредняющего фильтра.
        /// </summary>
        /// <returns>Экземпляр FilterParameters с предустановленными параметрами.</returns>
        public static FilterParameters GetDefaultForAveraging() {
            return new FilterParameters {
                ThresholdValue = null, // Пороговое значение не используется для усредняющего фильтра
                Radius = 1 // Радиус по умолчанию
            };
        }

        /// <summary>
        /// Создает параметры фильтра с настройками по умолчанию для порогового фильтра.
        /// </summary>
        /// <returns>Экземпляр FilterParameters с предустановленными параметрами.</returns>
        public static FilterParameters GetDefaultForThreshold() {
            return new FilterParameters {
                ThresholdValue = 128, // Пороговое значение по умолчанию
                Radius = 1 // Радиус по умолчанию
            };
        }
    }
}
