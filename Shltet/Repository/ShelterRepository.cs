using Shltet.Data;
using Shltet.Repository.IRepo;

namespace Shltet.Repository
{
    public class ShelterRepository : Repository<Modles.Shelter>, IshelterRepo
    {
        public ShelterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
