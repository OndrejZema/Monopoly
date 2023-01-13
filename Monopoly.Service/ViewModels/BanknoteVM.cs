namespace Monopoly.Service.ViewModels
{
    public class BanknoteVM
    {
        public long? Id { get; set; }
        public long Value { get; set; }

        public long Count { get; set; }

        public string Unit { get; set; }

        public long GameId { get; set; }
        public BanknoteVM() { } 

        public BanknoteVM(long? id, long value, long count, string unit, long gameId)
        {
            this.Id = id;
            this.Value = value;
            this.Count = count;
            this.Unit = unit;
            this.GameId = gameId;
        }
        public BanknoteVM(long value, long count, string unit, long gameId)
            : this(null, value, count, unit, gameId) { }
    }
}
