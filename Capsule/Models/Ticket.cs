using System;

namespace Capsule.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public virtual TicketType Type { get; set; }
        public virtual Severity Severity { get; set; }
        public virtual TicketStatus Status { get; set; }
    }

    public class Severity
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
    }

    public class TicketType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TicketStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}