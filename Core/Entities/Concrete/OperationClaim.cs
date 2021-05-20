using Entities.Concrete;

namespace Core.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        public int OperationClaimId { get; set; }

        public string Name { get; set; }

    }
}
