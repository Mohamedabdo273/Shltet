using Shelter.Models;

namespace Shltet.Services.IServices
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllMessagesAsync();
        Task<Message?> GetMessageByIdAsync(int id);
        Task CreateMessageAsync(Message message);
        Task DeleteMessageAsync(Message message);
    }
}
