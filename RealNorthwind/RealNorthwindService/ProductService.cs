using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyWCFServices.RealNorthwindBDO;
using MyWCFServices.RealNorthwindLogic;

namespace MyWCFServices.RealNorthwindService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        ProductLogic productLogic = new ProductLogic();
        public Product GetProduct(int id) 
        {
            ProductBDO productBDO = productLogic.GetProduct(id);
            Product product = new Product();
            TranslateProductBDOTToProductDTO(productBDO, product);
            return product;
        }

        public bool UpdateProduct(Product product, ref string message) 
        {
            bool result = true;

            //first check to see if  it is a valid price
            if (product.UnitPrice <= 0)
            {
                message = "Price cannot be <= 0";
                result = false;
            }
            // Product can't be empty
            else if (string.IsNullOrEmpty(product.ProductName))
            {
                message = "Preoduct name can't be empty";
                result = false;
            }
            // QuantityPerUnit cant't be empty
            else if (string.IsNullOrEmpty(product.QuantityPerUnit))
            {
                message = "QuantityPerUnit cant't be empty";
                result = false;
            }
            else
            {
                ProductBDO productBDO = new ProductBDO();
                TranslateProductDTOToProductBDO(product, productBDO);
                return productLogic.UpdateProduct(productBDO, ref message);
            }

            return result;
        }

        private void TranslateProductBDOTToProductDTO(ProductBDO productBDO, Product product) 
        {
            product.ProductId = productBDO.ProductID;
            product.ProductName = productBDO.ProductName;
            product.QuantityPerUnit = productBDO.QuantityPerUnit;
            product.UnitPrice = productBDO.UnitPrice;
            product.Discontinued = productBDO.Discontinued;
        }

        private void TranslateProductDTOToProductBDO(Product product, ProductBDO productBDO)
        {
            productBDO.ProductID = product.ProductId;
            productBDO.ProductName = product.ProductName;
            productBDO.QuantityPerUnit = product.QuantityPerUnit;
            productBDO.UnitPrice = product.UnitPrice;
            productBDO.Discontinued = product.Discontinued;
        }
    }
}
