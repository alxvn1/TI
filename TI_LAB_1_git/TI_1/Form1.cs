using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TI_1
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        // Очистка полей
        void ClearMenuStripItem_Click(object sender, EventArgs e)
        {
            PlainTextBox.Clear();
            KeyTextBox.Clear();
            ResultTextBox.Clear();
        }

        // Обработка кнопки для шифрования/дешифрования
        void CalculateButton_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли метод Виженера
            if (VizhinerRadioButton.Checked)
            {
                // Получаем ключ Виженера и проверяем его на корректность
                string vigenerKey = Vigener.GetPlainTextOrKey(KeyTextBox.Text);
                if (string.IsNullOrEmpty(vigenerKey))
                {
                    MessageBox.Show("Проверьте ваш ключ, чтобы он содержал русские буквы", "Неправильный ключ");
                    return;
                }

                // Обновляем отображение ключа в текстовом поле
                KeyTextBox.Text = vigenerKey;
                MessageBox.Show($"Ключ: {vigenerKey}", "Отладка");

                // Выбираем функцию для шифрования или дешифрования в зависимости от выбранного радиобаттона
                Func<string, string, string> processFunction =
                    EncipherRadioButton.Checked ? Vigener.Encipher : Vigener.Decipher;

                // Выполняем операцию шифрования или дешифрования
                var result = processFunction(PlainTextBox.Text, vigenerKey);

                // Если результат пустой, выводим сообщение об ошибке
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Проверьте ваш вводимый текст, чтобы он содержал русские буквы", "Неправильный текст");
                    return;
                }

                // Отображаем результат в текстовом поле
                ResultTextBox.Text = result;
                return; // Возвращаемся, чтобы не продолжать выполнение для других методов шифрования
            }

            // Обработка для других методов шифрования (например, Columnar Transposition)
            string columnarKey = ColumnarTransposition.GetValidKey(KeyTextBox.Text);
            if (string.IsNullOrEmpty(columnarKey))
            {
                MessageBox.Show("Введите корректный ключ!", "Ошибка");
                return;
            }

            string inputText = ColumnarTransposition.GetValidPlainText(PlainTextBox.Text);
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Введите корректный текст!", "Ошибка");
                return;
            }

            if (EncipherRadioButton.Checked)
            {
                ResultTextBox.Text = ColumnarTransposition.Encrypt(inputText, columnarKey);
            }
            else
            {
                ResultTextBox.Text = ColumnarTransposition.Decrypt(inputText, columnarKey);
            }
        }

        // Очистка поля с результатом при изменении текста
        void PlainTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Clear();
        }

        // Сохранение результата в файл
        void SaveFileMenu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ResultTextBox.Text))
            {
                MessageBox.Show("Нет данных для сохранения", "Ошибка");
                return;
            }

            // Проверка сохранения файла
            var dialogResult = SaveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(SaveFileDialog.FileName, ResultTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка");
                }
            }
        }

        // Открытие файла
        void OpenFileMenu_Click(object sender, EventArgs e)
        {
            var dialogResult = OpenFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    // Чтение файла и обработка текста
                    PlainTextBox.Text = File.ReadAllText(OpenFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка");
                }
            }
        }
    }
}