using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Services;
using System.Text.RegularExpressions;

namespace Lesson2.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Press 1 for reading from console, press 2 for reading from file:");
            string number = Console.ReadLine();

            string text = null;
            if (number == "1")
            {
                text = program.ReadFromConsole();
            }
            else if (number == "2")
            {
                text = program.ReadFromFile();
            }
            if (text != null)
            {
                Console.WriteLine(program.EditText(text));
            }
            Console.ReadKey();
        }

        //Метод, читающий текст с консоли
        public string ReadFromConsole()
        {
            string text = null;

            Console.WriteLine("Enter text. Write \"stop\" to stop input:");
            while (true)
            {
                String currentLine = Console.ReadLine();
                if (currentLine == "stop")
                {
                    break;
                }
                text += currentLine + "\n";
            }
            return text;
        }

        //Метод, читающий текст из файла
        public string ReadFromFile()
        {
            string text = null;

            Console.WriteLine("Enter the path:");
            string path = Console.ReadLine();
            try
            {
                text = string.Join("\n", File.ReadAllLines(path));
            }
            catch (SystemException e)
            {
                Console.WriteLine("Incorrect path");
            }
            return text;
        }

        //Метод, редактирующий текст
        public string EditText(string text)
        {
            text = text.ToLower().Replace(".", ".\n").Replace("!", "!\n").Replace("?", "?\n");
            string[] substrings = text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < substrings.Length; i++)
            {
                substrings[i] = ($"{DateTime.Now:MM/dd/yyy HH:mm:ss.fff} {substrings[i].Trim()}");
            }
            return string.Join("\n", substrings);
        }
    }
}

