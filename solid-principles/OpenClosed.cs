namespace solid_principles;

public class OpenClosed
{
    // Bir sınıf ya da fonksiyon var olan özellikleri korumalı
    // yani davranışını değiştirmiyor olmalı ve yeni özellikler kazanabilmelidir.
    public class BadCode
    {
        public class Cinema
        {
            double GetFinalTicketPrice(CustomerType customerType,double ticketPrice)
            {
                if (customerType == CustomerType.Student)
                {
                    //Müşteri öğrenci ise %40 indirim uygulanır
                    return ticketPrice * 0.6;
                }else
                {
                    //Müşteri yetişkin ise %10 indirim uygulanır
                    return ticketPrice * 0.9;
                }
                //if yazmak kodumuzun kalitesini ve sürdürülebilirliğini kötü yönde etkiler.
            }
        }
        public enum CustomerType
        {
            Student,
            Adult
        }
    }
    
    public class CleanCode
    {
        
        public class Cinema
        {
            private ICustomer _customer;

            public Cinema(ICustomer customer)
            {
                _customer = customer;
            }

            public double GetFinalTicketPrice(double ticketPrice)
            {
                return _customer.GetFinalTicketPrice(ticketPrice);
                //if else yazmaktan kurtulduk. Cinema sınıfına parametre olarak gelecek ICustomer referansı tutan sınıfa ait getFinalTicketPrice metodu çalışır.
            }
        }
        
        public interface ICustomer
        {
            public double GetFinalTicketPrice(double ticketPrice);
        }

        public class Student : ICustomer
        {
            public double GetFinalTicketPrice(double ticketPrice)
            {
                return ticketPrice * 0.6;
            }
        }

        public class Adult : ICustomer
        {
            public double GetFinalTicketPrice(double ticketPrice)
            {
                return ticketPrice * 0.9;
            }
        }
    }

    public void Main()
    {
        //Örnek kullanım:
        CleanCode.ICustomer customerStudent = new CleanCode.Student();
        CleanCode.ICustomer customerAdult = new CleanCode.Adult();
        
        CleanCode.Cinema cinema = new CleanCode.Cinema(customerStudent);
        // CleanCode.Cinema cinema = new CleanCode.Cinema(customerAdult);
        Console.WriteLine(cinema.GetFinalTicketPrice(100));
    }
    
}