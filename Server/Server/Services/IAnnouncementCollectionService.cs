using brta.Models;

namespace brta.Services
{
    public interface IAnnouncementCollectionService : ICollectionService<Announcement>
    {
        Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId);
    }
}
