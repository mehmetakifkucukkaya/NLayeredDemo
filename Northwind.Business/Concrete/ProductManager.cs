using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.Validation_Rules.FluentValidation;
using Northwind.DataAcces.Abstract;
using Northwind.DataAcces.Concrete;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager: IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ProductValidator productValidator = new ProductValidator();
           var result = productValidator.Validate(product);
            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);
            }
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch
            {
                throw new Exception("Silme işlemi gerçekleştirilemedi");
            }
        }
        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();

        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        
    }
}
