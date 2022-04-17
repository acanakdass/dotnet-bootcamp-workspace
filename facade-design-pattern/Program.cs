// See https://aka.ms/new-console-template for more information

void Main()
{
    Company company = new();
    company.PayEngineerSalary();
    company.PayManagerSalary();
}
Main();



interface IEmployee
{
    void PaySalary();
}

class Manager : IEmployee
{
    public void PaySalary()
    {
        Console.WriteLine("Müdür maaşı ödendi");
    }
}

class Engineer : IEmployee
{
    public void PaySalary()
    {
        Console.WriteLine("Mühendis maaşı ödendi");
    }
}

class Company
{
    private IEmployee engineer;
    private IEmployee manager;

    public Company()
    {
        this.engineer = new Engineer();
        this.manager = new Manager();
    }

    public void PayEngineerSalary()
    {
        engineer.PaySalary();
    }

    public void PayManagerSalary()
    {
        manager.PaySalary();
    }
}