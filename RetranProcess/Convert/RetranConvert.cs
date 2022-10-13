using Aspose.Cells;
using Aspose.Cells.Utility;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retran.Convert
{
    public class RetranConvert
    {
 
        /// <summary>
        /// <description>
        /// <b>It converts <u>"JSON"</u> content to <u>"CSV"</u> content. If there is no <u>"CSV"</u> file, it creates a new <u>"CSV"</u> file and writes the content to this file.</b>
        /// </description>
        /// <list type="bullet|number|table">
        /// <listheader>
        ///   <term><paramref name="_targetJsonFilePath"/> : </term>
        ///  <description>It is the string value that contains the <b><u>JSON</u></b> object. It should be given in the Json standard.</description>
        ///</listheader>
        ///<item>
        ///     <term><paramref name="_targetCsvFilePath"/> : </term>
        ///    <description>is the parameter value that represents the <b><u>CSV</u></b> file path to be exported.</description>
        /// </item>
        ///</list>
        /// <description>
        /// Example method usage is as follows.
        /// </description>
        ///<code>
        /// ConvertibleProcess.JsonToCsv(jsonContent, @"C:\Users\alierguc\documents\retran_files\example.csv, false");
        ///</code>
        /// </summary>
        /// <param name="_targetJsonFilePath"></param>
        /// <param name="_targetCsvFilePath"></param>
        /// <returns>bool</returns>
        public static bool RetranJsonToCsv(
            string _targetJsonFilePath, 
            string _targetCsvFilePath)
        {

            string _csvFilePath = String.Empty;
            string _createFolderPath = @$"{_targetCsvFilePath}\output";
            try
            {          
                    var expandos = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject[]>(System.IO.File.ReadAllText(_targetJsonFilePath));
                    using (TextWriter writer = new StreamWriter(_targetCsvFilePath))
                    {
                        using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
                        {
                            csv.WriteRecords((expandos as IEnumerable<dynamic>));
                        }

                        return true;
                    }    
            }
            catch
            {
                return false;
            }
        }




        /// <summary>
        /// <description>
        /// <b>It converts "CSV" content to "JSON" content. If there is no CSV file, it creates a new csv file and writes the content to this file.</b>
        /// </description>
        /// <list type="bullet|number|table">
        /// <listheader>
        ///   <term><paramref name="_csvFilePath"/> : </term>
        ///  <description>It is the string value that contains the <b>Json</b> object. It should be given in the Json standard.</description>
        ///</listheader>
        ///<item>
        ///     <term><paramref name="_targetJsonPath"/> : </term>
        ///    <description>is the parameter value that represents the <b>CSV</b> file path to be exported.</description>
        /// </item>
        ///</list>
        /// <description>
        /// Example method usage is as follows.
        /// </description>
        ///<code>
        /// ConvertibleProcess.JsonToCsv(jsonContent, @"C:\Users\alierguc\Desktop\retran_files\example.csv, false");
        ///</code>
        /// </summary>
        /// <param name="_csvFilePath"></param>
        /// <param name="_targetJsonPath"></param>
        /// <returns>bool</returns>
        public static bool RetranCsvToJson(string _csvFilePath, string _targetJsonPath)
        {
            try
            {

                var csv = new List<string[]>();
                var lines = File.ReadAllLines(_csvFilePath);

                foreach (string line in lines)
                    csv.Add(line.Split(','));

                var properties = lines[0].Split(',');

                var listObjResult = new List<Dictionary<string, string>>();

                for (int i = 1; i < lines.Length; i++)
                {
                    var objResult = new Dictionary<string, string>();
                    for (int j = 0; j < properties.Length; j++)
                        objResult.Add(properties[j], csv[i][j]);

                    listObjResult.Add(objResult);
                }
                var jsConv = JsonConvert.SerializeObject(listObjResult);
                File.WriteAllText(_targetJsonPath, jsConv);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// <description>
        /// <b>This method converts the <u>"JSON"</u> file content to <u>"EXCEL"</u> file content and saves it to the file location.</b>
        /// </description>
        /// <list type="bullet|number|table">
        /// <listheader>
        ///   <term><paramref name="_jsonFilePath"/> : </term>
        ///  <description>It is the string value that contains the <b>Json</b> object. It should be given in the Json standard.</description>
        ///</listheader>
        ///<item>
        ///     <term><paramref name="_targetExcelFilePath"/> : </term>
        ///    <description>is the parameter value that represents the <b>EXCEL</b> file path to be exported.</description>
        /// </item>
        ///</list>
        /// <description>
        /// Example method usage is as follows.
        /// </description>
        ///<code>
        /// RetranConvert.RetranJsonToExcel(@"C:\Users\alierguc\Retran\json_output\output_json_file\output_20221011174754.json"
        /// ,@"C:\Users\alierguc\Retran\excel_output\output_excel_file\output_20221011174754.xlsx");
        ///</code>
        /// </summary>
        /// <param name="_jsonFilePath"></param>
        /// <param name="_targetExcelFilePath"></param>
        /// <returns>bool</returns>
        public static bool RetranJsonToExcel(string _jsonFilePath, string _targetExcelFilePath)
        {
            try
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.Worksheets[0];
                string jsonInput = File.ReadAllText(_jsonFilePath);
                var sss = JsonConvert.SerializeObject(jsonInput);
                JsonLayoutOptions options = new JsonLayoutOptions();
                options.ArrayAsTable = true;
                JsonUtility.ImportData(jsonInput, worksheet.Cells, 0, 0, options);
                workbook.Save(_targetExcelFilePath);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

    }
}
