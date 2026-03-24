## University Equipment Rental System

A C# console application demonstrating object-oriented design principles, managing equipment rentals, returns, and user limits.

## How to Run
1. Open the solution in an IDE like Rider or Visual Studio.
2. Ensure the `APBD_TASK2` project is set as the startup project.
3. Run the application (or use `dotnet run` in the terminal). The console will output a full demonstration scenario.

## Design Decisions & Architecture

To address the requirements of cohesion, coupling, and clear class responsibilities, the project is structured into distinct layers:

* **Models (Data/State):** Classes like `Equipment`, `Laptop`, `User`, and `Student` represent the domain. I used abstract base classes (`Equipment`, `User`) to share common properties (like `Id`, `Name`, `DailyRentalPrice`) and enforce rules (like forcing users to define `MaxActiveRentals`). This keeps the models highly cohesive—they only care about their own data.
* **Services (Business Logic):** I separated the execution logic entirely from the data models and the console UI. The `RentalService` handles the complex rules (penalty calculations, limit checking).
* **Interfaces (Loose Coupling):** The `RentalService` implements `IRentalService`. If we later wanted to save rentals to a database instead of a memory list, we could write a `DatabaseRentalService` without breaking `Program.cs`. This prevents tight coupling.
* **Exceptions (Error Handling):** Instead of using magic strings or booleans to handle failures, I created custom exceptions (`EquipmentUnavailableException`, `RentalLimitExceededException`). This gives the `RentalService` a single, clear way to reject invalid operations, leaving `Program.cs` to handle the presentation.