using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer
{
    public class Library : AbstLibrary
    {
        public override void addEvent(string s)
        {
            AbstEvent anEvent = new Event(s);
            anEvent.GetInvoice = new Invoice();
            this.Events.Add(anEvent);
        }
    }

}
