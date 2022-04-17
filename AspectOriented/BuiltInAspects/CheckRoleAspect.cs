using AspectOriented.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspectOriented.Filters;

public class CheckRoleAspect : ActionFilterAttribute
{
    private string[] _roles;

    public CheckRoleAspect(string roles)
    {
        _roles = roles.Split(',');
    }

    

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //İstek header'ından JWT token geldiğini düşünelim
        var token = context.HttpContext.Request.Headers["Bearer"].ToString();
        //token'ı çözümleyip role stringlerini aldığımı düşünelim
        var rolesFromToken = new List<Role>() {new Role() {Name = "customer"}};
        foreach (var role in _roles)
        {
            if (rolesFromToken.Any(x => x.Name == role))
            {
                await next.Invoke();
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}