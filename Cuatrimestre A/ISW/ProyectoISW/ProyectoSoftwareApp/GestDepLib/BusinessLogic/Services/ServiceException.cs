using System;

namespace GestDepLib.Services
{
    public class ServiceException:Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(String message)
        :base(message)
        {
        }

        public ServiceException(String message, Exception inner)
        :base(message, inner)
        {
        }
    }
}
