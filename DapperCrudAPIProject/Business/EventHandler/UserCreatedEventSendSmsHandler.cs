using DapperCrudAPIProject.Business.Events;
using MediatR;

namespace DapperCrudAPIProject.Business.EventHandler
{
    public class UserCreatedEventSendSmsHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<UserCreatedEventSendSmsHandler> _logger;

        public UserCreatedEventSendSmsHandler(ILogger<UserCreatedEventSendSmsHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sms Gönderildi : Ürün id={notification.UserId} Ürün ismi : {notification.UserEmail}");

            return Task.CompletedTask;
        }

    }
}
