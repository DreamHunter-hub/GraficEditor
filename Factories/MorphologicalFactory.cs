using GraficEditor.Enums.Morphological;
using GraficEditor.Interfaces;
using GraficEditor.Strategies.Morphological.Binary;

namespace GraficEditor.Factories {
    /// <summary>
    /// Фабрика для создания стратегий морфологических операций.
    /// </summary>
    public static class MorphologicalFactory {
        /// <summary>
        /// Возвращает стратегию морфологической обработки на основе указанного типа.
        /// </summary>
        /// <param name="morphologicalType">Тип морфологической операции (BinaryMorphologicType).</param>
        /// <returns>Объект, реализующий интерфейс IMorphologicalStrategy.</returns>
        public static IMorphologicalStrategy GetMorphologicalStrategy(BinaryMorphologicType morphologicalType) {
            // Возвращаем соответствующую стратегию на основе типа морфологической операции
            return morphologicalType switch {
                BinaryMorphologicType.Erode => new ErosionImage(), // Стратегия эрозии
                _ => throw new ArgumentException("Неизвестный тип морфологизации.") // Исключение для неподдерживаемого типа
            };
        }
    }
}
