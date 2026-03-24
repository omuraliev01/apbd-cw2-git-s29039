namespace APBD_TASK2.Models;

public class Employee : User
{
    public override int MaxActiveRentals => 5;

    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}