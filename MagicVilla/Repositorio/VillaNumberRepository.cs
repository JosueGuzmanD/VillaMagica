using MagicVilla.Datos;
using MagicVilla.Models;
using MagicVilla.Repositorio.IRepositorio;

namespace MagicVilla.Repositorio
{
    public class VillaNumberRepository: Repository<VillaNumber>,IVillaNumberRepository
    {
        private readonly ApplicationDbContext _context;
        public VillaNumberRepository(ApplicationDbContext context):base (context) 
        {
            _context= context;
        }

        public async Task<VillaNumber> Update(VillaNumber entity)
        {

            entity.UpdateDate = DateTime.Now;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
