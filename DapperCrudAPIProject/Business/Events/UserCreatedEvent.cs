using MediatR;

namespace DapperCrudAPIProject.Business.Events
{
    public class UserCreatedEvent : INotification
    {

        public int UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
