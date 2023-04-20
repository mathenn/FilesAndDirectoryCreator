using System;
using System.IO;
using FilesAndDirectory.Entities;
using System.Globalization;

namespace FilesAndDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path:");
            string sourceFilePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFilePath + @"\out";
                string targetFilePath = targetFolderPath + @"\Summary.csv";

                Directory.CreateDirectory(targetFolderPath);


                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(",");
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Products prod = new Products(name, price, quantity);

                        sw.WriteLine(prod.Name + "," + prod.total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
                
            }
            catch (IOException e)
            {
                Console.Write("An error occurred :");
                Console.WriteLine(e.Message);
            }
        }
    }
}