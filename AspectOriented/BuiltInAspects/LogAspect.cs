using Microsoft.AspNetCore.Mvc.Filters;

namespace AspectOriented.Filters;

public class LogAspect : ActionFilterAttribute
{
    

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        //Hataları yakalamak için ExceptionFilterAttribute kullanılabilir fakat örnek olması açısından yazılmış kod:
        if (context.Exception != null)
        {
            using (StreamWriter writer = File.AppendText("wwwroot/Logs/error-logs.txt"))
            {
                var logString = $"ip_address: {context.HttpContext.Connection.RemoteIpAddress} \n" +
                                $"date: {DateTime.Now} \n" +
                                $"error_message {context.Exception.Message }\n";
                for (int i = 0; i < context.RouteData.Values.Count; i++)
                {
                    logString +=
                        $"{context.RouteData.Values.Keys.ToArray()[i]} : {context.RouteData.Values.Values.ToArray()[i]} \n";
                }

                writer.WriteLineAsync(logString);
                writer.WriteLineAsync("---------------------------------------------");
            }
        }

        using (StreamWriter writer = File.AppendText("wwwroot/Logs/logs.txt"))
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
        }
    }
}