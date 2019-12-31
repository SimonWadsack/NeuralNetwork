using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN
{
    static class NNMath
    {
        public static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public static double Sigmoid_Derivative(double x)
        {
            return x * (1 - x);
        }

        public static double[] createError(double[] training_outputs, double[] outputs)
        {
            int length = outputs.Length;
            double[] error = new double[length];

            for (int i = 0; i < length; i++)
            {
                error[i] = training_outputs[i] - outputs[i];
            }

            return error;
        }

        public static double[] createAdjustments(double[] error, double[,] inputs, double[] outputs, int numofweights)
        {
            double[] adjustments = new double[numofweights];

            for (int i = 0; i < numofweights; i++)
            {
                double adjust = 0;

                for (int y = 0; y < error.Length; y++)
                {
                    adjust += error[y] * inputs[y, i] * NNMath.Sigmoid_Derivative(outputs[y]);
                }

                adjustments[i] = adjust;

            }

            return adjustments;

        }

        public static double[] AdjustWeights(double[] weights, double[] adjustments)
        {
            double[] newWeights = new double[weights.Length];

            for (int i = 0; i < weights.Length; i++)
            {
                newWeights[i] = weights[i] + adjustments[i];
            }

            return newWeights;

        }

    }
}
