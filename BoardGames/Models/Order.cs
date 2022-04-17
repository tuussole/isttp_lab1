using System;
using System.Collections.Generic;

namespace BoardGames.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }

        public List<Item> Items { get; set; }
    }
}
