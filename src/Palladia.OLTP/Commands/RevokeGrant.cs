using Memstate;
using Palladia.Core;
using Palladia.OLTP.Events;

namespace Palladia.OLTP.Commands
{
    public class RevokeGrant : Command<AuthorisationModel>
    {
        public RevokeGrant(string operation, Resource resource, Principal principal)
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
                resource.Acl.RevokeGrant(Operation, Principal);
                RaiseEvent(new GrantRevoked(Operation, Resource, Principal));
            }
        }
    }
}
