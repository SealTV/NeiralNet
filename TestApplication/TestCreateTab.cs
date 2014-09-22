using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NeuronNet;
using NeuronNet.Serialize;
using TestApplication.ExamplesData;

namespace TestApplication
{
    public class TestCreateTab
    {
        private readonly TextBox[] inputBoxes;
        private readonly TextBox[] outputBoxes;

        private ExamplesDataHelper ExamplesDataHelper { get; set; }
        public ListBox ExamplesListBox { get; set; }
        public PictureBox TestPictureBox { get; set; }

        public TestCreateTab(ExamplesDataHelper ExamplesDataHelper, TextBox[] inputs, TextBox[] outputs)
        {
            this.ExamplesDataHelper = ExamplesDataHelper;
            this.ExamplesDataHelper.LoadExamples();
            this.inputBoxes = inputs;
            this.outputBoxes = outputs;
        }

        public void SelectExample()
        {
            var data = ExamplesListBox.SelectedItem as string;

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
                this.DeleteSelectedExample();
            }
        }

        public void AddTest()
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
            SelectExample();
            this.ExamplesDataHelper.Examples.Add(example);
            int index = ExamplesListBox.Items.Add(Serializer.SerializeExample(example));
            ExamplesListBox.SelectedIndex = index;
        }

        public void AddGeneratedTest()
        {
            Example example = new Example
            {
                InputValues = new double[this.inputBoxes.Length],
                OutputValues = new double[this.outputBoxes.Length]
            };
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

            for (int i = 0; i < this.inputBoxes.Length; i++)
            {
                this.inputBoxes[i].Text = example.InputValues[i].ToString();
            }
            example.OutputValues[0] = 1 - resultR;
            example.OutputValues[1] = resultAngle;

            for (int i = 0; i < this.outputBoxes.Length; i++)
            {
                outputBoxes[i].Text = example.OutputValues[i].ToString();
            }
        }

        public void SaveTest()
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
            var index = ExamplesListBox.SelectedIndex;
            if(index < 0 ) return;

            this.ExamplesDataHelper.Examples[index] = example;
            ExamplesListBox.Items[index] = Serializer.SerializeExample(example);
        }

        public void DeleteSelectedExample()
        {
            int index = ExamplesListBox.SelectedIndex;
            this.ExamplesDataHelper.Examples.RemoveAt(index);
            ExamplesListBox.Items.RemoveAt(index);

            if (ExamplesListBox.Items.Count > 0)
                ExamplesListBox.SelectedIndex = 0;
        }

        public void GenerateTests()
        {
            PictureBox pictureBox = this.TestPictureBox;
            Graphics graphics = pictureBox.CreateGraphics();
            graphics.Clear(Color.White);
            GraphicsDrawer.DrawEllipses();

            GraphicsDrawer.InputPoints = new List<PointF>();
            Random rnd = new Random();
            for (int j = 0; j < 8; j++)
            {

                Point point = new Point(rnd.Next(0, 2) * 2 - 1, rnd.Next(0, 2) * 2 - 1);
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
            this.AddGeneratedTest();
        }

        public void SetActive()
        {
            GraphicsDrawer.CenterX = TestPictureBox.Width * 0.5f;
            GraphicsDrawer.CenterY = TestPictureBox.Height * 0.5f;
            GraphicsDrawer.Radius = GraphicsDrawer.CenterX;
            GraphicsDrawer.DrawEllipses();
            ExamplesListBox.Items.Clear();
            foreach (var example in this.ExamplesDataHelper.Examples)
            {
                ExamplesListBox.Items.Add(Serializer.SerializeExample(example));
            }
            ExamplesListBox.Update();
            TestPictureBox.Update();
            GraphicsDrawer.DrawEllipses();
        }

        public void CleanDrawBox()
        {
            GraphicsDrawer.DrawEllipses();
            GraphicsDrawer.InputPoints.Clear();
        }
    }
}
