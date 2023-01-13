namespace Monopoly.Service.ViewModels
{
    public class CardVM
    {
        public long? Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public CardTypeVM Type { get; set; }

        public long GameId { get; set; }
        public CardVM() { } 

        public CardVM(long? id, string name, string description, CardTypeVM type, long gameId)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.GameId = gameId;
        }
        public CardVM(string name, string description, CardTypeVM type, long gameId) 
            : this(null, name, description, type, gameId) { }
    }
}
