using Microsoft.VisualBasic.FileIO;
using Monopoly.NewDAL.Entities;
using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories.Interfaces;

public interface IFieldRepository : IRepository<FieldDO>
{
    public List<FieldDO> GetAll(int? gameId, int? page, int? perPage);
    public int TotalCount(long? gameId);
}