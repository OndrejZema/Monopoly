using Monopoly.NewDAL.Entities;
using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories.Interfaces;

public interface ICardRepository : IRepository<CardDO>
{
    public List<CardDO> GetAll(int? gameId, int? page, int? perPage);
    public int TotalCount(long? gameId);
}