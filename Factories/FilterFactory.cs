using GraficEditor.Enums.Filtration;
using GraficEditor.Interfaces;
using GraficEditor.Strategies.Filter.Grayscale;

namespace GraficEditor.Factories {
    public static class FilterFactory {
        /// <summary>
        /// Возвращает стратегию применения фильтра к полутоновому изображению.
        /// </summary>
        /// <param name="filterType">Тип фильтра.</param>
        /// <returns>Объект стратегии фильтрации.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если тип фильтра неизвестен.</exception>
        public static IFilterStrategy GetFilter(GrayscaleFilterType filterType) {
            // Выбор стратегии фильтрации в зависимости от типа
            return filterType switch {
                GrayscaleFilterType.Averaging => new AveragingFilterStrategy(), // Усредняющий фильтр
                GrayscaleFilterType.Threshold => new ThresholdFilterStrategy(), // Пороговый фильтр
                _ => throw new ArgumentException("Неизвестный тип фильтра.") // Обработка неизвестного типа
            };
        }
    }
}
