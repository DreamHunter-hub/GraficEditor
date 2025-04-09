using GraficEditor.imageSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficEditor.Interfaces {
    /// <summary>
    /// Интерфейс для стратегий преобразования изображений.
    /// Определяет общий метод Transform для всех реализаций.
    /// </summary>
    public interface ITransformationStrategy {
        /// <summary>
        /// Выполняет преобразование изображения.
        /// </summary>
        /// <param name="image">Объект изображения, который нужно преобразовать.</param>
        /// <returns>Преобразованное изображение.</returns>
        ImageSample Transform(ImageSample image);
    }
}
