``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19043.2130/21H1/May2021Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.302
  [Host]     : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT AVX2  [AttachedDebugger]
  DefaultJob : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT AVX2


```
|                                     Method |        Mean |     Error |      StdDev |      Median |     Gen0 |     Gen1 |     Gen2 |  Allocated |
|------------------------------------------- |------------:|----------:|------------:|------------:|---------:|---------:|---------:|-----------:|
|    RETRAN_GET_EXPORT_API_TO_LOCAL_CSV_FILE | 41,367.0 μs | 756.92 μs | 1,458.32 μs | 41,104.0 μs |        - |        - |        - |    66.8 KB |
|   RETRAN_GET_EXPORT_API_TO_LOCAL_JSON_FILE | 41,129.2 μs | 816.55 μs | 1,430.12 μs | 40,837.0 μs |        - |        - |        - |   31.42 KB |
|  RETRAN_GET_EXPORT_API_TO_LOCAL_EXCEL_FILE | 44,144.9 μs | 737.06 μs |   653.38 μs | 44,172.4 μs | 750.0000 | 166.6667 |        - | 3854.27 KB |
|  RETRAN_MSSQL_DB_TO_EXPORT_LOCAL_JSON_FILE |    869.9 μs |  31.28 μs |    89.24 μs |    852.8 μs |  15.6250 |   7.8125 |        - |   63.98 KB |
|   RETRAN_MSSQL_DB_TO_EXPORT_LOCAL_CSV_FILE |  1,724.3 μs |  91.87 μs |   265.06 μs |  1,659.4 μs |  29.2969 |   9.7656 |        - |  125.14 KB |
| RETRAN_MSSQL_DB_TO_EXPORT_LOCAL_EXCEL_FILE |  5,955.8 μs | 235.46 μs |   690.57 μs |  5,578.6 μs | 937.5000 | 382.8125 |        - | 4383.74 KB |
|                 RETRAN_CONVERT_JSON_TO_CSV |  4,278.0 μs |  79.26 μs |   186.82 μs |  4,257.5 μs | 351.5625 | 179.6875 |  93.7500 | 2051.53 KB |
|                 RETRAN_CONVERT_CSV_TO_JSON |  3,454.6 μs |  58.29 μs |    51.68 μs |  3,474.7 μs | 273.4375 | 164.0625 | 109.3750 | 1754.58 KB |
|               RETRAN_CONVERT_JSON_TO_EXCEL |  3,797.4 μs |  70.49 μs |    65.93 μs |  3,781.7 μs | 796.8750 | 304.6875 |        - | 3834.64 KB |
|                     RETRAN_CREATE_CSV_FILE |    366.6 μs |   6.71 μs |     5.60 μs |    367.9 μs |        - |        - |        - |    1.01 KB |
|                    RETRAN_CREATE_JSON_FILE |    372.9 μs |   4.96 μs |     4.15 μs |    372.9 μs |        - |        - |        - |    1.03 KB |
