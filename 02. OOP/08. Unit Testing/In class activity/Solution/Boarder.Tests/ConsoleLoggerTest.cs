using Boarder.Loggers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Tests
{
    [TestClass]
    public class ConsoleLoggerTest
    {
        [TestMethod]
        public void ConsolTest()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Console.WriteLine("Boarder");
            Assert.AreEqual("Boarder", stringWriter.ToString().TrimEnd());
        }
    }
}
