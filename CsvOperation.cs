using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace FileIO_CSvAndJsonOperation
{
    public class CsvOperation
    {
        public static void CsvSerialize()
        {
            Console.WriteLine("WelCome to Address Book ");
            Person s = new Person();

            string csvFilePath = @"C:\Users\AZ\Desktop\myproject\FileIO-CSvAndJsonOperation\CSVData.csv";

            List<Person> Persons = new List<Person>()
            {
                new Person(){FirstName=" Subodh", LastName = "  Nagalwade ," ,Address=" Ujjwal nagar ," ,ZipCode=441804 , City= " Lakhni ,", State= " Maharashtra ,", Email= " subodh@gmail.com ,"  , PhoneNumber = 1234567890},
              
            };

            StreamWriter sw = new StreamWriter(csvFilePath);
            CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture);

            cw.WriteRecords<Person>(Persons);
            sw.Close();
            Console.WriteLine("Closed");
        }

        public static void CsvDeserialize()
        {
            string csvFilePath = @"C:\Users\AZ\Desktop\myproject\FileIO-CSvAndJsonOperation\CSVData.csv";

           // string CopyFilepath = @"C:\Users\AZ\Desktop\myproject\FileIO-CSvAndJsonOperation\CSVData.csv";

           
            StreamReader swReader = new StreamReader(csvFilePath);
            CsvReader csvReader = new CsvReader(swReader, CultureInfo.InvariantCulture);

            List<Person> Persons1 = csvReader.GetRecords<Person>().ToList();

            foreach (Person Person in Persons1)
            {
                Console.WriteLine(Person);
            }

            //csv to another csv

            //  using (var writer = new StreamWriter(CopyFilepath))
            // using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{
            //    csvExport.WriteRecords<Person>(Persons1);
            //}

           // for json operation UC-15
            string jsonFilePath = @"C:\Users\AZ\Desktop\myproject\FileIO-CSvAndJsonOperation\JsonData.";
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter stream = new StreamWriter(jsonFilePath))
            using (JsonWriter jsonWriter = new JsonTextWriter(stream))
            {
                serializer.Serialize(jsonWriter, Persons1);
            }

        }
    }


    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public double PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{FirstName}  {LastName}  {Address}  {City}  {State}  {ZipCode},  {Email}  {PhoneNumber} ";
        }
    }
}
