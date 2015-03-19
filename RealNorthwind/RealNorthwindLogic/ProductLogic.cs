using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWCFServices.RealNorthwindBDO;

namespace MyWCFServices.RealNorthwindLogic
{
    public class ProductLogic
    {
        public ProductBDO GetProduct(int id) 
        {
            ProductBDO p = new ProductBDO();
            p.ProductID = id;
            p.ProductName = "fake product name from business logic layer";
            p.UnitPrice = 20.00m;
            p.QuantityPerUnit = "fake QPU";

            if (id > 50)
            {
                p.UnitsOnOrder = 30;
            }
            return p;
        }

        public bool UpdateProduct(ProductBDO product, ref string message) 
        {
            ProductBDO productInDB = GetProduct(product.ProductID);
            // invalid product to update
            if (productInDB == null)
            {
                message = "cannot get product for this ID";
                return false;
            }
            // a product can't be discontinued
            if (product.Discontinued == true && productInDB.UnitsOnOrder > 0)
            {
                message = "cannot dicountinue this product";
                return false;
            }
            else
            {
                //TODO: call data access layer to update product
                message = "Product update successfully";
                return true;
            }
        }
    }
}
