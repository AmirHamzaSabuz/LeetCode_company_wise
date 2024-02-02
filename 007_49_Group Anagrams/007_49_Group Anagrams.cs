
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dictionary = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var key = new string(str.OrderBy(c => c).ToArray());

            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, new List<string>());
            }

            dictionary[key].Add(str);
        }

        return dictionary.Values.ToList();
    }

    public static void Main(string[] args)
    {
        // Sample array of strings to group
        string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };

        // Create an instance of the Solution class
        Solution solution = new Solution();

        // Call the GroupAnagrams method to group anagrams
        IList<IList<string>> anagramGroups = solution.GroupAnagrams(strs);

        // Print the grouped anagrams
        foreach (IList<string> group in anagramGroups)
        {
            Console.WriteLine(string.Join(", ", group));
        }
    }


}
