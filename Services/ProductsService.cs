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
    public class ProductsService
    {
        private readonly string _pathFile;

        public ProductsService(string pathFile)
        {
            _pathFile = pathFile;
        }

        public List<products> ReadProducts()
        {
            try
            {
                if (File.Exists(_pathFile))
                {

                    using (var reader = new StreamReader(_pathFile))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<products>().ToList();

                        var query = from Productos in records
                                    select Productos;

                        foreach (var record in records) 
                        { 
                            Console.WriteLine(
                               $"ID: {record.ProductID}, " +
                               $"Name: {record.ProductName}, " +
                               $"Category: {record.Category}, " +
                               $"Price: {record.Price}, " +
                               $"Stock: {record.Stock}"
                           );
                        }

                        return records;
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


