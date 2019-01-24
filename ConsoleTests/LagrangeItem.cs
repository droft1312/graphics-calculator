using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OxyPlot;

namespace ConsoleTests
{
    /// <summary>
    /// Class for producing a Lagrange item
    /// </summary>
    static class LagrangeItem
    {
        /// <summary>
        /// Produces a Lagrange Item, which looks like this: (x-Xj)/(Xterm - Xj), where term != j
        /// Example: ((x-X1)(x-X2)...(x-Xn)) / ((Xterm - x1)(Xterm - x2)...(Xterm - Xn))
        ///
        /// </summary>
        /// <param name="points">Given set of points</param>
        /// <param name="term">For which term you want to create a so-called Lagrange item</param>
        /// <returns>Lagrange item of the type MultiplicationNode</returns>
        public static MultiplicationNode ProduceLagrange (DataPoint[] points, int term) {
            MultiplicationNode item = new MultiplicationNode (null, null, null);
            item.left = new NumberNode (null, 1);

            for (int i = 0; i < points.Length; i++) {
                if (i == term) continue;

                SubstractionNode enumerator = new SubstractionNode (
                    new BasicFunctionXNode (""), // left
                    new NumberNode (null, points[i].X), // right
                    null // parent
                    );
                NumberNode denominator = new NumberNode (null, points[term].X - points[i].X);
                DivisionNode division = new DivisionNode (enumerator, denominator, null);
                item.LagrangePutToRightNode (division);
            }

            return item;
        }
    }
}
