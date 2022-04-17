using System;
using System.Collections.Generic;

namespace BoardGames.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
