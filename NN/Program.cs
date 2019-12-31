using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN
{
    class Program
    {
        static void Main(string[] args)
        {

            //double[,] training_inputs = { { 0, 0, 1}, { 1, 1, 1}, { 1, 0, 1}, { 0, 1, 1}, { 0, 0, 0}, { 1, 0, 0} };
            double[,] training_inputs = { { 0, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 } };
            //double[] training_outputs = { 0, 1, 1, 0, 0, 1};
            double[] training_outputs = { 0, 1, 1, 0};

            NeuralNetwork neuralNetwork = new NeuralNetwork();

            Console.WriteLine("Synaptic-Weights before training: ");
            foreach(var item in neuralNetwork.synaptic_weights)
            {
                Console.Write(item.ToString());
                Console.Write(" , ");
            }

            neuralNetwork.Train(training_inputs, training_outputs, 100000);

            Console.WriteLine("");
            Console.WriteLine("Synaptic-Weights after training: ");
            foreach (var item in neuralNetwork.synaptic_weights)
            {
                Console.Write(item.ToString());
                Console.Write(" , ");
            }

            Console.WriteLine("");
            Console.WriteLine("New Situation: ");
            Console.Write("Input1 = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Input2 = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Input3 = ");
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("New Situation data: {0}, {1}, {2} ",a,b,c);
            Console.WriteLine("");

            double[,] newInputs = { { a, b, c } };

            double[] outputs = neuralNetwork.Think(newInputs);

            int roundOutput = (int)Math.Round(outputs[0]);
            double roundPercent = 0;
            if (roundOutput == 1)
            {
                double percent = outputs[0] * 100;
                roundPercent = Math.Round(percent,2);
            }
            else
            {
                double percent = (1-outputs[0]) * 100;
                roundPercent = Math.Round(percent, 2);
            }

            Console.Write("With a probability of " + roundPercent + "% the Output is: ");
            Console.Write(Math.Round(outputs[0]));
            Console.Write(" (");
            Console.Write(outputs[0]);
            Console.Write(")");

            Console.ReadKey();
        }
    }
}
