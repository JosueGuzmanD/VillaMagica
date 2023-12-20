using MagicVilla.Models;

namespace MagicVilla.Repositorio.IRepositorio
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> Update(Villa entity);

    }
}
