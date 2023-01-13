namespace Monopoly.Repository.DomainObjects
{
    public class FieldDO
    {
        public long? Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public FieldTypeDO Type { get; set; }

        public long GameId { get; set; }

        public FieldDO(long? id, string name, string description, FieldTypeDO type, long gameId)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.GameId = gameId;
        }
        public FieldDO(string name, string description, FieldTypeDO type, long gameId)
            : this(null, name, description, type, gameId) { }
    }
}
