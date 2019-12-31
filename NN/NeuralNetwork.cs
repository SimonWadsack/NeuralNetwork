using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN
{
    class NeuralNetwork
    {
        public double[] synaptic_weights = new double[3];
        Random rand = new Random();

        public NeuralNetwork()
        {
            for (int i = 0; i < synaptic_weights.Length; i++)
            {
                synaptic_weights[i] = 2 * rand.NextDouble() - 1;
            }
            
        }

        public void Train(double[,] training_inputs, double[] training_outputs, int training_iterations)
        {
            for (int i = 0; i < training_iterations; i++)
            {
                double[] outputs = new double[training_inputs.Length / synaptic_weights.Length];
                double[] error = new double[training_inputs.Length / synaptic_weights.Length];
                double[] adjustments = new double[training_inputs.Length / synaptic_weights.Length];

                outputs = Think(training_inputs);
                error = NNMath.createError(training_outputs,outputs);

                adjustments = NNMath.createAdjustments(error, training_inputs, outputs, synaptic_weights.Length);

                synaptic_weights = NNMath.AdjustWeights(synaptic_weights, adjustments);

            }
        }

        public double[] Think(double[,] inputs)
        {
            double[] outputs = new double[inputs.Length/synaptic_weights.Length];

            for (int i = 0; i < outputs.Length; i++)
            {
                double output = 0;

                for (int j = 0; j < 3; j++)
                {
                    output += inputs[i, j] * synaptic_weights[j];
                }

                outputs[i] = NNMath.Sigmoid(output);

            }

            return outputs;

        }

    }
}
