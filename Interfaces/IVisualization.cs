namespace GraficEditor.Interfaces {
    /// <summary>
    /// Интерфейс для визуализации данных.
    /// </summary>
    public interface IVisualization {
        /// <summary>
        /// Метод для выполнения визуализации.
        /// </summary>
        /// <param name="control">Элемент управления, где будет происходить визуализация.</param>
        /// <param name="data">Данные для визуализации.</param>
        void Visualize(object control, object data);
    }
}
