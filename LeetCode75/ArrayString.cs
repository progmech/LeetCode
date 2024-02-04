using System.Text;

namespace LeetCode75
{
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
    }
}
