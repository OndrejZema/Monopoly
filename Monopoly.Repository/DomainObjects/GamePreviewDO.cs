namespace Monopoly.Repository.DomainObjects
{
    public class GamePreviewDO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CardsCount { get; set; }
        public int FieldsCount { get; set; }
        public int BanknotesCount { get; set; }
        public bool IsCompleted { get; set; }

        public GamePreviewDO(long id, string name, int cardsCount, int fieldsCount, int banknotesCount, bool isCompleted) {
            this.Id = id;
            this.Name = name;
            this.CardsCount = cardsCount;
            this.FieldsCount = fieldsCount;
            this.BanknotesCount = banknotesCount;
            this.IsCompleted = isCompleted;

        }
    }
}
