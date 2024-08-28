using Monopoly.NewDAL.Entities;
using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories.Interfaces;

public interface ICardTypeRepository : IRepository<CardTypeDO>
{
    public List<CardTypeDO> GetAll(int? page, int? perPage);
    public int TotalCount();
}