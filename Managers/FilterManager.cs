using GraficEditor.Enums.Filtration;
using GraficEditor.Factories;
using GraficEditor.Forms;
using GraficEditor.imageSamples;
using GraficEditor.Interfaces;
using GraficEditor.Strategies.Filter;

namespace GraficEditor.Managers {
    /// <summary>
    /// Менеджер для применения фильтров к изображениям.
    /// </summary>
    public static class FilterManager {
        /// <summary>
        /// Применяет усредняющий фильтр к изображению.
        /// </summary>
        /// <param name="imageSample">Объект изображения, к которому будет применён фильтр.</param>
        /// <returns>Новое изображение после применения усредняющего фильтра.</returns>
        public static ImageSample AverageFilter(ImageSample imageSample) {
            using (DataInputForm inputForm = new()) {
                inputForm.SetPromptMessage("Введите радиус фильтрации : ");

                if (inputForm.ShowDialog() == DialogResult.OK) {
                    // Инициализация параметров усредняющего фильтра
                    FilterParameters parameters = FilterParameters.GetDefaultForAveraging();
                    parameters.Radius = int.Parse(inputForm.InputData);

                    // Получение стратегии фильтрации
                    IFilterStrategy filter = FilterFactory.GetFilter(GrayscaleFilterType.Averaging);

                    // Применение фильтра
                    return filter.Filter(imageSample, parameters);
                }
                else {
                    throw new Exception("Ввод отменён.");
                }
            }
        }

        /// <summary>
        /// Применяет пороговый фильтр к изображению.
        /// </summary>
        /// <param name="imageSample">Объект изображения, к которому будет применён фильтр.</param>
        /// <returns>Новое изображение после применения порогового фильтра.</returns>
        public static ImageSample ThresholdFilter(ImageSample imageSample) {
            using (DataInputForm inputForm = new()) {
                inputForm.SetPromptMessage("Введите порог фильтрации : ");

                if (inputForm.ShowDialog() == DialogResult.OK) {
                    // Инициализация параметров порогового фильтра
                    FilterParameters parameters = FilterParameters.GetDefaultForThreshold();
                    parameters.ThresholdValue = int.Parse(inputForm.InputData);

                    inputForm.SetPromptMessage("Введите радиус фильтрации : ");

                    if (inputForm.ShowDialog() == DialogResult.OK) {
                        parameters.Radius = int.Parse(inputForm.InputData);
                    }

                    // Получение стратегии фильтрации
                    IFilterStrategy filter = FilterFactory.GetFilter(GrayscaleFilterType.Threshold);

                    // Применение фильтра
                    return filter.Filter(imageSample, parameters);
                }
                else {
                    throw new Exception("Ввод отменён.");
                }
            }
        }
    }
}
