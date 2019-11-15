using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SortingConsole
{
    class QuickSort : ObjSort, ISortable
    {
        public QuickSort(string file) : base(file) { }
        public QuickSort(List<float> list) : base(list) { }

        private int ca;

        public void PerformanceTest(int numberOfIterations, int maxElements, int avgFrom)
        {
            Console.WriteLine($"Performance test for Quick Sort started. note that every record is an average from {avgFrom} tests");

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
                    HeapSort sorted = new HeapSort(PrepairFile.GenerateRandomList(step * i));

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
            int count = UnsortedList.Count;
            float[] usTab = UnsortedList.ToArray();
            var temporaryList = new List<float>();
            ca = 0;

            Quick(usTab,0,count-1);

            for (int i = 0; i < count; i++)
            {
                temporaryList.Add(usTab[i]);
            }
            SortedList = temporaryList;

            return ca;
        }

        public int SortAscWrite()
        {
            int count = UnsortedList.Count;
            float[] usTab = UnsortedList.ToArray();
            var temporaryList = new List<float>();
            ca = 0;

            Console.WriteLine("Bubble sort started work on following set:");
            ObjSort.DisplayList(this.UnsortedList);

            QuickWrite(usTab, 0, count - 1);

            for (int i = 0; i < count; i++)
            {
                temporaryList.Add(usTab[i]);
            }
            SortedList = temporaryList;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Sortowanie zakończone, liczba kroków: {ca}");
            return ca;
        }

        private void Quick(float[] array, int left, int right)
        {
            var i = left;
            var j = right;
            var pivot = array[(left + right) / 2];
            while (i < j)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;
                if (i <= j)
                {
                    var tmp = array[i];
                    array[i++] = array[j];
                    array[j--] = tmp;
                    ca++;
                }
            }
            if (left < j) Quick(array, left, j);
            if (i < right) Quick(array, i, right);
        }

        private void QuickWrite(float[] array, int left, int right)
        {
            var i = left;
            var j = right;
            var pivot = array[(left + right) / 2];
            while (i < j)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;
                if (i <= j)
                {
                    var tmp = array[i];
                    array[i++] = array[j];
                    array[j--] = tmp;
                    // wyświetlanie
                    for (int k = 0; k < array.Length; k++)
                    {
                        if (k == i - 1 || k == j + 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("  |" + array[k]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write("  |" + array[k]);
                        }

                    }
                    Console.WriteLine();
                    ca++;
                }
            }
            if (left < j) QuickWrite(array, left, j);
            if (i < right) QuickWrite(array, i, right);
        }

        private void LoadSorted(float[] usTab)
        {
            List<float> temporaryList = new List<float>();
            int count = usTab.Length;

            for (int i = 0; i < count; i++)
            {
                temporaryList.Add(usTab[i]);
            }
            SortedList = temporaryList;
        }
    }
}
