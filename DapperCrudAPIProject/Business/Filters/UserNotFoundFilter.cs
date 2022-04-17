using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DapperCrudAPIProject.Business.Filters
{
    public class UserNotFoundFilter : ActionFilterAttribute
    {
        private readonly IUserRepository _userRepository;

        public UserNotFoundFilter(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            var idValue = context.HttpContext.Request.RouteValues["id"];
            int id = int.Parse(idValue.ToString());
            var user = await _userRepository.GetById(id);
            if (user!=null)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(ResponseDto<NoContent>.Fail($"Id({id})'ye sahip kullanıcı bulunamamıştır.", 404));
        }
    }
}
