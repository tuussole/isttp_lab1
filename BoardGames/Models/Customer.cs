﻿using System;
using System.Collections.Generic;

namespace BoardGames.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
