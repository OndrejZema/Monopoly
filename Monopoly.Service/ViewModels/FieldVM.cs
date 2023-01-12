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

    }
}
