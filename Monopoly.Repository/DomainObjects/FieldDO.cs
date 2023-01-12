namespace Monopoly.Repository.DomainObjects
{
    public class FieldDO
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public FieldTypeDO Type { get; set; }

        public GameDO Game { get; set; }
    }
}
