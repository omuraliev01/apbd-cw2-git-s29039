using System;

namespace APBD_TASK2.Models;

public class Rental
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public User Renter { get; set; }
    public Equipment RentedItem { get; set; }
    
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ActualReturnDate { get; set; } 
    
    public decimal BaseFee { get; set; }
    public decimal PenaltyFee { get; set; }

    public Rental(User renter, Equipment rentedItem, DateTime rentalDate, DateTime dueDate)
    {
        Renter = renter;
        RentedItem = rentedItem;
        RentalDate = rentalDate;
        DueDate = dueDate;
    }
}