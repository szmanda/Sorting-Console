using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SortingConsole
{
    class SelectSort : ObjSort
    {
        public SelectSort(string file) : base(file) { }
        public SelectSort(List<float> list) : base(list) { }

        // (TODO 1) to powinno być uniwersalne (być w klasie ObjSort) i działać na interfejsach, ale niestety ich nie ogarniam, więc niech zostanie na razie tak
        public void PerformenceTest(int numberOfIterations, int maxElements, int avgFrom)
        {
            Console.WriteLine($"Performance test for Select Sort started. note that every record is an average from {avgFrom} tests");
            int step = maxElements / numberOfIterations;
            int noOperations = 0;
            Stopwatch fullTime = new Stopwatch();
            Stopwatch localTime = new Stopwatch();
            for (int i = 1; i <= numberOfIterations; i++)
            {
                localTime.Reset();

                var times = new List<long>();

                for (int j = 0; j < avgFrom; j++)
                {
                    //PrepairFile.CreateFile("file.txt", step * i);
                    BubbleSort sorted = new BubbleSort(PrepairFile.GenerateRandomList(step * i));

                    fullTime.Start();
                    localTime.Start();

                    noOperations = sorted.SortAsc();

                    localTime.Stop();
                    fullTime.Stop();
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-----------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"no. elements: {step * i}");
                Console.WriteLine($"no. operatio: {noOperations / (double)avgFrom}");
                Console.WriteLine($"TIME (ticks): {localTime.ElapsedMilliseconds / (double)avgFrom} ms");
                Console.WriteLine($"TIME per el.: {(localTime.ElapsedMilliseconds / (double)avgFrom) / (double)(step * i)} ms");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Summary:\ntime: {fullTime.ElapsedMilliseconds} ms");
        }

        public int SortAsc()
        {
            var count = UnsortedList.Count;
            float[] usTab = UnsortedList.ToArray();
            int ca = 0;

            for (int i = 0; i < count; i++)
            {
                int lowestIndex = i;
                for (int j = i+1; j < count; j++)
                {
                    if (usTab[j] < usTab[lowestIndex])
                        lowestIndex = j;
                    ca++;
                }
                float temp = usTab[i];
                usTab[i] = usTab[lowestIndex];
                usTab[lowestIndex] = temp;
            }

            var temporaryList = new List<float>();
            for (int i = 0; i < count; i++)
            {
                temporaryList.Add(usTab[i]);
            }
            SortedList = temporaryList;
            return ca;
        }
    }
}
