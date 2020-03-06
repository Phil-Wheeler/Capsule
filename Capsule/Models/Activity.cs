using System;
using System.Collections.Generic;

namespace Capsule.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public Guid Ticket { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }

    public class TicketHandler : IObservable<Ticket>
    {
        private List<IObserver<Ticket>> observers;
        private List<Ticket> tickets;


        public TicketHandler()
        {
            observers = new List<IObserver<Ticket>>();
            tickets = new List<Ticket>();
        }


        public IDisposable Subscribe(IObserver<Ticket> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                foreach(var item in tickets)
                {
                    observer.OnNext(item);
                }
            }
            return new Unsubscriber<Ticket>(observers, observer);
        }


        internal class Unsubscriber<Ticket> : IDisposable
        {
            private List<IObserver<Ticket>> _observers;
            private IObserver<Ticket> _observer;

            internal Unsubscriber(List<IObserver<Ticket>> observers, IObserver<Ticket> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose() 
            {
                if (_observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}