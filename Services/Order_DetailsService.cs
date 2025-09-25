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
    public class Order_DetailsService
    {
        private readonly string _pathFile;

        public Order_DetailsService(string pathFile)
        {
            _pathFile = pathFile;
        }

        public void ReadOrderDetails()
        {
            try
            {
                if (File.Exists(_pathFile))
                {

                    using (var reader = new StreamReader(_pathFile))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<order_details>().ToList();

                        var query = from DetalleOrdenes in records
                                    select DetalleOrdenes;

                        foreach (var record in records) 
                        { 
                            Console.WriteLine(
                               $"OrderID: {record.OrderID}, " +
                               $"ProductID: {record.ProductID}, " +
                               $"Quantity: {record.Quantity}, " +
                               $"TotalPrice: {record.TotalPrice}"
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
