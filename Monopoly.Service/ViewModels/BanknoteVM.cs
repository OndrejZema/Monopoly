namespace Monopoly.Service.ViewModels
{
    public class BanknoteVM
    {
        public long Value { get; set; }

        public long Count { get; set; }

        public string Unit { get; set; }

        public GameVM Game { get; set; }
    }
}
