using AspectOriented.Core.CrossCuttingConcerns.Validation;
using AspectOriented.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using FluentValidation;

namespace AspectOriented.Core.Aspects.Autofac.Validation;

public class ValidationAspect : MethodInterception
{
    private Type _validatorType;

    public ValidationAspect(Type validatorType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new System.Exception("Bu bir doğrulama sınıfı değil");
        }

        _validatorType = validatorType;
    }

    //implemente ettiğimiz Method Interception classından gelen ve override edilmeyi bekleyen metodlardan:
    protected override void OnBefore(IInvocation invocation)
    {
        var validator = (IValidator) Activator.CreateInstance(_validatorType); 
        //Gönderilen validator tipinden bi instance oluşturur.
        
        var entityType = _validatorType.BaseType.GetGenericArguments()[0];
        //BaseType=> Gelen validator'ın base type'ını bul. =>AbstractValidator
        //GetGenericArguments => Base Type'ın generic argümanlarından ilkini al=>> AbstractValidator<User> ==>User
        
        var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
        //Aspect'in yazıldığı metoda gir, parametrelerden yukarıda aldığımız entity tipine eşit olanları bul. 
        //Örn. public void Add(User user){...} => User nesnesini bulur ve entities'e ekler
        
        foreach (var entity in entities)
        {
            //Method parametrelerinden aldığımız nesneleri Validation tool helper'ı ile kontrol et. 
            ValidationTool.Validate(validator, entity);
            //Kontrol esnasında validasyona uymayan durum olursa exceptionHandler ile yakalamak üzere hata fırlatılır.
        }
    }
}