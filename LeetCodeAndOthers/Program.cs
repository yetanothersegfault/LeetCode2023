using LeetCodeHelpers;

namespace LeetCodeAndOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            Solution sol = new Solution();

            //Running Sum of 1d Array
            //var nums = new int[] { 1, 2, 3, 4 };
            //var RS1DA = sol.RunningSum(nums);

            //var nums = new int[] { -1, 1, 2 };
            //var Pivot = sol.PivotIndex(nums);

            //var IsoString = sol.IsIsomorphic("paper", "title");

            //var isSub = sol.IsSubsequence("axc", "ahbgdc");

            var list1 = ListNode.Create(new int[] { 1, 2, 3 });
            //var list2 = ListNode.Create(new int[] { 1, 3, 4});
            //var merge = sol.MergeTwoLists(list1, list2);

            var reverse = sol.ReverseList(list1);
        }
    }
}