﻿using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using PaddleHub.DTOs;
using PaddleHub.Models;

namespace PaddleHub.Controllers.API
{
    [Authorize]
    public class AttendancesController : ApiController
    {       
        private ApplicationDbContext _context;

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Attend method
        /// </summary>        
        /// <param name="dto"></param>
        /// <returns></returns>        
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO dto)
        {
            var userId = User.Identity.GetUserId();
            var alreadyAttending = _context.Attendances.Any(a => a.AttendeeId == userId && a.PaddleID == dto.PaddleId);
            if (alreadyAttending) return BadRequest("Already attending this event");

            var attendance = new Attendance
            {
                AttendeeId = userId,
                PaddleID   = dto.PaddleId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok(200);
        }

        #endregion
    }
}
