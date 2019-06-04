using System;
using Memstate;
using Palladia.Core;

namespace Palladia.OLTP.Events
{
    public class ResourceAdded : Event
    {
        public readonly Resource NewResource;

        public ResourceAdded(Resource newResource)
        {
            Palladia.Core.Ensure.ArgumentIsNotNull(newResource, nameof(newResource));

            NewResource = newResource;
        }
    }
}