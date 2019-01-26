using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CPP_GraphPlotting;
using OxyPlot;

namespace GraphPlotting_UnitTests
{
    /// <summary>
    /// Summary description for LagrangeTests
    /// </summary>
    [TestClass]
    public class LagrangeTests
    {
        [TestMethod]
        public void ProduceLagrange_Test() {
            var plotter = new Plotter ();
            DataPoint[] dataPoints = new DataPoint[3];
            dataPoints[0] = new DataPoint (0, 15);
            dataPoints[1] = new DataPoint (10, 3);
            dataPoints[2] = new DataPoint (20, 30);

            var function = plotter.CreatePolynomialThroughPoints (dataPoints);

            Assert.AreEqual (15d, function.Calculate (0), 0);
        }
    }
}
