using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    class WeatherData : ISubject
    {
        private List<IObserver> observers;
        private  float temperature;
        private  float humidity;
        private  float pressure;

        public WeatherData()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if(observers.IndexOf(observer) >= 0)
                observers.Remove(observer);
        }

        public void NotifyOvserver()
        {
            for(int i = 0; i < observers.Count; i++)
            {
                observers[i].Update(temperature, humidity, pressure);
            }
        }

        public void MeasurementsChanged()
        {
            NotifyOvserver();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementsChanged();

            Console.ReadKey();
        }
    }
}
