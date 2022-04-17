using AspectOriented.Business;
using AspectOriented.Entities;
using AspectOriented.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspectOriented.Controllers
{
    //[LogAspect]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [CheckRoleAspect("customer")]
        //[LogAspect] //Action filter aspects
        [HttpGet]
        public IActionResult GetAll()
        {
            //LogAspect :
            /*using (StreamWriter writer = File.AppendText("wwwroot/Logs/logs.txt"))
            {
                var logString = $"ip_address: {context.HttpContext.Connection.RemoteIpAddress} \n" +
                                $"date: {DateTime.Now} \n";
                for (int i = 0; i < context.RouteData.Values.Count; i++)
                {
                    logString +=
                        $"{context.RouteData.Values.Keys.ToArray()[i]} : {context.RouteData.Values.Values.ToArray()[i]} \n";
                }
                writer.WriteLineAsync(logString);
                writer.WriteLineAsync("---------------------------------------------");
            }*/
            //Aspect Oriented sayesinde bu kod bloğunu dışarıya taşıdık
            //ve loglamak istediğimiz her metod için tekrar yazmaktan kurtulduk.
            //throw new Exception("An exc occured");
            return Ok(_userService.GetAll());
        }
        
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_userService.GetById(id));
        }

        
        //[CheckRoleAspect("admin")]
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _userService.Add(user);
            return Created(String.Empty, null);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            _userService.Update(user);
            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}