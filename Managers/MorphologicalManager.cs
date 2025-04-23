using GraficEditor.Enums.Morphological;
using GraficEditor.Factories;
using GraficEditor.Forms.Input;
using GraficEditor.imageSamples;
using GraficEditor.Interfaces;

namespace GraficEditor.Managers {
    /// <summary>
    /// Менеджер для выполнения морфологических операций над изображениями.
    /// </summary>
    public static class MorphologicalManager {
        /// <summary>
        /// Выполняет операцию эрозии над изображением.
        /// </summary>
        /// <param name="imageSample">Объект изображения, которое нужно обработать.</param>
        /// <returns>Новое изображение после применения операции эрозии.</returns>
        public static ImageSample ErosiImage(ImageSample imageSample) {
            using (MaskForm maskForm = new()) {
                // Открываем форму для ввода маски
                if (maskForm.ShowDialog() == DialogResult.OK) {
                    // Клонируем введенные данные маски
                    int[,] mask = (int[,])maskForm.InputData.Clone();

                    // Получаем стратегию морфологической операции
                    IMorphologicalStrategy morphological = MorphologicalFactory.GetMorphologicalStrategy(BinaryMorphologicType.Erode);

                    // Применяем операцию эрозии с использованием маски
                    return morphological.Morphologize(imageSample, mask);
                }
                else {
                    // Выбрасываем исключение, если ввод отменён
                    throw new Exception("Ввод отменён.");
                }
            }
        }
    }
}
