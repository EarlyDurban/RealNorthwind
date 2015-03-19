using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFServices.RealNorthwindService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        public Product GetProduct(int id) 
        {
            Product product = new Product();
            product.ProductId = id;
            product.ProductName = "fake product from service layer";
            product.UnitPrice = 10.0m;
            product.QuantityPerUnit = "fake QPU";

            return product;
        }

        public bool UpdateProduct(Product product, ref string messsage) 
        {
            bool result = true;

            //first check to see if  it is a valid price
            if (product.UnitPrice <= 0)
            {
                messsage = "Price cannot be <= 0";
                result = false;
            }
            // Product can't be empty
            else if (string.IsNullOrEmpty(product.ProductName))
            {
                messsage = "Preoduct name can't be empty";
                result = false;
            }
            // QuantityPerUnit cant't be empty
            else if (string.IsNullOrEmpty(product.QuantityPerUnit))
            {
                messsage = "QuantityPerUnit cant't be empty";
                result = false;
            }
            else
            {
                // TODO: call business logic layer to update product
                messsage = "Product update successfully";
                result = true;
            }

            return result;
        }
    }
}
