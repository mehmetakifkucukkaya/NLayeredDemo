using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities.Concrete;
using System.Linq.Expressions;
using Northwind.DataAcces.Abstract;

namespace Northwind.DataAccess.Concrete.NHibernate
{
    //* Farklı bir veritabanımızın var olsaydı bu şekilde ayrı bir dosyada işlemleri yapmamız gerekirdi.
    public class NhProductDal : IProductDal
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                new Product{
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "Laptop",
                    QuantityPerUnit = "1 in a box",
                    UnitPrice = 3000,
                    UnitsInStock = 11}
            };
            return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
