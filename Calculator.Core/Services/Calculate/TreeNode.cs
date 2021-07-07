using Calculator.Core.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Calculate
{
    public class TreeNode
    {
        public CalculateElementBase Token { get; set; }
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }

        public TreeNode()
        {

        }

        public TreeNode(CalculateElementBase token)
        {
            Token = token;
        }
    }
}
