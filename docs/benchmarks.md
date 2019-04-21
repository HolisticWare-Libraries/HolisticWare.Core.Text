# Benchmarks

benchmarks.md

##  CSV Parsing

### 2019-03-02

```
                    time [ns]           Memory [B]
String Split        300,700.36          701,244
Span                14                  16
Memory              15                  16
```

Windows

```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.706 (1803/April2018Update/Redstone4)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3394.0  [AttachedDebugger]
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3394.0
```

|                Method |           Mean |          Error |         StdDev |
|---------------------- |---------------:|---------------:|---------------:|
|         CSV_ParseLine | 775,270.183 ns | 15,237.3861 ns | 32,800.0810 ns |
|  CSV_ParseLine_Memory |      10.632 ns |      0.2119 ns |      0.3106 ns |
|        CSV_ParseLines | 634,861.563 ns | 10,148.6606 ns |  9,493.0634 ns |
| CSV_ParseLines_Memory |       8.699 ns |      0.1729 ns |      0.1617 ns |



```
BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.4 (18E226) [Darwin 18.5.0]
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : Mono 5.18.1.3 (2018-08/fdb26b0a445 Wed), 32bit  [AttachedDebugger]
  DefaultJob : Mono 5.18.1.3 (2018-08/fdb26b0a445 Wed), 64bit
```


|                Method |            Mean |          Error |         StdDev |
|---------------------- |----------------:|---------------:|---------------:|
|         CSV_ParseLine | 1,291,304.99 ns | 24,913.4061 ns | 31,507.4818 ns |
|  CSV_ParseLine_Memory |        23.26 ns |      0.3006 ns |      0.2812 ns |
|        CSV_ParseLines |   979,109.27 ns | 12,021.1162 ns | 10,038.1764 ns |
| CSV_ParseLines_Memory |        21.47 ns |      0.4506 ns |      0.5189 ns |


## File Reading
