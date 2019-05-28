using Memstate;
using Palladia.Core;

namespace Palladia.OLTP.Events
{
    public class PrincipalAdded : Event
    {
        public readonly Principal NewPrincipal;

        public PrincipalAdded(Principal newPrincipal)
        {
            this.NewPrincipal = newPrincipal;
        }
    }
}