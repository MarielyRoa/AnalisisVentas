using readcsv.Class;
using readcsv.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace readcsv.Services
{
    //TRANSFORMACIÓN Y LIMPIEZA DE DATOS
    public class ProcesamientoService
    {

        private readonly string _conexion;

        public ProcesamientoService(string conexion)
        {
            _conexion = conexion;
        }

        public List<products> LimpiarProductos(List<products> productos)
        {
            var limpios = productos
                            .Where(p => p.ProductID > 0 && !string.IsNullOrEmpty(p.ProductName))
                            .GroupBy(p => p.ProductID)
                            .Select(g => g.First())
                            .ToList();

            Console.WriteLine($"Productos: {productos.Count} de {limpios.Count} limpios");

            return limpios;
        }

        public List<customers> LimpiarClientes(List<customers> clientes)
        {
            var limpios = clientes
                            .Where(c => c.CustomerID > 0)
                            .GroupBy(c => c.CustomerID)
                            .Select(g => g.First())
                            .ToList();

            Console.WriteLine($"Clientes: {clientes.Count} de {limpios.Count} limpios");

            return limpios;
        }

        public List<orders> LimpiarOrdenes(List<orders> ordenes)
        {
            var limpios = ordenes
                            .Where(o => o.OrderID > 0 && o.CustomerID > 0)
                            .GroupBy(o => o.OrderID)
                            .Select(g => g.First())
                            .ToList();

            Console.WriteLine($"Ordenes: {ordenes.Count} de {limpios.Count} limpios");

            return limpios;
        }

        public List<order_details> LimpiarDetalles(List<order_details> detalles)
        {
            var limpios = detalles
                            .Where(d => d.OrderID > 0
                                     && d.ProductID > 0
                                     && d.Quantity > 0
                                     && d.TotalPrice > 0)
                            .GroupBy(d => new { d.OrderID, d.ProductID })
                            .Select(g => g.First())
                            .ToList();

            Console.WriteLine($"Detalles: {detalles.Count} de {limpios.Count} limpios");

            return limpios;
        }
        public void CalcularTotales(List<orders>ordenes, List<order_details> detalles)
        {

            using var context = new VentasContext(_conexion);

            var ordenesDB = context.Ordenes.ToList();
            var detallesDB = context.DetalleOrdenes.ToList();

            int totalCalculado = 0;

            foreach (var orden in ordenes)
            {
                var subtotal = detalles
                    .Where(d => d.OrderID == orden.OrderID && d.Quantity > 0 && d.TotalPrice > 0)
                    .Sum(d => (d.Quantity * d.TotalPrice));

                orden.Total = subtotal;

                if(subtotal > 0)
                {
                    totalCalculado++;
                }
            }
            
           context.SaveChanges();
            Console.WriteLine($"Totales calculados: {totalCalculado}/{ordenes.Count} ordenes con total > 0");
        }
    }
}
   