using System;

namespace Core.Text
{
    public ref struct SpanBuilder
    {
        Span<char> span;
        int position;

        public SpanBuilder(int maxlength)
        {
            span = new Span<char>(new char[maxlength]);
            position = 0;
        }

        internal void Append(ReadOnlySpan<char> str)
        {
            if (position + str.Length > span.Length) throw new IndexOutOfRangeException();
            str.CopyTo(span.Slice(position));
            position += str.Length;
        }

        internal void Append(string stringToAppend)
        {
            ReadOnlySpan<char> str = stringToAppend.AsSpan();
            if (position + str.Length > span.Length) throw new IndexOutOfRangeException();
            str.CopyTo(span.Slice(position));
            position += str.Length;
        }

        internal void Append(char ch)
        {
            Span<char> str = new Span<char>(new char[] { ch });
            if (position + str.Length > span.Length) throw new IndexOutOfRangeException();
            str.CopyTo(span.Slice(position));
            position += str.Length;
        }

        public override string ToString()
        {
            return span.Slice(0, position).ToString();
        }
    }
}
