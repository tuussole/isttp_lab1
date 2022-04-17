using System;
using System.Collections.Generic;

namespace BoardGames.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int LeftQuantity { get; set; }

        public int NOPId { get; set; }
        public NOPCategory NOPCategory { get; set; }
        public int AgeId { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public List<TypeGame> TypeGames { get; set; }
        public List<Item> Items { get; set; }
    }
}
