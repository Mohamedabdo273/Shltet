using Shltet.Data;
using Shltet.Modles;
using Shltet.Repository.IRepo;

namespace Shltet.Repository
{
    public class PetRepository : Repository<Pet>, IPetRepo
    {
        public PetRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
