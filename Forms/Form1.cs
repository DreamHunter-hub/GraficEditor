using GraficEditor.Enums.Filtration;
using GraficEditor.Enums.Morphological;
using GraficEditor.Enums.Transformation;
using GraficEditor.Factories;
using GraficEditor.Forms.Input;
using GraficEditor.imageSamples;
using GraficEditor.Interfaces;
using GraficEditor.Managers;
using GraficEditor.Strategies.Filter;
using GraficEditor.Utils;

namespace GraficEditor.Forms {
    /// <summary>
    /// Основная форма приложения для работы с изображениями.
    /// Содержит методы для загрузки, обработки и визуализации изображений.
    /// </summary>
    public partial class Form1 : Form {
        private ImageSample _image; // Хранит текущее изображение

        public Form1() {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик для кнопки загрузки изображения.
        /// </summary>
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new() {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Filter = "Bitmap изображения|*.bmp",
                Title = "Загрузка картинки"
            };

            if (openFile.ShowDialog() == DialogResult.OK) {
                Bitmap bitmap = new Bitmap(openFile.FileName);
                pictureBox1.Image = bitmap; // Отображаем загруженное изображение
                _image = ImageFactory.CreateImage(bitmap); // Создаем объект изображения
                UpdateMenuState(); // Обновляем состояние меню
            }
        }

        /// <summary>
        /// Обработчик для кнопки сохранения изображения.
        /// </summary>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) {
            if (pictureBox1.Image == null) {
                MessageBox.Show("Изображение не загружено");
                return;
            }

            SaveFileDialog saveFile = new() {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Filter = "Bitmap изображения|*.bmp",
                Title = "Сохранение картинки"
            };

            if (saveFile.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image.Save(saveFile.FileName); // Сохраняем текущее изображение
            }
        }

        /// <summary>
        /// Открывает матрицу яркости изображения.
        /// </summary>
        private void яркостиToolStripMenuItem_Click(object sender, EventArgs e) {
            HandleAction(() => {
                ImageVisualizationManager.ShowMatrix(_image);
            });
        }

        /// <summary>
        /// Строит гистограмму яркости изображения.
        /// </summary>
        private void построитьToolStripMenuItem_Click(object sender, EventArgs e) {
            HandleAction(() => {
                ImageVisualizationManager.ShowHistogram(_image);
            });
        }

        /// <summary>
        /// Открывает матрицу расстояний для бинарного изображения.
        /// </summary>
        private void расстоянийToolStripMenuItem_Click(object sender, EventArgs e) {
            HandleAction(() => {
                ImageVisualizationManager.ShowDistanceMatrix(_image);
            });
        }

        /// <summary>
        /// Вспомогательный метод для безопасного выполнения действий.
        /// </summary>
        private static void HandleAction(Action action) {
            try {
                action(); // Выполнение действия
            }
            catch (Exception exp) {
                MessageBox.Show(exp.Message, "Ошибка"); // Вывод сообщения об ошибке
            }
        }

        /// <summary>
        /// Обновляет состояние элементов меню в зависимости от типа изображения.
        /// </summary>
        private void UpdateMenuState() {
            bool isImageLoaded = _image != null;

            преобразоватьToolStripMenuItem.Enabled = isImageLoaded;
            матрицыToolStripMenuItem.Enabled = isImageLoaded;
            гистограммыToolStripMenuItem.Enabled = isImageLoaded;

            if (_image is RGBImage) {
                // Настройки для RGB изображений
                цветноеToolStripMenuItem.Enabled = false;
                полутоновоеToolStripMenuItem.Enabled = true;
                бинарноеToolStripMenuItem.Enabled = true;

                полутоновоеToolStripMenuItem.DropDownItems.Clear();
                полутоновоеToolStripMenuItem.DropDownItems.Add("Метод максимального", null, ConvertToGrayscaleMax_Click);
                полутоновоеToolStripMenuItem.DropDownItems.Add("Метод среднего", null, ConvertToGrayscaleAverage_Click);

                бинарноеToolStripMenuItem.DropDownItems.Clear();
                бинарноеToolStripMenuItem.DropDownItems.Add("Метод 40%", null, ConvertToBinary40Percent_Click);
                бинарноеToolStripMenuItem.DropDownItems.Add("Порог с экрана", null, ConvertToBinaryBorder_Click);

            }
            else if (_image is BinaryImage) {
                // Настройки для бинарных изображений
                цветноеToolStripMenuItem.Enabled = true;
                полутоновоеToolStripMenuItem.Enabled = true;
                бинарноеToolStripMenuItem.Enabled = false;

                полутоновоеToolStripMenuItem.DropDownItems.Clear();
                полутоновоеToolStripMenuItem.DropDownItems.Add("Городское расстояние", null, ConvertToUrbanDistance_Click);
            }
            else if (_image is GrayscaleImage) {
                // Настройки для изображений в градациях серого
                цветноеToolStripMenuItem.Enabled = true;
                полутоновоеToolStripMenuItem.Enabled = false;
                бинарноеToolStripMenuItem.Enabled = true;

                бинарноеToolStripMenuItem.DropDownItems.Clear();
                бинарноеToolStripMenuItem.DropDownItems.Add("Метод 40%", null, ConvertToBinary40Percent_Click);
                бинарноеToolStripMenuItem.DropDownItems.Add("Порог с экрана", null, ConvertToBinaryBorder_Click);
            }
        }

        private void ConvertToUrbanDistance_Click(object? sender, EventArgs e) {
            HandleAction(() => {
                _image = _image.toGrayscale(GrayscaleTransformationType.FromBinaryUrbanDistance);
                pictureBox1.Image = ImageProccesingUtils.MatrixToImage(_image.Pixels);
                UpdateMenuState();
            });
        }

        private void ConvertToBinary40Percent_Click(object? sender, EventArgs e) {
            HandleAction(() => {
                _image = _image.toBinary(BinaryTransformationType.FromGrayscaleFourtPrecent);
                pictureBox1.Image = ImageProccesingUtils.MatrixToImage(_image.Pixels);
                UpdateMenuState();
            });
        }

        private void ConvertToBinaryBorder_Click(object? sender, EventArgs e) {
            HandleAction(() => {
                _image = _image.toBinary(BinaryTransformationType.FromGrayscaleInputBorder);
                pictureBox1.Image = ImageProccesingUtils.MatrixToImage(_image.Pixels);
                UpdateMenuState();
            });
        }

        private void ConvertToGrayscaleAverage_Click(object? sender, EventArgs e) {
            HandleAction(() => {
                _image = _image.toGrayscale(GrayscaleTransformationType.FromRGBAverage);
                pictureBox1.Image = ImageProccesingUtils.MatrixToImage(_image.Pixels);
                UpdateMenuState();
            });
        }

        private void ConvertToGrayscaleMax_Click(object? sender, EventArgs e) {
            HandleAction(() => {
                _image = _image.toGrayscale(GrayscaleTransformationType.FromRGBMax);
                pictureBox1.Image = ImageProccesingUtils.MatrixToImage(_image.Pixels);
                UpdateMenuState();
            });
        }

        private void среднееЗначениеToolStripMenuItem_Click(object sender, EventArgs e) {
            HandleAction(() => {
                _image = FilterManager.AverageFilter(_image);
                pictureBox1.Image = ImageProccesingUtils.MatrixToImage(_image.Pixels);
                UpdateMenuState();
            });
        }

        private void пороговаяФильтрацияToolStripMenuItem_Click(object sender, EventArgs e) {
            HandleAction(() => {
                _image = FilterManager.ThresholdFilter(_image);
                pictureBox1.Image = ImageProccesingUtils.MatrixToImage(_image.Pixels);
                UpdateMenuState();
            });
        }

        private void эToolStripMenuItem_Click(object sender, EventArgs e) {
            HandleAction(() => {
                _image = MorphologicalManager.ErosiImage(_image);
                pictureBox1.Image = ImageProccesingUtils.MatrixToImage(_image.Pixels);
            });
        }
    }
}
