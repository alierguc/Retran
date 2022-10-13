
using Retran.Convert;
using Retran.DBExport;
using Retran.FileProcess;
using Retran.HttpExport;


Console.WriteLine("");





/*RetranConvert.RetranCsvToJson(@"C:\Users\alier\Desktop\Retran\Retran\csv_output\output_csv_file\output_20221011174322.csv",
    @"C:\Users\alier\Desktop\Retran\Retran\excel_output\output_excel_file\output_20221011174311.xlsx");*/



/* EXPORT LOCAL EXCEL FILE
Dictionary<string, object> httpParams = new Dictionary<string, object>();
httpParams.Add("postId", 1);

Dictionary<string, object> httpHeaders = new Dictionary<string, object>();
httpHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
httpHeaders.Add("User-Agent", "application/json");

RetranHttpExport.GET_ExportApiToLocalExcelFile("https://jsonplaceholder.typicode.com", "/comments",
    @"C:\Users\alier\Desktop\Retran\Retran\excel_output\output_excel_file\output_20221011174754.xlsx",
    httpParams,
    httpHeaders);
*/


/* MSSQL JSON CSV
RetranDBExport.MssqlDbToLocalJsonFile("DESKTOP-4KE4D8K","sa","sa123456", "MIA.BioID", "AccessPoints", @"C:\Users\alier\Desktop\Retran\Retran\json_output\output_json_file\output_20221011174318.json");
RetranDBExport.MssqlDbToLocalCsvFile("DESKTOP-4KE4D8K","sa","sa123456", "MIA.BioID", "AccessPoints", @"C:\Users\alier\Desktop\Retran\Retran\csv_output\output_csv_file\output_20221011174754.csv");
RetranDBExport.MssqlDbToExcelFile("DESKTOP-4KE4D8K", "sa", "sa123456", "MIA.BioID", "AccessPoints", @"C:\Users\alier\Desktop\Retran\Retran\excel_output\output_excel_file\output_20221011174754.xlsx");
 */



/*  GET REQUEST LOCAL CSV FILE
Dictionary<string, object> httpParams = new Dictionary<string, object>();
httpParams.Add("postId", 1);

Dictionary<string, object> httpHeaders = new Dictionary<string, object>();
httpHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
httpHeaders.Add("User-Agent", "application/json");

RetranHttpExport.GET_ExportApiToLocalCsvFile("https://jsonplaceholder.typicode.com","/comments",
    @"C:\Users\alier\Desktop\Retran\Retran\csv_output\output_csv_file\output_20221011174322.csv",
    httpParams,
    httpHeaders);
*/




/* GET REQUEST LOCAL JSON FILE
RetranHttpExport.GET_ExportApiToLocalJsonFile("https://jsonplaceholder.typicode.com","/comments",
    @"C:\Users\alier\Desktop\Retran\Retran\json_output\output_json_file\output_20221011174754.json",
    httpParams,
    httpHeaders);

*/




/* CREATE FİLE AND FOLDERS
var newCreatedJsonPath = RetranFile.RetranCreateJSONFile(@"C:\Users\alier\Desktop\Retran\Retran");
var newCreatedCSVPath = RetranFile.RetranCreateCSVFile(@"C:\Users\alier\Desktop\Retran\Retran");
*/





// Convert JSON, CSV AND EXCEL
//RetranConvert.RetranJsonToCsv(@"C:\Users\alier\Desktop\retran_files\example.json", @"C:\Users\alier\Desktop\retran_files\example.csv");
//RetranConvert.RetranCsvToJson(@"C:\Users\alier\Desktop\retran_files\example.csv", @"C:\Users\alier\Desktop\retran_files\example.json");
//RetranConvert.RetranJsonToExcel(@"C:\Users\alier\Desktop\Retran\Retran\json_output\output_json_file\output_20221011174754.json",@"C:\Users\alier\Desktop\Retran\Retran\excel_output\output_excel_file\Import-Data-JSON-To-Excel.xlsx");

