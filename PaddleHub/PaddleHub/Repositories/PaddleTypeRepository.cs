using PaddleHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace PaddleHub.Repositories
{
    public class PaddleTypeRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor

        public PaddleTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public List<PaddleType> RetrieveTypes()
        {
            return _context.PaddleTypes.ToList();
        }

        #endregion
    }
}