

using System;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] result = new int[2];

        // Iterate through the array, checking each element's complement
        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];

            // Search for the complement in the remaining part of the array
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[j] == complement) {
                    // Found the pair, store their indices
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }

        // If no pair is found, return an empty array
        return result;
    }

    public static void Main(string[] args) {
        int[] nums = new int[] { 2, 7, 11, 15 };
        int target = 9;

        int[] result = new Solution().TwoSum(nums, target);

        if (result.Length == 2) {
            Console.WriteLine("Indices of the two numbers that add up to " + target + ":");
            Console.WriteLine(result[0] + ", " + result[1]);
        } else {
            Console.WriteLine("No two numbers found that add up to " + target);
        }
    }
}

using System.Collections.Generic;

public class Solution2 {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> seenNums = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];

            if (seenNums.ContainsKey(complement)) {
                return new int[] { seenNums[complement], i };
            }

            seenNums.Add(nums[i], i);
        }

        return new int[] {};  // No solution found
    }
}