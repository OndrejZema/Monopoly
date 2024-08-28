using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services.Interfaces;

public interface ICardTypeService
{
    public CardTypeVM Create(CardTypeVM entity);

    public void Delete(int id);
    
    public CardTypeVM Get(int id);

    public List<CardTypeVM> GetAll(int? page, int? perPage);
    
    public CardTypeVM Update(CardTypeVM entity);

    public int TotalCount();
}