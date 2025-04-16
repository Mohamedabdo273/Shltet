using Shelter.Models;
using Shltet.Data;
using Shltet.Repository.IRepo;

namespace Shltet.Repository
{
    public class SupportRequestRepository : Repository<SupportRequest>, ISupportRequestRepo
    {
        public SupportRequestRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
