using Microsoft.Extensions.Options;

namespace EMS_Project.CustomException
{
    public class ConflictException : Exception
    {
        public ConflictException(string message) :base(message){ }
    }
}
