using System;

namespace Palladia.Core
{
    [Serializable]
    public class Resource<MessageT>
    {
        public string Name { get; }
        public AccessControlList<MessageT> Acl { get; } = new AccessControlList<MessageT>();

        public Resource(string name)
        {
            Name = name;
        }

        public bool IsAuthorised(MessageT msgType, User user)
        {
            return !Acl.IsDenied(msgType, user) && Acl.IsGranted(msgType, user);
        }
    }
}
