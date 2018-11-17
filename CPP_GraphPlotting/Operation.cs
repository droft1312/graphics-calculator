using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP_GraphPlotting
{
    /// <summary>
    /// For differentiating basic math operations
    /// </summary>
    enum MathActions
    {
        sum,
        div,
        mult,
        subs,
        pow,
        sin,
        cos
    };

    /// <summary>
    /// For differentiating math operators
    /// </summary>
    enum MathOperators
    {
        functionX,
        number,
        realNumber,
        otherNaturalNumber,
        pi
    };

    abstract class Operation
    {
        public string value; // value of the current node
        public Operation left, right, parent; // reference to leafs
        /// <summary>
        /// Inserts value to the left leaf of the tree
        /// </summary>
        /// <param name="e"></param>
        public void InsertLeft (Operation e) {
            left = e;
        }
        /// <summary>
        /// Inserts value to the right leaf of the tree
        /// </summary>
        /// <param name="e"></param>
        public void InsertRight(Operation e) {
            right = e;
        }
        /// <summary>
        /// Find last Node out of all left leafs
        /// </summary>
        /// <returns></returns>
        public Operation FindLastLeft() {
            if (left == null) {
                return this;
            } else {
                return left.FindLastLeft ();
            }
        }
        /// <summary>
        /// Find last Node out of all right leafs
        /// </summary>
        /// <returns></returns>
        public Operation FindLastRight() {
            if (right == null) {
                return this;
            } else {
                return right.FindLastRight ();
            }
        }
    }

    /// <summary>
    /// Represents sum/substraction/division/multiplication
    /// </summary>
    class BasicMathAction : Operation
    {
        MathActions type;
        
        public BasicMathAction (string v, Operation parent) {
            if (v[0] == '+') {
                type = MathActions.sum;
            } else if (v[0] == '-') {
                type = MathActions.subs;
            } else if (v[0] == '*') {
                type = MathActions.mult;
            } else if (v[0] == '/') {
                type = MathActions.div;
            } else if (v[0] == '^') {
                type = MathActions.pow;
            } else if (v[0] == 's') {
                type = MathActions.sin;
            } else if (v[0] == 'c') {
                type = MathActions.cos;
            } else {
                throw new Exception ("Something went wrong with the parsin. No such s[0] = " + v[0] + " has been found");
            }

            value = Plotter.GetStringFromIndex (v, 2); // so if we got an input of *(p,x) => value = p,x)
            this.parent = parent;
        }
    }

    class MathOperator : Operation
    {
        MathOperators type;

        public MathOperator (string v, Operation parent) {
           if (v[0] == 'x') {
                type = MathOperators.functionX;
            } else if ("0123456789".ToCharArray().Contains(v[0])) {
                type = MathOperators.number;
            } else if (v[0] == 'n') {
                type = MathOperators.otherNaturalNumber;
            } else if (v[0] == 'r') {
                type = MathOperators.realNumber;
            } else if (v[0] == 'p') {
                type = MathOperators.pi;
            }

            value = Plotter.GetStringFromIndex (v, 1); // so if we got an input of p, x) => value = ,x)
            this.parent = parent;
        }
    }
}
