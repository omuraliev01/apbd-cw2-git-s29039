using System.Collections.Generic;
using APBD_TASK2.Models;

namespace APBD_TASK2.Database;

public class Singleton
{
    private static Singleton? _instance;
    public static Singleton Instance
    {
        get
        {
            _instance ??= new Singleton();
            return _instance;
        }
    }

    private Singleton() { }
    
    public List<Equipment> Equipment { get; } = new();
    public List<User> Users { get; } = new();
    public List<Rental> Rentals { get; } = new();
}