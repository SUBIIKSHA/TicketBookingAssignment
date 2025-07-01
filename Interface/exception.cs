using System;
namespace exceptions
{
    public class EventNotFoundException : Exception
{
    public EventNotFoundException(string message) : base(message) { }
}

public class InvalidBookingIDException : Exception
{
    public InvalidBookingIDException(string message) : base(message) { }
}

 }
