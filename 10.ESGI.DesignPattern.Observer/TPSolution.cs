using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ESGI.DesignPattern.Observer
{
    public interface IObserver
    { 
        string State { get; }
        void Update(string state);
    }

    public class Student : IObserver
    {
        public string State { get; private set; }

        public Student()
        {
            State = "listen";
        }

        public void Update(string state)
        {
            State = state;
        }
    }

    public class Teacher : IObserver
    {
        public string State { get; private set; }

        public Teacher()
        {
            State = "speak";
        }

        public void Update(string state)
        {
            State = state;
        }
    }

    public class Break
    {
        private DateTime _breakTime;
        private List<IObserver> _observers;

        public Break(DateTime breakTime)
        {
            _breakTime = breakTime;
            _observers = new List<IObserver>();
        }

        public void Add(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify(DateTime now)
        {
            if (now == _breakTime)
                _observers.ForEach(o => o.Update("break"));
        }
    }
}
