using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using sorter;
using System.Collections.Generic;
using System.Linq;

namespace Unitsorter
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            sorter.Sorter.sorterandprintProcess("unsorted-names-list.txt");
        }
    }
}
