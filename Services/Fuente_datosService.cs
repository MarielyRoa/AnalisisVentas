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
    public class Fuente_datosService
    {
        private readonly string _pathFile;

        public Fuente_datosService(string pathFile)
        {
            _pathFile = pathFile;
        }

        public void ReadFuente_Datos()
        {
            try
            {
                if (File.Exists(_pathFile))
                {

                    using (var reader = new StreamReader(_pathFile))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<fuente_datos>().ToList();

                        var query = from FuenteDatos in records
                                    select FuenteDatos;

                                foreach (var record in records){
                                    Console.WriteLine(
                                   $"ID: {record.IdFuente}, " +
                                   $"Tipo Fuente: {record.TipoFuente}, " +
                                   $"Fecha Carga: {record.FechaCarga}"
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
