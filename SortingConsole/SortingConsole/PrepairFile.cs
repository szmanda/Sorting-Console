using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SortingConsole
{
    public static class PrepairFile
    {
        public static void CreateFile(String fileName, int howManyRows=100)
        {
            if (File.Exists(fileName))
            {
                //Console.WriteLine($"Notice! {fileName} already exists!");
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    GenerateRandomFile(sw, howManyRows);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    GenerateRandomFile(sw, howManyRows);
                }
               
            }
        }
        private static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-64,64));
            return (float)(mantissa * exponent);
        }
        public static void GenerateRandomFile(StreamWriter sw, int howManyRows)
        {
            for (int i = 0; i < howManyRows; i++)
            {
                sw.WriteLine(NextFloat(new Random()));
            }
        }
        public static List<float> GenerateRandomList(int howManyRows)
        {
            List<float> temp = new List<float>();
            for (int i = 0; i < howManyRows; i++)
            {
                temp.Add(NextFloat(new Random()));
            }
            return temp;
        }
    }
}
