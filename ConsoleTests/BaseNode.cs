using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class BinaryTree
    {
        public List<BaseNode> roots = new List<BaseNode> ();

        public BinaryTree () {
        }
    }

    class BaseNode
    {
        public string value;
        public BaseNode left, right, parent;

        public void Insert(BaseNode node) {
            if (left == null) {
                left = node;
            } else if (right == null) {
                right = node;
            } else {
                // do nothing
            }
        }

        public BaseNode FindLastLeft() {
            return (left == null ? this : left.FindLastLeft ());
        }
        
        public BaseNode FindLastRight() {
            return (right == null ? this : right.FindLastRight ());
        }
    }

    
    class MultiplicationNode : BaseNode
    {
        public MultiplicationNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }
    }

    class SumNode : BaseNode
    {
        public SumNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }
    }

    class NumberNode : BaseNode
    {
        double realValue;


        public NumberNode(string input, BaseNode parentNode, string realValue) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;


            if (realValue[0] == 'p') {
                this.realValue = 3.14d;
            } else {
                this.realValue = Double.Parse (realValue);
            }
        }
    }

    class BasicFunctionXNode : BaseNode
    {
        public BasicFunctionXNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }
    }

    class SinNode : BaseNode
    {
        public SinNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }
    }

}
