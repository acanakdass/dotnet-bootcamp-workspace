using DapperCrudAPIProject.Business.ObserverDP.Notifications.NotificationHandlers;

namespace DapperCrudAPIProject.Business.ObserverDP.Subjects;
public class NotificationSubject : INotificationSubject
{
    private readonly List<INotificationHandler> _observers = new ();


    public void Attach(INotificationHandler observer)
    {
        _observers.Add(observer);
    }

    public void Detach(INotificationHandler observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Handle();
        }
    }

    public void SendNotificationsToObservers()
    {
        Notify();
    }
}