namespace Monopoly.Repository.DomainObjects
{
    public class BanknoteDO
    {
        public long Id { get; set; }

        public long Value { get; set; }

        public long Count { get; set; }

        public string Unit { get; set; }

        public GameDO Game{ get; set; }
    }
}
