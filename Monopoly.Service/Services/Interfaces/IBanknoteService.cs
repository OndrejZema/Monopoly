using Monopoly.Service.ViewModels;
namespace Monopoly.Service.Services.Interfaces;

public interface IBanknoteService : IService<BanknoteVM>
{
    public int TotalCount(int? gameId);
}