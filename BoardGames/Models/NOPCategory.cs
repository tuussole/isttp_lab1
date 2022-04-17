using System;
using System.Collections.Generic;

namespace BoardGames.Models
{
    public class NOPCategory
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        public List<Game> Games { get; set; }
    }
}
