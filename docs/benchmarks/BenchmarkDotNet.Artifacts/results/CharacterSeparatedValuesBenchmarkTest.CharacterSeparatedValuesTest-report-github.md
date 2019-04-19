``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.706 (1803/April2018Update/Redstone4)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3394.0  [AttachedDebugger]
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3394.0


```
|                Method |          Mean |          Error |         StdDev |        Median |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|---------------------- |--------------:|---------------:|---------------:|--------------:|---------:|---------:|---------:|----------:|
|         CSV_ParseLine | 911,272.69 ns | 38,883.9258 ns | 114,650.132 ns | 896,521.00 ns | 333.0078 | 333.0078 | 333.0078 | 1689260 B |
|  CSV_ParseLine_Memory |      11.62 ns |      0.4562 ns |       1.324 ns |      11.55 ns |   0.0114 |        - |        - |      48 B |
|        CSV_ParseLines | 885,146.04 ns | 60,524.3497 ns | 172,679.375 ns | 836,225.00 ns | 333.0078 | 333.0078 | 333.0078 | 1658400 B |
| CSV_ParseLines_Memory |      12.98 ns |      0.6412 ns |       1.840 ns |      12.73 ns |   0.0114 |        - |        - |      48 B |
