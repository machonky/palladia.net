using Memstate;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Palladia.OLTP.Commands
{
    public class CreateResourceSnapshot : Command<AuthorisationModel>
    {
        private readonly Resource resource;
        private readonly Stream output;

        public CreateResourceSnapshot(Resource resource, Stream output)
        {
            this.resource = resource;
            this.output = output;
        }

        public override void Execute(AuthorisationModel model)
        {
            if (model.Resources.TryGetValue(resource.Name, out var value))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(output, value);
            }
        }
    }
}
