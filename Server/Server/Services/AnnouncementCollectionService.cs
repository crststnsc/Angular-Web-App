using brta.Models;
using brta.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Xml;

namespace brta.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        private readonly IMongoCollection<Announcement> _announcements;
        
        public AnnouncementCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _announcements = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
        }

        public async Task<List<Announcement>> GetAll()
        {
            var allAnnouncements = await _announcements.Find(_ => true).ToListAsync();
            return allAnnouncements;
        }

        public async Task<Announcement> Get(Guid id)
        {
            var announcement = await _announcements.Find(a => a.Id == id).FirstOrDefaultAsync();
            return announcement;
        }

        public async Task<bool> Create(Announcement model)
        {
            model.Id = Guid.NewGuid();
            await _announcements.InsertOneAsync(model);
            return true;
        }

        public async Task<bool> Update(Guid id, Announcement model)
        {
            var updateResult = await _announcements.ReplaceOneAsync(a => a.Id == id, model);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var deleteResult = await _announcements.DeleteOneAsync(a => a.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
