using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ClassLibrary1
{
    public class EquationManager
    {
        private static StreamReader file;
        private static double[,] resultMatrix;

        //Метод, решающий квадратное уравнение
        public static void SolveEquation(double a, double b, double c, out double x1, out double x2)
        {
            if (a == 0)
            {
                throw new WrongArgumentAException();
            }

            double d = b * b - 4 * a * c;
            if (d < 0)
            {
                throw new WrongDiscriminantException();
            }
            if (d == 0)
            {
                x1 = -b / (2 * a);
                x2 = x1;
            }
            else
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
            }
        }

        //Метод, решающий линейное уравнение
        public static void SolveEquation(double a, double b, out double x)
        {
            x = -b / a;
        }

        //Метод, перемножающий матрицы, находящиеся в файле, указанном в конфиге
        public static double[,] MultiplyMatricies()
        {
            file = new StreamReader(ConfigurationManager.AppSettings["filePath"]);
            double[,] matrix1 = ReadNextMatrixFromFile();
            double[,] matrix2 = ReadNextMatrixFromFile();

            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new MatriciesWithWrongDimensionsException();
            }

            resultMatrix = new double[matrix1.GetLength(0),matrix2.GetLength(1)];

            file.Close();

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return resultMatrix;
        }

        //Метод, считывающий следующую матрицу из файла
        private static double[,] ReadNextMatrixFromFile(){
            string line = file.ReadLine();
            string[] subStrings = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(subStrings[0]);
            int m = int.Parse(subStrings[1]);

            double[,] matrix = new double[n,m];

            for (int i = 0; i < n; i++)
            {
                string currentLine = file.ReadLine();
                string[] row = currentLine.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < row.Length; j++)
                {
                    matrix[i, j] = double.Parse(row[j]);
                }
            }
            return matrix;
        }

        //возвращает результирующий массив в виде string
        public static string ShowResultMatrixToConsole()
        {
            MultiplyMatricies();
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    sb.Append($"{resultMatrix[i, j]: 0.00} ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
