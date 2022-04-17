using DapperCrudAPIProject.DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DapperCrudAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomControllerBase : ControllerBase
{
    [NonAction]
     public IActionResult CreateActionResult<T>(ResponseDto<T> responseDto)
    {
        if (responseDto.StatusCode == 204)
            return new ObjectResult(responseDto) {StatusCode = responseDto.StatusCode};
        return new ObjectResult(responseDto) {StatusCode = responseDto.StatusCode};
    }
}