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
    }
}
