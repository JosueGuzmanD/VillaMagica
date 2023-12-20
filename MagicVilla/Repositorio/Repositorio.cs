using MagicVilla.Datos;
using MagicVilla.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla.Repositorio
{
    public class Repositorio<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext  _context;
        internal DbSet<T> DbSet;

        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
            this.DbSet = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
           await DbSet.AddAsync(entity);
            await SaveChanges();
                
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = DbSet;
            if (!tracked)
            {
                query= query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = DbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();


        }

        public async Task Remove(T entity)
        {

            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
        await _context.SaveChangesAsync();
        
        }
    }
}
