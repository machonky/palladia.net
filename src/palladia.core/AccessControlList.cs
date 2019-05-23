using System.Collections.Generic;
using System.Linq;

namespace Palladia.Core
{
    public class AccessControlList<MessageT> : IAccessControlList<MessageT>
    {
        private readonly HashSetDictionary<MessageT, Principal> _granted = new HashSetDictionary<MessageT, Principal>();
        private readonly HashSetDictionary<MessageT, Principal> _denied = new HashSetDictionary<MessageT, Principal>();

        public bool IsGranted(MessageT msgType, User user)
        {
            Ensure.ArgumentIsNotNull(msgType, "msgType");
            Ensure.ArgumentIsNotNull(user, "user");

            ISetGrouping<MessageT, Principal> grouping;
            if (_granted.TryGetGrouping(msgType, out grouping))
            {
                var principals = user.Principals;
                return principals.Any(principal => grouping.Contains(principal));
            }

            return false;
        }

        public IAccessControlList<MessageT> Grant(MessageT msgType, params Principal[] principals)
        {
            Ensure.ArgumentIsNotNull(msgType, "msgType");
            Ensure.ArgumentIsNotNull(principals, "principals");

            _granted.Add(msgType, new HashSet<Principal>(principals));

            return this;
        }

        public IAccessControlList<MessageT> RevokeGrant(MessageT msgType, params Principal[] principals)
        {
            Ensure.ArgumentIsNotNull(msgType, "msgType");
            Ensure.ArgumentIsNotNull(principals, "principals");

            _granted.Remove(msgType, new HashSet<Principal>(principals));

            return this;
        }

        public bool IsDenied(MessageT msgType, User user)
        {
            Ensure.ArgumentIsNotNull(msgType, "msgType");
            Ensure.ArgumentIsNotNull(user, "user");

            ISetGrouping<MessageT, Principal> grouping;
            if (_denied.TryGetGrouping(msgType, out grouping))
            {
                var principals = user.Principals;
                return principals.Any(principal => grouping.Contains(principal));
            }

            return false;
        }

        public IAccessControlList<MessageT> Deny(MessageT msgType, params Principal[] principals)
        {
            Ensure.ArgumentIsNotNull(msgType, "msgType");
            Ensure.ArgumentIsNotNull(principals, "principals");

            _denied.Add(msgType, new HashSet<Principal>(principals));

            return this;
        }

        public IAccessControlList<MessageT> RevokeDeny(MessageT msgType, params Principal[] principals)
        {
            Ensure.ArgumentIsNotNull(msgType, "msgType");
            Ensure.ArgumentIsNotNull(principals, "principals");

            _denied.Remove(msgType, new HashSet<Principal>(principals));

            return this;
        }

        public string Explain(MessageT msgType, Principal principal)
        {
            Ensure.ArgumentIsNotNull(msgType, "msgType");
            Ensure.ArgumentIsNotNull(principal, "principal");

            ISetGrouping<MessageT, Principal> grouping;
            if (_denied.TryGetGrouping(msgType, out grouping))
            {
                if (grouping.Contains(principal))
                {
                    return $"Permission was explicitly denied to user: \"{principal.Name}\" for instruction: {msgType}";
                }
            }

            if (_granted.TryGetGrouping(msgType, out grouping))
            {
                if (grouping.Contains(principal))
                {
                    return "Permission granted.";
                }

                return $"No permissions were granted to user: \"{principal.Name}\" for instruction: {msgType}";
            }

            return $"No access control was configured for user: \"{principal.Name}\" for instruction: {msgType}";
        }

        public string Explain(MessageT msgType, User user)
        {
            Ensure.ArgumentIsNotNull(msgType, "msgType");
            Ensure.ArgumentIsNotNull(user, "user");

            ISetGrouping<MessageT, Principal> grouping;
            if (_denied.TryGetGrouping(msgType, out grouping))
            {
                if (user.Principals.Any(principal => grouping.Contains(principal)))
                {
                    return $"Permission was explicitly denied to user: \"{user.Name}\" for instruction: {msgType}";
                }
            }

            if (_granted.TryGetGrouping(msgType, out grouping))
            {
                if (user.Principals.Any(principal => grouping.Contains(principal)))
                {
                    return "Permission granted.";
                }

                return $"No permissions were granted to user: \"{user.Name}\" for instruction: {msgType}";
            }

            return $"No access control was configured for user: \"{user.Name}\" for instruction: {msgType}";
        }
    }
}
