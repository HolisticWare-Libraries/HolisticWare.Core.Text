using System;

namespace Core.Memory
{
    public static class MemoryStringExtensions
    {
        public static string AsString(this System.ReadOnlySpan<char> span)
        {
            int idx = span.IndexOf('\0');

            string result = null;
            if (idx < 0)
            {
                result = new string(span);
            }
            else
            {
                result = new string(span.Slice(0, idx));
            }

            return result;
        }
    }
}
