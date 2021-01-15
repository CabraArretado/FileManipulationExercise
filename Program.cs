using System;
using System.IO;

namespace FileManipulationExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Full path of the project: ");
            string path = Console.ReadLine();
            string input = path  + @"\origin.csv";
            string target = path + @"\out\summary.csv";

            try
            {
                string[] str = File.ReadAllLines(input);
                using (StreamWriter output = File.AppendText(target))
                {
                    foreach(string line in str)
                    {
                        string[] product = line.Split(",");
                        double totalValue = double.Parse(product[1]) * int.Parse(product[2]);
                        output.WriteLine("Product: " + product[0] + "," + totalValue.ToString("F2"));
                    }
                }
                Console.WriteLine("File processed. Check target file.");
                
            }
            catch (IOException e)
            {
                Console.WriteLine("Error on file: " + e.Message);
            }
        }
    }
}
