using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services.Interfaces;

public interface IGamePreviewService
{
    public List<GamePreviewVM> GetAll(int page, int perPage);
}