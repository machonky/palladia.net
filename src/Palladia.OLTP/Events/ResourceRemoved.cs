using System;
using Memstate;

namespace Palladia.OLTP.Events
{
    public class ResourceRemoved : Event
    {
        public readonly string ResourceName;

        public ResourceRemoved(string resourceName)
        {
            Palladia.Core.Ensure.ArgumentIsNotNullOrWhitespace(resourceName, nameof(resourceName));

            ResourceName = resourceName;
        }
    }
}