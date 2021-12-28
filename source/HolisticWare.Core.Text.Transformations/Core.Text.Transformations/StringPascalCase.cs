using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Text.Transformations
{
    /// <summary>
    /// Convert sreing to PascalCase
    /// </summary>
    public static partial class StringPascalCase
    {
        public static
            string
                                    ToPascalCase
                                                (
                                                    this string s,
                                                    string replacement = "#"
                                                )
        {
            string result = null;

            if (string.IsNullOrEmpty(s))
            {
                return result;
            }

            string tmp = string.Join
                                    (
                                        string.Empty,
                                        // leave letters or digits
                                        // lowercase letters
                                        // rest replace with replacement string
                                        s
                                            .Select(c => char.IsLetterOrDigit(c) ? c.ToString().ToLower() : replacement)
                                            .ToArray()
                                    );

            string[] parts = tmp
                                .Split(new[] { replacement }, StringSplitOptions.RemoveEmptyEntries)
                                // loop faster than LINQ?
                                .Select(str => $"{str.Substring(0, 1).ToUpper()}{str.Substring(1)}")
                                .ToArray()
                                ;

            return string.Join(string.Empty, parts);
        }

        public static
            IEnumerable<string>
                                    ToPascalCase
                                                (
                                                    this IEnumerable<string> strings,
                                                    string replacement = "#"
                                                )
        {
            foreach (string s in strings)
            {
                yield return s.ToPascalCase();
            }
        }
    }
}
