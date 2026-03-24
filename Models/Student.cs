namespace APBD_TASK2.Models;

public class Student : User
{
    public override int MaxActiveRentals => 2; 

    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}