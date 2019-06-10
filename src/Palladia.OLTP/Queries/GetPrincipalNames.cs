using Memstate;
using System.Linq;

namespace Palladia.OLTP.Queries
{
    public class GetPrincipalNames : Query<AuthorisationModel, string[]>
    {
        public override string[] Execute(AuthorisationModel db)
        {
            return db.Principals.Values.Select(v => v.Name).ToArray();
        }
    }
}
