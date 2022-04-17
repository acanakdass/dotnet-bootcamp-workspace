namespace bridge_design_pattern;

public class Main
{
    public interface IEmployee
    {
        void paySalary();
    }
    public class Manager:IEmployee
    {
        public void paySalary()
        {
            //Müdür maaşı hesaplayıp ödeme
            Console.WriteLine("Müdür maaşı ödendi");
        }
    }
    public class Engineer:IEmployee
    {
        public void paySalary()
        {
            //Mühendis maaşı hesaplayıp ödeme
            Console.WriteLine("Mühendis maaşı ödendi");
        }
    }

    public class Company
    {
        private IEmployee _employee;

        public Company(IEmployee employee)
        {
            _employee = employee;
        }

        public void paySalaries()
        {
            _employee.paySalary();
        }
    }

    // Console.WriteLine("Hello, World!");
    // var employee = new Main.Manager();
    // var employee2 = new Main.Engineer();
    // var company = new Main.Company(employee2);
    // company.paySalaries();
     
}