using ProductDetails.Data;
using ProductDetails.Model;
using ProductDetails.Repository.IRepository;

namespace ProductDetails.Repository
{
    public class IssueDetailRepository : GenericRepository<IssueDetail>, IIssueDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public IssueDetailRepository(ApplicationDbContext dbContect) : base(dbContect)
        {
            _dbContect = dbContect;
        }
        
        public async Task Update(IssueDetail entity)
        {
            _dbContect.IssueDetails.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
