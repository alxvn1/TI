/* using System.Text;

namespace TI_1
{
    public static class Vigener
    {
        public const int LetterCount = 33;

        // Получаем ключ или текст, проверяя его на допустимые символы
        public static string GetPlainTextOrKey(string str)
        {
            StringBuilder sb = new();
            foreach (char symbol in str)
            {
                var upperSymbol = char.ToUpper(symbol);
                if (upperSymbol is >= 'А' and <= 'Я' or 'Ё')
                    sb.Append(upperSymbol);
            }
            return sb.ToString();
        }

        // Получаем текст с пробелами
        private static string GetPlainTextWithSpaces(string str)
        {
            StringBuilder sb = new();
            foreach (char symbol in str)
            {
                var upperSymbol = char.ToUpper(symbol);
                if (upperSymbol is >= 'А' and <= 'Я' or 'Ё' or ' ')
                    sb.Append(upperSymbol);
            }
            return sb.ToString();
        }

        // Шифрование текста
        public static string Encipher(string plainText, string key)
        {
            plainText = GetPlainTextWithSpaces(plainText);
            var resultText = GetPlainTextOrKey(plainText);
            if (string.IsNullOrEmpty(resultText)) return "";

            // Массив всех символов
            char[] letterArray = GenerateLetterArray();

            StringBuilder sbCipherText = new StringBuilder();
            int index = 0;
            for (int i = 0; i < resultText.Length; i++)
            {
                char keyLetter = key[index % key.Length];
                int changedLetter = GetLetterIndex(resultText[i]);

                // Применение шифрования
                sbCipherText.Append(EncryptChar(changedLetter, keyLetter, letterArray));

                index++;
            }

            // Формируем результат с заменой пробелов
            return BuildResultText(plainText, sbCipherText);
        }

        // Дешифрование текста
        public static string Decipher(string cipher, string key)
        {
            cipher = GetPlainTextWithSpaces(cipher);
            var resultText = GetPlainTextOrKey(cipher);
            if (string.IsNullOrEmpty(resultText)) return "";

            // Массив всех символов
            char[] letterArray = GenerateLetterArray();

            StringBuilder sbPlainText = new StringBuilder();
            int index = 0;
            for (int i = 0; i < resultText.Length; i++)
            {
                char keyLetter = key[index % key.Length];
                int changedLetter = GetLetterIndex(resultText[i]);

                // Применение дешифрования
                sbPlainText.Append(DecryptChar(changedLetter, keyLetter, letterArray));

                index++;
            }

            // Формируем результат с заменой пробелов
            return BuildResultText(cipher, sbPlainText);
        }

        // Генерация массива всех букв
        private static char[] GenerateLetterArray()
        {
            char[] letterArray = new char[LetterCount];
            int letter = 0;
            for (char i = 'А'; i <= 'Я'; i++)
            {
                if (letter == 6)
                {
                    letterArray[letter++] = 'Ё';
                }
                letterArray[letter++] = i;
            }
            return letterArray;
        }

        // Получаем индекс буквы
        private static int GetLetterIndex(char letter)
        {
            if (letter == 'Ё') return 6;
            return letter <= 'Е' ? letter - 'А' : letter - 'А' + 1;
        }

        // Шифруем символ
        private static char EncryptChar(int changedLetter, char keyLetter, char[] letterArray)
        {
            int changedKeyLetter = GetLetterIndex(keyLetter);
            return letterArray[(changedLetter + changedKeyLetter) % LetterCount];
        }

        // Дешифруем символ
        private static char DecryptChar(int changedLetter, char keyLetter, char[] letterArray)
        {
            int changedKeyLetter = GetLetterIndex(keyLetter);
            return letterArray[(changedLetter + (LetterCount - changedKeyLetter)) % LetterCount];
        }

        // Формируем окончательный результат
        private static string BuildResultText(string originalText, StringBuilder sbCipherText)
        {
            StringBuilder sbResultText = new StringBuilder(originalText);
            int index = 0;
            for (int i = 0; i < sbResultText.Length; i++)
            {
                if (sbResultText[i] == ' ') continue;
                sbResultText[i] = sbCipherText[index++];
            }
            return sbResultText.ToString();
        }
    }
} */

using System.Text;
using System.Windows.Forms;

namespace TI_1
{
    public static class Vigener
    {
        public const int LetterCount = 33;

        // Получаем ключ или текст, проверяя его на допустимые символы
        public static string GetPlainTextOrKey(string str)
        {
            StringBuilder sb = new();
            foreach (char symbol in str)
            {
                var upperSymbol = char.ToUpper(symbol);
                if (upperSymbol is >= 'А' and <= 'Я' or 'Ё')
                    sb.Append(upperSymbol);
            }
            return sb.ToString();
        }

        // Получаем текст с пробелами
        private static string GetPlainTextWithSpaces(string str)
        {
            StringBuilder sb = new();
            foreach (char symbol in str)
            {
                var upperSymbol = char.ToUpper(symbol);
                if (upperSymbol is >= 'А' and <= 'Я' or 'Ё' or ' ')
                    sb.Append(upperSymbol);
            }
            return sb.ToString();
        }

        // Генерация самогенерирующегося ключа
        private static string GenerateDynamicKey(string key, string text)
        {
            StringBuilder fullKey = new StringBuilder(key);
            int keyLength = key.Length;
            int textLength = text.Length;

            // Добавляем символы текста к ключу, если текст длиннее ключа
            int index = 0;
            while (fullKey.Length < textLength)
            {
                fullKey.Append(text[index % textLength]);
                index++;
            }

            return fullKey.ToString();
        }

        // Шифрование текста
        public static string Encipher(string plainText, string key)
        {
            plainText = GetPlainTextWithSpaces(plainText);
            var resultText = GetPlainTextOrKey(plainText);
            if (string.IsNullOrEmpty(resultText)) return "";

            // Генерация самогенерирующегося ключа
            key = GenerateDynamicKey(key, resultText);
            MessageBox.Show($"Ключ: {key}", "Отладка");

            // Массив всех символов
            char[] letterArray = GenerateLetterArray();

            StringBuilder sbCipherText = new StringBuilder();
            int index = 0;
            for (int i = 0; i < resultText.Length; i++)
            {
                char keyLetter = key[index % key.Length];
                int changedLetter = GetLetterIndex(resultText[i]);

                // Применение шифрования
                sbCipherText.Append(EncryptChar(changedLetter, keyLetter, letterArray));

                index++;
            }

            // Формируем результат с заменой пробелов
            return BuildResultText(plainText, sbCipherText);
        }

        // Дешифрование текста
        public static string Decipher(string cipher, string key)
        {
            cipher = GetPlainTextWithSpaces(cipher);
            var resultText = GetPlainTextOrKey(cipher);
            if (string.IsNullOrEmpty(resultText)) return "";

            // Массив всех символов
            char[] letterArray = GenerateLetterArray();

            StringBuilder sbPlainText = new StringBuilder();
            StringBuilder dynamicKey = new StringBuilder(key); // Начальный ключ
            int index = 0;

            for (int i = 0; i < resultText.Length; i++)
            {
                char cipherChar = resultText[i];

                // Пропускаем пробелы
                if (cipherChar == ' ') 
                {
                    sbPlainText.Append(' '); 
                    continue;
                }

                // Дешифровка символа
                char keyLetter = dynamicKey[index % dynamicKey.Length]; // Используем ключ текущей длины
                int changedLetter = GetLetterIndex(cipherChar);
                char plainChar = DecryptChar(changedLetter, keyLetter, letterArray);
                sbPlainText.Append(plainChar);

                // После расшифровки, добавляем символ в конец ключа
                dynamicKey.Append(plainChar);  // Добавляем расшифрованный символ в ключ

                index++;
            }

            MessageBox.Show($"Ключ: {dynamicKey.ToString()}", "Отладка");

            // Формируем результат с заменой пробелов
            return BuildResultText(cipher, sbPlainText);
        }

        // Генерация массива всех букв
        private static char[] GenerateLetterArray()
        {
            char[] letterArray = new char[LetterCount];
            int letter = 0;
            for (char i = 'А'; i <= 'Я'; i++)
            {
                if (letter == 6)
                {
                    letterArray[letter++] = 'Ё';
                }
                letterArray[letter++] = i;
            }
            return letterArray;
        }

        // Получаем индекс буквы
        private static int GetLetterIndex(char letter)
        {
            if (letter == 'Ё') return 6;
            return letter <= 'Е' ? letter - 'А' : letter - 'А' + 1;
        }

        // Шифруем символ
        private static char EncryptChar(int changedLetter, char keyLetter, char[] letterArray)
        {
            int changedKeyLetter = GetLetterIndex(keyLetter);
            return letterArray[(changedLetter + changedKeyLetter) % LetterCount];
        }

        // Дешифруем символ
        private static char DecryptChar(int changedLetter, char keyLetter, char[] letterArray)
        {
            int changedKeyLetter = GetLetterIndex(keyLetter);
            return letterArray[(changedLetter + (LetterCount - changedKeyLetter)) % LetterCount];
        }

        // Формируем окончательный результат
        private static string BuildResultText(string originalText, StringBuilder sbCipherText)
        {
            StringBuilder sbResultText = new StringBuilder(originalText);
            int index = 0;
            for (int i = 0; i < sbResultText.Length; i++)
            {
                if (sbResultText[i] == ' ') continue;
                if (sbResultText[i] != ' ') 
                {
                    sbResultText[i] = sbCipherText[index++];
                }
                ;
            }
            return sbResultText.ToString();
        }
    }
}
