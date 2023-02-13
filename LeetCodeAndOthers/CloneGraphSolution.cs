using LeetCodeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAndOthers
{
    public class CloneGraphSolution
    {
        public static Node CloneGraph(Node node)
        {
            HashSet<Node> visited = new HashSet<Node>();
            Queue<Node> queue = new Queue<Node>();
            Node Cloned = new Node();

            if (node != null)
                queue.Enqueue(node);

            while(queue.Count > 0)
            {
                Node temp = queue.Dequeue();
            }

            return Cloned;
        }
    }
}
