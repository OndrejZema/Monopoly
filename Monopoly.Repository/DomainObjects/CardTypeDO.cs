namespace Monopoly.Repository.DomainObjects
{
    public class CardTypeDO : IIsValid
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public int UserId { get; set; }
        public CardTypeDO(long? id, string name, string description) { 
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public CardTypeDO(string name, string description)
        :this(null, name, description)
        {

        }

        public bool IsValid()
        {
            return Name != "";
        }
    }
}
