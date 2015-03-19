using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealNorthwindClient.ProductServiceRef;
using MyWCFServices.RealNorthwindService;

namespace RealNorthwindClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServiceClient client = new ProductServiceClient();
            Product product = client.GetProduct(23);

            Console.WriteLine("product name is " + product.ProductName);
            Console.WriteLine("product price is " + product.UnitPrice.ToString());
            product.UnitPrice = 20.0m;
            string message = "";
            bool result = client.UpdateProduct(product, ref message);
            Console.WriteLine("Update result is " + result.ToString());
            Console.WriteLine("Update message is " + message);
            Console.ReadLine();
        }
    }
}
