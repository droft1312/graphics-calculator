using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPP_GraphPlotting;

namespace GraphPlotting_UnitTests
{
    [TestClass]
    public class PlotterTests
    {
        [TestMethod]
        public void CalculateIntegral_Test () {
            // Arrange
            var plotter = new Plotter ();
            plotter.ProcessString ("s(x)");

            // Act
            var result = plotter.ProcessIntegral (-1, 1);

            // Assert
            Assert.AreEqual (0.9109773016774638d, result, 2);
        }

        [TestMethod]
        public void CalculateDerivativeByQuotient_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("^(x,2)");

            var result = plotter.ProcessDerivative_Quotient (5, plotter.Root);

            Assert.AreEqual<double> (10d, result);
        }

        [TestMethod]
        public void CalculateNthDerivative_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("s(x)");

            var result = plotter.ProcessNthDerivative_Quotient (1, 2, plotter.Root);

            Assert.AreEqual (-0.841470d, result, 3);
        }

        [TestMethod]
        public void CalculateTree_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("^(x,2)");

            var result = plotter.ProcessTree (5, plotter.Root);

            Assert.AreEqual (25d, result, 0);
        }

        [TestMethod]
        public void GetStringFromIndex_Test() {
            var result = Plotter.GetStringFromIndex ("Hello", 1);
            Assert.AreEqual ("hello".Substring (1), result);
        }

        [TestMethod]
        public void PrefixToInfix_Test() {
            var plotter = new Plotter ();

            var result = plotter.PrefixToInfix ("+(1,x)");

            var expected_result = "(1 + x)";

            Assert.AreEqual (expected_result, result);
        }

        [TestMethod]
        public void DeleteCharFromString_Test() {
            var result = Plotter.DeleteCharFromString ("n(32)", 'n');
            var expected = "32";

            Assert.AreEqual (expected, result);
        }
    }
}
