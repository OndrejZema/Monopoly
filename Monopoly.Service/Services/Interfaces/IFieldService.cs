using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services.Interfaces;

public interface IFieldService : IService<FieldVM>
{
    public int TotalCount(int? gameId);
}