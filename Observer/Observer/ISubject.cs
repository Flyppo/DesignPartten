using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyOvserver();
    }
}
