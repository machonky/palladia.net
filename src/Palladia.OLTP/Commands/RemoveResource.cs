using Memstate;
using Palladia.OLTP.Events;

namespace Palladia.OLTP.Commands
{
    public class RemoveResource : Command<AuthorisationModel>
    {
        public string ResourceName { get; }

        public RemoveResource(string resourceName)
        {
            Palladia.Core.Ensure.ArgumentIsNotNullOrWhitespace(resourceName, nameof(resourceName));
            ResourceName = resourceName;
        }

        public override void Execute(AuthorisationModel model)
        {
            if (model.Resources.TryGetValue(ResourceName, out var resource))
            {
                model.Resources.Remove(ResourceName);
                RaiseEvent(new ResourceRemoved(ResourceName));
            }
        }
    }
}
