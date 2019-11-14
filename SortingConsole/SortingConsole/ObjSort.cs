using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SortingConsole
{
    public class ObjSort
    {
        private String line;
        private string[] separator;
        private string sourceFile;
        public List<float> UnsortedList { get; set; }
        public List<float> SortedList { get; set; }

        public ObjSort(string file = "file.txt")
        {
            SetPreferences("\n",file);
            ReadFromFile();
        }

        public ObjSort(List<float> readFromList)
        {
            SetPreferences();
            UnsortedList = readFromList;
        }

        public static void DisplayList(List<float> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }

        public virtual void DisplayList()
        {
            var collection = this.UnsortedList;
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine(item + "\t");
                }
            }
            
        }

        
        public void SetPreferences(String separ = "\n", String file = "file.txt")
        {
            separator = new string[] { "\n" };
            sourceFile = "file.txt";
        }

        public void ReadFromFile()
        {
            line = null;
            try
            {
                using (StreamReader sr = new StreamReader(this.sourceFile))
                {
                    line = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Unable to read the file:");
                Console.WriteLine(e.Message);
            }
            DivideToList(line, separator);
        }
        private void DivideToList(String text, String[] separators)
        {

            String[] stringTab = text.Split(separators, options: StringSplitOptions.None);
            var temporaryList = new List<float>();

            int i = 0;
            foreach (var item in stringTab)
            {
                String g = stringTab[i];
                if (g == "") continue;
                temporaryList.Add(float.Parse(g, CultureInfo.InvariantCulture.NumberFormat));
                //Console.WriteLine(g);
                i++;
            }
            UnsortedList = temporaryList;
        }


    }
}
