
using System;

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        if (prices == null || prices.Length <= 1)
        {
            return 0; // Handle invalid input and edge cases
        }

        int minPrice = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            minPrice = Math.Min(minPrice, prices[i]); // Update minimum buying price continuously
            maxProfit = Math.Max(maxProfit, prices[i] - minPrice); // Calculate profit based on current price and minimum buying price
        }

        return maxProfit;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int[] prices1 = { 7, 1, 5, 3, 6, 4 };
        int[] prices2 = { 7, 6, 4, 3, 1 };

        Solution solution = new Solution();
        int maxProfit1 = solution.MaxProfit(prices1);
        int maxProfit2 = solution.MaxProfit(prices2);

        Console.WriteLine("Max profit for prices1: {0}", maxProfit1);    // Output: 5
        Console.WriteLine("Max profit for prices2: {0}", maxProfit2);    // Output: 0
    }
}
