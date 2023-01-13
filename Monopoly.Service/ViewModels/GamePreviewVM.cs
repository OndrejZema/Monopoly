namespace Monopoly.Service.ViewModels
{
    public class GamePreviewVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int CardsCount { get; set; }
        public int FieldsCount { get; set; }
        public int BanknotesCount { get; set; }

        public GamePreviewVM() { }  
        public GamePreviewVM(long id, string name, string description, bool isCompleted, int cardsCount, int fieldsCount, int banknotesCount)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IsCompleted = isCompleted;
            this.CardsCount = cardsCount;
            this.FieldsCount = fieldsCount;
            this.BanknotesCount = banknotesCount;
        }
    }
}
