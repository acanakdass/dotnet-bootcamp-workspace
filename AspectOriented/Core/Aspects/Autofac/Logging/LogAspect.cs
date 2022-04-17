using AspectOriented.Core.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace AspectOriented.Core.Aspects.Autofac.Logging;

public class LogAspect : MethodInterception
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogAspect()
    {
        _httpContextAccessor =new HttpContextAccessor();
    }

    protected override void OnAfter(IInvocation invocation)
    {
        //LOGLAMA KÜTÜPHANELERİ İLE İYİLEŞTİRELECEK..
        var argsString = "";
        for (int i = 0; i < invocation.Arguments.Length; i++)
        {
            var Name = invocation.GetConcreteMethod().GetParameters()[i].Name;
            var Value = invocation.Arguments[i];
            var Type = invocation.Arguments[i].GetType().Name;
            argsString += $"Args \n" +
                          $"Name : {Name}\n" +
                          $"Value : {Value}\n" +
                          $"Type :{Type}\n";
        }
        using (StreamWriter writer = File.AppendText("wwwroot/Logs/logs.txt"))
        {
            var logString = $"date: {DateTime.Now} \n" +
                            $"method : {invocation.Method.Name}";
            logString += argsString;
            writer.WriteLineAsync(logString);
            writer.WriteLineAsync("---------------------------------------------");
        }
    }
}