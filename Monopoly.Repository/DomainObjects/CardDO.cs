namespace Monopoly.Repository.DomainObjects
{
    public class CardDO
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CardTypeDO Type { get; set; }
        
        public long GameId { get; set; }

        public CardDO(long? id, string name, string description, CardTypeDO type, long gameId) {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.GameId = gameId;
        }
        public CardDO(string name, string description, CardTypeDO type, long gameId)
            : this(null, name, description, type, gameId) { }
    }
}
