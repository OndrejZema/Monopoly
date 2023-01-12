namespace Monopoly.Service.ViewModels
{
    public class GamePreviewVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int CardsCount { get; set; }
        public int FieldsCount { get; set; }
        public int BanknotesCount { get; set; }

    }
}
