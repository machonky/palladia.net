namespace Palladia.Core
{
    public interface IAccessControlList<MessageT>
    {
        bool IsGranted(MessageT msg, User user);
        IAccessControlList<MessageT> Grant(MessageT msgType, params Principal[] principals);
        IAccessControlList<MessageT> RevokeGrant(MessageT msgType, params Principal[] principals);

        bool IsDenied(MessageT msg, User user);
        IAccessControlList<MessageT> Deny(MessageT msgType, params Principal[] principals);
        IAccessControlList<MessageT> RevokeDeny(MessageT msgType, params Principal[] principals);

        string Explain(MessageT msgType, Principal principal);
        string Explain(MessageT msgType, User user);
    }
}
