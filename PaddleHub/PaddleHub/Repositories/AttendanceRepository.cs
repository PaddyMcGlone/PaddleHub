using PaddleHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaddleHub.Repositories
{
    public class AttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Paddle.DateTime > DateTime.Now)
                .ToList();
        }
    }
}