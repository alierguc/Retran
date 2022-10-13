using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retran.FileProcess
{
    public class RetranFile
    {
        /// <summary>
        /// <description>
        /// <b><i>It converts <u>"JSON"</u> content to <u>"CSV"</u> content. If there is no <u>"CSV"</u> file, it creates a new <u>"CSV"</u> file and writes the content to this file.</i></b>
        /// </description>
        /// <list type="bullet|number|table">
        ///<item>
        ///     <term>_createCSVFilePath : </term>
        ///    <description>Create a new <b><u>CSV</u></b> file ?</description>
        /// </item>
        ///</list>
        /// <description>
        /// Example method usage is as follows.
        /// </description>
        ///<code>
        /// var newCreatedJsonPath = RetranFile.RetranCreateJSONFile(@"C:\Users\alierguc\Desktop\Retran\Retran");
        ///</code>
        /// </summary>
        /// <param name="_createCSVFilePath"></param>
        /// <returns>bool</returns>
        public static string RetranCreateCSVFile(string _createCSVFilePath)
        {
            var dateNow = DateTime.Now;
            string fullCsvPath = @$"{_createCSVFilePath}\csv_output\output_csv_file";
            string fileName = $"output_{dateNow.ToString("yyyyMMddHHmmss")}.csv";


            bool FileExists = System.IO.Directory.Exists(@$"{fullCsvPath}");
            if (!FileExists)
                System.IO.Directory.CreateDirectory(@$"{fullCsvPath}");
            using (FileStream fs = new FileStream(Path.Combine(fullCsvPath, fileName), FileMode.Create))
            {
                byte[] content = new UTF8Encoding(true).GetBytes("");

                fs.Write(content, 0, content.Length);
            }

            return fullCsvPath + fileName;

        }

        public static string RetranCreateJSONFile(string _createJSONFilePath)
        {
            var dateNow = DateTime.Now;
            string fullJsonPath = @$"{_createJSONFilePath}\json_output\output_json_file";
            string fileName = $"output_{dateNow.ToString("yyyyMMddHHmmss")}.json"; 


            bool FileExists = System.IO.Directory.Exists(@$"{fullJsonPath}");
            if (!FileExists)
                System.IO.Directory.CreateDirectory(@$"{fullJsonPath}");
            using (FileStream fs = new FileStream(Path.Combine(fullJsonPath, fileName), FileMode.Create))
            {
                byte[] content = new UTF8Encoding(true).GetBytes("");

                fs.Write(content, 0, content.Length);
            }

            return fullJsonPath+ fileName;
        }
    }
}
