using PaddleHub.Models;
using System.Linq;

namespace PaddleHub.Repositories
{
    public class FollowingRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public Following Retrieve(string followeeId, string followerId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == followeeId &&
                                      f.FollowerId == followerId);
        }

        #endregion
    }
}