using System;

namespace APBD_TASK2.Models;

public abstract class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    
    public abstract int MaxActiveRentals { get; } 

    protected User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}