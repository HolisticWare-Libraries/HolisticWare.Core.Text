using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace BenchmarkTestsDotNet471.Extensions
{
    public static class SplitSpanExtensions
    {
        public ref struct Enumerable<T> where T : IEquatable<T>
        {
            public Enumerable(ReadOnlySpan<T> span, ReadOnlySpan<T> separators)
            {
                Span = span;
                Separators = separators;
            }

            ReadOnlySpan<T> Span { get; }
            ReadOnlySpan<T> Separators { get; }

            public Enumerator<T> GetEnumerator() => new Enumerator<T>(Span, Separators);
        }

        public ref struct Enumerator<T> where T : IEquatable<T>
        {
            public Enumerator(ReadOnlySpan<T> span, ReadOnlySpan<T> separators)
            {
                Span = span;
                Separators = separators;
                Current = default;

                if (Span.IsEmpty)
                    TrailingEmptyItem = true;
            }

            ReadOnlySpan<T> Span { get; set; }
            ReadOnlySpan<T> Separators { get; }
            int SeparatorLength => 1;

            ReadOnlySpan<T> TrailingEmptyItemSentinel => Unsafe.As<T[]>(nameof(TrailingEmptyItemSentinel)).AsSpan();

            bool TrailingEmptyItem
            {
                get => Span == TrailingEmptyItemSentinel;
                set => Span = value ? TrailingEmptyItemSentinel : default;
            }

            public bool MoveNext()
            {
                if (TrailingEmptyItem)
                {
                    TrailingEmptyItem = false;
                    Current = default;
                    return true;
                }

                if (Span.IsEmpty)
                {
                    Span = Current = default;
                    return false;
                }

                int idx = Span.IndexOfAny(Separators);
                if (idx < 0)
                {
                    Current = Span;
                    Span = default;
                }
                else
                {
                    Current = Span.Slice(0, idx);
                    Span = Span.Slice(idx + SeparatorLength);
                    if (Span.IsEmpty)
                        TrailingEmptyItem = true;
                }

                return true;
            }

            public ReadOnlySpan<T> Current { get; private set; }
        }

        [Pure]
        public static Enumerable<T> Split<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> values)
            where T : IEquatable<T> => new Enumerable<T>(span, values);
    }
}
