using Memstate;
using System.Linq;

namespace Palladia.OLTP.Queries
{
    public class GetUserNames : Query<AuthorisationModel, string[]>
    {
        public override string[] Execute(AuthorisationModel db)
        {
            return db.Users.Values.Select(v => v.Name).ToArray();
        }
    }
}
