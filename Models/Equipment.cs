using System;
using APBD_TASK2.Enums;

namespace APBD_TASK2.Models;

public abstract class Equipment
{
    // Guid generates a unique identifier automatically
    public Guid Id { get; private set; } = Guid.NewGuid(); 
    public string Name { get; set; }
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
    
    // Shared data for all equipment
    public decimal DailyRentalPrice { get; set; } 

    protected Equipment(string name, decimal dailyRentalPrice)
    {
        Name = name;
        DailyRentalPrice = dailyRentalPrice;
    }
}