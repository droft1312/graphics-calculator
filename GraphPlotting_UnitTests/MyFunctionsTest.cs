using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPP_GraphPlotting;
using OxyPlot;
using OxyPlot.Series;

namespace GraphPlotting_UnitTests
{
    [TestClass]
    public class MyFunctionsTest
    {
        [TestMethod]
        public void GetNewRangeBasedUponOldOne_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("^(x,2)");
            plotter.CreateDerivativeTree ();

            var result = MyFunctions.GetNewRangeBasedUponOldOne (plotter.Root, Plotter.derivativeRoot, -100, 100);
            var expected = (lower: 0, upper: 99d);

            result = (lower: (int)result.lower, upper: (int)result.upper);

            Assert.AreEqual (expected, result);
        }

        [TestMethod]
        public void GetNewRangeBasedUponSetOfPoints_Test() {
            DataPoint[] points = new DataPoint[3];
            points[0] = new DataPoint (0, 10);
            points[1] = new DataPoint (10, 5);
            points[2] = new DataPoint (20, 20);

            var result = MyFunctions.GetNewRangeBasedUponSetOfPoints (points);
            var expected = (lower: 0, upper: 20);

            Assert.AreEqual (expected, result);
        }

        [TestMethod]
        public void ConvertDatapointsToScatterpoints_Test() {
            DataPoint[] points = new DataPoint[3];
            points[0] = new DataPoint (0, 10);
            points[1] = new DataPoint (10, 5);
            points[2] = new DataPoint (20, 20);

            var result = MyFunctions.ConvertDatapointsToScatterpoints (points);

            bool tru = false;

            if (result is List<ScatterPoint>)
                tru = true;

            Assert.IsTrue (tru);
        }
    }
}
