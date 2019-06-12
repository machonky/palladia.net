using System;
using System.Runtime.Serialization;

namespace Palladia.OLTP
{
    [Serializable]
    public class ResourceNotFoundException : Exception
    {
        private object resourceName;

        public ResourceNotFoundException()
        {
        }

        public ResourceNotFoundException(object resourceName)
        {
            this.resourceName = resourceName;
        }

        public ResourceNotFoundException(string message) : base(message)
        {
        }

        public ResourceNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}