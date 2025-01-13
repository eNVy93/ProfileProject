using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    public static class CSVParserService
    {
        public static List<T> ParseCsvToList<T>(MemoryStream memoryStream)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            config.MissingFieldFound = null;

            try
            {
                using var reader = new StreamReader(memoryStream);
                using var csv = new CsvReader(reader, config);

                return csv.GetRecords<T>().ToList();

            } catch
            {
                // TODO logging of exception
                return null;
            }
        }
    }
}
