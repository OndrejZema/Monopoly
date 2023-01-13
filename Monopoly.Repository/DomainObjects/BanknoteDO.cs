namespace Monopoly.Repository.DomainObjects
{
    public class BanknoteDO
    {
        public long? Id { get; set; }

        public long Value { get; set; }

        public long Count { get; set; }

        public string Unit { get; set; }

        public long GameId{ get; set; }

        public BanknoteDO(long? id, long value, long count, string unit, long gameId)
        {
            this.Id = id;
            this.Value = value;
            this.Count = count;
            this.Unit = unit;
            this.GameId = gameId;
        }
        public BanknoteDO(long value, long count, string unit, long gameId) 
            :this(null, value, count, unit, gameId) { }

    }
}
