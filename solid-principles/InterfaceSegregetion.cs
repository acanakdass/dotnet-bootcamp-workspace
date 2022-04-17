namespace solid_principles;

public class InterfaceSegregetion
{
    private class BadCode
    {
        interface IWorker
        {
            void PaySalary();
            void ProvideFood();
        }

        class CompanyWorker : IWorker
        {
            public void PaySalary()
            {
                //Pay salary
            }

            public void ProvideFood()
            {
                //Provide Food
            }
        }

        class OutsourceWorker : IWorker
        {
            public void PaySalary()
            {
                //Pay Salary
            }

            public void ProvideFood()
            {
                throw new NotImplementedException();
                //Burada bir operasyon yazamayız çünkü outsource çalışan bir işçiye yemek sağlamamız gerekmez.
                //İçini doldurmadığımız ve hata fırlatan bir metod kod kirliğine sebep olur ve  SOLID prensiplerine aykırıdır.
            }
        }
    }

    //Aşağıdaki kod ise yukarıdaki kodların daha temiz ve Interface Segregetion prensibine uygun olanıdır:
    //Interface'leri parçalayark her class'a ihtiyacı olanları sağlamalıyız
    private class CleanCode
    {
        interface IPayable
        {
            void PaySalary();
        }

        interface IEatable
        {
            void ProvideFood();
        }

        class CompanyWorker : IPayable, IEatable
        {
            public void PaySalary()
            {
                //Pay salary
            }

            public void ProvideFood()
            {
                //Provide Food
            }
        }

        class OutsourceWorker : IPayable
        {
            public void PaySalary()
            {
                //Pay Salary
            }
        }
        //Şirkette çalışan işçi için yemek sağlama ve maaş ödeme durumları geçerli olduğu için iki interface'i de sağladık.
        //Dışarıdan çalışan outsource işçi için yemek sağlama ihtiyacı olmadığından yalnızca Ipayable interface'ini aldı.
        //Böylece outsource işçi tipi için gereksiz ve iş yapmayan bir metod oluşturmamıza gerek kalmadı.
    }
}