using System.Text;

namespace LeetCode75;

internal class ArrayString
{
    // Easy 1768. Merge Strings Alternately
    /// <summary>
    /// Merges two strings by adding letters in alternating order, starting with word1.
    /// If a string is longer than the other, appends the additional letters onto the end of the merged string.
    /// </summary>
    /// <param name="word1"></param>
    /// <param name="word2"></param>
    /// <returns>The merged string.</returns>
    internal static string MergeAlternately(string word1, string word2)
    {
        int rightBound;
        string restOfString;
        if (word1.Length > word2.Length)
        {
            rightBound = word2.Length;
            restOfString = word1[(rightBound)..];
        }
        else if (word1.Length < word2.Length)
        {
            rightBound = word1.Length;
            restOfString = word2[(rightBound)..];
        }
        else
        {
            rightBound = word1.Length;
            restOfString = string.Empty;
        }

        StringBuilder builder = new();
        for (int i = 0; i < rightBound; i++)
        {
            builder.Append(word1[i]);
            builder.Append(word2[i]);
        }

        if (restOfString.Length > 0)
        {
            builder.Append(restOfString);
        }

        return builder.ToString();
    }

    // Easy 1071. Greatest Common Divisor of Strings
    /// <summary>
    /// For two strings s and t, we say "t divides s" if and only if s = t + ... + t
    /// (i.e., t is concatenated with itself one or more times).
    /// Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns>The largest string x such that x divides both str1 and str2</returns>
    internal static string GcdOfStrings(string str1, string str2)
    {
        string result = string.Empty;
        string biggestString = str1.Length > str2.Length ? str1 : str2;
        string smallestString = str1.Length > str2.Length ? str2 : str1;
        for (int i = smallestString.Length; i >= 0; i--)
        {
            string divisor = smallestString[0..i];
            var bigDivided = biggestString.Split(divisor);
            var smallDivided = smallestString.Split(divisor);
            if (bigDivided.Any(s => s == biggestString))
            {
                break;
            }
            if (bigDivided.Any(s => s.Length > 0) || smallDivided.Any(s => s.Length > 0))
            {
                continue;
            }

            result = divisor;
            break;
        }

        return result;
    }

    // Easy 1431. Kids With the Greatest Number of Candies
    /// <summary>
    /// There are n kids with candies. You are given an integer array candies, 
    /// where each candies[i] represents the number of candies the ith kid has, 
    /// and an integer extraCandies, denoting the number of extra candies that you have.
    /// Note that multiple kids can have the greatest number of candies.
    /// </summary>
    /// <param name="candies"></param>
    /// <param name="extraCandies"></param>
    /// <returns>A boolean array result of length n, where result[i] is true if,
    /// after giving the ith kid all the extraCandies, they will have the greatest
    /// number of candies among all the kids, or false otherwise.</returns>
    internal static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        return candies.Select(x => x + extraCandies >= candies.Max()).ToArray();
    }
}
