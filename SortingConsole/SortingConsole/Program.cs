using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SortingConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("#######################");
            Console.WriteLine("### SORTING CONSOLE ###");
            Console.WriteLine("#######################\n\n");


            BubbleSort kon = new BubbleSort(new List<float> { 6f, 0f, 5.3f,8f,10.5f,4f,2.4f,7f,2f });
            kon.SortAscWrite();
            Console.WriteLine("\n\n");

            //BubbleSort awa = new BubbleSort(new List<float> { 9,8,7,6,5,4,3,2,1,0});
            //awa.SortAsc();

            // PrepairFile.CreateFile("file.txt",1000);
            //ObjSort sortowany = new ObjSort("file.txt");
            //sortowany.DisplayList();

            BubbleSort b = new BubbleSort(PrepairFile.GenerateRandomList(6));
            b.PerformenceTest(4, 2048, 16);
            Console.WriteLine("\n\n");

            SelectSort s = new SelectSort(PrepairFile.GenerateRandomList(6));
            s.SortAsc();
            //ObjSort.DisplayList(s.SortedList);
            s.PerformenceTest(4, 2048, 16);

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
        
    }

}
