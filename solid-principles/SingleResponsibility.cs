using System.ComponentModel.DataAnnotations;

namespace solid_principles;

public class SingleResponsibility
{
    // Single Responsibility : Bir sınıfın,metodun,scope'un sadece bir iş yapması gerekir.
    // Tek bir amaca hizmet etmelidir.

    //Örnek 1

    public class User
    {
        [Required] public string? FirstName { get; set; }
        [MinLength(5)] public string LastName { get; set; }
        [EmailAddress] public string Email { get; set; }
    }

    //Yukarıda bir User entity sınıfı oluşturulmuştur. User sınıfı aynı zamanda vaildasyon işlemi de yapmaktadır.Bu Single Responsibility prensibine aykırıdır.
    //Validasyon işlemlerini ayrı bir yerde yapmalıyız.Örn. Fluent Validation

    //Örnek 2:

    //Bir kullanıcı ekleme metodumuz olsun.Aşağıdaki metodda kullanıcı ekleme işlemi yapılmış, daha sonra da kullanıcıyı bilgi mail'i gönderilmiştir.
    //Böylece AddUser metodunun birden fazla görevi olmuştur.
    class BadCode
    {
        void AddUser(Object userObject)
        {
            //_userService.Add(userObject).....
            //sending email with smtp.....
        }
    }
    class CleanCode
    {
        void AddUser(Object userObject)
        {
            //_userService.Add(userObject).....
            //MailHelper.SendEmail(userObject.Email);
        }

        public static class MailHelper
        {
            public static void SendEmail(string email)
            {
                //sending email with smtp.....
            }
        }
    }
}