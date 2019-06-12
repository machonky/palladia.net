using Memstate;

namespace Palladia.OLTP.Events
{
    public class ResourceSnapshotCreated : Event
    {
        public Resource Resource { get; }

        public ResourceSnapshotCreated(Resource resource)
        {
            Resource = resource;
        }
    }
}
