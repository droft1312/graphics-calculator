using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP_GraphPlotting
{
    class BaseNode
    {
        public string value;
        public BaseNode left, right, parent;
        public bool visited = false;

        public void Insert(BaseNode node) {
            if (left == null) {
                left = node;
            } else if (right == null) {
                right = node;
            } else {
                // do nothing
            }
        }

        public virtual double Calculate (double number) {
            return -1;
        }

        public BaseNode FindLastLeft () {
            return (left == null ? this : left.FindLastLeft ());
        }
        public BaseNode FindLastRight () {
            return (right == null ? this : right.FindLastRight ());
        }
    }

    class SubstractionNode : BaseNode
    {
        public SubstractionNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return left.Calculate (number) - right.Calculate (number);
        }
    }
    
    class MultiplicationNode : BaseNode
    {
        public MultiplicationNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return left.Calculate (number) * right.Calculate (number);
        }
    }

    class SumNode : BaseNode
    {
        public SumNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        
        public override double Calculate (double number) {
            return left.Calculate (number) + right.Calculate (number);
        }
    }

    class DivisionNode : BaseNode
    {
        public DivisionNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return left.Calculate (number) / right.Calculate (number);
        }
    }

    class NumberNode : BaseNode
    {
        double realValue;

        public NumberNode(string input, BaseNode parentNode, string realValue) {
            value = input;
            parent = parentNode;


            if (realValue[0] == 'p') {
                this.realValue = 3.14d;
            } else {
                this.realValue = Double.Parse (realValue);
            }
        }

        public double RealValue { get { return realValue; } }

        public override string ToString () {
            return realValue.ToString ();
        }

        public override double Calculate (double number) {
            return realValue;
        }
    }

    class BasicFunctionXNode : BaseNode
    {
        public BasicFunctionXNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return number;
        }
    }

    class SinNode : BaseNode
    {
        public SinNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return Math.Sin (left.Calculate (number));
        }
    }


    class CosNode : BaseNode
    {
        public CosNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return Math.Cos (left.Calculate (number));
        }
    }

    class PowerNode : BaseNode
    {
        public PowerNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return Math.Pow (left.Calculate (number), right.Calculate (number));
        }
    }
}
