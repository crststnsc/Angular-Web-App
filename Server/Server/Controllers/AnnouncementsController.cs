using brta.Models;
using brta.Services;
using Microsoft.AspNetCore.Mvc;

namespace brta.Controllers
{

    /// <summary>
    /// Class <c>AnnouncementsController</c> is a controller for announcements.
    /// </summary>
    /// 
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementsController : ControllerBase
    {


        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementsController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }


        /// <summary>
        /// Get the announcements list from the controller.
        /// </summary>
        /// <returns><c>The list of announcements of the controller</c></returns>
        [HttpGet]
        public async Task<ActionResult<List<Announcement>>> GetAll()
        {
            var announcements = await _announcementCollectionService.GetAll();
            return announcements;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Announcement>> Get(Guid id)
        {
            var announcement = await _announcementCollectionService.Get(id);
            if (announcement == null)
                return NotFound();

            return announcement;
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Announcement announcement)
        {
            var created = await _announcementCollectionService.Create(announcement);
            if (!created)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Announcement announcement)
        {
            var updated = await _announcementCollectionService.Update(announcement.Id, announcement);
            if (!updated)
                return NotFound();

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _announcementCollectionService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    

        //public IActionResult Index()
        //{

        //    return ViewResult();
        //}
    }
}
