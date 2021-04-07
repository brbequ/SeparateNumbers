using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    // A numeric string, s, is beautiful if it can be split into
    // a sequence of two or more positive integers, 
    // a[1], a[2], ..., a[n], satisfying the following conditions:

    // a[i] - a[i-1] = 1 for any 1 < i <= n
    // (i.e., each element in the sequence is 1 more than the
    // previous element).

    // No a[i] contains a leading zero. For example, we can split
    // s = 10203 into the sequence {1,02,03}, but it is not beautiful
    // because 02 and 03 have leading zeroes.

    // The contents of the sequence cannot be rearranged.
    // For example, we can split s=312 into the sequence {3,1,2},
    // but it is not beautiful because it breaks our first constraint
    // (i.e., 1-3 != 1).

    // Perform q queries where each query consists of some integer
    // string s. For each query, print whether or not the string is
    // beautiful on a new line. If it is beautiful, print YES x,
    // where x is the first number of the increasing sequence.
    // If there are multiple such values of x, choose the smallest.
    // Otherwise, print NO.

    // Complete the separateNumbers function below.
    static void separateNumbers(string s)
    {
        const string no = "NO";
        const string yes = "YES {0}";

        // Short circuit a leading zero
        if (s[0] != '0')
        {
            // The maxlen can't be more than half the string length
            int maxlen = s.Length / 2;
            for (int len = 1; len <= maxlen; len++)
            {
                // Get the substring of the first element and
                // convert it to long.
                int idx = 0;
                string s1 = s.Substring(idx, len);
                long l1 = long.Parse(s1);

                // Walk the rest of the string
                do
                {
                    // The string following s1 should equal
                    // s1 + 1. There is a special case to handle
                    // which is when the length of s2 is longer than
                    // s1. For example s1 = 999 and s2 = 1000. To
                    // solve this, I increment l1, and then convert
                    // it back to a string.
                    string s2 = (++l1).ToString();
                    idx += s1.Length;
                    if (idx + s2.Length <= s.Length &&
                        s.Substring(idx, s2.Length) == s2)
                    {
                        s1 = s2;

                        // If at the end of the string, it is beautiful
                        if (idx + s1.Length >= s.Length)
                        {
                            Console.WriteLine(yes, s.Substring(0, len));
                            return;
                        }
                    }
                    else
                    {
                        // No match. Loop around and try a longer initial
                        // string for s1
                        break;
                    }
                } while (true);
            }
        }

        Console.WriteLine(no);
        return;
    }

    static void Main(string[] args)
    {
        string[] testcases = new string[]
        {
            "1234",
            "91011",
            "99100",
            "101103",
            "010203",
            "13",
            "1",
            "99910001001",
            "7891011",
            "9899100",
            "999100010001",
            "429496729542949672964294967297",
            "429496729542949672964294967296",
            "429496729542949672964294967287",
            "429496729542949672964294967197",
            "42949672954294967296429496729",
            "4294967295429496729642949672",
            "429496729500000000000000000001",
            "42949672950123456789",
            "4294967295000010020030000456789",
            "4294967295000102003004005",
        };

        foreach (string s in testcases)
        {
            separateNumbers(s);
        }
    }
}
