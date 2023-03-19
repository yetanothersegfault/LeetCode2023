using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeetCodeHelpers;

/*
 * Contents:
 * 1) Running Sum of 1d Array (easy)
 * 2) Find Pivot Index (easy)
 * 3) Isomorphic Strings (easy)
 * 4) Is Subsequence (easy)
 * 5) Merge Two Lists (easy)
 * 6) Reverse List (easy)
 * 7) Middle of the Linked List (easy)
 * 8) Numbers With Same Consecutive Differences (medium)
 */

namespace LeetCodeAndOthers
{
    public class Solution
    {

        public int[] RunningSum(int[] nums)
        {
            var Result = new int[nums.Length];

            int RunSum = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                RunSum += nums[i];
                Result[i] = RunSum;
            }

            return Result;
        }

        public int PivotIndex(int[] nums)
        {
            int pivot = 0;
            int leftSum = 0;
            int rightSum = nums.ToList().GetRange(1, nums.Length - 1).Sum();

            while(pivot < nums.Length - 1 && (leftSum != rightSum))
            {
                leftSum += nums[pivot];
                pivot++;
                //take from right side and move to left
                rightSum -= nums[pivot];
            }

            // Check left and right sum if we are at the end
            if (pivot == nums.Length - 1 && leftSum != rightSum)
                pivot = -1;

            return pivot;
        }

        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> dic = new Dictionary<char, char>();
            Dictionary<char, char> dicopp = new Dictionary<char, char>();
            for(int i = 0; i < s.Length; i++)
            {
                if(dic.ContainsKey(s[i]) || dicopp.ContainsKey(t[i]))
                {
                    if (dic.GetValueOrDefault(s[i]) != t[i] || dicopp.GetValueOrDefault(t[i]) != s[i])
                    {
                        return false;
                    }
                }
                else
                {
                    dic.Add(s[i], t[i]);
                    dicopp.Add(t[i], s[i]);
                }
            }

            return true;
        }

        public bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0 || t.Length == 0)
                return true;

            int j = 0;
            for(int i = 0; i < t.Length; i++)
            {
                if (s[j] == t[i])
                {
                    j++;
                    if(j == s.Length)
                    {
                        return true;
                    }    
                }
            }
            return false;
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var ret = new ListNode();

            var trav = ret;

            while(list1 != null || list2 != null)
            {
                if (list1 == null)
                    Merge(ref list2, ref trav);
                else if (list2 == null)
                    Merge(ref list1 , ref trav);
                else
                {
                    if (list1.val <= list2.val)
                        Merge(ref list1, ref trav);
                    else
                        Merge(ref list2, ref trav);
                }
            }

            return ret.next;
        }

        public static void Merge(ref ListNode list1, ref ListNode list2)
        {
            // make new node and add it to the list
            var node = new ListNode(list1.val, null);
            list2.next = node;

            // point to the next
            list1 = list1.next;
            list2 = list2.next;
        }

        public ListNode ReverseList(ListNode head) 
        {
            // case in which list is empty
            if (head == null)
                return head;

            // go through the linked list and get the nodes in reverse order
            var list = new List<ListNode>();
            Traverse(head, ref list);

            // point to new head
            head = list.First();

            for(int i =0; i < list.Count - 1; i++)
            {
                list[i].next = list[i + 1];
            }

            return head;
        }

        public void Traverse(ListNode head, ref List<ListNode> list)
        {
            // keep going till we find the end
            if(head.next != null)
                Traverse(head.next, ref list);

            // remove the next as we will be replacing them
            head.next = null;

            list.Add(head);
        }

        public ListNode MiddleNode(ListNode head)
        {
            if (head == null)
                return head;

            var list = new List<ListNode>();
            while(head != null) 
            { 
                list.Add(head);
                head = head.next;
            }

            int half = list.Count / 2;

            return list[half];
        }

        public ListNode DetectCycle(ListNode head)
        {
            var dic = new Dictionary<ListNode, int>();

            while(head != null ) 
            {
                if (!dic.ContainsKey(head))
                    dic.Add(head, 1);
                else
                    return head;
            }

            return null;
        }

        public int[] NumsSameConsecDiff(int n, int k)
        {
            List<int> list = new List<int>();

            var trees = new List<TreeNode>();

            //make trees

            //start loop at 1 since the values can not start at zero eg 070 (n = 3, k=7) or 0246 (n = 4, k = 2)
            for(int i = 1; i < 10; i++)
            {
                int level = 0;

                var tree = new TreeNode(i);
                trees.Add(tree);

                var queue = new Queue<TreeNode>();
                queue.Enqueue(tree);

                var NextLevel = new Queue<TreeNode>();

                while(queue.Count > 0 && level < n - 1)
                {
                    var node = queue.Dequeue();

                    if(node.val - k >= 0)
                    {
                        var lNode = new TreeNode(node.val - k);
                        node.Left = lNode;
                        NextLevel.Enqueue(lNode);
                    }

                    if (node.val + k < 10)
                    {
                        var rNode = new TreeNode(node.val + k);
                        node.Right = rNode;
                        NextLevel.Enqueue(rNode);
                    }

                    // when the original queue is empty we will be on the next level down
                    // Copy the next level down to the queue to keep going if there is another level to explore
                    if (queue.Count == 0)
                    {
                        level++;

                        if(level != n)
                        {
                            queue = new Queue<TreeNode>(NextLevel);
                            NextLevel.Clear();
                        }
                    }
                }
            }

            //traverse trees for values

            foreach(var t in trees)
            {
                //skip over tree if both left and right are null since this contains no values
                if (t.Left == null && t.Right == null) continue;

                var sb = new StringBuilder();
                sb.Append(t.val.ToString());

                if(t.Left != null)
                    CreateString(t.Left, sb.ToString(), ref list);

                if(t.Right != null)
                    CreateString(t.Right, sb.ToString(), ref list);
            }

            return list.ToHashSet().ToArray();
        }

        public static void CreateString(TreeNode t, string val, ref List<int> list)
        {
            var sb = new StringBuilder(val);

            // check to see if at the end of the line
            if (t.Left == null && t.Right == null)
            {
                list.Add(int.Parse(sb.Append(t.val).ToString()));
                return;
            }

            sb.Append(t.val.ToString());

            if(t.Left != null)
                CreateString(t.Left, sb.ToString(), ref list);

            if (t.Right != null)
                CreateString(t.Right, sb.ToString(), ref list);
        }
    }
}
