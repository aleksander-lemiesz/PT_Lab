using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class Event
    {
        private String name { get; }
        private Invoice invoice { get; set; }
        
        public Event(String n)
        {
            name = n;
        }
    }
}
