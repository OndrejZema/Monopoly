namespace Monopoly.Service.ViewModels
{
    public class FieldVM
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public FieldTypeVM Type { get; set; }

        public GameVM Game{ get; set; }
    }
}
