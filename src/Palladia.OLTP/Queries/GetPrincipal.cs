using Memstate;
using Palladia.Core;

namespace Palladia.OLTP.Queries
{
    public class GetPrincipal : Query<AuthorisationModel, Principal>
    {
        private readonly string principalName;

        public GetPrincipal(string principalName)
        {
            this.principalName = principalName;
        }

        public override Principal Execute(AuthorisationModel db)
        {
            if (db.Principals.TryGetValue(principalName, out var principal))
            {
                return principal;
            }
            throw new PrincipalNotFoundException(principalName);
        }
    }
}
