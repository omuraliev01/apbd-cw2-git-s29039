using System;
using System.Collections.Generic;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services;

public interface IRentalService
{
    Rental RentEquipment(User user, Equipment equipment, DateTime dueDate);
    void ReturnEquipment(Rental rental, DateTime actualReturnDate);
    
    IEnumerable<Rental> GetActiveRentalsForUser(User user);
    IEnumerable<Rental> GetOverdueRentals(DateTime currentDate);
}