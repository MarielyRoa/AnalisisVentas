using CsvHelper;
using readcsv.Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readcsv.Services
{
    public class CustomerService
    {
        private readonly string _pathFile;

        public CustomerService(string pathFile)
        {

            _pathFile = pathFile;
        }

        public void ReadCustomers()
        {
            try
            {
                if (File.Exists(_pathFile))
                {

                    using (var reader = new StreamReader(_pathFile))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<customers>().ToList();

                        var query = from Clientes in records
                                    select Clientes;

                        foreach (var record in records)
                        {
                            Console.WriteLine(
                               $"ID: {record.CustomerID}, " +
                               $"Name: {record.FirstName} {record.LastName}, " +
                               $"Email: {record.Email}, " +
                               $"Phone: {record.Phone}, " +
                               $"City: {record.City}, " +
                               $"Country: {record.Country}"
                           );
                        }
                    }

                }
                else
                {
                    throw new FileNotFoundException("El archivo no existe.", _pathFile);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
