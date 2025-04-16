using Shelter.Models;
using Shltet.Repository.IRepo;
using Shltet.Services.IServices;

namespace Shltet.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo _messageRepo;

        public MessageService(IMessageRepo messageRepo)
        {
            _messageRepo = messageRepo;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            return await _messageRepo.GetAsync();
        }

        public async Task<Message?> GetMessageByIdAsync(int id)
        {
            return await _messageRepo.GetOneAsync(expression: m => m.Id == id);
        }

        public async Task CreateMessageAsync(Message message)
        {
            await _messageRepo.CreateAsync(message);
            await _messageRepo.CommitAsync();
        }

        public async Task DeleteMessageAsync(Message message)
        {
            _messageRepo.Delete(message);
            await _messageRepo.CommitAsync();
        }
    }
}
