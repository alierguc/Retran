// See https://aka.ms/new-console-template for more information


using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Retran.Convert;
using Retran.DBExport;
using Retran.FileProcess;
using Retran.HttpExport;




var runner = BenchmarkRunner.Run<BenchmarkTests>();

[MemoryDiagnoser]
public class BenchmarkTests
{


    #region GET EXPORT API LOCAL FILE BENCHMARKING
    [Benchmark]
    public void RETRAN_GET_EXPORT_API_TO_LOCAL_CSV_FILE()
    {
        Dictionary<string, object> httpParams = new Dictionary<string, object>();
        httpParams.Add("postId", 1);

        Dictionary<string, object> httpHeaders = new Dictionary<string, object>();
        httpHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        httpHeaders.Add("User-Agent", "application/json");

        RetranHttpExport.GET_ExportApiToLocalCsvFile("https://jsonplaceholder.typicode.com", "/comments",
            @"C:\Users\alier\Desktop\Retran\Retran\csv_output\output_csv_file\output_20221011174322.csv",
            httpParams,
            httpHeaders);
    }

    [Benchmark]
    public void RETRAN_GET_EXPORT_API_TO_LOCAL_JSON_FILE()
    {
        Dictionary<string, object> httpParams = new Dictionary<string, object>();
        httpParams.Add("postId", 1);

        Dictionary<string, object> httpHeaders = new Dictionary<string, object>();
        httpHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        httpHeaders.Add("User-Agent", "application/json");

        RetranHttpExport.GET_ExportApiToLocalJsonFile("https://jsonplaceholder.typicode.com", "/comments",
            @"C:\Users\alier\Desktop\Retran\Retran\json_output\output_json_file\output_20221011174318.csv",
            httpParams,
            httpHeaders);
    }

    [Benchmark]
    public void RETRAN_GET_EXPORT_API_TO_LOCAL_EXCEL_FILE()
    {
        Dictionary<string, object> httpParams = new Dictionary<string, object>();
        httpParams.Add("postId", 1);

        Dictionary<string, object> httpHeaders = new Dictionary<string, object>();
        httpHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        httpHeaders.Add("User-Agent", "application/json");

        RetranHttpExport.GET_ExportApiToLocalExcelFile("https://jsonplaceholder.typicode.com", "/comments",
            @"C:\Users\alier\Desktop\Retran\Retran\excel_output\output_excel_file\output_20221011174754.xlsx",
            httpParams,
            httpHeaders);
    }

    #endregion

    #region MSSQL DB EXPORT BENCHMARKING
    [Benchmark]
    public void RETRAN_MSSQL_DB_TO_EXPORT_LOCAL_JSON_FILE()
    {
        RetranDBExport.MssqlDbToLocalJsonFile("DESKTOP-4KE4D8K", "sa", "sa123456", "MIA.BioID", "AccessPoints", @"C:\Users\alier\Desktop\Retran\Retran\json_output\output_json_file\output_20221011174318.json");
    }


    [Benchmark]
    public void RETRAN_MSSQL_DB_TO_EXPORT_LOCAL_CSV_FILE()
    {
        RetranDBExport.MssqlDbToLocalCsvFile("DESKTOP-4KE4D8K", "sa", "sa123456", "MIA.BioID", "AccessPoints", @"C:\Users\alier\Desktop\Retran\Retran\csv_output\output_csv_file\output_20221011174754.csv");
    }


    [Benchmark]
    public void RETRAN_MSSQL_DB_TO_EXPORT_LOCAL_EXCEL_FILE()
    {
        RetranDBExport.MssqlDbToExcelFile("DESKTOP-4KE4D8K", "sa", "sa123456", "MIA.BioID", "AccessPoints", @"C:\Users\alier\Desktop\Retran\Retran\excel_output\output_excel_file\output_20221011174754.xlsx");
    }
    #endregion

    #region CONVERT FILES BENCHMARKING
    [Benchmark]
    public void RETRAN_CONVERT_JSON_TO_CSV()
    {
        RetranConvert.RetranJsonToCsv(@"C:\Users\alier\Desktop\retran_files\example.json", @"C:\Users\alier\Desktop\retran_files\example.csv");
    }


    [Benchmark]
    public void RETRAN_CONVERT_CSV_TO_JSON()
    {
        RetranConvert.RetranCsvToJson(@"C:\Users\alier\Desktop\retran_files\example.csv", @"C:\Users\alier\Desktop\retran_files\example.json");
    }


    [Benchmark]
    public void RETRAN_CONVERT_JSON_TO_EXCEL()
    {
        RetranConvert.RetranJsonToExcel(@"C:\Users\alier\Desktop\Retran\Retran\json_output\output_json_file\output_20221011174754.json", @"C:\Users\alier\Desktop\Retran\Retran\excel_output\output_excel_file\Import-Data-JSON-To-Excel.xlsx");
    }
    #endregion

    #region CREATE FILE PROCESS BENCHMARKING
    [Benchmark]
    public void RETRAN_CREATE_CSV_FILE()
    {
        RetranFile.RetranCreateCSVFile(@"C:\Users\alier\Desktop\Retran\Retran");
    }

    [Benchmark]
    public void RETRAN_CREATE_JSON_FILE()
    {
        RetranFile.RetranCreateJSONFile(@"C:\Users\alier\Desktop\Retran\Retran");
    }
    #endregion
}



