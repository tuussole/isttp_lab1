using System;
using System.Collections.Generic;

namespace BoardGames.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public List<TypeGame> TypeGames { get; set; }
    }

}


//public int Id { get; set; } = 10;
//public string Description { get; set; } = null;
//public string Name { get; set; } = null;
//public void t()
//{
//    var t = new Type();
//    t.Id = 10;
//    t.Name = "name";

//    var t2 = new Type
//    {
//        Id = 10,
//        Name = "name"
//    };

//}