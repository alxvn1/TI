namespace TI3
{
    public partial class MainForm : Form
    {
        private Encrypter elGamal;
        private List<int> primitiveRoots;
        private string inputFilePath;
        private byte[] inputFileBytes;
        private byte[] encryptedFileData;
        private byte[] decryptedFileData;

        bool isEncrypted;
        public List<byte> ByteArray { get; set; }

        public MainForm()
        {
            InitializeComponent();
            elGamal = new Encrypter();
        }

        private void txtPrimeP_TextChanged(object sender, EventArgs e)
        {
            lblPrimeStatus.Text = "";
            btnFindPrimitiveRoots.Enabled = false;

            if (int.TryParse(txtPrimeP.Text, out int p))
            {
                bool isPrime = Prime.IsPrime(p);
                lblPrimeStatus.Text = isPrime ? $"{p} - простое число" : $"{p} - не является простым числом";
                lblPrimeStatus.ForeColor = isPrime ? Color.Green : Color.Red;
                btnFindPrimitiveRoots.Enabled = isPrime;
            }
            else if (!string.IsNullOrEmpty(txtPrimeP.Text))
            {
                lblPrimeStatus.Text = "Некорректный формат числа";
                lblPrimeStatus.ForeColor = Color.Red;
            }
        }

        private void btnFindPrimitiveRoots_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPrimeP.Text, out int p))
            {
                lstPrimitiveRoots.Items.Clear();
                primitiveRoots = Roots.FindPrimitiveRoots(p);
                lblRoots.Text = "Кол-во корней: " + primitiveRoots.Count.ToString();
                if (primitiveRoots.Count > 0)
                {
                    foreach (var root in primitiveRoots)
                    {
                        lstPrimitiveRoots.Items.Add(root.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Первообразные корни не найдены", "Результат поиска", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void lstPrimitiveRoots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPrimitiveRoots.SelectedIndex != -1)
            {
                txtSelectedG.Text = lstPrimitiveRoots.SelectedItem.ToString();
            }
        }

        private void btnGeneratePublicKey_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPrimeP.Text, out int p) &&
                int.TryParse(txtSelectedG.Text, out int g) &&
                int.TryParse(txtPrivateKeyX.Text, out int x))
            {
                if (x >= p - 1 || x <= 1)
                {
                    MessageBox.Show("Закрытый ключ x должен быть: 1 < x < p-1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                elGamal.GenerateKeys(p, g, x);
                lblPublicKey.Text = $"Y: ({elGamal.Y})";
            }
            else
            {
                MessageBox.Show("Проверьте корректность введенных данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectInputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputFilePath = openFileDialog.FileName;
                try
                {
                    inputFileBytes = File.ReadAllBytes(openFileDialog.FileName);
                    lblInputFile.Text = Path.GetFileName(openFileDialog.FileName);

                    if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".enc")
                    {
                        if (inputFileBytes.Length % 4 != 0)
                        {
                            MessageBox.Show("Некорректный формат .enc файла (должно быть кратно 4 байтам)");
                            return;
                        }

                        List<string> pairs = new List<string>();
                        for (int i = 0; i < inputFileBytes.Length; i += 4)
                        {
                            ushort a = BitConverter.ToUInt16(inputFileBytes, i);
                            ushort b = BitConverter.ToUInt16(inputFileBytes, i + 2);
                            pairs.Add($"({a}, {b})");
                        }
                        txtInput.Text = string.Join(" ", pairs);
                    }
                    else
                    {
                        txtInput.Text = string.Join(" ", inputFileBytes.Select(b => b.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EncButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputFilePath))
            {
                MessageBox.Show("Выберите файл для шифрования");
                return;
            }

            if (!int.TryParse(txtKValue.Text, out int k) || k <= 1 || k >= elGamal.P - 1)
            {
                MessageBox.Show($"k должно быть: 1 < k < {elGamal.P - 1}");
                return;
            }

            try
            {
                byte[] data = File.ReadAllBytes(inputFilePath);
                txtOutput.Clear();

                ByteArray = new List<byte>(data);
                List<byte> encryptedData = new List<byte>();
                List<string> encryptedPairs = new List<string>();

                foreach (byte b in data)
                {
                    var encrypted = elGamal.Encrypt(b, k);
                    encryptedData.AddRange(BitConverter.GetBytes((ushort)encrypted.a));
                    encryptedData.AddRange(BitConverter.GetBytes((ushort)encrypted.b));
                    encryptedPairs.Add($"({encrypted.a}, {encrypted.b})");
                }

                encryptedFileData = encryptedData.ToArray();
                txtOutput.Text = string.Join(" ", encryptedPairs);
                MessageBox.Show("Файл успешно зашифрован", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isEncrypted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при шифровании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DecButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputFilePath))
            {
                MessageBox.Show("Выберите файл для дешифрования");
                return;
            }

            try
            {
                byte[] data = File.ReadAllBytes(inputFilePath);
                txtOutput.Clear();

                if (data.Length % 4 != 0)
                {
                    MessageBox.Show("Некорректный формат данных (должно быть кратно 4 байтам)");
                    return;
                }

                List<byte> decryptedBytes = new List<byte>();

                for (int i = 0; i < data.Length; i += 4)
                {
                    ushort a = BitConverter.ToUInt16(data, i);
                    ushort b = BitConverter.ToUInt16(data, i + 2);
                    int decrypted = elGamal.Decrypt(a, b);

                    if (decrypted < 0 || decrypted > 255)
                    {
                        MessageBox.Show($"Ошибка: некорректное значение {decrypted}");
                        return;
                    }

                    decryptedBytes.Add((byte)decrypted);
                }

                decryptedFileData = decryptedBytes.ToArray();
                txtOutput.Text = string.Join(" ", decryptedBytes.Select(b => b.ToString()));
                MessageBox.Show("Файл успешно дешифрован", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isEncrypted = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при дешифровании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = isEncrypted
                ? "Зашифрованные файлы (*.enc)|*.enc|Все файлы (*.*)|*.*"
                : "Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] dataToSave = isEncrypted ? encryptedFileData : decryptedFileData;

                    if (dataToSave == null || dataToSave.Length == 0)
                    {
                        MessageBox.Show("Нет данных для сохранения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    File.WriteAllBytes(saveFileDialog.FileName, dataToSave);
                    MessageBox.Show("Файл успешно сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

//< Project Sdk = "Microsoft.NET.Sdk" >

//  < PropertyGroup >
//    < OutputType > WinExe </ OutputType >
//    < TargetFramework > net8.0 - windows </ TargetFramework >
//    < Nullable > enable </ Nullable >
//    < UseWindowsForms > true </ UseWindowsForms >
//    < ImplicitUsings > enable </ ImplicitUsings >
//  </ PropertyGroup >

//</ Project >