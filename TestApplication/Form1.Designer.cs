using System;
using NeuronNet.FunctionActivation;

namespace TestApplication
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.loadNetButton = new System.Windows.Forms.Button();
            this.SaveNetButton = new System.Windows.Forms.Button();
            this.AlphaValueTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ActivationFunckType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateNetButton = new System.Windows.Forms.Button();
            this.NeuronsInLayersTextBox = new System.Windows.Forms.TextBox();
            this.LayersCountTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.teachbutton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.correctLable = new System.Windows.Forms.Label();
            this.checkButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.outLable2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.outLable1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.learnProgressBar = new System.Windows.Forms.ProgressBar();
            this.testListBox = new System.Windows.Forms.ListBox();
            this.stepCountTextBox = new System.Windows.Forms.TextBox();
            this.learnSpeedtextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.examplesListBox = new System.Windows.Forms.ListBox();
            this.inputBox1 = new System.Windows.Forms.TextBox();
            this.inputBox5 = new System.Windows.Forms.TextBox();
            this.inputBox2 = new System.Windows.Forms.TextBox();
            this.inputBox3 = new System.Windows.Forms.TextBox();
            this.inputBox6 = new System.Windows.Forms.TextBox();
            this.inputBox7 = new System.Windows.Forms.TextBox();
            this.inputBox4 = new System.Windows.Forms.TextBox();
            this.outputBox1 = new System.Windows.Forms.TextBox();
            this.inputBox8 = new System.Windows.Forms.TextBox();
            this.outputBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AddTestButton = new System.Windows.Forms.Button();
            this.SaveTestsButton = new System.Windows.Forms.Button();
            this.DeeleteRowButton = new System.Windows.Forms.Button();
            this.SaveTestButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.testPictureBox = new System.Windows.Forms.PictureBox();
            this.addTestButton2 = new System.Windows.Forms.Button();
            this.cleanButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testPictureBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1519, 537);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.loadNetButton);
            this.tabPage1.Controls.Add(this.SaveNetButton);
            this.tabPage1.Controls.Add(this.AlphaValueTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.ActivationFunckType);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.CreateNetButton);
            this.tabPage1.Controls.Add(this.NeuronsInLayersTextBox);
            this.tabPage1.Controls.Add(this.LayersCountTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1511, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Нейронная сеть";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // loadNetButton
            // 
            this.loadNetButton.Location = new System.Drawing.Point(26, 156);
            this.loadNetButton.Name = "loadNetButton";
            this.loadNetButton.Size = new System.Drawing.Size(155, 23);
            this.loadNetButton.TabIndex = 12;
            this.loadNetButton.Text = "Load Net";
            this.loadNetButton.UseVisualStyleBackColor = true;
            // 
            // SaveNetButton
            // 
            this.SaveNetButton.Location = new System.Drawing.Point(187, 127);
            this.SaveNetButton.Name = "SaveNetButton";
            this.SaveNetButton.Size = new System.Drawing.Size(155, 23);
            this.SaveNetButton.TabIndex = 11;
            this.SaveNetButton.Text = "Save Net";
            this.SaveNetButton.UseVisualStyleBackColor = true;
            this.SaveNetButton.Click += new System.EventHandler(this.SaveNetButton_Click);
            // 
            // AlphaValueTextBox
            // 
            this.AlphaValueTextBox.Location = new System.Drawing.Point(168, 95);
            this.AlphaValueTextBox.Name = "AlphaValueTextBox";
            this.AlphaValueTextBox.Size = new System.Drawing.Size(150, 20);
            this.AlphaValueTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 98);
            this.label5.MaximumSize = new System.Drawing.Size(150, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Знначения параметра альфа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 76);
            this.label4.MaximumSize = new System.Drawing.Size(150, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Функция активации";
            // 
            // ActivationFunckType
            // 
            this.ActivationFunckType.FormattingEnabled = true;
            this.ActivationFunckType.Location = new System.Drawing.Point(168, 68);
            this.ActivationFunckType.Name = "ActivationFunckType";
            this.ActivationFunckType.Size = new System.Drawing.Size(150, 21);
            this.ActivationFunckType.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.MaximumSize = new System.Drawing.Size(150, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количество нейронов в каждом слое";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.MaximumSize = new System.Drawing.Size(150, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество слоёв";
            // 
            // CreateNetButton
            // 
            this.CreateNetButton.Location = new System.Drawing.Point(26, 127);
            this.CreateNetButton.Name = "CreateNetButton";
            this.CreateNetButton.Size = new System.Drawing.Size(155, 23);
            this.CreateNetButton.TabIndex = 3;
            this.CreateNetButton.Text = "Create Net";
            this.CreateNetButton.UseVisualStyleBackColor = true;
            this.CreateNetButton.Click += new System.EventHandler(this.CreateNetButton_Click);
            // 
            // NeuronsInLayersTextBox
            // 
            this.NeuronsInLayersTextBox.Location = new System.Drawing.Point(168, 42);
            this.NeuronsInLayersTextBox.Name = "NeuronsInLayersTextBox";
            this.NeuronsInLayersTextBox.Size = new System.Drawing.Size(150, 20);
            this.NeuronsInLayersTextBox.TabIndex = 1;
            this.NeuronsInLayersTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // LayersCountTextBox
            // 
            this.LayersCountTextBox.Location = new System.Drawing.Point(168, 16);
            this.LayersCountTextBox.Name = "LayersCountTextBox";
            this.LayersCountTextBox.Size = new System.Drawing.Size(150, 20);
            this.LayersCountTextBox.TabIndex = 0;
            this.LayersCountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.saveButton);
            this.tabPage3.Controls.Add(this.teachbutton);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.learnProgressBar);
            this.tabPage3.Controls.Add(this.testListBox);
            this.tabPage3.Controls.Add(this.stepCountTextBox);
            this.tabPage3.Controls.Add(this.learnSpeedtextBox);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1511, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Обучение";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(351, 357);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 24;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveNetButton_Click);
            // 
            // teachbutton
            // 
            this.teachbutton.Location = new System.Drawing.Point(270, 357);
            this.teachbutton.Name = "teachbutton";
            this.teachbutton.Size = new System.Drawing.Size(75, 23);
            this.teachbutton.TabIndex = 23;
            this.teachbutton.Text = "Обучить";
            this.teachbutton.UseVisualStyleBackColor = true;
            this.teachbutton.Click += new System.EventHandler(this.teachButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.correctLable);
            this.panel1.Controls.Add(this.checkButton);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.outLable2);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.textBox10);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.outLable1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBox9);
            this.panel1.Controls.Add(this.textBox8);
            this.panel1.Location = new System.Drawing.Point(432, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 445);
            this.panel1.TabIndex = 22;
            // 
            // correctLable
            // 
            this.correctLable.AutoSize = true;
            this.correctLable.BackColor = System.Drawing.Color.Red;
            this.correctLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.correctLable.Location = new System.Drawing.Point(171, 182);
            this.correctLable.Name = "correctLable";
            this.correctLable.Size = new System.Drawing.Size(49, 15);
            this.correctLable.TabIndex = 18;
            this.correctLable.Text = "Correct?";
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(112, 78);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(102, 20);
            this.checkButton.TabIndex = 17;
            this.checkButton.Text = "Проверить";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "1";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "1";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 78);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "1";
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 104);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "1";
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 130);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "1";
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(6, 156);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 12;
            this.textBox6.Text = "1";
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // outLable2
            // 
            this.outLable2.AutoSize = true;
            this.outLable2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outLable2.Location = new System.Drawing.Point(171, 159);
            this.outLable2.Name = "outLable2";
            this.outLable2.Size = new System.Drawing.Size(58, 15);
            this.outLable2.TabIndex = 5;
            this.outLable2.Text = "OutLabel2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Проверить результат";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(112, 52);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 20);
            this.textBox10.TabIndex = 16;
            this.textBox10.Text = "1";
            this.textBox10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(6, 182);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 13;
            this.textBox7.Text = "1";
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // outLable1
            // 
            this.outLable1.AutoSize = true;
            this.outLable1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outLable1.Location = new System.Drawing.Point(171, 137);
            this.outLable1.Name = "outLable1";
            this.outLable1.Size = new System.Drawing.Size(58, 15);
            this.outLable1.TabIndex = 1;
            this.outLable1.Text = "OutLabel1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Результат";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(112, 26);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 20);
            this.textBox9.TabIndex = 15;
            this.textBox9.Text = "1";
            this.textBox9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(6, 208);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 14;
            this.textBox8.Text = "1";
            this.textBox8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // learnProgressBar
            // 
            this.learnProgressBar.Location = new System.Drawing.Point(10, 313);
            this.learnProgressBar.Name = "learnProgressBar";
            this.learnProgressBar.Size = new System.Drawing.Size(416, 23);
            this.learnProgressBar.TabIndex = 21;
            // 
            // testListBox
            // 
            this.testListBox.FormattingEnabled = true;
            this.testListBox.HorizontalScrollbar = true;
            this.testListBox.Location = new System.Drawing.Point(10, 56);
            this.testListBox.Name = "testListBox";
            this.testListBox.Size = new System.Drawing.Size(416, 238);
            this.testListBox.TabIndex = 20;
            // 
            // stepCountTextBox
            // 
            this.stepCountTextBox.Location = new System.Drawing.Point(179, 30);
            this.stepCountTextBox.Name = "stepCountTextBox";
            this.stepCountTextBox.Size = new System.Drawing.Size(140, 20);
            this.stepCountTextBox.TabIndex = 18;
            this.stepCountTextBox.Text = "10000";
            this.stepCountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // learnSpeedtextBox
            // 
            this.learnSpeedtextBox.Location = new System.Drawing.Point(10, 29);
            this.learnSpeedtextBox.Name = "learnSpeedtextBox";
            this.learnSpeedtextBox.Size = new System.Drawing.Size(100, 20);
            this.learnSpeedtextBox.TabIndex = 17;
            this.learnSpeedtextBox.Text = "1";
            this.learnSpeedtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Скорость обучения";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(176, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Количество итераация";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(11, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Neuron Layer";
            // 
            // examplesListBox
            // 
            this.examplesListBox.FormattingEnabled = true;
            this.examplesListBox.HorizontalScrollbar = true;
            this.examplesListBox.Location = new System.Drawing.Point(8, 144);
            this.examplesListBox.Name = "examplesListBox";
            this.examplesListBox.Size = new System.Drawing.Size(489, 290);
            this.examplesListBox.TabIndex = 13;
            this.examplesListBox.SelectedIndexChanged += new System.EventHandler(this.examplesListBox_SelectedIndexChanged);
            // 
            // inputBox1
            // 
            this.inputBox1.Location = new System.Drawing.Point(8, 63);
            this.inputBox1.Name = "inputBox1";
            this.inputBox1.Size = new System.Drawing.Size(100, 20);
            this.inputBox1.TabIndex = 1;
            this.inputBox1.Enter += new System.EventHandler(this.textBox_Enter);
            this.inputBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // inputBox5
            // 
            this.inputBox5.Location = new System.Drawing.Point(8, 89);
            this.inputBox5.Name = "inputBox5";
            this.inputBox5.Size = new System.Drawing.Size(100, 20);
            this.inputBox5.TabIndex = 5;
            this.inputBox5.Enter += new System.EventHandler(this.textBox_Enter);
            this.inputBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // inputBox2
            // 
            this.inputBox2.Location = new System.Drawing.Point(114, 63);
            this.inputBox2.Name = "inputBox2";
            this.inputBox2.Size = new System.Drawing.Size(100, 20);
            this.inputBox2.TabIndex = 2;
            this.inputBox2.Enter += new System.EventHandler(this.textBox_Enter);
            this.inputBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // inputBox3
            // 
            this.inputBox3.Location = new System.Drawing.Point(220, 63);
            this.inputBox3.Name = "inputBox3";
            this.inputBox3.Size = new System.Drawing.Size(100, 20);
            this.inputBox3.TabIndex = 3;
            this.inputBox3.Enter += new System.EventHandler(this.textBox_Enter);
            this.inputBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // inputBox6
            // 
            this.inputBox6.Location = new System.Drawing.Point(114, 89);
            this.inputBox6.Name = "inputBox6";
            this.inputBox6.Size = new System.Drawing.Size(100, 20);
            this.inputBox6.TabIndex = 6;
            this.inputBox6.Enter += new System.EventHandler(this.textBox_Enter);
            this.inputBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // inputBox7
            // 
            this.inputBox7.Location = new System.Drawing.Point(220, 89);
            this.inputBox7.Name = "inputBox7";
            this.inputBox7.Size = new System.Drawing.Size(100, 20);
            this.inputBox7.TabIndex = 7;
            this.inputBox7.Enter += new System.EventHandler(this.textBox_Enter);
            this.inputBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // inputBox4
            // 
            this.inputBox4.Location = new System.Drawing.Point(326, 63);
            this.inputBox4.Name = "inputBox4";
            this.inputBox4.Size = new System.Drawing.Size(100, 20);
            this.inputBox4.TabIndex = 4;
            this.inputBox4.Enter += new System.EventHandler(this.textBox_Enter);
            this.inputBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // outputBox1
            // 
            this.outputBox1.Location = new System.Drawing.Point(500, 63);
            this.outputBox1.Name = "outputBox1";
            this.outputBox1.Size = new System.Drawing.Size(109, 20);
            this.outputBox1.TabIndex = 9;
            this.outputBox1.Enter += new System.EventHandler(this.textBox_Enter);
            this.outputBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTextBox);
            // 
            // inputBox8
            // 
            this.inputBox8.Location = new System.Drawing.Point(326, 89);
            this.inputBox8.Name = "inputBox8";
            this.inputBox8.Size = new System.Drawing.Size(100, 20);
            this.inputBox8.TabIndex = 8;
            this.inputBox8.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // outputBox2
            // 
            this.outputBox2.Location = new System.Drawing.Point(500, 89);
            this.outputBox2.Name = "outputBox2";
            this.outputBox2.Size = new System.Drawing.Size(109, 20);
            this.outputBox2.TabIndex = 10;
            this.outputBox2.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Входные данные";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(500, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Выходные значения";
            // 
            // AddTestButton
            // 
            this.AddTestButton.Location = new System.Drawing.Point(500, 115);
            this.AddTestButton.Name = "AddTestButton";
            this.AddTestButton.Size = new System.Drawing.Size(75, 23);
            this.AddTestButton.TabIndex = 11;
            this.AddTestButton.Text = "Добавить новый элемент";
            this.AddTestButton.UseVisualStyleBackColor = true;
            this.AddTestButton.Click += new System.EventHandler(this.AddTestButton_Click);
            // 
            // SaveTestsButton
            // 
            this.SaveTestsButton.Location = new System.Drawing.Point(179, 458);
            this.SaveTestsButton.Name = "SaveTestsButton";
            this.SaveTestsButton.Size = new System.Drawing.Size(141, 23);
            this.SaveTestsButton.TabIndex = 15;
            this.SaveTestsButton.Text = "Сохранить все тесты";
            this.SaveTestsButton.UseVisualStyleBackColor = true;
            this.SaveTestsButton.Click += new System.EventHandler(this.SaveTestsButton_Click);
            // 
            // DeeleteRowButton
            // 
            this.DeeleteRowButton.Location = new System.Drawing.Point(32, 458);
            this.DeeleteRowButton.Name = "DeeleteRowButton";
            this.DeeleteRowButton.Size = new System.Drawing.Size(141, 23);
            this.DeeleteRowButton.TabIndex = 14;
            this.DeeleteRowButton.Text = "Удалить строку";
            this.DeeleteRowButton.UseVisualStyleBackColor = true;
            this.DeeleteRowButton.Click += new System.EventHandler(this.DeleteRowButton_Click);
            // 
            // SaveTestButton
            // 
            this.SaveTestButton.Location = new System.Drawing.Point(581, 115);
            this.SaveTestButton.Name = "SaveTestButton";
            this.SaveTestButton.Size = new System.Drawing.Size(100, 23);
            this.SaveTestButton.TabIndex = 12;
            this.SaveTestButton.Text = "Сохранить тест";
            this.SaveTestButton.UseVisualStyleBackColor = true;
            this.SaveTestButton.Click += new System.EventHandler(this.SaveTestButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Сгенерировать тесты";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // testPictureBox
            // 
            this.testPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testPictureBox.Location = new System.Drawing.Point(503, 144);
            this.testPictureBox.Name = "testPictureBox";
            this.testPictureBox.Size = new System.Drawing.Size(250, 250);
            this.testPictureBox.TabIndex = 17;
            this.testPictureBox.TabStop = false;
            this.testPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // addTestButton2
            // 
            this.addTestButton2.Location = new System.Drawing.Point(615, 440);
            this.addTestButton2.Name = "addTestButton2";
            this.addTestButton2.Size = new System.Drawing.Size(132, 23);
            this.addTestButton2.TabIndex = 18;
            this.addTestButton2.Text = "Добавить тест";
            this.addTestButton2.UseVisualStyleBackColor = true;
            this.addTestButton2.Click += new System.EventHandler(this.addTestButton2_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(615, 414);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(132, 23);
            this.cleanButton.TabIndex = 22;
            this.cleanButton.Text = "Очистить";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(618, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 24);
            this.button2.TabIndex = 23;
            this.button2.Text = "Сгенерить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.GenerateTest_Button_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(618, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Сгенерить 100";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.generateMultyTests_ButtonClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.cleanButton);
            this.tabPage2.Controls.Add(this.addTestButton2);
            this.tabPage2.Controls.Add(this.testPictureBox);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.SaveTestButton);
            this.tabPage2.Controls.Add(this.DeeleteRowButton);
            this.tabPage2.Controls.Add(this.SaveTestsButton);
            this.tabPage2.Controls.Add(this.AddTestButton);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.outputBox2);
            this.tabPage2.Controls.Add(this.inputBox8);
            this.tabPage2.Controls.Add(this.outputBox1);
            this.tabPage2.Controls.Add(this.inputBox4);
            this.tabPage2.Controls.Add(this.inputBox7);
            this.tabPage2.Controls.Add(this.inputBox6);
            this.tabPage2.Controls.Add(this.inputBox3);
            this.tabPage2.Controls.Add(this.inputBox2);
            this.tabPage2.Controls.Add(this.inputBox5);
            this.tabPage2.Controls.Add(this.inputBox1);
            this.tabPage2.Controls.Add(this.examplesListBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1511, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Создание тестов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 548);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testPictureBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox NeuronsInLayersTextBox;
        private System.Windows.Forms.TextBox LayersCountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateNetButton;
        private System.Windows.Forms.ComboBox ActivationFunckType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AlphaValueTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SaveNetButton;
        private System.Windows.Forms.Button loadNetButton;
        private System.Windows.Forms.Button teachbutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label outLable2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label outLable1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.ProgressBar learnProgressBar;
        private System.Windows.Forms.ListBox testListBox;
        private System.Windows.Forms.TextBox stepCountTextBox;
        private System.Windows.Forms.TextBox learnSpeedtextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Button saveButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label correctLable;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.Button addTestButton2;
        private System.Windows.Forms.PictureBox testPictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveTestButton;
        private System.Windows.Forms.Button DeeleteRowButton;
        private System.Windows.Forms.Button SaveTestsButton;
        private System.Windows.Forms.Button AddTestButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox outputBox2;
        private System.Windows.Forms.TextBox inputBox8;
        private System.Windows.Forms.TextBox outputBox1;
        private System.Windows.Forms.TextBox inputBox4;
        private System.Windows.Forms.TextBox inputBox7;
        private System.Windows.Forms.TextBox inputBox6;
        private System.Windows.Forms.TextBox inputBox3;
        private System.Windows.Forms.TextBox inputBox2;
        private System.Windows.Forms.TextBox inputBox5;
        private System.Windows.Forms.TextBox inputBox1;
        private System.Windows.Forms.ListBox examplesListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

