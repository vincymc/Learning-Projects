using System.Linq;
using System.Web.Http;
using GigHubApp.Dtos;
using GigHubApp.Models;
using Microsoft.AspNet.Identity;

namespace GigHubApp.Controllers.Apis
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context= new ApplicationDbContext();
        }

        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists");

            var following = new Following()
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
