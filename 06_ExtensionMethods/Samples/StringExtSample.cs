using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System
{
    public static class StringExtSample
    {
        public static int LetterCount(this string @this, char c)
        {
            int count = 0;
            foreach (var @char in @this)
            {
                if (@char == c)
                {
                    count++;
                }
            }
            return count;
        }
        public static string ReplaceFirst(this string value, string search, string replace)
        {
            int pos = value.IndexOf(search);
            if (pos < 0)
            {
                return value;
            }
            return value.Substring(0, pos) + replace + value.Substring(pos + search.Length);
        }
        public static void SaveToFile(this string value, string path, bool createDirIfNotExist = false)
        {
            if (createDirIfNotExist)
            {
                (new FileInfo(path)).Directory.Create();
            }
            File.WriteAllText(path, value);
        }
    }
}
