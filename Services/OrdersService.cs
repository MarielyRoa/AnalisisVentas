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
    public class OrdersService
    {
        private readonly string _pathFile;

        public OrdersService(string pathFile)
        {
            _pathFile = pathFile;
        }

        public void ReadOrders()
        {
            try
            {
                if (File.Exists(_pathFile))
                {

                    using (var reader = new StreamReader(_pathFile))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<orders>().ToList();

                        var query = from Ordenes in records
                                    select Ordenes;

                        foreach (var record in records) 
                        { 
                            Console.WriteLine(
                                $"OrderID: {record.OrderID}, " +
                                $"CustomerID: {record.CustomerID}, " +
                                $"OrderDate: {record.OrderDate}, " +
                                $"Status: {record.Status}"
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
