using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Repositories.Abstraction
{
    public interface IAdressRepository : IRepository<Address>
    {
        Task<ICollection<Address>> GetAllAsync(Guid id);
    }
}