using System;
using System.Collections.Generic;
using System.Linq;
using APBD_TASK2.Database; 
using APBD_TASK2.Enums;
using APBD_TASK2.Exceptions;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services;

public class RentalService : IRentalService
{
    private readonly Singleton _db = Singleton.Instance;

    private const decimal PenaltyMultiplier = 2.0m;

    public Rental RentEquipment(User user, Equipment equipment, DateTime dueDate)
    {
        if (equipment.Status != EquipmentStatus.Available)
            throw new EquipmentUnavailableException($"The equipment '{equipment.Name}' is currently {equipment.Status}.");

        var activeRentalsCount = GetActiveRentalsForUser(user).Count();
        if (activeRentalsCount >= user.MaxActiveRentals)
            throw new RentalLimitExceededException($"User {user.FirstName} has reached their max limit of {user.MaxActiveRentals} rentals.");

        var rental = new Rental(user, equipment, DateTime.Now, dueDate);
        equipment.Status = EquipmentStatus.Rented;
        
        _db.Rentals.Add(rental); 
        return rental;
    }

    public void ReturnEquipment(Rental rental, DateTime actualReturnDate)
    {
        rental.ActualReturnDate = actualReturnDate;
        
        var totalRentalDays = (rental.DueDate - rental.RentalDate).Days;
        if (totalRentalDays < 1) totalRentalDays = 1;
        rental.BaseFee = totalRentalDays * rental.RentedItem.DailyRentalPrice;

        if (actualReturnDate > rental.DueDate)
        {
            var lateDays = (actualReturnDate - rental.DueDate).Days;
            if (lateDays < 1) lateDays = 1; 
            rental.PenaltyFee = lateDays * (rental.RentedItem.DailyRentalPrice * PenaltyMultiplier);
        }

        rental.RentedItem.Status = EquipmentStatus.Available;
    }

    public IEnumerable<Rental> GetActiveRentalsForUser(User user)
    {
        return _db.Rentals.Where(r => r.Renter.Id == user.Id && r.ActualReturnDate == null);
    }

    public IEnumerable<Rental> GetOverdueRentals(DateTime currentDate)
    {
        return _db.Rentals.Where(r => r.ActualReturnDate == null && r.DueDate < currentDate);
    }
}