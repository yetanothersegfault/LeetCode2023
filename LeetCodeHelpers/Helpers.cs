using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHelpers
{
    public class Node
    {
        public int Val;
        public IList<Node> Neighbors;

        public Node()
        {
            Val = 0;
            Neighbors = new List<Node>();
        }

        public Node(int val)
        {
            Val = val;
            Neighbors = new List<Node>();
        }

        public Node(int val, IList<Node> neighbors)
        {
            Val = val;
            Neighbors = neighbors;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode (int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode Create(int[] array)
        {
            if(array.Length == 0)
                return null;

            var ret = new ListNode(array[0]);
            var next = ret;

            for(int i =1; i < array.Length; i++)
            {
                var node = new ListNode(array[i]);
                next.next = node;
                next = next.next;
            }

            return ret;
        }

        public static ListNode CreateWithCycle(int[] array)
        {
            if (array.Length == 0)
                return null;

            var ret = new ListNode(array[0]);
            var next = ret;

            for (int i = 1; i < array.Length; i++)
            {
                var node = new ListNode(array[i]);
                next.next = node;
                next = next.next;
            }

            return ret;
        }
    }


}
