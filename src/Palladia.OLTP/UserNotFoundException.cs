using System;
using System.Runtime.Serialization;

namespace Palladia.OLTP
{
    [Serializable]
    public class UserNotFoundException : Exception
    {
        private Guid userId;

        public UserNotFoundException()
        {
        }

        public UserNotFoundException(Guid userId)
        {
            this.userId = userId;
        }

        public UserNotFoundException(string message) : base(message)
        {
        }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}