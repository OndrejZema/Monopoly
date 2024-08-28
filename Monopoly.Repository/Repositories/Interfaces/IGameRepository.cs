using Monopoly.NewDAL.Entities;
using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories.Interfaces;

public interface IGameRepository : IRepository<GameDO>
{
    public List<GameDO> GetAll(int? page, int? perPage);
    public int TotalCount();
}