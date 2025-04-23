namespace TI3
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblPrimeP = new Label();
            txtPrimeP = new TextBox();
            lblPrimeStatus = new Label();
            btnFindPrimitiveRoots = new Button();
            lstPrimitiveRoots = new ListBox();
            lblRoots = new Label();
            lblSelectedG = new Label();
            txtSelectedG = new TextBox();
            lblPrivateKeyX = new Label();
            txtPrivateKeyX = new TextBox();
            btnGeneratePublicKey = new Button();
            lblPublicKey = new Label();
            btnSelectInputFile = new Button();
            lblInputFile = new Label();
            lblKValue = new Label();
            txtKValue = new TextBox();
            txtInput = new TextBox();
            txtOutput = new TextBox();
            btnSaveOutput = new Button();
            lblInputData = new Label();
            lblOutputData = new Label();
            panelKeyGeneration = new Panel();
            panelFileOperations = new Panel();
            DecButton = new Button();
            EncButton = new Button();
            panelDataIO = new Panel();
            panelKeyGeneration.SuspendLayout();
            panelFileOperations.SuspendLayout();
            panelDataIO.SuspendLayout();
            SuspendLayout();
            // 
            // lblPrimeP
            // 
            lblPrimeP.AutoSize = true;
            lblPrimeP.Location = new Point(10, 9);
            lblPrimeP.Margin = new Padding(2, 0, 2, 0);
            lblPrimeP.Name = "lblPrimeP";
            lblPrimeP.Size = new Size(104, 15);
            lblPrimeP.TabIndex = 0;
            lblPrimeP.Text = "Простое число p:";
            // 
            // txtPrimeP
            // 
            txtPrimeP.BackColor = Color.White;
            txtPrimeP.Location = new Point(10, 27);
            txtPrimeP.Margin = new Padding(2);
            txtPrimeP.Name = "txtPrimeP";
            txtPrimeP.Size = new Size(141, 23);
            txtPrimeP.TabIndex = 1;
            txtPrimeP.TextChanged += txtPrimeP_TextChanged;
            // 
            // lblPrimeStatus
            // 
            lblPrimeStatus.AutoSize = true;
            lblPrimeStatus.Location = new Point(158, 29);
            lblPrimeStatus.Margin = new Padding(2, 0, 2, 0);
            lblPrimeStatus.Name = "lblPrimeStatus";
            lblPrimeStatus.Size = new Size(0, 15);
            lblPrimeStatus.TabIndex = 3;
            // 
            // btnFindPrimitiveRoots
            // 
            btnFindPrimitiveRoots.BackColor = Color.MediumPurple;
            btnFindPrimitiveRoots.Enabled = false;
            btnFindPrimitiveRoots.FlatStyle = FlatStyle.Flat;
            btnFindPrimitiveRoots.ForeColor = Color.White;
            btnFindPrimitiveRoots.Location = new Point(10, 54);
            btnFindPrimitiveRoots.Margin = new Padding(2);
            btnFindPrimitiveRoots.Name = "btnFindPrimitiveRoots";
            btnFindPrimitiveRoots.Size = new Size(196, 24);
            btnFindPrimitiveRoots.TabIndex = 4;
            btnFindPrimitiveRoots.Text = "Найти первообразные корни";
            btnFindPrimitiveRoots.UseVisualStyleBackColor = false;
            btnFindPrimitiveRoots.Click += btnFindPrimitiveRoots_Click;
            // 
            // lstPrimitiveRoots
            // 
            lstPrimitiveRoots.BackColor = Color.AliceBlue;
            lstPrimitiveRoots.FormattingEnabled = true;
            lstPrimitiveRoots.ItemHeight = 15;
            lstPrimitiveRoots.Location = new Point(259, 54);
            lstPrimitiveRoots.Margin = new Padding(2);
            lstPrimitiveRoots.Name = "lstPrimitiveRoots";
            lstPrimitiveRoots.Size = new Size(106, 154);
            lstPrimitiveRoots.TabIndex = 5;
            lstPrimitiveRoots.SelectedIndexChanged += lstPrimitiveRoots_SelectedIndexChanged;
            // 
            // lblRoots
            // 
            lblRoots.AutoSize = true;
            lblRoots.Location = new Point(266, 35);
            lblRoots.Margin = new Padding(2, 0, 2, 0);
            lblRoots.Name = "lblRoots";
            lblRoots.Size = new Size(99, 15);
            lblRoots.TabIndex = 6;
            lblRoots.Text = "Первообразные:";
            // 
            // lblSelectedG
            // 
            lblSelectedG.AutoSize = true;
            lblSelectedG.Location = new Point(10, 90);
            lblSelectedG.Margin = new Padding(2, 0, 2, 0);
            lblSelectedG.Name = "lblSelectedG";
            lblSelectedG.Size = new Size(136, 15);
            lblSelectedG.TabIndex = 7;
            lblSelectedG.Text = "Выбранный корень (g):";
            // 
            // txtSelectedG
            // 
            txtSelectedG.BackColor = Color.AliceBlue;
            txtSelectedG.Location = new Point(10, 108);
            txtSelectedG.Margin = new Padding(2);
            txtSelectedG.Name = "txtSelectedG";
            txtSelectedG.ReadOnly = true;
            txtSelectedG.Size = new Size(141, 23);
            txtSelectedG.TabIndex = 8;
            // 
            // lblPrivateKeyX
            // 
            lblPrivateKeyX.AutoSize = true;
            lblPrivateKeyX.Location = new Point(10, 135);
            lblPrivateKeyX.Margin = new Padding(2, 0, 2, 0);
            lblPrivateKeyX.Name = "lblPrivateKeyX";
            lblPrivateKeyX.Size = new Size(115, 15);
            lblPrivateKeyX.TabIndex = 9;
            lblPrivateKeyX.Text = "Закрытый ключ (x):";
            // 
            // txtPrivateKeyX
            // 
            txtPrivateKeyX.BackColor = Color.White;
            txtPrivateKeyX.Location = new Point(10, 153);
            txtPrivateKeyX.Margin = new Padding(2);
            txtPrivateKeyX.Name = "txtPrivateKeyX";
            txtPrivateKeyX.Size = new Size(141, 23);
            txtPrivateKeyX.TabIndex = 10;
            // 
            // btnGeneratePublicKey
            // 
            btnGeneratePublicKey.BackColor = Color.MediumPurple;
            btnGeneratePublicKey.FlatStyle = FlatStyle.Flat;
            btnGeneratePublicKey.ForeColor = Color.White;
            btnGeneratePublicKey.Location = new Point(10, 180);
            btnGeneratePublicKey.Margin = new Padding(2);
            btnGeneratePublicKey.Name = "btnGeneratePublicKey";
            btnGeneratePublicKey.Size = new Size(196, 24);
            btnGeneratePublicKey.TabIndex = 11;
            btnGeneratePublicKey.Text = "Сгенерировать открытый ключ";
            btnGeneratePublicKey.UseVisualStyleBackColor = false;
            btnGeneratePublicKey.Click += btnGeneratePublicKey_Click;
            // 
            // lblPublicKey
            // 
            lblPublicKey.AutoSize = true;
            lblPublicKey.Location = new Point(10, 213);
            lblPublicKey.Margin = new Padding(2, 0, 2, 0);
            lblPublicKey.Name = "lblPublicKey";
            lblPublicKey.Size = new Size(0, 15);
            lblPublicKey.TabIndex = 12;
            // 
            // btnSelectInputFile
            // 
            btnSelectInputFile.BackColor = Color.MediumPurple;
            btnSelectInputFile.FlatStyle = FlatStyle.Flat;
            btnSelectInputFile.ForeColor = Color.White;
            btnSelectInputFile.Location = new Point(14, 15);
            btnSelectInputFile.Margin = new Padding(2);
            btnSelectInputFile.Name = "btnSelectInputFile";
            btnSelectInputFile.Size = new Size(140, 24);
            btnSelectInputFile.TabIndex = 14;
            btnSelectInputFile.Text = "Выбрать файл";
            btnSelectInputFile.UseVisualStyleBackColor = false;
            btnSelectInputFile.Click += btnSelectInputFile_Click;
            // 
            // lblInputFile
            // 
            lblInputFile.AutoSize = true;
            lblInputFile.Location = new Point(158, 15);
            lblInputFile.Margin = new Padding(2, 0, 2, 0);
            lblInputFile.Name = "lblInputFile";
            lblInputFile.Size = new Size(0, 15);
            lblInputFile.TabIndex = 15;
            // 
            // lblKValue
            // 
            lblKValue.AutoSize = true;
            lblKValue.Location = new Point(14, 59);
            lblKValue.Margin = new Padding(2, 0, 2, 0);
            lblKValue.Name = "lblKValue";
            lblKValue.Size = new Size(16, 15);
            lblKValue.TabIndex = 18;
            lblKValue.Text = "k:";
            // 
            // txtKValue
            // 
            txtKValue.BackColor = Color.White;
            txtKValue.Location = new Point(34, 55);
            txtKValue.Margin = new Padding(2);
            txtKValue.Name = "txtKValue";
            txtKValue.Size = new Size(71, 23);
            txtKValue.TabIndex = 19;
            // 
            // txtInput
            // 
            txtInput.BackColor = Color.AliceBlue;
            txtInput.Location = new Point(10, 27);
            txtInput.Margin = new Padding(2);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(666, 92);
            txtInput.TabIndex = 22;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = Color.AliceBlue;
            txtOutput.Location = new Point(10, 147);
            txtOutput.Margin = new Padding(2);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(666, 92);
            txtOutput.TabIndex = 24;
            // 
            // btnSaveOutput
            // 
            btnSaveOutput.BackColor = Color.MediumPurple;
            btnSaveOutput.FlatStyle = FlatStyle.Flat;
            btnSaveOutput.ForeColor = Color.White;
            btnSaveOutput.Location = new Point(10, 246);
            btnSaveOutput.Margin = new Padding(2);
            btnSaveOutput.Name = "btnSaveOutput";
            btnSaveOutput.Size = new Size(140, 24);
            btnSaveOutput.TabIndex = 25;
            btnSaveOutput.Text = "Сохранить в файл";
            btnSaveOutput.UseVisualStyleBackColor = false;
            btnSaveOutput.Click += btnSaveOutput_Click;
            // 
            // lblInputData
            // 
            lblInputData.AutoSize = true;
            lblInputData.Location = new Point(10, 9);
            lblInputData.Margin = new Padding(2, 0, 2, 0);
            lblInputData.Name = "lblInputData";
            lblInputData.Size = new Size(101, 15);
            lblInputData.TabIndex = 21;
            lblInputData.Text = "Входные данные:";
            // 
            // lblOutputData
            // 
            lblOutputData.AutoSize = true;
            lblOutputData.Location = new Point(10, 129);
            lblOutputData.Margin = new Padding(2, 0, 2, 0);
            lblOutputData.Name = "lblOutputData";
            lblOutputData.Size = new Size(110, 15);
            lblOutputData.TabIndex = 23;
            lblOutputData.Text = "Выходные данные:";
            // 
            // panelKeyGeneration
            // 
            panelKeyGeneration.BackColor = Color.LightPink;
            panelKeyGeneration.Controls.Add(lblPrimeP);
            panelKeyGeneration.Controls.Add(txtPrimeP);
            panelKeyGeneration.Controls.Add(lblPrimeStatus);
            panelKeyGeneration.Controls.Add(btnFindPrimitiveRoots);
            panelKeyGeneration.Controls.Add(lstPrimitiveRoots);
            panelKeyGeneration.Controls.Add(lblRoots);
            panelKeyGeneration.Controls.Add(lblSelectedG);
            panelKeyGeneration.Controls.Add(txtSelectedG);
            panelKeyGeneration.Controls.Add(lblPrivateKeyX);
            panelKeyGeneration.Controls.Add(txtPrivateKeyX);
            panelKeyGeneration.Controls.Add(btnGeneratePublicKey);
            panelKeyGeneration.Controls.Add(lblPublicKey);
            panelKeyGeneration.Location = new Point(10, 9);
            panelKeyGeneration.Margin = new Padding(2);
            panelKeyGeneration.Name = "panelKeyGeneration";
            panelKeyGeneration.Size = new Size(367, 240);
            panelKeyGeneration.TabIndex = 26;
            // 
            // panelFileOperations
            // 
            panelFileOperations.BackColor = Color.LightPink;
            panelFileOperations.Controls.Add(DecButton);
            panelFileOperations.Controls.Add(EncButton);
            panelFileOperations.Controls.Add(btnSelectInputFile);
            panelFileOperations.Controls.Add(lblInputFile);
            panelFileOperations.Controls.Add(lblKValue);
            panelFileOperations.Controls.Add(txtKValue);
            panelFileOperations.Location = new Point(381, 9);
            panelFileOperations.Margin = new Padding(2);
            panelFileOperations.Name = "panelFileOperations";
            panelFileOperations.Size = new Size(292, 132);
            panelFileOperations.TabIndex = 27;
            // 
            // DecButton
            // 
            DecButton.BackColor = Color.MediumPurple;
            DecButton.FlatStyle = FlatStyle.Flat;
            DecButton.ForeColor = Color.White;
            DecButton.Location = new Point(149, 96);
            DecButton.Margin = new Padding(2);
            DecButton.Name = "DecButton";
            DecButton.Size = new Size(140, 24);
            DecButton.TabIndex = 30;
            DecButton.Text = "Расшифровать";
            DecButton.UseVisualStyleBackColor = false;
            DecButton.Click += DecButton_Click;
            // 
            // EncButton
            // 
            EncButton.BackColor = Color.MediumPurple;
            EncButton.FlatStyle = FlatStyle.Flat;
            EncButton.ForeColor = Color.White;
            EncButton.Location = new Point(14, 96);
            EncButton.Margin = new Padding(2);
            EncButton.Name = "EncButton";
            EncButton.Size = new Size(140, 24);
            EncButton.TabIndex = 29;
            EncButton.Text = "Шифровать";
            EncButton.UseVisualStyleBackColor = false;
            EncButton.Click += EncButton_Click;
            // 
            // panelDataIO
            // 
            panelDataIO.BackColor = Color.LightPink;
            panelDataIO.Controls.Add(lblInputData);
            panelDataIO.Controls.Add(txtInput);
            panelDataIO.Controls.Add(lblOutputData);
            panelDataIO.Controls.Add(txtOutput);
            panelDataIO.Controls.Add(btnSaveOutput);
            panelDataIO.Location = new Point(10, 258);
            panelDataIO.Margin = new Padding(2);
            panelDataIO.Name = "panelDataIO";
            panelDataIO.Size = new Size(686, 282);
            panelDataIO.TabIndex = 28;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(707, 552);
            Controls.Add(panelDataIO);
            Controls.Add(panelFileOperations);
            Controls.Add(panelKeyGeneration);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "TI3 - Шифрование Эль-Гамаля";
            panelKeyGeneration.ResumeLayout(false);
            panelKeyGeneration.PerformLayout();
            panelFileOperations.ResumeLayout(false);
            panelFileOperations.PerformLayout();
            panelDataIO.ResumeLayout(false);
            panelDataIO.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblPrimeP;
        private TextBox txtPrimeP;
        private Label lblPrimeStatus;
        private Button btnFindPrimitiveRoots;
        private ListBox lstPrimitiveRoots;
        private Label lblRoots;
        private Label lblSelectedG;
        private TextBox txtSelectedG;
        private Label lblPrivateKeyX;
        private TextBox txtPrivateKeyX;
        private Button btnGeneratePublicKey;
        private Label lblPublicKey;
        private Button btnSelectInputFile;
        private Label lblInputFile;
        private Label lblKValue;
        private TextBox txtKValue;
        private TextBox txtInput;
        private TextBox txtOutput;
        private Button btnSaveOutput;
        private Label lblInputData;
        private Label lblOutputData;
        private Panel panelKeyGeneration;
        private Panel panelFileOperations;
        private Panel panelDataIO;
        private Button DecButton;
        private Button EncButton;
    }
}