using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using addressbook_web_tests;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;


namespace addressbook_web_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("OPOWKFNJANFD");
            int testDataCount = Convert.ToInt32(args[0]);
            // StreamWriter writer = new StreamWriter(args[1]);
            string fileName = args[1];

            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < testDataCount; i++)
            {

                groups.Add(new GroupData()
                {
                    Name = TestBase.GenerateRandomString(10),
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            if (format == "excel")
            {
                WriteGroupsToExcelFile(groups, fileName);
            }
            else
            {
                StreamWriter writer = new StreamWriter(fileName);
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                {
                    Console.Out.WriteLine("Неизвестный формат");
                }

                writer.Close();
            }
            static void WriteGroupsToExcelFile(List<GroupData> groups, string fileName)
            {
                Excel.Application app = new Excel.Application();
                
                app.Visible = true;
                Excel.Workbook workbook = app.Workbooks.Add();
                
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                int row = 1;
                foreach (var group in groups)
                {
                    worksheet.Cells[row, 1] = group.Name;
                    worksheet.Cells[row, 2] = group.Header;
                    worksheet.Cells[row, 3] = group.Footer;
                    row++;
                }

                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                File.Delete(fullPath);
                workbook.SaveAs(fullPath);

                workbook.Close();
                app.Quit();
            }
            static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
            }
            static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
            {
                foreach (var group in groups)
                {
                    writer.WriteLine(String.Format("${0},${1},${2}",
                        group.Name, group.Header, group.Footer));
                }
            }

            static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
            }
        }
    }
}
