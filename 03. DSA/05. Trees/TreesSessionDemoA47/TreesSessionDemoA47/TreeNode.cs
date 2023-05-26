using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesSessionDemoA47
{
    public class TreeNode
    {
        public TreeNode(int value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }

        public int Value { get;  }

        public List<TreeNode> Children { get; }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
