using Monopoly.Repository.DomainObjects;
using Monopoly.NewDAL.Entities;

namespace Monopoly.Repository.Utils
{
    public static class Converter
    {
        public static Banknote BanknoteDOToBanknote(BanknoteDO entity)
        {
            Banknote banknote = new Banknote();
            banknote.Id= entity.Id;
            banknote.Unit = entity.Unit;
            banknote.Value = entity.Value;
            banknote.Count = entity.Count;
            banknote.GameId = entity.GameId;
            return banknote;
        }
        public static Card CardDOToCard(CardDO entity)
        {
            Card card = new Card();
            card.Id = entity.Id;
            card.Name = entity.Name;
            card.Description = entity.Description;
            card.CardTypeId = (long)entity.Type.Id;
            card.GameId = entity.GameId;
            return card;
        }
        public static CardType CardTypeDOToCardType(CardTypeDO entity) {

            CardType cardType = new CardType();
            cardType.Id = entity.Id;
            cardType.Name = entity.Name;
            cardType.Description = entity.Description;
            return cardType;
        }
        public static Field FieldDOToField(FieldDO entity)
        {
            Field field = new Field();
            field.Id = entity.Id;
            field.Name = entity.Name;
            field.Description = entity.Description;
            field.FieldTypeId = (long)entity.Type.Id;
            field.GameId = entity.GameId;
            return field;
        }
        public static FieldType FieldTypeDOToFieldType(FieldTypeDO entity)
        {
            FieldType fieldType = new FieldType();
            fieldType.Id = entity.Id;   
            fieldType.Name = entity.Name;
            fieldType.Description = entity.Description;
            return fieldType;
        }
        public static Game GameDOToGame(GameDO entity)
        {
            Game game = new Game();
            game.Id = entity.Id;
            game.Name = entity.Name;
            game.Description = entity.Description;
            game.IsCompleted = entity.IsCompleted?1:0;
            return game;
        }
    }
}
