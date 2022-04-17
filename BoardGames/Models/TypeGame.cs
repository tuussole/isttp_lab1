using System;
namespace BoardGames.Models
{
    public class TypeGame
    {
        public int Id { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
