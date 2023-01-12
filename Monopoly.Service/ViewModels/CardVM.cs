﻿namespace Monopoly.Service.ViewModels
{
    public class CardVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CardTypeVM Type { get; set; }

        public GameVM Game { get; set; }
    }
}