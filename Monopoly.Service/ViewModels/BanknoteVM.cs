namespace Monopoly.Service.ViewModels
{
    public class BanknoteVM
    {
        public long? Id { get; set; }
        public long Value { get; set; }

        public long Count { get; set; }

        public string Unit { get; set; }

        public long GameId { get; set; }
    }
}
