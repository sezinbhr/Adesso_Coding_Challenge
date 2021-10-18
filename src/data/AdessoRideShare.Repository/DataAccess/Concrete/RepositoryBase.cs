
using AdessoRideShare.Repository.Context.Concrete;
using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.Repository.EntityModel.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdessoRideShare.Repository.DataAccess.Concrete
{
    public class RepositoryBase<TT> : IRepositoryBase<TT> where TT : class, IBaseEntityModel, new()
    {
        private readonly RideShareDbContext _context;
        public RepositoryBase(RideShareDbContext context)
        {
            _context = context;
        }
        public async Task<TT> AddAsync(TT entity)
        {
            await _context.Set<TT>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TT entity)
        {
            _context.Set<TT>().Remove(entity);
            return await _context.SaveChangesAsync()>0;
        }

        public  Task<TT> GetAsync(Expression<Func<TT, bool>> expression)=> _context.Set<TT>().FirstOrDefaultAsync(expression);

        public Task<List<TT>> GetListAsync(Expression<Func<TT, bool>> expression = null)
        {
            return expression != null ? _context.Set<TT>().Where(expression).ToListAsync() : _context.Set<TT>().ToListAsync();
        }

        public async Task<TT> UpdateAsync(TT entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
