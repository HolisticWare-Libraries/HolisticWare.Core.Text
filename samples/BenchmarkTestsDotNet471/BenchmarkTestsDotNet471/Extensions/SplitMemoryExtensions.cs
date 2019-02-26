using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace BenchmarkTestsDotNet471.Extensions
{
    public static class SplitMemoryExtensions
    {
        public ref struct Enumerable<T> where T : IEquatable<T>
        {
            public Enumerable(ReadOnlyMemory<T> memory, Span<T> separators)
            {
                Memory = memory;
                Separators = separators;
            }

            ReadOnlyMemory<T> Memory { get; }
            Span<T> Separators { get; }

            public Enumerator<T> GetEnumerator() => new Enumerator<T>(Memory, Separators);
        }

        public ref struct Enumerator<T> where T : IEquatable<T>
        {
            public Enumerator(ReadOnlyMemory<T> memory, Span<T> separators)
            {
                Memory = memory;
                Separators = separators;
                Current = default;

                if (Memory.IsEmpty)
                    TrailingEmptyItem = true;
            }

            ReadOnlyMemory<T> Memory { get; set; }
            Span<T> Separators { get; }
            int SeparatorLength => 1;

            ReadOnlyMemory<T> TrailingEmptyItemSentinel => Unsafe.As<T[]>(nameof(TrailingEmptyItemSentinel)).AsMemory();

            bool TrailingEmptyItem
            {
                get => Memory.Equals(TrailingEmptyItemSentinel);
                set => Memory = value ? TrailingEmptyItemSentinel : default;
            }

            public bool MoveNext()
            {
                if (TrailingEmptyItem)
                {
                    TrailingEmptyItem = false;
                    Current = default;
                    return true;
                }

                if (Memory.IsEmpty)
                {
                    Memory = Current = default;
                    return false;
                }

                int idx = Memory.Span.IndexOfAny(Separators);
                if (idx < 0)
                {
                    Current = Memory;
                    Memory = default;
                }
                else
                {
                    Current = Memory.Slice(0, idx);
                    Memory = Memory.Slice(idx + SeparatorLength);
                    if (Memory.IsEmpty)
                        TrailingEmptyItem = true;
                }

                return true;
            }

            public ReadOnlyMemory<T> Current { get; private set; }
        }

        [Pure]
        public static Enumerable<T> Split<T>(this ReadOnlyMemory<T> memory, Span<T> values)
            where T : IEquatable<T> => new Enumerable<T>(memory, values);
    }
}
