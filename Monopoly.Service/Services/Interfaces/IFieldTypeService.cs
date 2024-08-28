using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services.Interfaces;

public interface IFieldTypeService
{
    public FieldTypeVM Create(FieldTypeVM entity);

    public void Delete(int id);
    
    public FieldTypeVM Get(int id);

    public List<FieldTypeVM> GetAll(int? page, int? perPage);
    
    public FieldTypeVM Update(FieldTypeVM entity);

    public int TotalCount();
}