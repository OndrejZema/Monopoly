namespace Monopoly.Service.ViewModels
{
    public class CardVM
    {
        public long? Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public CardTypeVM Type { get; set; }

        public long GameId { get; set; }
    }
}
