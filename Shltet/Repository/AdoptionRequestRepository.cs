using Shelter.Models;
using Shltet.Data;
using Shltet.Repository.IRepo;

namespace Shltet.Repository
{
    public class AdoptionRequestRepository : Repository<AdoptionRequest>, IAdoptionRequestRepo
    {
        public AdoptionRequestRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
