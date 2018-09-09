using PaddleHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PaddleHub.Repositories
{
    public class PaddleRepository
    {
        private readonly ApplicationDbContext _context;

        public PaddleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Paddle> GetPaddlesUserIsAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Paddle)
                .Include(g => g.Paddler.UserDetails)
                .Include(g => g.PaddleType)
                .ToList();
        }

        public Paddle GetPaddleWithAttendees(int paddleId)
        {
            return _context.Paddles
                .Include(p => p.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(p => p.Id == paddleId);
        }

        public Paddle Retrieve(int paddleId)
        {
            return _context.Paddles
                .Include(p => p.Paddler)
                .Include(p => p.Paddler.UserDetails)
                .SingleOrDefault(p => p.Id == paddleId);
        }

        public List<Paddle> RetrieveAllFuturePaddles(string userId)
        {
            return _context.Paddles
                .Where(p => p.PaddlerId == userId &&
                       p.DateTime >= DateTime.Now)
                .Include(p => p.PaddleType)
                .ToList();
        }
    }
}