using System;

namespace APBD_TASK2.Exceptions;

public class RentalLimitExceededException : Exception
{
    public RentalLimitExceededException(string message) : base(message)
    {
    }
}