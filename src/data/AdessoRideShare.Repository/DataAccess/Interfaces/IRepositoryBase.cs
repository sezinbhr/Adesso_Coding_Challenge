using AdessoRideShare.Repository.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdessoRideShare.Repository.DataAccess.Interfaces
{
    public interface IRepositoryBase<T> where T : class, IBaseEntityModel, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression=null);

        Task<T> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);


    }
}
