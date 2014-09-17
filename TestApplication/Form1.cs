using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NeuronNet;
using NeuronNet.FunctionActivation;
using NeuronNet.Serialize;
using TestApplication.ExamplesData;
using TestApplication.NeuralNetData;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        private TextBox[] inputBoxes;
        private TextBox[] outputBoxes;
        private TextBox[] testInputBoxes;
        private TextBox[] testOutputBoxes;

        private ExamplesDataHelper exampleHelper;
        private NeuralNetDataHelper neuralNetData;

        private double speed;
        private int maxCount;
        
        public Form1()
        {
            InitializeComponent();
            InitElements();
        }

        private void InitElements()
        {
            this.inputBoxes = new[] {inputBox1, inputBox2, inputBox3, inputBox4, inputBox5, inputBox6, inputBox7, inputBox8};
            this.outputBoxes = new[] {outputBox1, outputBox2};

            this.testInputBoxes = new[] {textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8};
            this.testOutputBoxes = new[] {textBox9, textBox10};


            this.neuralNetData = new NeuralNetDataHelper();
            this.neuralNetData.LoadNeuralNet();

            if (this.neuralNetData.NET != null)
            {
                UpdateNetInfoFields();
            }
            this.exampleHelper = new ExamplesDataHelper();
            this.exampleHelper.LoadExamples();

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
        }

        private void UpdateNetInfoFields()
        {
            LayersCountTextBox.Text = neuralNetData.NET.LayersCount.ToString();
            string result = string.Empty;
            if (neuralNetData.NET.LayersCount > 0)
            {
                for (int i = 0; i < neuralNetData.NET.LayersCount - 1; i++)
                {
                    result += neuralNetData.NET[i].NeuronsCount.ToString() + ',';
                }
                result += neuralNetData.NET[neuralNetData.NET.LayersCount - 1].NeuronsCount.ToString();
            }
            NeuronsInLayersTextBox.Text = result;
            ActivationFunckType.SelectedItem = this.neuralNetData.NET.Type;
            AlphaValueTextBox.Text = this.neuralNetData.NET.Alpha.ToString();
        }

        #region event handlers
        private void KeyPressTextBox(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar != '.' || e.KeyChar != ',')))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void CreateNetButton_Click(object sender, EventArgs e)
        {
            int layersCount;
            int[] neuronsInLayer;
            double alpha;
            ActivationFunctionType activationFunctionType;
            try
            {
                layersCount = Int32.Parse(LayersCountTextBox.Text);
                neuronsInLayer = new int[layersCount];
                string[] values = NeuronsInLayersTextBox.Text.Split(',');
                if(values.Length != layersCount)
                    throw new InvalidDataException(string.Format("{0} layers count", values.Length));

                for (int i = 0; i < layersCount; i++)
                {
                    neuronsInLayer[i] = Int32.Parse(values[i]);
                }

                activationFunctionType = (ActivationFunctionType)ActivationFunckType.SelectedItem;
                string str = AlphaValueTextBox.Text.Replace('.', ',');
                alpha = double.Parse(str);
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }

            neuralNetData.NET = new NeuralNetwork(neuronsInLayer, activationFunctionType, alpha);
            this.neuralNetData.SaveNeuralNet();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (neuralNetData.NET == null)
                {
                    neuralNetData.LoadNeuralNet();
                }
                UpdateNetInfoFields();
            }

            if (tabControl1.SelectedIndex == 1)
            {
                GraphicsDrawer.CenterX= testPictureBox.Width * 0.5f;
                GraphicsDrawer.CenterY = testPictureBox.Height * 0.5f;
                GraphicsDrawer.Radius = GraphicsDrawer.CenterX;
                GraphicsDrawer.DrawEllipses();
                examplesListBox.Items.Clear();
                foreach (var example in this.exampleHelper.Examples)
                {
                    examplesListBox.Items.Add(Serializer.SerializeExample(example));
                }
                examplesListBox.Update();
                testPictureBox.Update();
                GraphicsDrawer.DrawEllipses();
            }

            if (tabControl1.SelectedIndex == 2)
            {

                testListBox.Items.Clear();
                foreach (var example in this.exampleHelper.Examples)
                {
                    testListBox.Items.Add(Serializer.SerializeExample(example));
                }
                examplesListBox.Update();
            }
        }

        private void examplesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = examplesListBox.SelectedItem as string;

            var example = Deserializer.DeserializeExample(data);
            if (example == null) return;
            try
            {
                for (int i = 0; i < this.inputBoxes.Length; i++)
                {
                    this.inputBoxes[i].Text = example.InputValues[i].ToString();
                }
                for (int i = 0; i < this.outputBoxes.Length; i++)
                {
                    this.outputBoxes[i].Text = example.OutputValues[i].ToString();
                }
            }
            catch (Exception)
            {
                DeleteRowButton_Click(sender, e);
            }
        }

        private void AddTestButton_Click(object sender, EventArgs e)
        {
            var example = new Example
            {
                InputValues = new double[this.inputBoxes.Length],
                OutputValues = new double[this.outputBoxes.Length]
            };

            for (int i = 0; i < this.inputBoxes.Length; i++)
            {
                if (string.IsNullOrEmpty(this.inputBoxes[i].Text)) return;
                example.InputValues[i] = double.Parse(this.inputBoxes[i].Text.Replace('.', ','));
            }

            for (int i = 0; i < this.outputBoxes.Length; i++)
            {
                if (string.IsNullOrEmpty(this.inputBoxes[i].Text)) return;
                example.OutputValues[i] = double.Parse(this.outputBoxes[i].Text.Replace('.', ','));
            }
            this.exampleHelper.Examples.Add(example);
            examplesListBox.Items.Add(Serializer.SerializeExample(example));
        }

        private void SaveTestButton_Click(object sender, EventArgs e)
        {
            var example = new Example
            {
                InputValues = new double[this.inputBoxes.Length],
                OutputValues = new double[this.outputBoxes.Length]
            };

            for (int i = 0; i < this.inputBoxes.Length; i++)
            {
                if (string.IsNullOrEmpty(this.inputBoxes[i].Text)) return;
                example.InputValues[i] = double.Parse(this.inputBoxes[i].Text.Replace('.', ','));
            }

            for (int i = 0; i < this.outputBoxes.Length; i++)
            {
                if (string.IsNullOrEmpty(this.outputBoxes[i].Text)) return;
                example.OutputValues[i] = double.Parse(this.outputBoxes[i].Text.Replace('.', ','));
            }
            var index = examplesListBox.SelectedIndex;
            this.exampleHelper.Examples[index] = example;
            examplesListBox.Items[index] = Serializer.SerializeExample(example);
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
            int index = examplesListBox.SelectedIndex;
            this.exampleHelper.Examples.RemoveAt(index);
            examplesListBox.Items.RemoveAt(index);

            if (examplesListBox.Items.Count > 0)
                examplesListBox.SelectedIndex = 0;
        }

        private void SaveNetButton_Click(object sender, EventArgs e)
        {
            this.neuralNetData.SaveNeuralNet();
        }

        private void teachButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy) return;

            speed = double.Parse(lernSpeedtextBox.Text.Replace('.', ','));
            maxCount = Int32.Parse(stepCountTextBox.Text);
            learnProgressBar.Maximum = maxCount;
            backgroundWorker.RunWorkerAsync();
        }


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            for (int i = 0; i < maxCount; i++)
            {
                foreach (var example in this.exampleHelper.Examples)
                {

                    this.neuralNetData.NET.TeachNeuronNet(example, speed);

                }
                speed *= 0.9999f;


                Console.WriteLine();
                if (worker != null) worker.ReportProgress(i);
            }
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
            var example = new Example
            {
                InputValues = new double[this.testInputBoxes.Length],
                OutputValues = new double[this.testOutputBoxes.Length]
            };

            for (int i = 0; i < this.testInputBoxes.Length; i++)
            {
                if (string.IsNullOrEmpty(this.testInputBoxes[i].Text)) return;
                example.InputValues[i] = double.Parse(this.testInputBoxes[i].Text.Replace('.', ','));
            }

            for (int i = 0; i < this.testOutputBoxes.Length; i++)
            {
                if (string.IsNullOrEmpty(this.testOutputBoxes[i].Text)) return;
                example.OutputValues[i] = double.Parse(this.testOutputBoxes[i].Text.Replace('.', ','));
            }


            var result = this.neuralNetData.NET.NextStep(example.InputValues);
            outLable1.Text = result[0].ToString();
            outLable2.Text = result[1].ToString();

            bool isCorrect = Math.Abs(result[0] - example.OutputValues[0]) <= 0.1 &&
                           Math.Abs(result[1] - example.OutputValues[1]) <= 0.1;
            correctLable.Text = isCorrect ? "correct" : "incorrect!";
            correctLable.BackColor = isCorrect ? Color.LimeGreen : Color.Red;
        }

        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            GraphicsDrawer.DrawNewElement(point);
        }

       

        private void addTestButton2_Click(object sender, EventArgs e)
        {
            Example example = new Example {InputValues = new double[8]};
            for (int i = 0; i < example.InputValues.Length; i++)
            {
                example.InputValues[i] = 1f;
            }

            PointF centre = new PointF(0, 0);
            foreach (PointF inputPoint in GraphicsDrawer.InputPoints)
            {
                double magnitude = Math.Sqrt(inputPoint.X * inputPoint.X + inputPoint.Y * inputPoint.Y);
                double Angle = (((GraphicsDrawer.GetSimpleAngle(inputPoint) / 8f) + 0.0625f) * 2 * Math.PI);
                centre.X += (float)(Math.Cos(Angle) * magnitude);
                centre.Y += (float)(Math.Sin(Angle) * magnitude);
                example.InputValues[GraphicsDrawer.GetSimpleAngle(inputPoint)] = magnitude;
            }
            var x = (centre.X / GraphicsDrawer.InputPoints.Count);
            var y = (centre.Y / GraphicsDrawer.InputPoints.Count);
            var resultR = Math.Sqrt(x * x + y * y);

            double resultAngle = (Math.Atan2(y, x) + Math.PI);
            resultAngle /= (Math.PI * 2);

            //todo: remove this debug code! 
            Console.WriteLine(resultAngle);
            
            int j = 0;
            foreach (TextBox inputBox in this.inputBoxes)
            {
                inputBox.Text = example.InputValues[j++].ToString();
            }
            example.OutputValues = new[] { 1 - resultR, resultAngle };
            j = 0;
            foreach (TextBox outputBox in this.outputBoxes)
            {
                outputBox.Text = example.OutputValues[j++].ToString();
            }
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            GraphicsDrawer.DrawEllipses();
            GraphicsDrawer.InputPoints.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void GenerateTest_Button_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            PictureBox pictureBox = testPictureBox;
            Graphics graphics = pictureBox.CreateGraphics();
            graphics.Clear(Color.White);
            GraphicsDrawer.DrawEllipses();

            GraphicsDrawer.InputPoints = new List<PointF>();
            Random rnd = new Random();
            for (int j = 0; j < 8; j++)
            {

                Point point = new Point(rnd.Next(0, 2) * 2 - 1, rnd.Next(0, 2 ) * 2 - 1);
                GraphicsDrawer.DrawNewElement(point);
                var r = Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
                if (r < 1)
                {
                    graphics.Clear(Color.White);
                    GraphicsDrawer.DrawEllipses();
                    Console.WriteLine("{0} {1}", point, r);
                    GraphicsDrawer.GetSimpleAngle(point);
                    bool isnewPoint = true;
                    for (int i = 0; i < GraphicsDrawer.InputPoints.Count; i++)
                    {


                        if (GraphicsDrawer.GetSimpleAngle(GraphicsDrawer.InputPoints[i])
                            == GraphicsDrawer.GetSimpleAngle(point))
                        {
                            GraphicsDrawer.InputPoints[i] = point;
                            isnewPoint = false;
                        }
                        graphics.DrawLine(new Pen(Color.Crimson), GraphicsDrawer.CenterX, GraphicsDrawer.CenterY,
                                          (GraphicsDrawer.InputPoints[i].X * GraphicsDrawer.Radius)
                                          + GraphicsDrawer.CenterX,
                                          (GraphicsDrawer.InputPoints[i].Y * -GraphicsDrawer.Radius)
                                          + GraphicsDrawer.CenterY);
                        graphics.FillEllipse(new SolidBrush(Color.DarkRed),
                                             new RectangleF(
                                                             (GraphicsDrawer.InputPoints[i].X * GraphicsDrawer.Radius)
                                                             + GraphicsDrawer.CenterX,
                                                             (GraphicsDrawer.InputPoints[i].Y * -GraphicsDrawer.Radius)
                                                             + GraphicsDrawer.CenterY, 5, 5));
                    }
                    if (isnewPoint)
                    {
                        GraphicsDrawer.InputPoints.Add(point);
                        graphics.DrawLine(new Pen(Color.Crimson), GraphicsDrawer.CenterX, GraphicsDrawer.CenterY,
                                          (point.X * GraphicsDrawer.Radius) + GraphicsDrawer.CenterX,
                                          (point.Y * -GraphicsDrawer.Radius) + GraphicsDrawer.CenterY);
                        graphics.FillEllipse(new SolidBrush(Color.DarkRed),
                                             new RectangleF((point.X * GraphicsDrawer.Radius) + GraphicsDrawer.CenterX,
                                                            (point.Y * -GraphicsDrawer.Radius) + GraphicsDrawer.CenterY, 5, 5));
                    }
                }
            }
            addTestButton2_Click(sender, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                GenerateTest_Button_Click(sender, e);
                AddTestButton_Click(sender, null);
            }
        }

        #endregion
    }
}
