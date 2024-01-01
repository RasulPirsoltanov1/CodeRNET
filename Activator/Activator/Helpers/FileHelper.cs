using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activator.Helpers
{
    public class FileHelper
    {
        public void FileReader()
        {
            using (var reader = new StreamReader("filePersons.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Person>();
                }
            }
         
        }
    }
}
