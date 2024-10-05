//public class Solution
//{
//    public int FindMiddleIndex(int[] nums)
//    {

//        if (nums.Length == 1)
//            return 0;
//        if (nums.Length == 2 && nums[1] == 0)
//            return 0;

//        var lookup = new Dictionary<int, (int left, int right)>();
//        lookup[-1] = (left: 0, 0);
//        lookup[nums.Length] = (0, 0);

//        for (int i = 0; i < nums.Length; i++)
//        {
//            if (lookup.TryGetValue(i, out var value1))
//                lookup[i] = (left: lookup[i - 1].left + nums[i], right: value1.right);
//            else
//                lookup[i] = (left: lookup[i - 1].left + nums[i], right: 0);
//        }

//        for (int i = 0; i < nums.Length; i++)
//        {

//            if (lookup.TryGetValue(nums.Length - 1 - i, out var value2))
//                lookup[nums.Length - 1 - i] = (left: value2.left, right: lookup[nums.Length - i].right + nums[nums.Length - 1 - i]);
//        }
//        for (int i = 0; i < nums.Length; i++)
//        {
//            (int left, int right) = lookup[i];
//            if (left == right)
//                return i;
//        }
//        return -1;

//    }
//}
