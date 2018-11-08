using ClassLibrary1ShoppingCart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1ShoppingCart.Core.Facade
{
    public interface IProductsRepository
    {
        // CRUd
        IEnumerable<Product> FindAll();
    }
}
