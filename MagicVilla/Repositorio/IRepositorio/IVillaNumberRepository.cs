using MagicVilla.Models;

namespace MagicVilla.Repositorio.IRepositorio
{
    public interface IVillaNumberRepository: IRepository<VillaNumber>
    {
        Task<VillaNumber> Update(VillaNumber entity);


    }
}
