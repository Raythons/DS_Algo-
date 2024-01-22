using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Node
    {
        public Node Next;
        public int Data;
        public Node(int data)
        {
            Data = data;
        }
    }
}
