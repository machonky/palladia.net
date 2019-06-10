using Memstate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Palladia.OLTP.Queries
{
    public class GetResourceNames : Query<AuthorisationModel, string[]>
    {
        public override string[] Execute(AuthorisationModel db)
        {
            return db.Resources.Values.Select(v => v.Name).ToArray();
        }
    }
}
