using MagicVilla.Datos;
using MagicVilla.Models;
using MagicVilla.Repositorio.IRepositorio;

namespace MagicVilla.Repositorio
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public VillaRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Villa> Update(Villa entity)
        {

            entity.UpdateDate = DateTime.Now;
            _dbContext.Villas.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }
    }
}
