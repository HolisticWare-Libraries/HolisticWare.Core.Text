using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using NUnit.Framework;

using HolisticWare.Core.Text.Core.Text;

namespace HolisticWare.Core.Math.Statistics.UnitTests
{
    public partial class UnitTestsParser01
    {
        Stopwatch sw = null;

        string input = "";
        Parser parser;
        bool correct_syntactic;
        bool correct_lexical;

        [Test()]
        public void Average()
        {
            //====================================================================================================
            // Arrange
            input = @"{ 1, 2, 3, 4,5, 6, 7, 7, 8,   9}";

            parser = new Parser();


            sw = Stopwatch.StartNew();
            //----------------------------------------------------------------------------------------------------
            // Act

            sw.Stop();
            Console.WriteLine($"List<int>.Average()");
            Console.WriteLine($"          elapsed[ticks]     = {sw.ElapsedTicks}");
            Console.WriteLine($"          elapsed[ms]        = {sw.Elapsed.TotalMilliseconds}");
            sw.Reset();

            //----------------------------------------------------------------------------------------------------
            // Assert
            Assert.AreEqual(true, correct_syntactic);
            //====================================================================================================

            return;
        }
    }
}
