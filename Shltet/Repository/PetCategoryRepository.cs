using Shltet.Data;
using Shltet.Modles;
using Shltet.Repository.IRepo;

namespace Shltet.Repository
{
    public class PetCategoryRepository : Repository<PetCategory>, IPetCategoryRepo
    {
        public PetCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
