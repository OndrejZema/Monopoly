using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories.Interfaces;

public interface IBanknoteRepository : IRepository<BanknoteDO>
{
    public List<BanknoteDO> GetAll(int? gameId, int? page, int? perPage);
    public int TotalCount(long? gameId);
}