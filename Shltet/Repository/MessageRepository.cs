using Shelter.Models;
using Shltet.Data;
using Shltet.Repository.IRepo;

namespace Shltet.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepo
    {
        public MessageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
