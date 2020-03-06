using System;
using System.Collections.Generic;

namespace Capsule.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }



        public virtual ICollection<Contact> Contacts { get; set; }
    }
}