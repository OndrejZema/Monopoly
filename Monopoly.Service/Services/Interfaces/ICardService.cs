using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services.Interfaces;

public interface ICardService : IService<CardVM>
{
    public int TotalCount(int? gameId);
}