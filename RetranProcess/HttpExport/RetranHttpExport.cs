using Aspose.Cells;
using Aspose.Cells.Utility;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Retran.HttpExport
{
    public class RetranHttpExport
    {


        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// <description>
        ///  <para></para><b>This method makes a get request with the api url and writes this information to the <u>"JSON"</u> file at the location you specified.</b>
        /// </description>
        /// <list type="bullet|number|table">
        /// <listheader>
        ///   <term><paramref name="_baseApiUrl"/> : </term>
        ///  <description>Url is the main part of your address.</description>
        ///</listheader>
        ///<item>
        ///     <term><paramref name="_urlPrefix"/> : </term>
        ///    <description>Represents the parameter part of the url address. Also known as prefix.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_exportJsonFilePath"/> : </term>
        ///    <description>represents the file location to which you will transfer the information.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_requestParams"/> : </term>
        ///    <description>Represents the parameters that you will send to the URL address you will request.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_requestHeaders"/> : </term>
        ///    <description>It represents the headers you will add to the URL address you will request.</description>
        /// </item>
        ///</list>
        /// <description>
        /// <u><b>Example method usage is as follows.</b></u>
        /// </description>
        ///<code>
        /// RetranHttpExport.GET_ExportApiToLocalJsonFile("https://alierguc.github.com","/repos",@"C:\Users\alierguc\Retran\json_output\output_json_file\output_20221011174754.json",httpParams,httpHeaders);
        ///</code>
        /// </summary>
        /// <param name="_baseApiUrl"></param>
        /// <param name="_urlPrefix"></param>
        /// <param name="_exportJsonFilePath"></param>
        /// <param name="_requestParams"></param>
        /// <param name="_requestHeaders"></param>
        /// <returns>bool</returns>


        public static bool GET_ExportApiToLocalJsonFile(
            string _baseApiUrl, 
            string _urlPrefix, 
            string _exportJsonFilePath, 
            Dictionary<string, object>? _requestParams,
            Dictionary<string, object>? _requestHeaders)
        {
            try
            {

            #region STRING BUILDER INITIALIZE ( _requestParams )
            StringBuilder initializePath = new StringBuilder(String.Empty);
            StringBuilder fullPath = new StringBuilder(String.Empty);
            StringBuilder paramKeys = new StringBuilder(String.Empty);
            StringBuilder paramValues = new StringBuilder(String.Empty);
            #endregion

            #region STRING BUILDER INITIALIZE ( _requestHeaders )
            StringBuilder headersValue = new StringBuilder(String.Empty);
            StringBuilder headersKey = new StringBuilder(String.Empty);
            #endregion

            if (_requestParams != null)
            {
                foreach (KeyValuePair<string, object> item in _requestParams)
                {

                    if (initializePath.Length == 0)
                    {
                        paramKeys.Append("?" + item.Key + "=");
                        paramValues.Append(item.Value);
                    }
                    else
                    {
                        paramKeys.Append("&" + item.Key + "=");
                        paramValues.Append(item.Value);
                    }
                    initializePath.Append(paramKeys.ToString() + paramValues.ToString());
                    paramKeys.Clear();
                    paramValues.Clear();
                }
            }
            fullPath.Append(_baseApiUrl + _urlPrefix + initializePath.ToString());
            var request = (HttpWebRequest)WebRequest.Create($"{fullPath}");
           
            if (_requestHeaders != null)
            {
                foreach (KeyValuePair<string, object> item in _requestHeaders)
                {
                    headersValue.Append(item.Value);
                    headersKey.Append(item.Key);
                    request.Headers.Add(item.Key.ToString(), item.Value.ToString());
                }
            }

            var response = (HttpWebResponse)request.GetResponse();
            string responseData = new StreamReader(response.GetResponseStream()).ReadToEnd();

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_exportJsonFilePath), true))
            {
                outputFile.WriteLine(responseData);
            }

            return true;

            }
            catch
            {
              return false;
            }
        }




        /// <summary>
        /// <description>
        ///  <para></para><b>This method makes a get request with the api url and writes this information to the <u>"CSV"</u> file at the location you specified.</b>
        /// </description>
        /// <list type="bullet|number|table">
        /// <listheader>
        ///   <term><paramref name="_baseApiUrl"/> : </term>
        ///  <description>Url is the main part of your address.</description>
        ///</listheader>
        ///<item>
        ///     <term><paramref name="_urlPrefix"/> : </term>
        ///    <description>Represents the parameter part of the url address. Also known as prefix.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_exportCsvFilePath"/> : </term>
        ///    <description>represents the file location to which you will transfer the information.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_requestParams"/> : </term>
        ///    <description>Represents the parameters that you will send to the URL address you will request.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_requestHeaders"/> : </term>
        ///    <description>It represents the headers you will add to the URL address you will request.</description>
        /// </item>
        ///</list>
        /// <description>
        /// <u><b>Example method usage is as follows.</b></u>
        /// </description>
        ///<code>
        /// RetranHttpExport.GET_ExportApiToLocalJsonFile("https://alierguc.github.com","/repos",@"C:\Users\alierguc\Retran\csv_output\output_csv_file\output_20221011174322.csv",httpParams,httpHeaders);
        ///</code>
        /// </summary>
        /// <param name="_baseApiUrl"></param>
        /// <param name="_urlPrefix"></param>
        /// <param name="_exportCsvFilePath"></param>
        /// <param name="_requestParams"></param>
        /// <param name="_requestHeaders"></param>
        /// <returns>bool</returns>
        public static bool GET_ExportApiToLocalCsvFile(
            string _baseApiUrl,
            string _urlPrefix,
            string _exportCsvFilePath,
            Dictionary<string, object>? _requestParams,
            Dictionary<string, object>? _requestHeaders)
        {
            try
            {

                #region STRING BUILDER INITIALIZE ( _requestParams )
                StringBuilder initializePath = new StringBuilder(String.Empty);
                StringBuilder fullPath = new StringBuilder(String.Empty);
                StringBuilder paramKeys = new StringBuilder(String.Empty);
                StringBuilder paramValues = new StringBuilder(String.Empty);
                #endregion

                #region STRING BUILDER INITIALIZE ( _requestHeaders )
                StringBuilder headersValue = new StringBuilder(String.Empty);
                StringBuilder headersKey = new StringBuilder(String.Empty);
                #endregion

                if (_requestParams != null)
                {
                    foreach (KeyValuePair<string, object> item in _requestParams)
                    {

                        if (initializePath.Length == 0)
                        {
                            paramKeys.Append("?" + item.Key + "=");
                            paramValues.Append(item.Value);
                        }
                        else
                        {
                            paramKeys.Append("&" + item.Key + "=");
                            paramValues.Append(item.Value);
                        }
                        initializePath.Append(paramKeys.ToString() + paramValues.ToString());
                        paramKeys.Clear();
                        paramValues.Clear();
                    }
                }
                fullPath.Append(_baseApiUrl + _urlPrefix + initializePath.ToString());
                var request = (HttpWebRequest)WebRequest.Create($"{fullPath}");

                if (_requestHeaders != null)
                {
                    foreach (KeyValuePair<string, object> item in _requestHeaders)
                    {
                        headersValue.Append(item.Value);
                        headersKey.Append(item.Key);
                        request.Headers.Add(item.Key.ToString(), item.Value.ToString());
                    }
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseData = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var expandos = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject[]>(responseData);

                using (TextWriter writer = new StreamWriter(_exportCsvFilePath))
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
        ///  <para></para><b>This method makes a get request with the api url and writes this information to the <u>"EXCEL"</u> file at the location you specified.</b>
        /// </description>
        /// <list type="bullet|number|table">
        /// <listheader>
        ///   <term><paramref name="_baseApiUrl"/> : </term>
        ///  <description>Url is the main part of your address.</description>
        ///</listheader>
        ///<item>
        ///     <term><paramref name="_urlPrefix"/> : </term>
        ///    <description>Represents the parameter part of the url address. Also known as prefix.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_targetExportExcelFilePath "/> : </term>
        ///    <description>represents the file location to which you will transfer the information.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_requestParams"/> : </term>
        ///    <description>Represents the parameters that you will send to the URL address you will request.</description>
        /// </item>
        ///<item>
        ///     <term><paramref name="_requestHeaders"/> : </term>
        ///    <description>It represents the headers you will add to the URL address you will request.</description>
        /// </item>
        ///</list>
        /// <description>
        /// <u><b>Example method usage is as follows.</b></u>
        /// </description>
        ///<code>
        /// RetranHttpExport.GET_ExportApiToLocalJsonFile("https://alierguc.github.com","/repos",@"C:\Users\alierguc\Retran\csv_output\output_excel_file\output_20221011174322.xlsx",httpParams,httpHeaders);
        ///</code>
        /// </summary>
        /// <param name="_baseApiUrl"></param>
        /// <param name="_urlPrefix"></param>
        /// <param name="_targetExportExcelFilePath"></param>
        /// <param name="_requestParams"></param>
        /// <param name="_requestHeaders"></param>
        /// <returns>bool</returns>
        public static bool GET_ExportApiToLocalExcelFile(
           string _baseApiUrl,
           string _urlPrefix,
           string _targetExportExcelFilePath,
           Dictionary<string, object>? _requestParams,
           Dictionary<string, object>? _requestHeaders)
        {
            try
            {

                #region STRING BUILDER INITIALIZE ( _requestParams )
                StringBuilder initializePath = new StringBuilder(String.Empty);
                StringBuilder fullPath = new StringBuilder(String.Empty);
                StringBuilder paramKeys = new StringBuilder(String.Empty);
                StringBuilder paramValues = new StringBuilder(String.Empty);
                #endregion

                #region STRING BUILDER INITIALIZE ( _requestHeaders )
                StringBuilder headersValue = new StringBuilder(String.Empty);
                StringBuilder headersKey = new StringBuilder(String.Empty);
                #endregion

                if (_requestParams != null)
                {
                    foreach (KeyValuePair<string, object> item in _requestParams)
                    {

                        if (initializePath.Length == 0)
                        {
                            paramKeys.Append("?" + item.Key + "=");
                            paramValues.Append(item.Value);
                        }
                        else
                        {
                            paramKeys.Append("&" + item.Key + "=");
                            paramValues.Append(item.Value);
                        }
                        initializePath.Append(paramKeys.ToString() + paramValues.ToString());
                        paramKeys.Clear();
                        paramValues.Clear();
                    }
                }
                fullPath.Append(_baseApiUrl + _urlPrefix + initializePath.ToString());
                var request = (HttpWebRequest)WebRequest.Create($"{fullPath}");

                if (_requestHeaders != null)
                {
                    foreach (KeyValuePair<string, object> item in _requestHeaders)
                    {
                        headersValue.Append(item.Value);
                        headersKey.Append(item.Key);
                        request.Headers.Add(item.Key.ToString(), item.Value.ToString());
                    }
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseData = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var expandos = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject[]>(responseData);

                var convertSerializeJsonObject = JsonConvert.SerializeObject(expandos);
                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.Worksheets[0];
                JsonLayoutOptions options = new JsonLayoutOptions();
                options.ArrayAsTable = true;
                JsonUtility.ImportData(convertSerializeJsonObject, worksheet.Cells, 0, 0, options);
                workbook.Save(_targetExportExcelFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
