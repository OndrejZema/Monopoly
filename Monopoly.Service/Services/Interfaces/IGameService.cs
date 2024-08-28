using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services.Interfaces;

public interface IGameService
{
    public GameVM Create(GameVM entity);

    public void Delete(int id);

    public GameVM Get(int id);

    public List<GameVM> GetAll(int page, int perPage);

    public GameVM Update(GameVM entity);

    public int TotalCount();
}