using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SortingConsole
{
    class HeapSort : ObjSort, ISortable
    {
        private float[] usTab;

        public HeapSort(string file) : base(file)
        {
            usTab = UnsortedList.ToArray();
        }
        public HeapSort(List<float> list) : base(list)
        {
            usTab = UnsortedList.ToArray();
        }

        public void PerformanceTest(int numberOfIterations, int maxElements, int avgFrom)
        {
            Console.WriteLine($"Performance test for Heap Sort started. note that every record is an average from {avgFrom} tests");
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

        private int heapify(int n, int i)
        {
            int counter = 1;

            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && usTab[left] > usTab[largest])
                largest = left;
            if (right < n && usTab[right] > usTab[largest])
                largest = right;
            if (largest != i)
            {
                float swap = usTab[i];
                usTab[i] = usTab[largest];
                usTab[largest] = swap;
                counter+=heapify(n, largest);
            }
            return counter;
        }
        private int heapifyWrite(int n, int i)
        {
            int counter=1;

            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && usTab[left] > usTab[largest])
                largest = left;
            if (right < n && usTab[right] > usTab[largest])
                largest = right;
            if (largest != i)
            {
                float swap = usTab[i];
                usTab[i] = usTab[largest];
                usTab[largest] = swap;
                counter+=heapifyWrite(n, largest);
            }
            // wyświetlanie
            for (int k = 0; k < usTab.Length; k++)
            {
                if (k == i || k == largest)
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
            return counter;
        }

        public int SortAsc()
        {
            int n = UnsortedList.Count;
            usTab = UnsortedList.ToArray();
            int ca = 0;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                ca+=heapify(n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                float temp = usTab[0];
                usTab[0] = usTab[i];
                usTab[i] = temp;
                ca+=heapify(i, 0);
            }

            LoadSorted(usTab);
            return ca;
        }
        public int SortAscWrite()
        {
            int n = UnsortedList.Count;
            usTab = UnsortedList.ToArray();
            int ca = 0;

            Console.WriteLine("Heap sort started work on following set:");
            ObjSort.DisplayList(this.UnsortedList);

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                ca+=heapifyWrite(n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                float temp = usTab[0];
                usTab[0] = usTab[i];
                usTab[i] = temp;
                // wyświetlanie
                for (int k = 0; k < usTab.Length; k++)
                {
                    if (k == i || k == 0)
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
                ca+=heapifyWrite(i, 0);
                
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Sortowanie zakończone, liczba kroków: {ca}");
            LoadSorted(usTab);
            return ca;
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
