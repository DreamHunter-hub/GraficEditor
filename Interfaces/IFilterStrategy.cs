using GraficEditor.imageSamples;
using GraficEditor.Strategies.Filter;

namespace GraficEditor.Interfaces {
    /// <summary>
    /// Интерфейс для реализации стратегий фильтрации изображений.
    /// </summary>
    public interface IFilterStrategy {
        /// <summary>
        /// Применяет фильтр к изображению на основе заданных параметров.
        /// </summary>
        /// <param name="image">Объект изображения, которое нужно обработать.</param>
        /// <param name="parameters">Параметры фильтрации.</param>
        /// <returns>Новое изображение после применения фильтра.</returns>
        public ImageSample Filter(ImageSample image, FilterParameters parameters);
    }
}
