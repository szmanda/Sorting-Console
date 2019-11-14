using System;
using System.Collections.Generic;
using System.Text;

namespace SortingConsole
{
    interface ISortable
    {
        void PerformanceTest(int numberOfIterations, int maxElements, int avgFrom);
    }
}
