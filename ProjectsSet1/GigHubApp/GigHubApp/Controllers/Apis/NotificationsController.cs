using AutoMapper;
using GigHubApp.Dtos;
using GigHubApp.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHubApp.Controllers.Apis
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context=new ApplicationDbContext();
        }
        //[HttpGet, ActionName("newUnRead")]
        [Route("api/notifications/GetNewNotifications")]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {            
            var userId = User.Identity.GetUserId();
            var newNotifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();  

            return newNotifications.Select(Mapper.Map<Notification,NotificationDto>);

            //return notifications.Select(n => new NotificationDto()
            //{
            //    Gig= new GigDto()
            //    {
            //        Artist = new UserDto()
            //        {
            //            Id = n.Gig.Artist.Id,
            //            Name = n.Gig.Artist.Name
            //        },
            //        Id = n.Gig.Id,
            //        IsCancelled = n.Gig.IsCancelled,
            //        DateTime = n.Gig.DateTime,
            //        Venue = n.Gig.Venue
            //    },
            //    DateTime = n.DateTime,
            //    Type = n.Type,
            //    OriginalDateTime = n.OriginalDateTime,
            //    OriginalVenue = n.OriginalVenue
            //});
        }
        //[HttpGet, ActionName("recentRead")]
        [Route("api/notifications/GetRecentNotifications")]
        public IEnumerable<NotificationDto> GetRecentNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .OrderByDescending(n => n.DateTime)
                .Take(GigSettings.noOfRecentNotifications)
                .ToList();
            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }
        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)                           
                .ToList();
            notifications.ForEach(n => n.Read());
            _context.SaveChanges();
            return Ok();
        }
    }
}
