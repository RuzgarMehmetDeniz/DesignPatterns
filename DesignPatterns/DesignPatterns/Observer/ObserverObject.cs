using DesignPatterns.Entites;
namespace DesignPatterns.DesignPatterns.Observer
{
    public class ObserverObject
    {
        private readonly List<IObserver> _observers = new();
        public void RegisterObserver(IObserver observer) => _observers.Add(observer);
        public void NotifyObservers(CustomerProcess process)
        {
            _observers.ForEach(x => x.CreateObserver(process));
        }
    }
}