using Microsoft.Data.SqlClient;
using readcsv.Class;
using readcsv.Services;


string connStr = "ServeRr=DESKTOP-B3FNPSK\\SQLEXPRESS;Database=AnalisisVentasDB;Trusted_Connection=True;TrustServerCertificate=True;";
string pathFile = @"C:\Users\Mariely\Source\Repos\readcsv\Data Analisis de ventas";

ProcesamientoService procesamientoService = new ProcesamientoService(connStr);
var loadService = new LoadDataService(connStr);


// EXTRACCIÓN
var customerService = new CustomerService($"{pathFile}//customers.csv");
var productsService = new ProductsService($"{pathFile}//products.csv");
var ordersService = new OrdersService($"{pathFile}//orders.csv");
var orderDetailsService = new Order_DetailsService($"{pathFile}//order_details.csv");

var customers = customerService.ReadCustomers();
var products = productsService.ReadProducts();
var orders = ordersService.ReadOrders();
var order_details = orderDetailsService.ReadOrderDetails();

// TRANSFORMACIÓN
var ordersLimpias = procesamientoService.LimpiarOrdenes(orders);
var order_detailsLimpios = procesamientoService.LimpiarDetalles(order_details);
var customersLimpios = procesamientoService.LimpiarClientes(customers);
var productsLimpios = procesamientoService.LimpiarProductos(products);

//CALULO DE TOTALES
procesamientoService.CalcularTotales(ordersLimpias, order_detailsLimpios);

//CARGA
loadService.LoadCustomers(customersLimpios);
loadService.LoadProducts(productsLimpios);
loadService.LoadOrders(ordersLimpias);
loadService.LoadOrderDetails(order_detailsLimpios);
procesamientoService.CalcularTotales(orders, order_details);

Console.WriteLine("Proceso completado.");
