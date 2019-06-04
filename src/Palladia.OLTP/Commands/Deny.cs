using Memstate;
using Palladia.Core;
using Palladia.OLTP.Events;

namespace Palladia.OLTP.Commands
{
    public class Deny : Command<AuthorisationModel>
    {
        public Deny(string operation, Resource resource, Principal principal)
        {
            Operation = operation;
            Resource = resource;
            Principal = principal;
        }

        public string Operation { get; }
        public Resource Resource { get; }
        public Principal Principal { get; }

        public override void Execute(AuthorisationModel model)
        {
            if (model.Resources.TryGetValue(Resource.Name, out var resource))
            {
                resource.Acl.Deny(Operation, Principal);
                RaiseEvent(new Denied(Operation, Resource, Principal));
            }
        }
    }
}
