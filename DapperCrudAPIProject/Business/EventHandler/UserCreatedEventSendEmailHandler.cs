using DapperCrudAPIProject.Business.Events;
using MediatR;

namespace DapperCrudAPIProject.Business.EventHandler
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
            _logger.LogInformation($"Email Gönderildi : Ürün id={notification.UserId} Ürün ismi : {notification.UserEmail}");
            return Task.CompletedTask;
        }
    }
}
