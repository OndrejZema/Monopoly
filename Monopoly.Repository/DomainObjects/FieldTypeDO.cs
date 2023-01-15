namespace Monopoly.Repository.DomainObjects
{
    public class FieldTypeDO : IIsValid
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public FieldTypeDO(long? id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public FieldTypeDO(string name, string description)
            : this(null, name, description) { }

        public bool IsValid()
        {
            return Name != "";
        }
    }
}
