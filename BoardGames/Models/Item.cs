using System;
namespace BoardGames.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
