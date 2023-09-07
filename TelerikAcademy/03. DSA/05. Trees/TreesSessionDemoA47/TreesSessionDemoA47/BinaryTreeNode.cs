using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesSessionDemoA47
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode Right { get; set; }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
