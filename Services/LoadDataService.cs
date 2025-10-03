
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using readcsv.Class;
using readcsv.Context;

namespace readcsv.Services
{
    public class LoadDataService
    {
        private readonly string _conexion;

        public LoadDataService(string conexion)
        {
            _conexion = conexion;
        }

        public void LoadProducts(List<products> productsList)
        {
            if (productsList is null) return;

            using var context = new VentasContext(_conexion);

            int insertados = 0;

            foreach (var product in productsList)
            {
                    context.Productos.Add(product);
                    insertados++;

                if (insertados % 1000 == 0)
                {
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                }
            }

            context.SaveChanges();
            Console.WriteLine($"Productos: {insertados} insertados de {productsList.Count} unicos");
        }

        public void LoadCustomers(List<customers> customersList)
        {
            if (customersList is null) return;

            using var context = new VentasContext(_conexion);

            int insertados = 0;

            foreach (var customer in customersList)
            {

                    context.Clientes.Add(customer);
                    insertados++;

                if (insertados % 1000 == 0)
                {
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                }
            }

            context.SaveChanges();
            Console.WriteLine($"Clientes: {insertados} insertados de {customersList.Count} únicos");
        }

        public void LoadOrders(List<orders> ordersList)
        {
            if (ordersList is null) return;

            using var context = new VentasContext(_conexion);

            int insertados = 0;

            foreach (var order in ordersList)
            {
                    context.Ordenes.Add(order);
                    insertados++;

                if (insertados % 1000 == 0)
                {
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                }
            }

            context.SaveChanges();
            Console.WriteLine($"Órdenes: {insertados} insertados de {ordersList.Count} únicos");
        }

        public void LoadOrderDetails(List<order_details> orderDetailsList)
        {
            if (orderDetailsList is null) return;

            using var context = new VentasContext(_conexion);
            int insertados = 0;

            foreach (var detail in orderDetailsList)
            {

                    context.DetalleOrdenes.Add(detail);
                    insertados++;

                if (insertados % 1000 == 0)
                {
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                }
            }

            context.SaveChanges();
            Console.WriteLine($"Detalles: {insertados} insertados de {orderDetailsList.Count} únicos");
        }
    }
    }
