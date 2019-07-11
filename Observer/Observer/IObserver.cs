using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }
}
