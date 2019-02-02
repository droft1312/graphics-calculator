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

        public void DivisionNode_CreateDerivativeTree_Test() {

        }
    }
}
