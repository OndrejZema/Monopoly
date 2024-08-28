using Microsoft.VisualBasic.FileIO;
using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories.Interfaces;

public interface IFieldTypeRepository : IRepository<FieldTypeDO>
{
    public List<FieldTypeDO> GetAll(int? page, int? perPage);
    public int TotalCount();
}