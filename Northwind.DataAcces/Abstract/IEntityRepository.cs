using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcces.Abstract
{
    //* Generic kullanıyoruz
    public interface IEntityRepository <T> where T :class, IEntity, new() //* Generic Kısıt getirdik
    {
        List<T> GetAll(Expression <Func<T,bool>> filter=null); //* Linq kullanarak filtreleme yapılacak
        //* filter=null yaparsak  filtre vermeyebiliriz.
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T entitiy);
        void Add(T entitiy);
        void Update(T entitiy);
    }
}
