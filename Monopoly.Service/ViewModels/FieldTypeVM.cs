namespace Monopoly.Service.ViewModels
{
    public class FieldTypeVM
    {
        public long? Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }
        public FieldTypeVM() { }

        public FieldTypeVM(long? id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public FieldTypeVM(string name, string description)
            : this(null, name, description) { }
    }
}
