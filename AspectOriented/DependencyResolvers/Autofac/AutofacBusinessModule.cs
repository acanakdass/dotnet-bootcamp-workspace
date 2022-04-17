using AspectOriented.Business;
using AspectOriented.Core.Utilities.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace AspectOriented.DependencyResolvers.Autofac;

public class AutofacBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
        
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();


        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}