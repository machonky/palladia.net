using Memstate;

namespace Palladia.OLTP.Queries
{
    public class GetResource : Query<AuthorisationModel, Resource>
    {
        private readonly string resourceName;

        public GetResource(string resourceName)
        {
            this.resourceName = resourceName;
        }

        public override Resource Execute(AuthorisationModel db)
        {
            if (db.Resources.TryGetValue(resourceName, out var resource))
            {
                return resource;
            }

            throw new ResourceNotFoundException(resourceName);
        }
    }
}
