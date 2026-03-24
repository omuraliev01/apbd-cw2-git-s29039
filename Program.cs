using System;
using APBD_TASK2.Exceptions;
using APBD_Task2.Models;
using APBD_TASK2.Models;
using APBD_TASK2.Services;

IRentalService rentalService = new RentalService();

Console.WriteLine("--- UNIVERSITY EQUIPMENT RENTAL SYSTEM ---\n");




var laptop = new Laptop("Dell XPS 15", 50, 16, 15);
var camera = new Camera("Sony A7 III", 75.0m, 24.2, true);
var projector = new Projector("Epson 1080p", 30.0m, "1920x1080", 3000);

Console.WriteLine("Equipment added to the system.");

var student = new Student("Jan", "Kowalski");
var employee = new Employee("Anna", "Nowak");

Console.WriteLine("Users added to the system.\n");

Console.WriteLine("--- DEMO: Correct Rental ---");
var today = DateTime.Now;
var rental1 = rentalService.RentEquipment(student, laptop, today.AddDays(3)); 
Console.WriteLine($"{student.FirstName} successfully rented {laptop.Name}. Status: {laptop.Status}\n");

Console.WriteLine("--- DEMO: Invalid Operation (Unavailable Equipment) ---");
try
{
    rentalService.RentEquipment(employee, laptop, today.AddDays(2));
}
catch (EquipmentUnavailableException ex)
{
    Console.WriteLine($"BLOCKED: {ex.Message}\n");
}

Console.WriteLine("--- DEMO: Invalid Operation (Exceeding Student Limit) ---");
try
{
    rentalService.RentEquipment(student, camera, today.AddDays(2)); 
    Console.WriteLine($"{student.FirstName} successfully rented {camera.Name}.");
    
    rentalService.RentEquipment(student, projector, today.AddDays(2)); 
}
catch (RentalLimitExceededException ex)
{
    Console.WriteLine($"BLOCKED: {ex.Message}\n");
}

Console.WriteLine("--- DEMO: On-Time Return ---");
rentalService.ReturnEquipment(rental1, rental1.DueDate);
Console.WriteLine($"{student.FirstName} returned {rental1.RentedItem.Name} on time.");
Console.WriteLine($"Base Fee: {rental1.BaseFee:C}, Penalty: {rental1.PenaltyFee:C}\n");

Console.WriteLine("--- DEMO: Delayed Return ---");
var rental3 = rentalService.RentEquipment(employee, projector, today.AddDays(2));

var lateReturnDate = rental3.DueDate.AddDays(5);
rentalService.ReturnEquipment(rental3, lateReturnDate);

Console.WriteLine($"{employee.FirstName} returned {rental3.RentedItem.Name} LATE!");
Console.WriteLine($"Base Fee: {rental3.BaseFee:C}, Penalty Fee: {rental3.PenaltyFee:C}\n");

Console.WriteLine("--- FINAL SYSTEM REPORT ---");
Console.WriteLine($"Laptop Status: {laptop.Status}");
Console.WriteLine($"Camera Status: {camera.Status}");
Console.WriteLine($"Projector Status: {projector.Status}");