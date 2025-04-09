using System.ComponentModel;

namespace GraficEditor.Forms {
    /// <summary>
    /// Форма для ввода данных пользователем.
    /// Позволяет вводить текстовые данные, которые могут использоваться в дальнейшем.
    /// </summary>
    public partial class DataInputForm : Form {
        /// <summary>
        /// Свойство для хранения введенных данных пользователем.
        /// Данные будут доступны после закрытия формы.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? InputData { get; private set; } = null;

        /// <summary>
        /// Конструктор формы.
        /// Выполняет инициализацию визуальных компонентов интерфейса.
        /// </summary>
        public DataInputForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки подтверждения ввода.
        /// Выполняет сохранение введенных данных и закрытие формы с положительным результатом.
        /// </summary>
        /// <param name="sender">Источник события (кнопка подтверждения).</param>
        /// <param name="e">Данные о событии.</param>
        private void button1_Click(object sender, EventArgs e) {
            InputData = textBox1.Text; // Сохраняем данные из текстового поля
            this.DialogResult = DialogResult.OK; // Устанавливаем результат диалога как "OK"
            this.Close(); // Закрываем форму
        }

        /// <summary>
        /// Обработчик события нажатия кнопки отмены.
        /// Закрывает форму без сохранения данных и с отрицательным результатом.
        /// </summary>
        /// <param name="sender">Источник события (кнопка отмены).</param>
        /// <param name="e">Данные о событии.</param>
        private void button2_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel; // Устанавливаем результат диалога как "Cancel"
            this.Close(); // Закрываем форму
        }
    }
}
