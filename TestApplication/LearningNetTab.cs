using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NeuroNet;
using NeuronNet;
using NeuronNet.Serialize;
using TestApplication.ExamplesData;
using TestApplication.NeuralNetData;

namespace TestApplication
{
    public class LearningNetTab
    {

        private double speed;
        private int maxCount;
        private BackPropagationLearning Learning;

        public TextBox[] TestInputBoxes { get; set; }
        public TextBox[] TestOutputBoxes { get; set; }

        public NeuralNetDataHelper NeuralNetDataHelper { get; set; }
        public ExamplesDataHelper ExampleHelper { get; set; }
        public ListBox TestListBox { get; set; }
        public ListBox ExamplesListBox { get; set; }
        public Label OutLabel1 { get; set; }
        public Label OutLabel2 { get; set; }
        public Label CorrectLabel { get; set; }
        public TextBox LearnSpeedtextBox { get; set; }
        public TextBox StepCountTextBox { get; set; }
        public ProgressBar LearnProgressBar { get; set; }
        public BackgroundWorker BackgroundWorker { get; set; }

        public void CheckNeuralNet()
        {
            var example = new Example
            {
                InputValues = new double[this.TestInputBoxes.Length],
                OutputValues = new double[this.TestOutputBoxes.Length]
            };

            for (int i = 0; i < this.TestInputBoxes.Length; i++)
            {
                if (string.IsNullOrEmpty(this.TestInputBoxes[i].Text)) return;
                example.InputValues[i] = double.Parse(this.TestInputBoxes[i].Text.Replace('.', ','));
            }

            for (int i = 0; i < this.TestOutputBoxes.Length; i++)
            {
                if (string.IsNullOrEmpty(this.TestOutputBoxes[i].Text)) return;
                example.OutputValues[i] = double.Parse(this.TestOutputBoxes[i].Text.Replace('.', ','));
            }


            var result = this.NeuralNetDataHelper.Network.NextStep(example.InputValues);
            OutLabel1.Text = result[0].ToString();
            OutLabel2.Text = result[1].ToString();

            bool isCorrect = Math.Abs(result[0] - example.OutputValues[0]) <= 0.1 &&
                           Math.Abs(result[1] - example.OutputValues[1]) <= 0.1;
            CorrectLabel.Text = isCorrect ? "correct" : "incorrect!";
            CorrectLabel.BackColor = isCorrect ? Color.LimeGreen : Color.Red;
        }

        public void SetActive()
        {
            TestListBox.Items.Clear();
            foreach (var example in this.ExampleHelper.Examples)
            {
                TestListBox.Items.Add(Serializer.SerializeExample(example));
            }
            ExamplesListBox.Update();
        }

        public void Learn(object sender)
        {
            BackgroundWorker = sender as BackgroundWorker;
            Learning = new BackPropagationLearning(this.NeuralNetDataHelper.Network);
            double error;
            do
            {
                //foreach (var example in this.ExampleHelper.Examples)
                //{

                //    this.NeuralNetDataHelper.Network.TeachNeuronNet(example, speed);

                //}
                Learning.LearningRate = speed;
                error = Learning.RunEpoch(this.ExampleHelper.Examples.ToArray());

                speed *= 0.9999f;

                Console.WriteLine();
                //if (worker != null) worker.ReportProgress(i);
            } while (error > 1);
        }

        public void StartLearn()
        {
            if (BackgroundWorker.IsBusy) return;

            speed = double.Parse(LearnSpeedtextBox.Text.Replace('.', ','));
            maxCount = Int32.Parse(StepCountTextBox.Text);
            LearnProgressBar.Maximum = maxCount;
            BackgroundWorker.RunWorkerAsync();
        }
    }
}
