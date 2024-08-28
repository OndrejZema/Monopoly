namespace Monopoly.Service.ViewModels
{
    public class GameVM
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public GameVM() { }
        public GameVM(long? id, string name, string description, bool isCompleted)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IsCompleted = isCompleted;
        }
        public GameVM(string name, string description) 
            :this(null, name, description, false) { }
    }
}
