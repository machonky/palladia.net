using Memstate;
using Palladia.Core;

namespace Palladia.OLTP.Events
{
    public class GrantRevoked : Event
    {
        public GrantRevoked(string operation, Resource resource, Principal principal)
        {
            Operation = operation;
            Resource = resource;
            Principal = principal;
        }

        public string Operation { get; }
        public Resource Resource { get; }
        public Principal Principal { get; }
    }
}
