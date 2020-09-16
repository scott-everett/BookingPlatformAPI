using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingPlatformAPI.Helpers
{
    public class AuthenticationFailedException : Exception
    {
    }

    public class AccountAlreadyExistsException : Exception
    {
    }

    public class NotFoundException : Exception
    {
    }

    public class RoomNotAvailableException : Exception
    {
    }

    public class RoomCapacityInsufficentException : Exception
    {
    }

}
