using System;
using System.Collections.Generic;

namespace BoardGames.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}
