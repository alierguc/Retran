# Retran \ Exporting - Converting
### 


![alt text](https://github.com/alierguc/git-raw/blob/master/retran_logo_500x500.png?raw=true)

#### **Retran** is a package that has various file conversion processes, allows you to import data from api in the file format you specify, and also creates **( CSV, JSON, EXCEL )** files, speeds up and simplifies work.You can connect to the database and transfer it as a (JSON, CSV or EXCEL) file.


## - File Conversions Operations
- ##### **It is a module where you can perform file conversion operations. You can perform various translation operations on your JSON, CSV and EXCEL files.**
> **Note:** To use the methods, You need to add the following namespace.
```C#
using Retran.Convert;
```
- ***JsonToCsv***
	- *It is a method by which you can convert csv files to json files.*
	***-<sub> Example method usage is as follows.</sub>***
	> **Note:** The parameters you need to pay attention to when using the ***<sup>RetranJsonToCsv</sup>*** class are; The first parameter represents the file location you will convert to, the second parameter represents the target file location..

```C#
RetranConvert.RetranJsonToCsv(@"C:\alierguc\retran_files\example.json", @"C:\alierguc\retran_files\example.csv");
```
### 
	
- ***CsvToJson***
	- *It is a method by which you can convert json files to csv files.*
	***-<sub> Example method usage is as follows.</sub>***
	> **Note:** The parameters you need to pay attention to when using the ***RetranCsvToJson*** class are; The first parameter represents the file location you will convert to, the second parameter represents the target file location..

```C#
RetranConvert.RetranCsvToJson(@"C:\Users\alier\Desktop\retran_files\example.csv", @"C:\Users\alier\Desktop\retran_files\example.json");
```


- ***JsonToExcel***
	- *It is a method by which you can convert json files to excel files.*
	***-<sub> Example method usage is as follows.</sub>***
	> **Note:** The parameters you need to pay attention to when using the ***JsonToExcel*** class are; The first parameter represents the file location you will convert to, the second parameter represents the target file location.

```C#
RetranConvert.RetranJsonToExcel(@"C:\Users\alier\Desktop\retran_files\json_output\output_json_file\output_20221011174754.json",@"C:\Users\alier\Desktop\retran_files\excel_output\output_\output_20221011174754.xlsx");
```

## - Database Export Operations
- ##### **It allows you to transfer the data in your database to your JSON, CSV and Excel files by establishing a database connection.**
> **Note:** To use the methods, You need to add the following namespace.
```C#
using Retran.DBExport;
```

- ***MssqlDbToLocalJsonFile***
	- *This method allows you to transfer data to the **JSON** file location you specified by making a database connection. The database it uses is MSSQL.*
	***-<sub> Example method usage is as follows.</sub>***

```C#
RetranDBExport.MssqlDbToLocalJsonFile("server_name","user_id","uyser_password", "database_name", "table_name", @"C:\alierguc\Retran\json_output\output_json_file\output_20221011174318.json");
;
```
### 
	
- ***MssqlDbToLocalCsvFile***
	- *This method allows you to transfer data to the **CSV** file location you specified by making a database connection. The database it uses is MSSQL.*
	***-<sub> Example method usage is as follows.</sub>***

```C#
RetranDBExport.MssqlDbToLocalCsvFile("server_name","user_id","uyser_password", "database_name", "table_name", @"C:\alierguc\Retran\json_output\output_csv_file\output_20221011174318.csv");
```


- ***MssqlDbToExcelFile***
	- *This method allows you to transfer data to the **EXCEL** file location you specified by making a database connection. The database it uses is MSSQL.*
	***-<sub> Example method usage is as follows.</sub>***

```C#
RetranDBExport.MssqlDbToExcelFile("server_name","user_id","uyser_password", "database_name", "table_name", @"C:\alierguc\Retran\excel_output\output_excel_file\output_20221011174318.xlsx");
```
## - File Process Operations
- ##### **This method does file and folder creation operations. It allows you to generate JSON or CSV File and folders optionally. Returns the directory of the file it creates.**
> **Note:** To use the methods, You need to add the following namespace.
```C#
using Retran.FileProcess;
```

- ***RetranCreateJSONFile***
	- *Generates **JSON** file to specified directory.*
	***-<sub> Example method usage is as follows.</sub>***

```C#
var newCreatedJsonPath = RetranFile.RetranCreateJSONFile(@"target_created_json_path");
```
### 
	
- ***newCreatedCSVPath***
	- *Generates **CSV** file to specified directory.*
	***-<sub> Example method usage is as follows.</sub>***

```C#
var newCreatedCSVPath = RetranFile.RetranCreateCSVFile(@"target_created_csv_path");
```

## - HTTP Export Operations
- ##### **It receives the data according to the HTTP ( GET ) request, transfers the specified file type ( JSON, CSV, EXCEL).**
> **Note:** To use the methods, You need to add the following namespace.
```C#
using Retran.HttpExport;
```

- ***GET_ExportApiToLocalExcelFile***
	- *This method receives the data by making an **HTTP** request and writes to the specified excel file.*
	***-<sub> Example method usage is as follows.</sub>***

```C#
Dictionary<string, object> httpParams = new Dictionary<string, object>();
httpParams.Add("postId", 1);

Dictionary<string, object> httpHeaders = new Dictionary<string, object>();
httpHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
httpHeaders.Add("User-Agent", "application/json");

RetranHttpExport.GET_ExportApiToLocalExcelFile("https://jsonplaceholder.typicode.com", "/comments",
    @"target_excel_folder_path\output_20221011174754.xlsx",
    httpParams,
    httpHeaders);
```
### 
	
- ***GET_ExportApiToLocalCsvFile***
	- *This method receives the data by making an **HTTP** request and writes to the specified **CSV** file..*
	***-<sub> Example method usage is as follows.</sub>***

```C#
Dictionary<string, object> httpParams = new Dictionary<string, object>();
httpParams.Add("postId", 1);

Dictionary<string, object> httpHeaders = new Dictionary<string, object>();
httpHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
httpHeaders.Add("User-Agent", "application/json");

RetranHttpExport.GET_ExportApiToLocalCsvFile("https://jsonplaceholder.typicode.com", "/comments",
    @"target_csv_folder_path\output_20221011174754.csv",
    httpParams,
    httpHeaders);
```

- ***GET_ExportApiToLocalJsonFile***
	- *This method receives the data by making an **HTTP** request and writes to the specified **JSON** file..*
	***-<sub> Example method usage is as follows.</sub>***

```C#
Dictionary<string, object> httpParams = new Dictionary<string, object>();
httpParams.Add("postId", 1);

Dictionary<string, object> httpHeaders = new Dictionary<string, object>();
httpHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
httpHeaders.Add("User-Agent", "application/json");

RetranHttpExport.GET_ExportApiToLocalJsonFile("https://jsonplaceholder.typicode.com", "/comments",
    @"target_json_folder_path\output_20221011174754.json",
    httpParams,
    httpHeaders);
```
## - BENCHMARKING
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



