using Memstate;
using Palladia.Core;

namespace Palladia.OLTP.Queries
{
    public class GetUser : Query<AuthorisationModel, User>
    {
        private readonly string userName;

        public GetUser(string userName)
        {
            this.userName = userName;
        }

        public override User Execute(AuthorisationModel db)
        {
            if (db.Users.TryGetValue(userName, out var user))
            {
                return user;
            }
            throw new UserNotFoundException(userName);
        }
    }
}
