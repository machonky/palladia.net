using Memstate;
using Palladia.Core;
using Palladia.OLTP.Events;

namespace Palladia.OLTP.Commands
{
    public class AddResource : Command<AuthorisationModel>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public override void Execute(AuthorisationModel model)
        {
            var result = new Resource(Name, Description);
            model.Resources.Add(Name, result);
            RaiseEvent(new ResourceAdded(result));
        }
    }
}
