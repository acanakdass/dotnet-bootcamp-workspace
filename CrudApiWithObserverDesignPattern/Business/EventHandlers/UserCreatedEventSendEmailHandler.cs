using DapperCrudAPIProject.Business.Events;
using MediatR;

namespace DapperCrudAPIProject.Business.EventHandlers
{
    public class UserCreatedEventSendEmailHandler : INotificationHandler<UserCreatedEvent>
    {

        private readonly ILogger<UserCreatedEventSendEmailHandler> _logger;

        public UserCreatedEventSendEmailHandler(ILogger<UserCreatedEventSendEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Email Gönderildi : Kullanıcı Id={notification.UserId} Email : {notification.UserEmail}");
            return Task.CompletedTask;
        }
    }
}
