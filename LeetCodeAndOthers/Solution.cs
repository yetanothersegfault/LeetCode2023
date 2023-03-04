﻿using System;
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
            var ret = new ListNode(head.val);
            if(head.next != null)
            {
                var node = ReverseList(head.next);
                node.next = ret;
            }

            return ret;
        }
    }
}
