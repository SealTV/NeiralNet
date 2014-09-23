using System;
using NeuronNet;

namespace NeuroNet
{
    /// <summary>
    /// Back propagation learning algorithm
    /// </summary>
    /// 
    /// <remarks>The class implements back propagation learning algorithm,
    /// which is widely used for training multi-layer neural networks with
    /// continuous activation functions.</remarks>
    /// 
    public class BackPropagationLearning : ISupervisedLearning
    {
        private readonly NeuralNetwork network;
        // learning rate
        private double learningRate = 0.1;
        // momentum
        private double momentum = 0.0;

        // neuron's errors
        private readonly double[][] neuronErrors = null;
        // weight's updates
        private readonly double[][][] weightsUpdates = null;
        // threshold's updates
        private readonly double[][] thresholdsUpdates = null;

        /// <summary>
        /// Learning rate
        /// </summary>
        /// 
        /// <remarks>The value determines speed of learning. Default value equals to 0.1.</remarks>
        /// 
        public double LearningRate
        {
            get { return learningRate; }
            set
            {
                learningRate = Math.Max(0.0, Math.Min(1.0, value));
            }
        }

        /// <summary>
        /// Momentum
        /// </summary>
        /// 
        /// <remarks>The value determines the portion of previous weight's update
        /// to use on current iteration. Weight's update values are calculated on
        /// each iteration depending on neuron's error. The momentum specifies the amount
        /// of update to use from previous iteration and the amount of update
        /// to use from current iteration. If the value is equal to 0.1, for example,
        /// then 0.1 portion of previous update and 0.9 portion of current update are used
        /// to update weight's value.<br /><br />
        ///	Default value equals to 0.0.</remarks>
        /// 
        public double Momentum
        {
            get { return momentum; }
            set
            {
                momentum = Math.Max(0.0, Math.Min(1.0, value));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackPropagationLearning"/> class
        /// </summary>
        /// 
        /// <param name="network">Network to teach</param>
        /// 
        public BackPropagationLearning(NeuralNetwork network)
        {
            this.network = network;

            // create error and deltas arrays
            neuronErrors = new double[network.LayersCount][];
            weightsUpdates = new double[network.LayersCount][][];
            thresholdsUpdates = new double[network.LayersCount][];

            // initialize errors and deltas arrays for each layer
            for (int i = 0, n = network.LayersCount; i < n; i++)
            {
                Layer layer = network[i];

                neuronErrors[i] = new double[layer.NeuronsCount];
                weightsUpdates[i] = new double[layer.NeuronsCount][];
                thresholdsUpdates[i] = new double[layer.NeuronsCount];

                // for each neuron
                for (int j = 0; j < layer.NeuronsCount; j++)
                {
                    weightsUpdates[i][j] = new double[layer[0].InputLinks.Length];
                }
            }
        }

        /// <summary>
        /// Runs learning iteration
        /// </summary>
        /// 
        /// <param name="example">input and output vector</param>
        /// <returns>Returns squared error of the last layer divided by 2</returns>
        ///  
        ///  <remarks>Runs one learning iteration and updates neuron's
        ///  weights.</remarks>
        public double Run(Example example)
        {
            // compute the network's output
            double[] result = network.NextStep(example.InputValues);

            // calculate network error
            double error = CalculateError(example.OutputValues);

            // calculate weights updates
            CalculateUpdates(example.InputValues);

            // update the network
            UpdateNetwork();

            return error;
        }

        /// <summary>
        /// Runs learning epoch
        /// </summary>
        /// 
        /// <param name="examples">Array of input and output values</param>
        /// <returns>Returns sum of squared errors of the last layer divided by 2</returns>
        /// 
        /// <remarks>Runs series of learning iterations - one iteration
        /// for each input sample. Updates neuron's weights after each sample
        /// presented.</remarks>
        public double RunEpoch(Example[] examples)
        {
            double error = 0.0;

            // run learning procedure for all samples
            for (int i = 0, n = examples.Length; i < n; i++)
            {
                error += Run(examples[i]);
            }

            // return summary error
            return error;
        }


        /// <summary>
        /// Calculates error values for all neurons of the network
        /// </summary>
        /// 
        /// <param name="desiredOutput">Desired output vector</param>
        /// 
        /// <returns>Returns summary squared error of the last layer divided by 2</returns>
        /// 
        private double CalculateError(double[] desiredOutput)
        {
            // current and the next layers
            Layer layer, layerNext;
            // current and the next errors arrays
            double[] errors, errorsNext;
            // error values
            double error = 0, e, sum;
            // neuron's output value
            double output;
            // layers count
            int layersCount = network.LayersCount;

            // assume, that all neurons of the network have the same activation function
            IActivationFunction function = network[0][0].ActivationFunction;

            // calculate error values for the last layer first
            layer = network[layersCount - 1];
            errors = neuronErrors[layersCount - 1];

            for (int i = 0, n = layer.NeuronsCount; i < n; i++)
            {
                output = layer[i].GetResutValue();
                // error of the neuron
                e = desiredOutput[i] - output;
                // error multiplied with activation function's derivative
                errors[i] = e * function.Derivative2(output);
                // squre the error and sum it
                error += (e * e);
            }

            // calculate error values for other layers
            for (int j = layersCount - 2; j >= 0; j--)
            {
                layer = network[j];
                layerNext = network[j + 1];
                errors = neuronErrors[j];
                errorsNext = neuronErrors[j + 1];

                // for all neurons of the layer
                for (int i = 0, n = layer.NeuronsCount; i < n; i++)
                {
                    sum = 0.0;
                    // for all neurons of the next layer
                    for (int k = 0, m = layerNext.NeuronsCount; k < m; k++)
                    {
                        sum += errorsNext[k] * layerNext[k][i];
                    }
                    errors[i] = sum * function.Derivative2(layer[i].GetResutValue());
                }
            }

            // return squared error of the last layer divided by 2
            return error / 2.0;
        }

        /// <summary>
        /// Calculate weights updates
        /// </summary>
        /// 
        /// <param name="input">Network's input vector</param>
        /// 
        private void CalculateUpdates(double[] input)
        {
            // current neuron
            Neuron neuron;
            // current and previous layers
            Layer layer, layerPrev;
            // layer's weights updates
            double[][] layerWeightsUpdates;
            // layer's thresholds updates
            double[] layerThresholdUpdates;
            // layer's error
            double[] errors;
            // neuron's weights updates
            double[] neuronWeightUpdates;
            // error value
            double error;

            // 1 - calculate updates for the last layer fisrt
            layer = network[0];
            errors = neuronErrors[0];
            layerWeightsUpdates = weightsUpdates[0];
            layerThresholdUpdates = thresholdsUpdates[0];

            // for each neuron of the layer
            for (int i = 0, n = layer.NeuronsCount; i < n; i++)
            {
                neuron = layer[i];
                error = errors[i];
                neuronWeightUpdates = layerWeightsUpdates[i];

                // for each weight of the neuron
                for (int j = 0, m = neuron.InputLinks.Length; j < m; j++)
                {
                    // calculate weight update
                    neuronWeightUpdates[j] = learningRate * (
                        momentum * neuronWeightUpdates[j] +
                        (1.0 - momentum) * error * input[j]
                        );
                }

                // calculate treshold update
                layerThresholdUpdates[i] = learningRate * (
                    momentum * layerThresholdUpdates[i] +
                    (1.0 - momentum) * error
                    );
            }

            // 2 - for all other layers
            for (int k = 1, l = network.LayersCount; k < l; k++)
            {
                layerPrev = network[k - 1];
                layer = network[k];
                errors = neuronErrors[k];
                layerWeightsUpdates = weightsUpdates[k];
                layerThresholdUpdates = thresholdsUpdates[k];

                // for each neuron of the layer
                for (int i = 0, n = layer.NeuronsCount; i < n; i++)
                {
                    neuron = layer[i];
                    error = errors[i];
                    neuronWeightUpdates = layerWeightsUpdates[i];

                    // for each synapse of the neuron
                    for (int j = 0, m = neuron.InputLinks.Length; j < m; j++)
                    {
                        // calculate weight update
                        neuronWeightUpdates[j] = learningRate * (
                            momentum * neuronWeightUpdates[j] +
                            (1.0 - momentum) * error * layerPrev[j].GetResutValue());
                    }

                    // calculate treshold update
                    layerThresholdUpdates[i] = learningRate * (
                        momentum * layerThresholdUpdates[i] +
                        (1.0 - momentum) * error
                        );
                }
            }
        }

        /// <summary>
        /// Update network'sweights
        /// </summary>
        /// 
        private void UpdateNetwork()
        {
            // current neuron
            Neuron neuron;
            // current layer
            Layer layer;
            // layer's weights updates
            double[][] layerWeightsUpdates;
            // layer's thresholds updates
            double[] layerThresholdUpdates;
            // neuron's weights updates
            double[] neuronWeightUpdates;

            // for each layer of the network
            for (int i = 0, n = network.LayersCount; i < n; i++)
            {
                layer = network[i];
                layerWeightsUpdates = weightsUpdates[i];
                layerThresholdUpdates = thresholdsUpdates[i];

                // for each neuron of the layer
                for (int j = 0, m = layer.NeuronsCount; j < m; j++)
                {
                    neuron = layer[j];
                    neuronWeightUpdates = layerWeightsUpdates[j];

                    // for each weight of the neuron
                    for (int k = 0, s = neuron.InputLinks.Length; k < s; k++)
                    {
                        // update weight
                        neuron[k] += neuronWeightUpdates[k];
                    }
                    // update treshold
                    neuron.Threshold += layerThresholdUpdates[j];
                }
            }
        }
    }
}
