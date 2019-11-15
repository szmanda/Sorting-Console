using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace SortingConsole
{
    class BubbleSort : ObjSort, ISortable
    {
        public BubbleSort(string file) : base(file) { }
        public BubbleSort(List<float> list) : base(list) { }

        // (TODO 1) to powinno być uniwersalne (być w klasie ObjSort) i działać na interfejsach, ale niestety ich nie ogarniam, więc niech zostanie na razie tak
        public void PerformanceTest(int numberOfIterations, int maxElements, int avgFrom)
        {
            Console.WriteLine($"Performance test for Bubble Sort started. note that every record is an average from {avgFrom} tests");
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
                    BubbleSort sorted = new BubbleSort(PrepairFile.GenerateRandomList(step*i));

                    fullTime.Start();
                    localTime.Start();

                    noOperations += sorted.SortAsc();

                    localTime.Stop();
                    fullTime.Stop();
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-----------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"no. elements: {step * i}");
                Console.WriteLine($"no. operatio: {noOperations/(double)avgFrom}");
                Console.WriteLine($"TIME (ticks): {localTime.ElapsedMilliseconds/(double)avgFrom} ms");
                Console.WriteLine($"TIME per el.: {(localTime.ElapsedMilliseconds/(double)avgFrom)/(double)(step*i)} ms");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Summary:\ntime: {fullTime.ElapsedMilliseconds} ms");
        }
        public int SortAscWrite()
        {
            int count = UnsortedList.Count;
            float[] usTab = UnsortedList.ToArray();
            var temporaryList = new List<float>();
            int ca = 0, cb = 0;

            Console.WriteLine("Bubble sort started work on following set:");
            ObjSort.DisplayList(this.UnsortedList);

            for (int i = 0; i < count-1; i++)
            {
                bool changed = false;
                for (int j = 0; j < count-i-1; j++)
                {
                    if (usTab[j] > usTab[j + 1])
                    {
                        changed = true;
                        float temp = usTab[j];
                        usTab[j] = usTab[j + 1];
                        usTab[j + 1] = temp;
                        // wyświetlanie
                        for (int k = 0; k < usTab.Length; k++)
                        {
                            if (k == j || k == j + 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("  |" + usTab[k]);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write("  |" + usTab[k]);
                            }

                        }
                        Console.WriteLine();
                        ca++;
                    }
                    else {cb++;}
                }
                if (!changed) break;
            }
            for (int i=0; i < count; i++)
            {
                temporaryList.Add(usTab[i]);
            }
            SortedList = temporaryList;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Sortowanie zakończone, liczba kroków: {ca} + {cb} jeśli liczyć te bez zamiany elementów");
            return ca + cb;
        }
        public int SortAsc()
        {
            int count = UnsortedList.Count;
            float[] usTab = UnsortedList.ToArray();
            var temporaryList = new List<float>();
            int ca = 0, cb = 0;

            for (int i = 0; i < count - 1; i++)
            {
                bool changed = false;
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (usTab[j] > usTab[j + 1])
                    {
                        changed = true;
                        float temp = usTab[j];
                        usTab[j] = usTab[j + 1];
                        usTab[j + 1] = temp;
                        ca++;
                    }
                    else { cb++; }
                }
                if (!changed) break;
            }
            for (int i = 0; i < count; i++)
            {
                temporaryList.Add(usTab[i]);
            }
            SortedList = temporaryList;

            //Console.WriteLine($"Sortowanie zakończone, liczba kroków: {ca} + {cb} jeśli liczyć te bez zamiany elementów");
            return ca + cb;
        }
        public override void DisplayList()
        {
            var collection = this.SortedList;
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine(item + "\t");
                }
            }

        }
    }
}
