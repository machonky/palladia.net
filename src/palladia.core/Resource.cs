using System;

namespace Palladia.Core
{
    [Serializable]
    public class Resource<MessageT>
    {
        public string Name { get; }
        public string Description { get; }

        public AccessControlList<MessageT> Acl { get; } = new AccessControlList<MessageT>();

        public Resource(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public bool IsAuthorised(MessageT msgType, User user)
        {
            return !Acl.IsDenied(msgType, user) && Acl.IsGranted(msgType, user);
        }
    }
}
