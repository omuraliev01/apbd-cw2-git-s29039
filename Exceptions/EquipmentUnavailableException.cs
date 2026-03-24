using System;

namespace APBD_TASK2.Exceptions;

public class EquipmentUnavailableException : Exception
{
    public EquipmentUnavailableException(string message) : base(message)
    {
    }
}