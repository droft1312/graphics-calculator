using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPP_GraphPlotting;

namespace GraphPlotting_UnitTests
{
    [TestClass]
    public class PlotterTests
    {
        [TestMethod]
        public void ProcessTree_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("x");

            Assert.AreEqual (1d, plotter.ProcessTree (1, plotter.Root), 0);
        }


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
        public void CreateDerivativeTree_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("/(*(s(x), +(1,x)),-(l(x),c(x)))");
            plotter.CreateDerivativeTree ();

            var calculatedDerivative = plotter.ProcessTree (10, Plotter.derivativeRoot);
            var expectedResult = -3.3802484747843029d;

            Assert.AreEqual (expectedResult, calculatedDerivative, 5);
        }

        [TestMethod]
        public void CalculateNthDerivative_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("s(x)");

            var result = plotter.ProcessNthDerivative_Quotient (1, 2, plotter.Root);

            Assert.AreEqual (-0.841470d, result, 3);
        }

        [TestMethod]
        public void PrintNodeConnections_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("/(*(s(x), +(1,x)),-(l(x),c(x)))");
            plotter.CreateDerivativeTree ();

            var result = plotter.GenerateGraphVIZTEXT (Plotter.derivativeRoot);
            //var expected = "graph calculus {\nnode [ fontname = \"Arial\" ]\nnode87 [ label = \"/\" ]\nnode88 [ label = \"-\" ]\nnode89 [ label = \"*\" ]\nnode90 [ label = \"+\" ]\nnode91 [ label = \"*\" ]\nnode94 [ label = \"cos\" ]\nnode95 [ label = \"x\" ]\nnode96 [ label = \"+\" ]\nnode97 [ label = \"1\" ]\nnode98 [ label = \"x\" ]\nnode100 [ label = \"sin\" ]\nnode101 [ label = \"x\" ]\nnode105 [ label = \"-\" ]\nnode106 [ label = \"ln\" ]\nnode107 [ label = \"x\" ]\nnode108 [ label = \"cos\" ]\nnode109 [ label = \"x\" ]\nnode110 [ label = \"*\" ]\nnode111 [ label = \"*\" ]\nnode112 [ label = \"sin\" ]\nnode113 [ label = \"x\" ]\nnode114 [ label = \"+\" ]\nnode115 [ label = \"1\" ]\nnode116 [ label = \"x\" ]\nnode117 [ label = \"-\" ]\nnode119 [ label = \"/\" ]\nnode120 [ label = \"1\" ]\nnode121 [ label = \"x\" ]\nnode125 [ label = \"*\" ]\nnode126 [ label = \"-1\" ]\nnode127 [ label = \"sin\" ]\nnode128 [ label = \"x\" ]\nnode129 [ label = \"^\" ]\nnode130 [ label = \"-\" ]\nnode131 [ label = \"ln\" ]\nnode132 [ label = \"x\" ]\nnode133 [ label = \"cos\" ]\nnode134 [ label = \"x\" ]\nnode135 [ label = \"2\" ]\nnode87 -- node88\nnode87 -- node129\nnode88 -- node89\nnode88 -- node110\nnode89 -- node90\nnode89 -- node105\nnode90 -- node91\nnode90 -- node100\nnode91 -- node94\nnode91 -- node96\nnode94 -- node95\nnode96 -- node97\nnode96 -- node98\nnode100 -- node101\nnode105 -- node106\nnode105 -- node108\nnode106 -- node107\nnode108 -- node109\nnode110 -- node111\nnode110 -- node117\nnode111 -- node112\nnode111 -- node114\nnode112 -- node113\nnode114 -- node115\nnode114 -- node116\nnode117 -- node119\nnode117 -- node125\nnode119 -- node120\nnode119 -- node121\nnode125 -- node126\nnode125 -- node127\nnode127 -- node128\nnode129 -- node130\nnode129 -- node135\nnode130 -- node131\nnode130 -- node133\nnode131 -- node132\nnode133 -- node134\n}";

            Assert.IsNotNull (result);
        }

        [TestMethod]
        public void SimplifyTree_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("/(*(s(x), +(1,x)),-(l(x),c(x)))");
            var simplified = plotter.SimplifyTree (Plotter.derivativeRoot);

            var expected = plotter.ProcessTree (10, Plotter.derivativeRoot);
            var result = plotter.ProcessTree (10, simplified);

            Assert.AreEqual (expected, result);
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

        [TestMethod]
        public void CreateMcLaurienSeries_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("s(x)");

            BaseNode mcLaurien;
            plotter.CreateMcLaurienSeries (out mcLaurien, 3);

            var result = plotter.ProcessTree (2, mcLaurien);
            var expected = 0.6666d;

            Assert.AreEqual (expected, result, 3);
        }

        [TestMethod]
        public void CreateMcLaurienSeriesByLimits_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("s(x)");

            BaseNode mcLaurien;
            plotter.CreateMcLaurienSeriesByLimits (out mcLaurien, 3);

            var result = plotter.ProcessTree (2, mcLaurien);
            var expected = 0.6666d;

            Assert.AreEqual (expected, result, 3);
        }

        [TestMethod]
        public void ProcessString_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("^(x,3)");

            var expected = Math.Pow (2, 3);
            var result = plotter.ProcessTree (2, plotter.Root);

            Assert.AreEqual (expected, result, 0);
        }

        [TestMethod]
        public void CloneTree_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("^(x,3)");

            var expectedResult = plotter.ProcessTree (3, plotter.Root);

            var copy_tree = Plotter.CloneTree (plotter.Root);

            var result = copy_tree.Calculate (3);

            Assert.AreEqual (expectedResult, result);
        }

    }
}
