using System.Security.Policy;

namespace Monopoly.Service.ViewModels
{
    public class FieldVM
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public FieldTypeVM Type { get; set; }

        public long GameId { get; set; }

        public FieldVM() { }
        public FieldVM(long? id, string name, string description, FieldTypeVM type, long gameId)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.GameId = gameId;
        }
        public FieldVM(string name, string description, FieldTypeVM type, long gameId)
            : this(null, name, description, type, gameId) { }
    }
}
