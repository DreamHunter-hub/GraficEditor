using GraficEditor.imageSamples;

namespace GraficEditor.Interfaces {
    /// <summary>
    /// Интерфейс для реализации стратегий морфологических операций.
    /// </summary>
    public interface IMorphologicalStrategy {
        /// <summary>
        /// Выполняет морфологическую операцию на изображении с использованием заданной маски.
        /// </summary>
        /// <param name="image">Изображение, к которому будет применена морфологическая операция.</param>
        /// <param name="mask">Маска (двумерный массив), используемая в морфологической операции.</param>
        /// <returns>Новое изображение после применения морфологической операции.</returns>
        public ImageSample Morphologize(ImageSample image, int[,] mask);
    }
}
