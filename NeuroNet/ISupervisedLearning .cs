using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuronNet;

namespace NeuroNet
{
    /// <summary>
    /// Supervised learning interface
    /// </summary>
    /// 
    /// <remarks>The interface describes methods, which should be implemented
    /// by all supervised learning algorithms. Supervised learning is such a
    /// type of learning algorithms, where system's desired output is known on
    /// the learning stage. So, given sample input values and desired outputs,
    /// system should adopt its internals to produce correct (or closer to correct)
    /// result after the learning step is complete.</remarks>
    /// 
    interface ISupervisedLearning
    {
        /// <summary>
        /// Runs learning iteration
        /// </summary>
        /// 
        /// <param name="example">input and output vector</param>
        /// <returns>Returns learning error</returns>
        double Run(Example example);

        /// <summary>
        /// Runs learning epoch
        /// </summary>
        /// 
        /// <param name="examples">Array of inputs and output vectors</param>
        /// <returns>Returns sum of learning errors</returns>
        double RunEpoch(Example[] examples);
    }
}
