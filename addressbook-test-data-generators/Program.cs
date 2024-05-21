using webAddressbookTests;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
//using System.Text.RegularExpressions;

namespace addressbook_test_data_generators
{
    class Program
    {
        //генератор
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            string fullPath = Path.GetFullPath(args[2]);
            string format = args[3];
            Console.WriteLine(fullPath);
           
            if (dataType == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "excel")
                {
                    writeGroupsToXlsFile(groups, fullPath);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(fullPath);
                    if (format == "csv")
                    {
                        writeGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        Console.Out.Write(" Неизвестный формат " + format + ". Доступные форматы данных: csv, xml, json");
                    }
                    writer.Close();
                }
            }
            else if (dataType == "contact")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(15), TestBase.GenerateRandomString(10))
                    {
                        Address = TestBase.GenerateRandomString(10),
                        Middlename = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(17),
                        Email2 = TestBase.GenerateRandomString(17),
                        Email3 = TestBase.GenerateRandomString(17),
                        UrlHomepage = TestBase.GenerateRandomString(20)
                    });
                }

                StreamWriter writer = new StreamWriter(fullPath);
                if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    Console.Out.Write(" Неизвестный формат " + format + ". Доступные форматы данных: xml и json");
                }
                writer.Close();
            }
            else
            {
                Console.Out.Write(" Неизвестный тип данных " + dataType + ". Доступные типы данных: contact и group");
            }
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Header
                    ));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeGroupsToXlsFile(List<GroupData> groups, string fileName)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;
            sheet.Cells[1, 1] = "test";
        }

        //для контактов
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
