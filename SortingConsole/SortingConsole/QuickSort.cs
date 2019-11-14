using System;
using System.Collections.Generic;
using System.Text;

namespace SortingConsole
{
    class QuickSort : ObjSort, ISortable
    {
        public QuickSort(string file) : base(file) { }
        public QuickSort(List<float> list) : base(list) { }

        public void PerformanceTest(int numberOfIterations, int maxElements, int avgFrom)
        {
            Console.WriteLine("Not implemented yet");
        }

        public int SortAsc()
        {
            Console.WriteLine("Not implemented yet");
            return 1;
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
