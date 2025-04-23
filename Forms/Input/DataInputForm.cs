using System;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace GraficEditor.Forms {
    /// <summary>
    /// Форма для ввода данных пользователем.
    /// Позволяет задавать текстовую подсказку и получать вводимые данные.
    /// </summary>
    public partial class DataInputForm : Form {
        /// <summary>
        /// Свойство для хранения введенных данных пользователем.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? InputData { get; private set; } = null;

        /// <summary>
        /// Свойство для хранения текста подсказки.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? PromptMessage { get; private set; } = null;

        /// <summary>
        /// Конструктор формы.
        /// Выполняет инициализацию визуальных компонентов.
        /// </summary>
        public DataInputForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для установки текста подсказки пользователю.
        /// </summary>
        /// <param name="promptMessage">Текст подсказки.</param>
        public void SetPromptMessage(string promptMessage) {
            PromptMessage = promptMessage;
            label1.Text = promptMessage;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки подтверждения ввода.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void button1_Click(object sender, EventArgs e) {
            InputData = textBox1.Text; // Сохраняем данные из текстового поля.
            textBox1.Text = "";
            this.DialogResult = DialogResult.OK; // Устанавливаем результат диалога как "OK".
            this.Close(); // Закрываем форму.
        }

        /// <summary>
        /// Обработчик события нажатия кнопки отмены.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void button2_Click(object sender, EventArgs e) {
            textBox1.Text = "";
            this.DialogResult = DialogResult.Cancel; // Устанавливаем результат диалога как "Cancel".
            this.Close(); // Закрываем форму.
        }
    }
}
