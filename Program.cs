using readcsv.Services;


namespace readcsv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pathFile = @"C:\Users\Mariely\Source\Repos\readcsv\Data Analisis de ventas\customers.csv";
                CustomerService customerService = new CustomerService(pathFile);
                customerService.ReadCustomers();
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine($"Error: {fex.Message}");
            }
        }
    }
}