namespace DapperCrudAPIProject.Business.ObserverDP.Notifications.NotificationHandlers;
public class UserCreatedSendSmsNotificationHandler:INotificationHandler
{
    public Task Handle()
    {
        Console.WriteLine("Uer created sms sent");
        return Task.CompletedTask;
    }
}