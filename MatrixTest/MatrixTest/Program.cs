using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("d:/matrix.txt");

            string line = file.ReadLine();
            string[] subStrings = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(subStrings[0]);
            int m = int.Parse(subStrings[1]);
            double[,] matrix1 = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                string currentLine = file.ReadLine();
                string[] row = currentLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < row.Length; j++)
                {
                    matrix1[i, j] = double.Parse(row[j]);
                    Console.Write(matrix1[i,j]+" ");
                }
                Console.WriteLine();
            }

            line = file.ReadLine();
            subStrings = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int n2 = int.Parse(subStrings[0]);
            int m2 = int.Parse(subStrings[1]);

            double[,] matrix2 = new double[n2, m2];

            for (int i = 0; i < n2; i++)
            {
                string currentLine = file.ReadLine();
                string[] row = currentLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < row.Length; j++)
                {
                    matrix2[i, j] = double.Parse(row[j]);
                    Console.Write(matrix2[i, j] + " ");
                }
                Console.WriteLine();
            }

            double[,] resultMatrix = new double[n, m2];

            int resultCount0 = resultMatrix.GetLength(0);
            int resultCount1 = resultMatrix.GetLength(1);

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                    Console.Write("{0} ", resultMatrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
