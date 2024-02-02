

public class Solution {
    public int[][] Merge(int[][] intervals) {
        // Sort the intervals based on their starting times
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> mergedIntervals = new List<int[]>();

        // Iterate through the sorted intervals
        int[] currentInterval = intervals[0];
        mergedIntervals.Add(currentInterval);

        for (int i = 1; i < intervals.Length; i++) {
            int[] nextInterval = intervals[i];

            // If the current interval's end time is greater than or equal to the next interval's start time, there's an overlap
            if (currentInterval[1] >= nextInterval[0]) {
                // Merge the intervals by updating the current interval's end time to the maximum of the two end times
                currentInterval[1] = Math.Max(currentInterval[1], nextInterval[1]);
            } else {
                // No overlap, start a new merged interval
                currentInterval = nextInterval;
                mergedIntervals.Add(currentInterval);
            }
        }

        return mergedIntervals.ToArray();
    }

    public static void Main(string[] args) {
        // Example usage of the Merge method
        int[][] intervals = new int[][] {
            new int[] { 1, 3 },
            new int[] { 2, 6 },
            new int[] { 8, 10 },
            new int[] { 15, 18 }
        };

        int[][] mergedIntervals = new Solution().Merge(intervals);

        // Print the merged intervals
        foreach (int[] interval in mergedIntervals) {
            Console.WriteLine($"[{interval[0]}, {interval[1]}]");
        }
    }
}
