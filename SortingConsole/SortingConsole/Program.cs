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

            int input;
            List<float> set = new List<float> { 6f, 0f, 5.3f, 8f, 10.5f, 4f, 2.4f, 7f, 2f };

            PrepairFile.CreateFile("rr.txt", 5);

            input = ConsoleUI.Menu();

            List<ISortable> sortables = new List<ISortable>() { };
            sortables.Add(new BubbleSort(set));
            sortables.Add(new SelectSort(set));
            sortables.Add(new HeapSort(set));
            sortables.Add(new QuickSort(set));

            switch (input){
                case 1:
                    // from file
                    Console.WriteLine("Podaj ścieżkę do pliku:");
                    string file = Console.ReadLine();
                    List<ISortable> fromFile = new List<ISortable>() { };
                    fromFile.Add(new BubbleSort(file));
                    fromFile.Add(new SelectSort(file));
                    fromFile.Add(new HeapSort(file));
                    fromFile.Add(new QuickSort(file));

                    foreach (var item in fromFile)
                    {
                        Console.WriteLine("   - - -");
                        item.SortAscWrite();
                    }
                    break;
                case 2:
                    // example set
                    foreach (var item in sortables)
                    {
                        item.SortAscWrite();
                    }
                    break;
                case 3:
                    // performance
                    Console.WriteLine("ustaw parametry, aby uruchomić testy wydajnościowe:");
                    int noZakresy, maxElements, avgFrom;

                    while (true)
                    {
                        try
                        {
                            Console.Write("Podaj na ile zakresów chcesz podzielić test: ");
                            noZakresy = Int32.Parse(Console.ReadLine());
                            Console.Write("Podaj maksymalną ilość elementów w zbiorze: ");
                            maxElements = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Test uśredniony z (n) prób");
                            avgFrom = Int32.Parse(Console.ReadLine());
                            if (noZakresy>0&&maxElements>5&&avgFrom>0)
                                break;
                            else
                                Console.WriteLine("podane wartości są zbyt małe");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("nieprawidłowe dane, spróbuj ponownie");
                            noZakresy = 4;
                            maxElements = 1024;
                            avgFrom = 8;
                        }
                        
                    }
                    foreach (var item in sortables)
                    {
                        

                        item.PerformanceTest(noZakresy, maxElements, avgFrom);
                    }
                    break;
                default:
                    break;
            }

            //BubbleSort b = new BubbleSort(PrepairFile.GenerateRandomList(6));
            //b.PerformanceTest(4, 2048, 16);
            //Console.WriteLine("\n\n");

            //SelectSort s = new SelectSort(PrepairFile.GenerateRandomList(6));
            //s.SortAsc();
            ////ObjSort.DisplayList(s.SortedList);
            //s.PerformanceTest(4, 2048, 16);


            Console.WriteLine("Press any key to close");
            Console.ReadKey();

        }
        
    }

}
