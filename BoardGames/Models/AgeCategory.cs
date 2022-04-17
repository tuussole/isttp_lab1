using System;
using System.Collections.Generic;

namespace BoardGames.Models
{
    public class AgeCategory
    {
        public int Id { get; set; }
        public int From { get; set; }

        public List<Game> Games { get; set; }
    }
}
