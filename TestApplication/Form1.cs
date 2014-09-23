using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NeuronNet.FunctionActivation;
using TestApplication.ExamplesData;
using TestApplication.NeuralNetData;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        
        private ExamplesDataHelper exampleHelper;
        private NeuralNetDataHelper neuralNetDataHelper;

        
        private NetCreateTab netCreateTab;
        private TestCreateTab testCreateTab;
        private LearningNetTab learningNetTab;

        public Form1()
        {
            InitializeComponent();
            InitElements();
        }

        private void InitElements()
        {
            ActivationFunckType.DataSource = new[]
            {
                ActivationFunctionType.Sigma,
                ActivationFunctionType.HiberBallTangens,
                ActivationFunctionType.SimpleTest
            };

            comboBox2.DataSource = new[]
            {
                "Input",
                "Output"
            };

            GraphicsDrawer.Graphics = testPictureBox.CreateGraphics();
            GraphicsDrawer.DrawEllipses();

            this.neuralNetDataHelper = new NeuralNetDataHelper();
            netCreateTab = new NetCreateTab(this.neuralNetDataHelper)
            {
                ActivationFunckType = this.ActivationFunckType,
                AlphaValueTextBox = this.AlphaValueTextBox,
                LayersCountTextBox = this.LayersCountTextBox,
                NeuronsInLayersTextBox = this.NeuronsInLayersTextBox
            };
            netCreateTab.UpdateNetInfoFields();


            this.exampleHelper = new ExamplesDataHelper();
            var inputBoxes = new[] { inputBox1, inputBox2, inputBox3, inputBox4, inputBox5, inputBox6, inputBox7, inputBox8 };
            var outputBoxes = new[] { outputBox1, outputBox2 };
            testCreateTab = new TestCreateTab(exampleHelper, inputBoxes, outputBoxes)
            {
                TestPictureBox = testPictureBox,
                ExamplesListBox = examplesListBox
            };

            var testInputBoxes = new[] {textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8};
            var testOutputBoxes = new[] {textBox9, textBox10};     
            learningNetTab = new LearningNetTab
            {
                ExampleHelper = exampleHelper,
                NeuralNetDataHelper = neuralNetDataHelper,
                TestOutputBoxes = testOutputBoxes,
                TestInputBoxes = testInputBoxes,
                ExamplesListBox = examplesListBox,
                TestListBox = testListBox,
                CorrectLabel = correctLable,
                OutLabel1 = outLable1,
                OutLabel2 = outLable2,
                LearnSpeedtextBox = learnSpeedtextBox,
                StepCountTextBox = stepCountTextBox,
                BackgroundWorker = backgroundWorker,
                LearnProgressBar = learnProgressBar
            };
        }

        private void KeyPressTextBox(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || (e.KeyChar != '.' || e.KeyChar != ',')) return;
            if (e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void CreateNetButton_Click(object sender, EventArgs e)
        {
            netCreateTab.CreateNet();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.netCreateTab.SetActive();
            }

            if (tabControl1.SelectedIndex == 1)
            {
                this.testCreateTab.SetActive();
            }

            if (tabControl1.SelectedIndex == 2)
            {
                this.learningNetTab.SetActive();
            }
        }

        private void examplesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.testCreateTab.SelectExample();
        }

        private void AddTestButton_Click(object sender, EventArgs e)
        {
            this.testCreateTab.AddTest();
        }

        private void SaveTestButton_Click(object sender, EventArgs e)
        {
            this.testCreateTab.SaveTest();
        }

        private void SaveTestsButton_Click(object sender, EventArgs e)
        {
            this.exampleHelper.SaveExamples();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            var texBox = sender as TextBox;
            if (texBox == null) return;
            texBox.SelectionStart = 0;
            texBox.SelectionLength = texBox.Text.Length;
        }

        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            this.testCreateTab.DeleteSelectedExample();
        }

        private void SaveNetButton_Click(object sender, EventArgs e)
        {
            this.neuralNetDataHelper.SaveNeuralNet();
        }

        private void teachButton_Click(object sender, EventArgs e)
        {
            this.learningNetTab.StartLearn();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.learningNetTab.Learn(sender);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            learnProgressBar.Value = e.ProgressPercentage;
            learnProgressBar.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            learnProgressBar.Value = 0;
            learnProgressBar.Update();
        }
    
        private void checkButton_Click(object sender, EventArgs e)
        {
            this.learningNetTab.CheckNeuralNet();
        }

        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            Point point = new Point(e.X, e.Y);
            GraphicsDrawer.DrawEllipses();
            if (e.Button == MouseButtons.Right)
            {
                GraphicsDrawer.RemoveElement(point);
            }
            else 
                GraphicsDrawer.DrawNewElement(point);

            this.testCreateTab.AddCreatedTest();
        }

       

        private void addTestButton2_Click(object sender, EventArgs e)
        {
            this.testCreateTab.AddCreatedTest();
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            this.testCreateTab.CleanDrawBox();
        }


        private void GenerateTest_Button_Click(object sender, EventArgs e)
        {
            this.testCreateTab.GenerateTests();
        }

        private void generateMultyTests_ButtonClick(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                this.testCreateTab.GenerateTests();
                this.testCreateTab.AddTest();
            }
        }

    }
}
