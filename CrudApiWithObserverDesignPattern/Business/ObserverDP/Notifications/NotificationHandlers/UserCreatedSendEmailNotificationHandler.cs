namespace DapperCrudAPIProject.Business.ObserverDP.Notifications.NotificationHandlers;
public class UserCreatedSendEmailNotificationHandler:INotificationHandler
{
    public Task Handle()
    {
        Console.WriteLine("USer created email sent");
        return Task.CompletedTask;
    }
}