using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CPP_GraphPlotting;

namespace GraphPlotting_UnitTests
{
    [TestClass]
    public class NodesTest
    {
        [TestMethod]
        public void BasicFunctionXNodeCalculate_Test() {
            BasicFunctionXNode func = new BasicFunctionXNode ("");
            var result = func.Calculate (1);

            Assert.AreEqual (1d, result);
        }

        [TestMethod]
        public void BasicFunctionXNodeToString_Test() {
            BasicFunctionXNode func = new BasicFunctionXNode ("");
            Assert.AreEqual ("x", func.ToString ());
        }

        [TestMethod]
        public void DivisionNodeSimplify_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("/(10,5)");
            var simplified = plotter.SimplifyTree (plotter.Root);

            Assert.AreEqual (plotter.ProcessTree (0, plotter.Root), plotter.ProcessTree (0, simplified));
        }

        [TestMethod]
        public void ExponentialNode_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("/(s(x),e(x))");

            var expected = -6.71884969743d;
            var result = plotter.ProcessTree (-2, plotter.Root);

            Assert.AreEqual (expected, result, 3);
        }

        [TestMethod]
        public void ExponentialNodeDerivative_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("/(s(x),e(x))");
            plotter.CreateDerivativeTree ();

            var expected = 3.64392d;
            var result = plotter.ProcessTree (-2, Plotter.derivativeRoot);

            Assert.AreEqual (expected, result, 3);
        }

        [TestMethod]
        public void FactorialNodeDerivative_Test() {
            var plotter = new Plotter ();
            plotter.ProcessString ("!(5)");
            plotter.CreateDerivativeTree ();

            Assert.AreEqual (0, plotter.ProcessTree (0, Plotter.derivativeRoot));
        }
    }
}
