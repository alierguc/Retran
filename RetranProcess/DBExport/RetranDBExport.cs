using Aspose.Cells;
using Aspose.Cells.Utility;
using CsvHelper;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retran.DBExport
{
    public class RetranDBExport
    {



        /// <summary>
        /// <description>
        ///  <para></para><b>This method, by making a database connection, writes the data in your table to your <u>"JSON"</u> file, according to the table name you specified.</b>
        /// </description>
        /// <list type="bullet|number|table">
        /// <listheader>
        ///   <term><paramref name="_dbServerName"/> : </term>
        ///  <description>Url is the main part of your address.</description>
        ///</listheader>
        ///<item>
        ///     <term><paramref name="_dbUserId"/> : </term>
        ///    <description>Represents the parameter part of the url address. Also known as prefix.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_dbPassword"/> : </term>
        ///    <description>represents the file location to which you will transfer the information.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_dbName"/> : </term>
        ///    <description>Represents the parameters that you will send to the URL address you will request.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_dbTableName"/> : </term>
        ///    <description>It represents the headers you will add to the URL address you will request.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_targetLocalJsonFilePath"/> : </term>
        ///    <description>It represents the headers you will add to the URL address you will request.</description>
        /// </item>
        ///</list>
        /// <description>
        /// <u><b>Example method usage is as follows.</b></u>
        /// </description>
        ///<code>
        /// RetranDBExport.MssqlDbToLocalJsonFile("127.0.0.1","sa","alierguc1", "RetranDB", "tb_retran_subscribe", @"C:\Users\alierguc\Retran\json_output\output_json_file\output_20221011174318.json");
        ///</code>
        /// </summary>
        /// <param name="_dbServerName"></param>
        /// <param name="_dbUserId"></param>
        /// <param name="_dbPassword"></param>
        /// <param name="_dbName"></param>
        /// <param name="_dbTableName"></param>
        /// <param name="_targetLocalJsonFilePath"></param>
        /// <returns>bool</returns>
        public static bool MssqlDbToLocalJsonFile(
            string _dbServerName,
            string _dbUserId,
            string _dbPassword,
            string _dbName,
            string _dbTableName,
            string _targetLocalJsonFilePath)
        {

            StringBuilder _dbConnectionString = new StringBuilder();
            StringBuilder _sqlQuery = new StringBuilder();


            _dbConnectionString.Append($"Server={_dbServerName};Database={_dbName};User Id={_dbUserId}; Password={_dbPassword}");
            _sqlQuery.Append($"SELECT * FROM {_dbTableName}");

            using var connection = new SqlConnection(_dbConnectionString.ToString());
            var returnDBResult = connection.Query<object>(_sqlQuery.ToString());
            var convertSerializeJsonObject = JsonConvert.SerializeObject(returnDBResult);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_targetLocalJsonFilePath), true))
            {
                outputFile.WriteLine(convertSerializeJsonObject);
            }

            return true;
        }


        /// <summary>
        /// <description>
        ///  <para></para><b>This method, by making a database connection, writes the data in your table to your <u>"CSV"</u> file, according to the table name you specified.</b>
        /// </description>
        /// <list type="bullet|number|table">
        /// <listheader>
        ///   <term><paramref name="_dbServerName"/> : </term>
        ///  <description>Represent is the server address of your database..</description>
        ///</listheader>
        ///<item>
        ///     <term><paramref name="_dbUserId"/> : </term>
        ///    <description>Represents your database user id..</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_dbPassword"/> : </term>
        ///    <description>Represents your database password.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_dbName"/> : </term>
        ///    <description>Represents the database name.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_dbTableName"/> : </term>
        ///    <description>Represents the Database table name.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_targetLocalCsvFilePath"/> : </term>
        ///    <description>Represents the location of your local <b><u>"CSV"</u></b> file.</description>
        /// </item>
        ///</list>
        /// <description>
        /// <u><b>Example method usage is as follows.</b></u>
        /// </description>
        ///<code>
        /// RetranDBExport.MssqlDbToLocalCsvFile("127.0.0.1","sa","alierguc1", "RetranDB", "tb_retran_subscribe", @"C:\Users\alier\Desktop\Retran\Retran\csv_output\output_csv_file\output_20221011174754.csv");
        ///</code>
        /// </summary>
        /// <param name="_dbServerName"></param>
        /// <param name="_dbUserId"></param>
        /// <param name="_dbPassword"></param>
        /// <param name="_dbName"></param>
        /// <param name="_dbTableName"></param>
        /// <param name="_targetLocalCsvFilePath"></param>
        /// <returns>bool</returns>
        public static bool MssqlDbToLocalCsvFile(
            string _dbServerName,
            string _dbUserId,
            string _dbPassword,
            string _dbName,
            string _dbTableName,
            string _targetLocalCsvFilePath)
        {

            StringBuilder _dbConnectionString = new StringBuilder();
            StringBuilder _sqlQuery = new StringBuilder();


            _dbConnectionString.Append($"Server={_dbServerName};Database={_dbName};User Id={_dbUserId}; Password={_dbPassword}");
            _sqlQuery.Append($"SELECT * FROM {_dbTableName}");

            using var connection = new SqlConnection(_dbConnectionString.ToString());
            var returnDBResult = connection.Query<object>(_sqlQuery.ToString());
            var convertSerializeJsonObject = JsonConvert.SerializeObject(returnDBResult);
            var expandos = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject[]>(convertSerializeJsonObject);

            using (TextWriter writer = new StreamWriter(_targetLocalCsvFilePath))
            {
                using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.WriteRecords((expandos as IEnumerable<dynamic>));
                }

                return true;
            }
        }

        /// <summary>
        /// <description>
        ///  <para></para><b>This method, by making a database connection, writes the data in your table to your <u>"EXCEL"</u> file, according to the table name you specified.</b>
        /// </description>
        /// <list type="bullet|number|table">
        /// <listheader>
        ///   <term><paramref name="_dbServerName"/> : </term>
        ///  <description>Represent is the server address of your database..</description>
        ///</listheader>
        ///<item>
        ///     <term><paramref name="_dbUserId"/> : </term>
        ///    <description>Represents your database user id..</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_dbPassword"/> : </term>
        ///    <description>Represents your database password.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_dbName"/> : </term>
        ///    <description>Represents the database name.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_dbTableName"/> : </term>
        ///    <description>Represents the Database table name.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_targetLocalExcelFilePath"/> : </term>
        ///    <description>Represents the location of your local <b><u>"EXCEL"</u></b> file.</description>
        /// </item>
        ///</list>
        /// <description>
        /// <u><b>Example method usage is as follows.</b></u>
        /// </description>
        ///<code>
        /// RetranDBExport.MssqlDbToLocalCsvFile("127.0.0.1","sa","alierguc1", "RetranDB", "tb_retran_subscribe", @"C:\Users\alier\Desktop\Retran\Retran\excel_output\output_excel_file\output_20221011174754.xlsx");
        ///</code>
        /// </summary>
        /// <param name="_dbServerName"></param>
        /// <param name="_dbUserId"></param>
        /// <param name="_dbPassword"></param>
        /// <param name="_dbName"></param>
        /// <param name="_dbTableName"></param>
        /// <param name="_targetLocalExcelFilePath"></param>
        /// <returns>bool</returns>
        public static bool MssqlDbToExcelFile(
            string _dbServerName,
            string _dbUserId,
            string _dbPassword,
            string _dbName,
            string _dbTableName,
            string _targetLocalExcelFilePath)
        {
            try {
                StringBuilder _dbConnectionString = new StringBuilder();
                StringBuilder _sqlQuery = new StringBuilder();


                _dbConnectionString.Append($"Server={_dbServerName};Database={_dbName};User Id={_dbUserId}; Password={_dbPassword}");
                _sqlQuery.Append($"SELECT * FROM {_dbTableName}");

                using var connection = new SqlConnection(_dbConnectionString.ToString());
                var returnDBResult = connection.Query<object>(_sqlQuery.ToString());
                var convertSerializeJsonObject = JsonConvert.SerializeObject(returnDBResult);
                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.Worksheets[0];
                JsonLayoutOptions options = new JsonLayoutOptions();
                options.ArrayAsTable = true;
                JsonUtility.ImportData(convertSerializeJsonObject, worksheet.Cells, 0, 0, options);
                workbook.Save(_targetLocalExcelFilePath);
                return true;
            }
            catch
            {
                return false;

            }
        }

    }
}
