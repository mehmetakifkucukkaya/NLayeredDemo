﻿using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Validation_Rules.FluentValidation
{
  public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün İsmi Boş Olamaz");
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);
            
        }
    }
}
