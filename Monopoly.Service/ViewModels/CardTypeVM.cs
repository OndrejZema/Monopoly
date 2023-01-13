namespace Monopoly.Service.ViewModels
{
    public class CardTypeVM
    {
        public long? Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public CardTypeVM() { }
        public CardTypeVM(long? id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public CardTypeVM(string name, string description) 
            : this(null, name, description) { }
    }
}
