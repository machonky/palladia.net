using Memstate;
using Palladia.OLTP.Events;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Palladia.OLTP.Commands
{
    public class CreateResourceSnapshot : Command<AuthorisationModel>
    {
        private readonly string resourceName;
        private readonly Stream output;

        public CreateResourceSnapshot(string resourceName, Stream output)
        {
            this.resourceName = resourceName;
            this.output = output;
        }

        public override void Execute(AuthorisationModel model)
        {
            if (model.Resources.TryGetValue(resourceName, out var value))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(output, value);

                RaiseEvent(new ResourceSnapshotCreated(value));
            }
        }
    }
}
