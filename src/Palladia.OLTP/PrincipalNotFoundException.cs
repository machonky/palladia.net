using System;
using System.Runtime.Serialization;

namespace Palladia.OLTP
{
    [Serializable]
    public class PrincipalNotFoundException : Exception
    {
        private Guid principalId;

        public PrincipalNotFoundException()
        {
        }

        public PrincipalNotFoundException(Guid principalId)
        {
            this.principalId = principalId;
        }

        public PrincipalNotFoundException(string message) : base(message)
        {
        }

        public PrincipalNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PrincipalNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}