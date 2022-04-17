

using DapperCrudAPIProject.Business.ObserverDP.Notifications.NotificationHandlers;

namespace DapperCrudAPIProject.Business.ObserverDP.Subjects;

public interface INotificationSubject
{
    void Attach(INotificationHandler observer);

    void Detach(INotificationHandler observer);

    void Notify();
}